using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ProtoCore.DSASM.Mirror;
using ProtoTest.TD;
using ProtoCore.Lang.Replication;
using ProtoTestFx.TD;
namespace ProtoTest.Associative
{
    public class MethodsFocusTeam
    {
        public TestFrameWork thisTest = new TestFrameWork();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SimpleCtorResolution01()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("x", 123);
            thisTest.Verify("y", 345);
        }

        [Test]
        public void T_upgrade()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 1 };
            thisTest.Verify("a", v1);

        }

        [Test]
        public void T001_DotOp_DefautConstructor_01()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("x", 0);
            thisTest.Verify("y", 0);
        }

        [Test]
        public void T002_DotOp_DefautConstructor_02()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            //Assert.Fail("0.0 should not be evaluated to be the same as 'null' in verification");
            thisTest.Verify("x", 0.0);
            thisTest.Verify("y", null);
        }

        [Test]
        public void T003_DotOp_DefautConstructor_03()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("x", 0.0);
            thisTest.Verify("y", 0.0);
        }

        [Test]
        public void T004_DotOp_DefautConstructor_04()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object v1 = new Object();
            v1 = null;
            thisTest.Verify("x", v1);
            thisTest.Verify("y", v1);
        }

        [Test]
        public void T005_DotOp_DefautConstructor_05()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object v1 = new Object();
            v1 = null;
            thisTest.Verify("x", v1);
            thisTest.Verify("y", v1);
        }

        [Test]
        public void T006_DotOp_SelfDefinedConstructor_01()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("x", 10);
            thisTest.Verify("y", 20);
        }

        [Test]
        public void T007_DotOp_SelfDefinedConstructor_02()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("x", 10.0);
            thisTest.Verify("y", 20.0);
        }

        [Test]
        public void TV1467134_intToDouble_1()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r", 2.0);
        }

        [Test]
        public void TV1467134_intToDouble_2()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r", 4.1415926);
        }

        [Test]
        public void TV1467134_intToDouble_dotOp()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            //thisTest.Verify("r1", );
        }

        [Test]
        public void T008_DotOp_MultiConstructor_01()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("x1", 1);
            thisTest.Verify("y1", 2);
            thisTest.Verify("x2", 3);
            thisTest.Verify("y2", 4);
        }

        [Test]
        public void T009_DotOp_FuncCall()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("x1", 3);
            thisTest.Verify("y1", 4);
            thisTest.Verify("x2", 3);
            thisTest.Verify("y2", 4);
        }

        [Test]
        public void T010_DotOp_Property()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 0, 1, 2 };
            Object[] v2 = new Object[] { 1, 2, 3 };
            thisTest.Verify("m", v1);
            thisTest.Verify("n", v2);
        }

        [Test]
        public void T011_DotOp_Property_2()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 0, 1, 2 };
            Object[] v2 = new Object[] { 1, 2, 3 };
            thisTest.Verify("m", v1);
            thisTest.Verify("n", v2);
        }

        [Test]
        public void T012_DotOp_UserDefinedClass_01()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r1", 3);
            thisTest.Verify("r2", 3);
            thisTest.Verify("r3", 5);
        }

        [Test]
        public void T013_DotOp_UserDefinedClass_02()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 1, 2, 3 };
            Object[] v2 = new Object[] { 1, 2, 3 };
            Object[] v3 = new Object[] { 1, 2, 3, 4, 5 };
            thisTest.Verify("r1", v1);
            thisTest.Verify("r2", v2);
            thisTest.Verify("r3", v3);
        }

        [Test]
        public void T014_DotOp_UserDefinedClass_03()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 1, 2, 3 };
            //Object[] v2 = new Object[] { 1, 10 };
            //Object[] v3 = new Object[] { 2, 10 };
            //Object[] v4 = new Object[] { 3, 10 };
            //Object[] v5 = new Object[] { v2, v3, v4 };
            Object[] v6 = new Object[] { 2, 11 };
            Object[] v7 = new Object[] { 3, 11 };
            Object[] v8 = new Object[] { 4, 11 };
            Object[] v9 = new Object[] { v6, v7, v8 };
            thisTest.Verify("r1", v1);
            thisTest.Verify("r2", v9);
            thisTest.Verify("r3", v9);
            //Assert.Fail("1467135 - Sprint 24 - Rev 2941: non-deterministic dispatch warning message thrown out when using replication with dot opration");
            thisTest.VerifyBuildWarningCount(0);
        }

        [Test]
        [Category("Failure")]
        public void TV1467135_DotOp_Replication_1()
        {
            String code =
@"
            // Tracked by: http://adsk-oss.myjetbrains.com/youtrack/issue/MAGN-1693
            string str = "MAGN-1693 Regression : Dot Operation using Replication on heterogenous array of instances is yielding wrong output";
            thisTest.VerifyRunScriptSource(code, str);
            Object[] v1 = new Object[] { 1, 2 };
            Object[] v2 = new Object[] { null, 2 };
            thisTest.Verify("r1", v1);
            thisTest.Verify("r2", v2);
            thisTest.VerifyBuildWarningCount(0);
        }

        [Test]
        public void TV1467135_DotOp_Replication_2()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 1, 1 };
            Object[] v2 = new Object[] { 2, 2 };
            thisTest.Verify("rfx", v1);
            thisTest.Verify("raby", v1);
            thisTest.Verify("rfy", v2);
            thisTest.VerifyBuildWarningCount(0);
        }

        [Test]
        [Category("Failure")]
        public void TV1467135_DotOp_Replication_3()
        {
            String code =
@"
            // Tracked by: http://adsk-oss.myjetbrains.com/youtrack/issue/MAGN-1693
            string str = "MAGN-1693 Regression : Dot Operation using Replication on heterogenous array of instances is yielding wrong output";
            thisTest.VerifyRunScriptSource(code, str);
            Object[] v1 = new Object[] { 1, 1 };
            Object[] v2 = new Object[] { 2, 2 };
            Object[] v3 = new Object[] { v1, v2 };
            thisTest.Verify("rfoo", v3);
            thisTest.VerifyBuildWarningCount(0);
        }


        [Test]
        public void TV1467135_CallingFuncInSameScope()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 4, 4 };
            thisTest.Verify("rc", v1);
            thisTest.VerifyBuildWarningCount(0);
        }

        [Test]
        public void TV1467135_CallingFuncInSameScope_this()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.SetErrorMessage("1467372 - Sprint 27 - Rev 4107:\"this\" keyword doesn't return correct answer when using with replication");
            Object[] v1 = new Object[] { 4, 4 };
            thisTest.Verify("rc", v1);
            thisTest.VerifyBuildWarningCount(0);
        }

        [Test]
        public void TV1467372_ThisKeyword()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 4, 4 };
            thisTest.Verify("rc", v1);
        }

        [Test]
        public void TV1467372_ThisKeyword_InMemberFunction_Replication()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 1, 1 };
            thisTest.Verify("rc", v1);
        }

        [Test]
        public void TV1467372_ThisKeyword_InMemberFunction_Replication_2()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 5, 5 };
            thisTest.Verify("r1", v1);
        }

        [Test]
        public void TV1467372_ThisKeyword_InMemberFunction_Replication_3()
        {
            String code =
@"
            string str = "";
            thisTest.RunScriptSource(code, str);
            Object[] v1 = new Object[] { 15, 15 };
            thisTest.Verify("r1", v1);
        }

        [Test]
        public void TV1467372_ThisKeyword_2()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("ra", 1);
        }

        [Test]
        public void TV1467372_ThisKeyword_2_Replication()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 1, 1 };
            thisTest.Verify("ra", v1);
        }

        [Test]
        public void TV1467372_ThisKeyword_3()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 1, 1 };
            Object[] v2 = new Object[] { 2, 2 };
            thisTest.Verify("ra", v1);
            thisTest.Verify("rb", v2);
        }

        [Test]
        public void TV1467372_ThisKeyword_InMemberFunction_1()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("rc", 1);
        }

        [Test]
        public void TV1467135_DotOp_Replication_4()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 11, 11 };
            Object[] v2 = new Object[] { 2, 2 };
            thisTest.Verify("t1", v1);
            thisTest.Verify("t2", v2);
            thisTest.Verify("t3", v2);
            thisTest.VerifyBuildWarningCount(0);
        }

        [Test]
        public void T015_DotOp_Collection_01()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r1", true);
        }

        [Test]
        public void T015_DotOp_Collection_01a()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r1", true);
        }

        [Test]
        public void T016_DotOp_Collection_02()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 0 };
            Object[] v2 = new Object[] { 1 };
            Object[] v3 = new Object[] { 2 };
            Object[] v4 = new Object[] { v1, v2, v3 };
            thisTest.Verify("r1", v4);
        }

        [Test]
        public void T017_DotOp_Collection_03()
        {
            String code =
@"
            thisTest.RunScriptSource(code);

            thisTest.Verify("r1", 1);
        }

        [Test]
        public void T018_DotOp_Collection_04()
        {
            String code =
                    @"
            thisTest.RunScriptSource(code);
            //Assert.Fail("1467136 - Sprint 24 - Rev 2941:resolution failure when using dot operation to get 2D array property ");
            Object[] v1 = { 10, 11 };
            Object[] v2 = { v1, v1 };
            thisTest.Verify("r1", v2);

        }

        [Test]
        public void TV018_DotOp_Collection_04_1()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object v1 = new Object[] { 10, 11 };
            Object v2 = new Object[] { v1, v1 };
            thisTest.Verify("r1", v2);
        }

        [Test]
        public void TV018_DotOp_Collection_04_2()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object v1 = null;
            thisTest.Verify("r", v1);
        }

        [Test]
        public void TV018_DotOp_Collection_04_3()
        {
            String code =
                    @"
            thisTest.RunScriptSource(code);
            Object v1 = new Object[] { 10, 11 };
            Object v2 = new Object[] { new object[] { v1, v1 }, new object[] { v1, v1 } };
            thisTest.Verify("r1", v2);
        }

        [Test]
        public void TV018_DotOp_Collection_04_4()
        {
            String code =
                    @"
            thisTest.RunScriptSource(code);
            Object v1 = new Object[] { 10, 11 };
            Object v2 = new Object[] { v1, v1 };
            thisTest.Verify("r1", v2);
        }


        [Test]
        public void T020_Replication_Var()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object v1 = new Object[] { 2, 3 };
            thisTest.Verify("r", v1);
        }

        [Test]
        public void T019_DotOp_Collection_05()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.SetErrorMessage("1467333 - Sprint 27 - Rev 3959: when initializing class member, array is converted to not indexable type, which gives wrong result");
            Object v1 = null;
            thisTest.Verify("r1", v1);
            thisTest.Verify("r2", v1);
            thisTest.Verify("r3", v1);

        }

        [Test]
        public void T021_DotOp_Nested_01()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r", 100);


        }

        [Test]
        public void T021_DotOp_Nested_02()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.SetErrorMessage("1467137 - Sprint 24 - Rev 2941: wrong result when using dot opration to get property for more than two collections");
            Object[] v1 = new Object[] { 10, 11 };
            Object[] v2 = new Object[] { 1, 2 };
            thisTest.Verify("r1", v1);
            thisTest.Verify("r2", v1);
            thisTest.Verify("r3", v1);
            thisTest.Verify("r4", v2);
        }

        [Test]
        public void TV1467137_DotOp_Indexing_1()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r1", null);
            thisTest.Verify("r2", 100);
            thisTest.Verify("r3", 100);
            thisTest.Verify("r4", 100);
            thisTest.Verify("r5", 100);
            thisTest.Verify("r6", 100);
        }

        [Test]
        public void TV1467137_1_DotOp_Update()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 100, 100 };
            thisTest.SetErrorMessage("1467137 - Sprint 24 - Rev 2941: wrong result when using dot opration to get property for more than two collections");
            thisTest.Verify("r1", v1);
            thisTest.Verify("r2", v1);
            thisTest.Verify("r3", v1);
            thisTest.Verify("r4", 100);
            thisTest.Verify("r5", 100);
            thisTest.Verify("r6", 100);
        }

        [Test]
        [Category("Failure")]
        public void T021_DotOp_Nested_03()
        {
            String code =
@"
            // Tracked by: http://adsk-oss.myjetbrains.com/youtrack/issue/MAGN-4045
            thisTest.SetErrorMessage("MAGN-4045 Initializing class member at class level with array of objects, causes crash");

            thisTest.RunScriptSource(code);  
            Object v1 = null;
            thisTest.Verify("m", v1);
            thisTest.Verify("s", v1);
            thisTest.Verify("r", true);
        }

        [Test]
        public void TV1467333()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.SetErrorMessage("1467333 - Sprint 27 - Rev 3959: when initializing class member, array is converted to not indexable type, which gives wrong result");
            Object v1 = null;
            //thisTest.Verify("va", v1); (as the constuction of the object is valid even if the assignment fails)
            thisTest.Verify("m", v1);
            thisTest.Verify("s", v1);
            thisTest.Verify("r", true);
        }

        [Test]
        public void T022_DotOp_CallFunc_01()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r1", 1);
            thisTest.Verify("r2", 2);
            thisTest.Verify("r3", 3);
        }

        [Test]
        [Category("Failure")]
        public void T023_DotOp_FuncCall_02()
        {
            // Tracked by: http://adsk-oss.myjetbrains.com/youtrack/issue/MAGN-4048
            String code =
@"
            Assert.Fail("MAGN-4048 Cyclic dependency undetected resulting in StackOverflowException");
            thisTest.RunScriptSource(code);

        }

        [Test]
        public void T024_DotOp_FuncCall_03()
        {
            String code =
@"

            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 1, true };
            thisTest.Verify("r", v1);
        }

        [Test]
        public void T025_DotOp_FuncCall_04()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 0, 1 };
            thisTest.Verify("r", v1);

        }

        [Test]
        public void TV025_1467140_1()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 0, 1 };
            Object[] v2 = new Object[] { 0, 1 };
            thisTest.Verify("r", v1);
            thisTest.Verify("r2", v2);
        }

        [Test]
        public void TV025_1467140_2()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 0, 1 };
            Object[] v2 = new Object[] { 10, 11 };
            thisTest.Verify("r", v1);
            thisTest.Verify("r2", v2);
        }

        [Test]
        public void T026_DotOp_FuncCall_05()
        {
            String code =
@"
            string str = "";
            thisTest.VerifyRunScriptSource(code, str);
            Object[] v1 = new Object[] { 0, 10 };
            Object[] v2 = new Object[] { 1, 11 };
            Object[] v3 = new Object[] { v1, v2 };
            thisTest.Verify("r1", v3);
        }

        [Test]
        public void T027_DotOp_FuncCall_06()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 0, 20 };
            Object[] v2 = new Object[] { 0, 21 };
            Object[] v3 = new Object[] { v1, v2 };

            thisTest.Verify("r2", v3);
        }
        //////Inheritance

        [Test]
        public void T028_Inheritance_Property()
        {
            String code =
@"
            // Assert.Fail("1467141 - Sprint 24 - Rev 2954: declare a property in subclass with the same name as the property in super class will cause Nunit crash");
            Assert.Throws(typeof(ProtoCore.Exceptions.CompileErrorsOccured), () =>
           {
               thisTest.RunScriptSource(code);
           });

            //thisTest.Verify("r1", 1);

        }

        [Test]
        [Category("Class")]
        public void T029_Inheritance_Property_1()
        {
            String code =
@"

            thisTest.RunScriptSource(code);
            thisTest.Verify("r1", 1);
            thisTest.Verify("r2", 0);
            thisTest.Verify("r3", 2);
            
        }

        [Test]
        public void T030_Inheritance_Property_2()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r", 10);
        }


        [Test]
        public void T031_Inheritance_Property_3()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 1, 2 };
            Object[] v2 = new Object[] { 12, 13 };
            thisTest.Verify("r1", v1);
            thisTest.Verify("r2", v1);
            thisTest.Verify("r3", v2);
            thisTest.Verify("r4", null);
        }

        [Test]
        public void T032_ReservationCheck_rangeExp()
        {
            String code =
@"
            thisTest.RunScriptSource(code);

            thisTest.Verify("r1", 1);
        }

        [Test]
        public void T032_Defect_ReservationCheck_rangeExp()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            //thisTest.Verify("r1", 1);
            thisTest.Verify("r2", 1);
        }

        [Test]
        public void T033_PushThroughCasting()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object r = 3;
            thisTest.Verify("r", r);
        }

        [Test]
        public void T033_PushThroughCasting_UserDefinedType()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r", 3);
        }

        [Test]
        public void T034_PushThroughCastingWithReplication()
        {
            //DNL-1467147 When arguments are up-converted to a var during replication, the type of the value is changed, not the type of the reference
            String code =
@"
            thisTest.RunScriptSource(code);
            Object r = new Object[] 
            ;
            thisTest.Verify("r", r);
        }

        [Test]
        public void TV1467147_PushThroughCastingWithReplication_1()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object r = new Object[] 
            ;
            thisTest.Verify("r", r);
        }

        [Test]
        public void TV1467147_PushThroughCastingWithReplication_2_constructor()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object r = new Object[] 
            ;
            thisTest.Verify("r", r);
        }

        [Test]
        public void T034_PushThroughCastingWithReplication_UserDefinedType()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] rs = new Object[] { 3, 3 };
            thisTest.Verify("r", rs);
        }

        [Test]
        public void T035_PushThroughIntWithReplication()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object r = new Object[] 
            ;
            thisTest.Verify("r", r);
        }

        [Test]
        public void T036_Replication_ArrayDimensionDispatch_SubTest_0D()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("va", 7);
        }

        [Test]
        public void T036_Replication_ArrayDimensionDispatch_SubTest_1D()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("va", new object[] { 7 });
        }

        [Test]
        public void T036_Replication_ArrayDimensionDispatch_SubTest_1D2()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("va", new object[] { 7, 7 });
        }

        [Test]
        public void T036_Replication_ArrayDimensionDispatch_SubTest_2D()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("va", new object[] { new object[] { 7 } });
        }

        [Test]
        public void T036_Replication_ArrayDimensionDispatch_SubTest_2D2()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("va", new object[] { new object[] { 7 }, new object[] { 7 } });
        }

        [Test]
        public void T036_Replication_ArrayDimensionDispatch_SubTest_3D()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("va", new object[] { new object[] { new object[] { 7 } } });
        }

        [Test]
        public void T036_Replication_ArrayDimensionDispatch_SubTest_4D()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("va", new object[] { new object[] { new object[] { new object[] { 7 } } } });
        }


        [Test]
        public void T036_Replication_ArrayDimensionDispatch_SubTest()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("vc", new object[]
            thisTest.Verify("vd", new object[]
        }

        [Test]
        public void T036_Replication_ArrayDimensionDispatch()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("vz", 7);
            thisTest.Verify("va", new object[0]);
            thisTest.Verify("vb", new object[] { 7 });
            thisTest.Verify("vc", new object[]
            thisTest.Verify("vd", new object[]
        }

        [Test]
        public void T037_Replication_ArrayDimensionDispatch_Var()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("vz", 7);
            thisTest.Verify("va", new object[0]);
            thisTest.Verify("vb", new object[] { 7 });
            thisTest.Verify("vc", new object[]
            thisTest.Verify("vd", new object[]
        }

        [Test]
        public void T038_Replication_HigherArrayDimensionDispatch()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("vz", 3);
            thisTest.Verify("va", 7);
            thisTest.Verify("vb", 7);
            thisTest.Verify("vc",
                                                  new object[] { 7 }
                                              );
            thisTest.Verify("vd",
                                                  new object[]
                                              );
        }

        [Test]
        public void Z001_ReplicationGuides_Minimal_01()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] r = new object[] { 3, 3, 3 };
            thisTest.Verify("r", r);
        }

        [Test]
        public void Z002_ReplicationGuides_Minimal_02()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] r = new object[]
            thisTest.Verify("r", r);
        }

        [Test]
        public void Z003_ReplicationGuides_MultipleGuides_01_ExecAtAllCheck()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
        }

        [Test]
        public void R001_Replicator_Internal_ReductionsToGuides_SimpleCartesian()
        {

            List<int> reductionC0 = new List<int>() { 1 };
            List<ReplicationInstruction> instructionsC0 = Replicator.ReductionToInstructions(reductionC0);
            Assert.IsTrue(instructionsC0.Count == 1);
            Assert.IsTrue(instructionsC0[0].CartesianIndex == 0);
            Assert.IsTrue(instructionsC0[0].Zipped == false);
        }

        [Test]
        public void R001_Replicator_Internal_ReductionsToGuides_SimpleCartesian2()
        {
            List<int> reductionC0 = new List<int>() { 2 };
            List<ReplicationInstruction> instructionsC0 = Replicator.ReductionToInstructions(reductionC0);
            Assert.IsTrue(instructionsC0.Count == 2);
            Assert.IsTrue(instructionsC0[0].CartesianIndex == 0);
            Assert.IsTrue(instructionsC0[0].Zipped == false);
            Assert.IsTrue(instructionsC0[1].CartesianIndex == 0);
            Assert.IsTrue(instructionsC0[1].Zipped == false);

        }

        [Test]
        public void R002_Replicator_Internal_ReductionsToGuides_SimpleZipped()
        {
            List<int> reductionZ01 = new List<int>() { 1, 1 };
            List<ReplicationInstruction> instructionsZ01 = Replicator.ReductionToInstructions(reductionZ01);
            Assert.IsTrue(instructionsZ01.Count == 1);
            Assert.IsTrue(instructionsZ01[0].ZipIndecies.Count == 2);
            Assert.IsTrue(instructionsZ01[0].ZipIndecies.Contains(0));
            Assert.IsTrue(instructionsZ01[0].ZipIndecies.Contains(1));
            Assert.IsTrue(instructionsZ01[0].Zipped == true);
        }

        [Test]
        public void R002_Replicator_Internal_ReductionsToGuides_SimpleZipped2()
        {
            List<int> reductionZ01 = new List<int>() { 2, 2 };
            List<ReplicationInstruction> instructionsZ01 = Replicator.ReductionToInstructions(reductionZ01);
            Assert.IsTrue(instructionsZ01.Count == 2);
            Assert.IsTrue(instructionsZ01[0].ZipIndecies.Count == 2);
            Assert.IsTrue(instructionsZ01[0].ZipIndecies.Contains(0));
            Assert.IsTrue(instructionsZ01[0].ZipIndecies.Contains(1));
            Assert.IsTrue(instructionsZ01[0].Zipped == true);
            Assert.IsTrue(instructionsZ01[1].ZipIndecies.Contains(0));
            Assert.IsTrue(instructionsZ01[1].ZipIndecies.Contains(1));
            Assert.IsTrue(instructionsZ01[1].Zipped == true);
        }
        /*
[Test]

        [Test]
        public void T039_Inheritance_Method_1()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r1", 11);
            thisTest.Verify("r2", 20);
            thisTest.Verify("r3", 11);
        }

        [Test]
        public void TV1467161_Inheritance_Update_1()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r1", 101);
            thisTest.Verify("r2", 101);
            thisTest.Verify("r3", 101);
        }

        [Test]
        public void TV1467161_Inheritance_Update_2()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r1", 101);
            thisTest.Verify("r2", 20);
            thisTest.Verify("r3", 100);
            thisTest.Verify("r4", 101);
        }

        [Test]
        public void T040_Inheritance_Dynamic_Typing_1()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r1", 11);
            thisTest.Verify("r2", 20);
            thisTest.Verify("r3", 11);
        }

        [Test]
        public void T041_Inheritance_Dynamic_Typing_2()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object v1 = new Object();
            v1 = null;
            thisTest.Verify("r1", 11);
            thisTest.Verify("r2", v1);
            thisTest.Verify("r3", 11);
        }

        [Test]
        public void T042_Inheritance_Dynamic_Typing_3()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object v1 = new Object();
            v1 = null;
            thisTest.Verify("r1", 11);
            thisTest.Verify("r2", v1);
            thisTest.Verify("r3", 11);
        }

        [Test]
        public void T044_Function_Overriding_NoArgs()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r1", 100);
            thisTest.Verify("r2", 200);

        }

        [Test]
        public void T043_Function_Overriding_1()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r1", 11);
            thisTest.Verify("r2", 100);
            thisTest.Verify("r3", 11);
            thisTest.Verify("r4", 100);

        }

        [Test]
        public void T043_Function_Overriding_2()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r1", 11);
            thisTest.Verify("r2", 100);
            thisTest.Verify("r3", 11);
            thisTest.Verify("r4", 100);

        }

        [Test]
        [Category("Failure")]
        public void TV1467063_Function_Overriding()
        {
            // Tracked by: http://adsk-oss.myjetbrains.com/youtrack/issue/MAGN-4054
            string err = "";
            String code =
@"
            thisTest.RunScriptSource(code, err);
            thisTest.SetErrorMessage("MAGN-4054: Function overriding: when using function overriding, wrong function is called");
            thisTest.Verify("r1", 11);
            thisTest.Verify("r2", 100);
            thisTest.Verify("r3", 11);
            thisTest.Verify("r4", 100);
        }

        [Test]
        public void T045_Inheritance_Method_02()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r1", 1);
            thisTest.Verify("r2", 11);
        }

        [Test]
        public void T046_Inheritance_Method_03()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r1", 11);
            thisTest.Verify("r2", 1);
        }

        [Test]
        public void T047_Inheritance_Method_04()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            //Assert.Fail("1467175 - sprint 25 - Rev 3150: [design issue] :cast distance to a var comparing with cast distance to a double ");
            thisTest.Verify("r1", 11);
            thisTest.Verify("r2", 1);
        }

        [Test]
        public void TV1467175_1()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r", 1.0);
        }

        [Test]
        public void TV1467175_2()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r", 1.0);
        }

        [Test]
        public void TV1467175_3()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("ra", 1.0);
            thisTest.Verify("rb", 1.0);
        }

        [Test]
        public void TV1467175_4()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("ra", 1);
            thisTest.Verify("rb", 1.0);
        }

        [Test]
        public void T049_Inheritance_Update_01()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            // Assert.Fail("1467167 - Sprint 25 - Rev 3132: class member doesn't get updated correctly");
            thisTest.Verify("r1", 11);
            thisTest.Verify("r2", 22);
            thisTest.Verify("r3", 11);
            thisTest.Verify("r4", 22);
        }

        [Test]
        public void T049_Inheritance_Update_02()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r1", 11);
            thisTest.Verify("r2", 22);
            thisTest.Verify("r3", 33);
            thisTest.Verify("r4", 11);
            thisTest.Verify("r5", 22);
            thisTest.Verify("r6", 33);
        }

        [Test]
        public void T049_Inheritance_Update_03()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.SetErrorMessage("1467167 - Sprint 25 - Rev 3132: class member doesn't get updated correctly");
            thisTest.Verify("r1", 11);
            thisTest.Verify("r2", 22);
            thisTest.Verify("r3", 33);
            thisTest.Verify("r4", 11);
            thisTest.Verify("r5", 22);
            thisTest.Verify("r6", 33);
        }

        [Test]
        [Category("Failure")]
        public void TV1467167()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r1", 111);
            thisTest.Verify("r2", 222);
            thisTest.Verify("r3", 3);
            thisTest.Verify("r4", 11);
            thisTest.Verify("r5", 22);
            thisTest.Verify("r6", 33);
            thisTest.Verify("r7", 33);
            thisTest.Verify("r8", 3);
        }


        [Test]
        public void T050_Transitive_Inheritance_01()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r1", 11);
            thisTest.Verify("r2", 2);
            thisTest.Verify("r3", 3);
            thisTest.Verify("r4", 11);
        }

        [Test]
        public void T050_Transitive_Inheritance_02()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.SetErrorMessage("1467167 - Sprint 25 - Rev 3132: class member doesn't get updated correctly");
            thisTest.Verify("r1", 1);
            thisTest.Verify("r2", 22);
            thisTest.Verify("r3", 3);
            thisTest.Verify("r4", 22);
        }

        [Test]
        public void T050_Inheritance_Multi_Constructor_01()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object v1 = null;
            thisTest.Verify("r1", 0);
            thisTest.Verify("r2", 1);
            thisTest.Verify("r3", 1);
            thisTest.Verify("r4", v1);
        }

        [Test]
        [Category("ToFixJun")]
        [Category("Failure")]
        [Category("Class")]
        public void T051_TransitiveInheritance_Constructor()
        {
            String code =
@"
            // Tracked by: http://adsk-oss.myjetbrains.com/youtrack/issue/MAGN-4050
            string err = "MAGN-4050 Transitive inheritance base constructor causes method resolution failure";
            thisTest.RunScriptSource(code, err);
            thisTest.Verify("r1", 0);
            thisTest.Verify("r2", 2);
            thisTest.Verify("r3", 3.0); // Actual result is 2 as C.C(1.0) instead of calling double overload of ctor A calls its int counterpart instead??
        }

        [Test]
        public void T050_Inheritance_Multi_Constructor_02()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            //Assert.Fail("1467179 - Sprint25 : rev 3152 : multiple inheritance base constructor causes method resolution");
            Object v1 = null;
            thisTest.Verify("r1", 0);
            thisTest.Verify("r2", 1);
            thisTest.Verify("r3", 3);
            thisTest.Verify("r4", v1);
        }

        [Test]
        public void T052_Defect_ReplicationMethodOverloading()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 2, 2, 2 };
            thisTest.Verify("r", v1);
        }

        [Test]
        [Category("Method Resolution")]
        [Category("Failure")]
        public void T052_Defect_ReplicationMethodOverloading_2()
        {
            String code =
@"
            // Tracked by: http://adsk-oss.myjetbrains.com/youtrack/issue/MAGN-4052
            thisTest.RunScriptSource(code);
            Object[] v1 = new Object[] { 1, 2, 2, 3 };
            thisTest.Verify("r", v1);
        }

        [Test]
        [Category("Method Resolution")]
        [Category("Failure")]
        public void TV052_Defect_ReplicationMethodOverloading_01()
        {
            String code =
@"
            // Tracked by: http://adsk-oss.myjetbrains.com/youtrack/issue/MAGN-4052
            string err = "MAGN-4052 Replication and Method overload issue, resolving to wrong method";
            thisTest.RunScriptSource(code, err);
            Object[] v1 = new Object[] { 1, 2, 2, null };
            thisTest.Verify("r", v1);
        }

        [Test]
        [Category("Method Resolution")]
        public void TV052_Defect_ReplicationMethodOverloading_02()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r", 3);
        }

        [Test]
        [Category("Method Resolution")]
        [Category("Failure")]
        public void TV052_Defect_ReplicationMethodOverloading_03()
        {
            String code =
@"
            // Tracked by: http://adsk-oss.myjetbrains.com/youtrack/issue/MAGN-4052
            string err = "MAGN-4052 Replication and Method overload issue, resolving to wrong method";
            thisTest.RunScriptSource(code, err);
            Object[] v1 = new Object[] { 1, 2, 2, null };
            thisTest.Verify("r", v1);
        }

        [Test]
        [Category("Method Resolution")]
        [Category("Failure")]
        public void TV052_Defect_ReplicationMethodOverloading_InUserDefinedClass()
        {
            String code =
@"
            // Tracked by: http://adsk-oss.myjetbrains.com/youtrack/issue/MAGN-4052
            string err = "MAGN-4052 Replication and Method overload issue, resolving to wrong method";
            thisTest.RunScriptSource(code, err);
            Object[] v1 = new Object[] { 1, 2, 2, null };
            Object[] v2 = new Object[] { 11, 22, 22, null };
            thisTest.Verify("r", v1);
            thisTest.Verify("r2", v2);
        }
        /*
[Test]

        [Test]
        [Category("Failure")]
        public void T053_ReplicationWithDiffTypesInArr()
        {
            String code =
@"
            // Tracked by http://adsk-oss.myjetbrains.com/youtrack/issue/MAGN-1693
            string str = "MAGN-1693 Regression : Dot Operation using Replication on heterogenous array of instances is yielding wrong output";
            thisTest.VerifyRunScriptSource(code, str);

            Object[] v1 = new Object[] { 1, 2, 1 };
            Object[] v2 = new Object[] { 2, 1, 2 };
            thisTest.Verify("r1", v1);
            thisTest.Verify("r2", v2);
        }

        [Test]
        [Category("Failure")]
        public void T054_ReplicationWithInvalidTypesInArr()
        {
            String code =
@"
            // Tracked by http://adsk-oss.myjetbrains.com/youtrack/issue/MAGN-1693
            string str = "MAGN-1693 Regression : Dot Operation using Replication on heterogenous array of instances is yielding wrong output";
            thisTest.RunScriptSource(code, str);
            Object v3 = null;
            Object[] v1 = new Object[] { 1, 2, v3 };
            Object[] v2 = new Object[] { 2, 1, v3, v3 };

            thisTest.Verify("r1", v1);
            thisTest.Verify("r2", v2);
        }
        
        [Test]
        public void T055_ReplicationWithDiffTypesInArr_UserDefined_Simpler()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r1a", new object[] { 1, 1, 1 });
            thisTest.Verify("r1b", new object[] { 1, 2, 1 });
        }

        [Test]
        public void ReplicationSubDispatch()
        {
            String code =
@"
            thisTest.RunScriptSource(code);

            thisTest.Verify("ret", new object[] { 1, 2, 1, 2 });
        }

        [Test]
        public void Test()
        {
            String code =
@"
            thisTest.RunScriptSource(code);
        }

        [Test]
        public void T056_nonmatchingclass_1467162()
        {
            String code =
            @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", null);
            TestFrameWork.VerifyRuntimeWarning(ProtoCore.RuntimeData.WarningID.kConversionNotPossible);
        }

        [Test]
        public void T057_nonmatchingclass_1467162_2()
        {
            String code =
            @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", null);
            TestFrameWork.VerifyRuntimeWarning(ProtoCore.RuntimeData.WarningID.kConversionNotPossible);
        }

        [Test]
        public void T058_nonmatchingclass_1467162_3()
        {
            String code =
            @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", null);
            TestFrameWork.VerifyRuntimeWarning(ProtoCore.RuntimeData.WarningID.kConversionNotPossible);
        }

        [Test]
        public void T059_Polymphism()
        {
            String code =
            @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("ret", "A.bar()");
        }

        [Test]
        public void T059_Polymphism_2()
        {
            String code =
            @"
            string error = "1467150 Sprint 25 - Rev 3026 - Polymorphism in design script broken when nested function calls between the different class ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("ret", "B.bar()");
        }

        [Test]
        public void T059_Polymphism_3()
        {
            String code =
            @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("ret", null);
        }

        [Test]
        public void T059_Polymphism_4()
        {
            String code =
            @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("ret", null);
        }

        [Test]
        public void T059_Polymphism_5()
        {
            String code =
            @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("g", 100);
        }

        [Test]
        public void T060_DispatchOnArrayLevel()
        {
            String code =
            @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("d", 1);
        }

        [Test]
        public void T060_DispatchOnArrayLevel_1()
        {
            String code =
            @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("d", 2);
        }

        [Test]
        public void T060_DispatchOnArrayLevel_2()
        {
            String code =
            @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("d", 1);
        }


        [Test]
        public void RepoTests_MAGN3177()
        {
            String code =
                @"
            thisTest.RunScriptSource(code);
            //thisTest.Verify("d", 1);
        }

        /// <summary>
        /// As member function is overloaded with %thisptr as the first
        /// parameter, this test case tries to verify that method resolution
        /// work properly for overloaded member function and non-overloaded
        /// member function which has same signature. E.g.,
        /// 
        ///     void foo(x: X, y: X);
        ///     void foo(%thisptr:X, x:X);
        ///     
        /// </summary>
        [Test]
        public void TestMethodResolutionForThisPtrs1()
        {
            string code = @"
class A
{
    def foo()
    {
        return = 41;
    }

    def foo(x : A)
    {
        return = 42;
    }

    def foo(x : A, y: A)
    {
        return = 43;
    }

    def foo(x : A, y: A, z:A)
    {
        return = 44;
    }
}

a = A();
r1 = a.foo();
r2 = a.foo(a);
r3 = a.foo(a,a);
r4 = a.foo(a,a,a);
";

            thisTest.RunScriptSource(code);
            thisTest.VerifyBuildWarningCount(0);
            thisTest.Verify("r1", 41);
            thisTest.Verify("r2", 42);
            thisTest.Verify("r3", 43);
            thisTest.Verify("r4", 44);
        }

        [Test]
        public void TestMethodResolutionForThisPtrs2()
        {
            string code = @"
class A
{
    def foo(x: int)
    {
        return = 41;
    }

    static def foo(x : A, y: int)
    {
        return = 42;
    }
}

a = A();
r1 = a.foo(1);
r2 = a.foo(a, 1);
";

            thisTest.RunScriptSource(code);
            thisTest.VerifyBuildWarningCount(0);
            thisTest.Verify("r1", 41);
            thisTest.Verify("r2", 42);
        }

        [Test]
        public void TestMethodResolutionForThisPtrs3()
        {
            string code = @"
class A
{
    def foo(x: int)
    {
        return = 41;
    }

    static def foo(x : A, y: int)
    {
        return = 42;
    }
}

a = A();
r1 = a.foo({1});
r2 = a.foo(a, {1});
";

            thisTest.RunScriptSource(code);
            thisTest.VerifyBuildWarningCount(0);
            thisTest.Verify("r1", new object[] {41});
            thisTest.Verify("r2", new object[] {42});
        }
    }
}
