﻿using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;

using Dynamo.PackageManager;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using Dynamo.Wpf.Properties;

namespace Dynamo.ViewModels
{
    public class PackageViewModel : NotificationObject
    {
        private DynamoViewModel dynamoViewModel;
        public Package Model { get; private set; }

        public bool HasAdditionalFiles
        {
            get { return this.Model.AdditionalFiles.Any(); }
        }

        public bool HasAdditionalAssemblies
        {
            get { return this.Model.LoadedAssemblies.Any(x => !x.IsNodeLibrary); }
        }

        public bool HasNodeLibraries
        {
            get { return this.Model.LoadedAssemblies.Any(x => x.IsNodeLibrary); }
        }

        public bool HasCustomNodes
        {
            get { return this.Model.LoadedCustomNodes.Any();  }
        }

        public bool HasAssemblies
        {
            get { return this.Model.LoadedAssemblies.Any(); }
        }

        public DelegateCommand ToggleTypesVisibleInManagerCommand { get; set; }
        public DelegateCommand GetLatestVersionCommand { get; set; }
        public DelegateCommand PublishNewPackageVersionCommand { get; set; }
        public DelegateCommand UninstallCommand { get; set; }
        public DelegateCommand PublishNewPackageCommand { get; set; }
        public DelegateCommand DeprecateCommand { get; set; }
        public DelegateCommand UndeprecateCommand { get; set; }
        public DelegateCommand UnmarkForUninstallationCommand { get; set; }
        public DelegateCommand GoToRootDirectoryCommand { get; set; }

        public PackageViewModel(DynamoViewModel dynamoViewModel, Package model)
        {
            this.dynamoViewModel = dynamoViewModel;
            this.Model = model;

            ToggleTypesVisibleInManagerCommand = new DelegateCommand(ToggleTypesVisibleInManager, CanToggleTypesVisibleInManager);
            GetLatestVersionCommand = new DelegateCommand(GetLatestVersion, CanGetLatestVersion);
            PublishNewPackageVersionCommand = new DelegateCommand(PublishNewPackageVersion, CanPublishNewPackageVersion);
            PublishNewPackageCommand = new DelegateCommand(PublishNewPackage, CanPublishNewPackage);
            UninstallCommand = new DelegateCommand(Uninstall, CanUninstall);
            DeprecateCommand = new DelegateCommand(this.Deprecate, CanDeprecate);
            UndeprecateCommand = new DelegateCommand(this.Undeprecate, CanUndeprecate);
            UnmarkForUninstallationCommand = new DelegateCommand(this.UnmarkForUninstallation, this.CanUnmarkForUninstallation);
            GoToRootDirectoryCommand = new DelegateCommand(this.GoToRootDirectory, this.CanGoToRootDirectory);

            this.Model.LoadedAssemblies.CollectionChanged += LoadedAssembliesOnCollectionChanged;
            this.Model.PropertyChanged += ModelOnPropertyChanged;
            this.dynamoViewModel.Model.NodeAdded += (node) => UninstallCommand.RaiseCanExecuteChanged();
            this.dynamoViewModel.Model.NodeDeleted += (node) => UninstallCommand.RaiseCanExecuteChanged();
            this.dynamoViewModel.Model.WorkspaceHidden += (ws) => UninstallCommand.RaiseCanExecuteChanged();
            this.dynamoViewModel.Model.Workspaces.CollectionChanged += (sender, args) => UninstallCommand.RaiseCanExecuteChanged();
        }

        private void LoadedAssembliesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            RaisePropertyChanged(/*NXLT*/"HasAdditionalAssemblies");
            RaisePropertyChanged(/*NXLT*/"HasAssemblies");
            RaisePropertyChanged(/*NXLT*/"HasNodeLibraries");
        }

