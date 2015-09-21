using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NetLegacySupport.Tuple.Tests.Net20
{
    public class TestAction : AssertionHelper
    {
        private static void Test() { }
        private static void Test(int a1) { }
        private static void Test(int a1, int a2) { }
        private static void Test(int a1, int a2, int a3) { }
        private static void Test(int a1, int a2, int a3, int a4) { }
        private static void Test(int a1, int a2, int a3, int a4, int a5) { }
        private static void Test(int a1, int a2, int a3, int a4, int a5, int a6) { }
        private static void Test(int a1, int a2, int a3, int a4, int a5, int a6, int a7) { }
        private static void Test(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8) { }

        private static int Return() { return 0; }
        private static int Return(int a1) { return 0; }
        private static int Return(int a1, int a2) { return 0; }
        private static int Return(int a1, int a2, int a3) { return 0; }
        private static int Return(int a1, int a2, int a3, int a4) { return 0; }
        private static int Return(int a1, int a2, int a3, int a4, int a5) { return 0; }
        private static int Return(int a1, int a2, int a3, int a4, int a5, int a6) { return 0; }
        private static int Return(int a1, int a2, int a3, int a4, int a5, int a6, int a7) { return 0; }
        private static int Return(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8) { return 0; }

        [Test]
        public static void TestAction_0()
        {
            Assert.NotNull(new Action(Test));
        }

        [Test]
        public static void TestAction_1()
        {
            Assert.NotNull(new Action<int>(Test));
        }

        [Test]
        public static void TestAction_2()
        {
            Assert.NotNull(new Action<int, int>(Test));
        }

        [Test]
        public static void TestAction_3()
        {
            Assert.NotNull(new Action<int, int, int>(Test));
        }

        [Test]
        public static void TestAction_4()
        {
            Assert.NotNull(new Action<int, int, int, int>(Test));
        }

        [Test]
        public static void TestAction_5()
        {
            Assert.NotNull(new Action<int, int, int, int, int>(Test));
        }

        [Test]
        public static void TestAction_6()
        {
            Assert.NotNull(new Action<int, int, int, int, int, int>(Test));
        }

        [Test]
        public static void TestAction_7()
        {
            Assert.NotNull(new Action<int, int, int, int, int, int, int>(Test));
        }

        [Test]
        public static void TestAction_8()
        {
            Assert.NotNull(new Action<int, int, int, int, int, int, int, int>(Test));
        }

        [Test]
        public static void TestFunc_0()
        {
            Assert.NotNull(new Func<int>(Return));
        }

        [Test]
        public static void TestFunc_1()
        {
            Assert.NotNull(new Func<int, int>(Return));
        }

        [Test]
        public static void TestFunc_2()
        {
            Assert.NotNull(new Func<int, int, int>(Return));
        }

        [Test]
        public static void TestFunc_3()
        {
            Assert.NotNull(new Func<int, int, int, int>(Return));
        }

        [Test]
        public static void TestFunc_4()
        {
            Assert.NotNull(new Func<int, int, int, int, int>(Return));
        }

        [Test]
        public static void TestFunc_5()
        {
            Assert.NotNull(new Func<int, int, int, int, int, int>(Return));
        }

        [Test]
        public static void TestFunc_6()
        {
            Assert.NotNull(new Func<int, int, int, int, int, int, int>(Return));
        }

        [Test]
        public static void TestFunc_7()
        {
            Assert.NotNull(new Func<int, int, int, int, int, int, int, int>(Return));
        }

        [Test]
        public static void TestFunc_8()
        {
            Assert.NotNull(new Func<int, int, int, int, int, int, int, int, int>(Return));
        }
    }
}