        private void ModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "MarkedForUninstall")
            {
                this.UnmarkForUninstallationCommand.RaiseCanExecuteChanged();
                this.UninstallCommand.RaiseCanExecuteChanged();
            }
        }

        private void UnmarkForUninstallation()
        {
            this.Model.UnmarkForUninstall( this.dynamoViewModel.Model.PreferenceSettings );
        }

        private bool CanUnmarkForUninstallation()
        {
            return this.Model.MarkedForUninstall;
        }

        private void Uninstall()
        {
            if (this.Model.LoadedAssemblies.Any())
            {
                var resAssem =
                    MessageBox.Show(Resources.MessageNeedToRestart,
                        Resources.UninstallingPackageMessageBoxTitle,
                        MessageBoxButton.OKCancel,
                        MessageBoxImage.Exclamation);
                if (resAssem == MessageBoxResult.Cancel) return;
            }

            var res = MessageBox.Show(String.Format(Resources.MessageConfirmToUninstallPackage, this.Model.Name),
                                      Resources.UninstallingPackageMessageBoxTitle,
                                      MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.No) return;

            try
            {
                var dynModel = this.dynamoViewModel.Model;
                Model.UninstallCore(dynModel.CustomNodeManager, dynModel.Loader.PackageLoader, dynModel.PreferenceSettings, dynModel.Logger);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.MessageFailedToUninstall,
                    Resources.UninstallFailureMessageBoxTitle,
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanUninstall()
        {
            return (!this.Model.InUse(this.dynamoViewModel.Model) || this.Model.LoadedAssemblies.Any()) 
                && !this.Model.MarkedForUninstall;
        }

        private void GoToRootDirectory()
        {
            Process.Start(this.Model.RootDirectory);
        }

        private bool CanGoToRootDirectory()
        {
            return true;
        }

        private void Deprecate()
        {
            var res = MessageBox.Show(String.Format(Resources.MessageToDeprecatePackage, this.Model.Name),
                                      Resources.DeprecatingPackageMessageBoxTitle, 
                                      MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.No) return;

            dynamoViewModel.Model.PackageManagerClient.Deprecate(this.Model.Name);
        }

        private bool CanDeprecate()
        {
            return this.dynamoViewModel.Model.PackageManagerClient.HasAuthenticator;
        }

        private void Undeprecate()
        {
            var res = MessageBox.Show(String.Format(Resources.MessageToUndeprecatePackage, this.Model.Name),
                                      Resources.UndeprecatingPackageMessageBoxTitle, 
                                      MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.No) return;

            dynamoViewModel.Model.PackageManagerClient.Undeprecate(this.Model.Name);
        }

        private bool CanUndeprecate()
        {
            return this.dynamoViewModel.Model.PackageManagerClient.HasAuthenticator;
        }

        private void PublishNewPackageVersion()
        {
            this.Model.RefreshCustomNodesFromDirectory(this.dynamoViewModel.Model.CustomNodeManager);
            var vm = PublishPackageViewModel.FromLocalPackage(dynamoViewModel, this.Model);
            vm.IsNewVersion = true;

            dynamoViewModel.OnRequestPackagePublishDialog(vm);
        }

        private bool CanPublishNewPackageVersion()
        {
            return this.dynamoViewModel.Model.PackageManagerClient.HasAuthenticator;
        }

        private void PublishNewPackage()
        {
            this.Model.RefreshCustomNodesFromDirectory(this.dynamoViewModel.Model.CustomNodeManager);
            var vm = PublishPackageViewModel.FromLocalPackage(dynamoViewModel, this.Model);
            vm.IsNewVersion = false;

            dynamoViewModel.OnRequestPackagePublishDialog(vm);
        }

        private bool CanPublishNewPackage()
        {
            return this.dynamoViewModel.Model.PackageManagerClient.HasAuthenticator;
        }

        private void GetLatestVersion()
        {
            throw new NotImplementedException();
        }

        private bool CanGetLatestVersion()
        {
            return false;
        }

        private void ToggleTypesVisibleInManager()
        {
            this.Model.TypesVisibleInManager = !this.Model.TypesVisibleInManager;
        }

        private bool CanToggleTypesVisibleInManager()
        {
            return true;
        }
    }
}