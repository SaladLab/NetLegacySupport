// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using NUnit.Framework;

namespace System.Numerics.Tests
{
    public class multiplyTest
    {
        private static int s_samples = 10;
        private static int s_seed = 100;

        [Test]
#if NET20
        public static void RunMultiply_TwoLargeBigIntegers_NET20()
#elif NET35
        public static void RunMultiply_TwoLargeBigIntegers_NET35()
#elif NET40
        public static void RunMultiply_TwoLargeBigIntegers_NET40()
#endif
        {
            Random random = new Random(s_seed);
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];

            // Multiply Method - One Large BigInteger
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(random);
                VerifyMultiplyString(Print(tempByteArray1) + "uMultiply");
            }

            // Multiply Method - Two Large BigIntegers
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(random);
                tempByteArray2 = GetRandomByteArray(random);
                VerifyMultiplyString(Print(tempByteArray1) + Print(tempByteArray2) + "bMultiply");
            }
        }

        [Test]
#if NET20
        public static void RunMultiply_TwoLargeBigIntegers_Threshold_NET20()
#elif NET35
        public static void RunMultiply_TwoLargeBigIntegers_Threshold_NET35()
#elif NET40
        public static void RunMultiply_TwoLargeBigIntegers_Threshold_NET40()
#endif
        {
            // Again, with lower threshold
            //BigIntTools.Utils.RunWithFakeThreshold("SquareThreshold", 8, () =>
            //    BigIntTools.Utils.RunWithFakeThreshold("MultiplyThreshold", 8, RunMultiply_TwoLargeBigIntegers)
            //);

            //// Again, with lower threshold
            //BigIntTools.Utils.RunWithFakeThreshold("SquareThreshold", 8, () =>
            //    BigIntTools.Utils.RunWithFakeThreshold("MultiplyThreshold", 8, () =>
            //        BigIntTools.Utils.RunWithFakeThreshold("AllocationThreshold", 8, RunMultiply_TwoLargeBigIntegers)
            //    )
            //);
        }

        [Test]
#if NET20
        public static void RunMultiply_TwoSmallBigIntegers_NET20()
#elif NET35
        public static void RunMultiply_TwoSmallBigIntegers_NET35()
#elif NET40
        public static void RunMultiply_TwoSmallBigIntegers_NET40()
#endif
        {
            Random random = new Random(s_seed);
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];

            // Multiply Method - Two Small BigIntegers
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(random, 2);
                tempByteArray2 = GetRandomByteArray(random, 2);
                VerifyMultiplyString(Print(tempByteArray1) + Print(tempByteArray2) + "bMultiply");
            }
        }

        [Test]
#if NET20
        public static void RunMultiply_OneLargeOneSmall_NET20()
#elif NET35
        public static void RunMultiply_OneLargeOneSmall_NET35()
#elif NET40
        public static void RunMultiply_OneLargeOneSmall_NET40()
#endif
        {
            Random random = new Random(s_seed);
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];

            // Multiply Method - One large and one small BigIntegers
            for (int i = 0; i < s_samples; i++)
            {
                try
                {
                    tempByteArray1 = GetRandomByteArray(random);
                    tempByteArray2 = GetRandomByteArray(random, 2);
                    VerifyMultiplyString(Print(tempByteArray1) + Print(tempByteArray2) + "bMultiply");

                    tempByteArray1 = GetRandomByteArray(random, 2);
                    tempByteArray2 = GetRandomByteArray(random);
                    VerifyMultiplyString(Print(tempByteArray1) + Print(tempByteArray2) + "bMultiply");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Array1: " + Print(tempByteArray1));
                    Console.WriteLine("Array2: " + Print(tempByteArray2));
                    throw;
                }
            }
        }

        [Test]
#if NET20
        public static void RunMultiply_OneLargeOneZero_NET20()
#elif NET35
        public static void RunMultiply_OneLargeOneZero_NET35()
#elif NET40
        public static void RunMultiply_OneLargeOneZero_NET40()
#endif
        {
            Random random = new Random(s_seed);
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];

            // Multiply Method - One large BigIntegers and zero
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(random);
                tempByteArray2 = new byte[] { 0 };
                VerifyMultiplyString(Print(tempByteArray1) + Print(tempByteArray2) + "bMultiply");

                tempByteArray1 = new byte[] { 0 };
                tempByteArray2 = GetRandomByteArray(random);
                VerifyMultiplyString(Print(tempByteArray1) + Print(tempByteArray2) + "bMultiply");
            }
        }

        [Test]
#if NET20
        public static void RunMultiply_OneSmallOneZero_NET20()
#elif NET35
        public static void RunMultiply_OneSmallOneZero_NET35()
#elif NET40
        public static void RunMultiply_OneSmallOneZero_NET40()
#endif
        {
            Random random = new Random(s_seed);
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];

            // Multiply Method - One small BigIntegers and zero
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(random, 2);
                tempByteArray2 = new byte[] { 0 };
                VerifyMultiplyString(Print(tempByteArray1) + Print(tempByteArray2) + "bMultiply");

                tempByteArray1 = new byte[] { 0 };
                tempByteArray2 = GetRandomByteArray(random, 2);
                VerifyMultiplyString(Print(tempByteArray1) + Print(tempByteArray2) + "bMultiply");
            }
        }

        [Test]
#if NET20
        public static void RunMultiply_AxiomXX1_NET20()
#elif NET35
        public static void RunMultiply_AxiomXX1_NET35()
#elif NET40
        public static void RunMultiply_AxiomXX1_NET40()
#endif
        {
            Random random = new Random(s_seed);
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];

            // Axiom: X*1 = X
            VerifyIdentityString(Int32.MaxValue + " " + BigInteger.One + " bMultiply", Int32.MaxValue.ToString());
            VerifyIdentityString(Int64.MaxValue + " " + BigInteger.One + " bMultiply", Int64.MaxValue.ToString());

            for (int i = 0; i < s_samples; i++)
            {
                String randBigInt = Print(GetRandomByteArray(random));
                VerifyIdentityString(randBigInt + BigInteger.One + " bMultiply", randBigInt + "u+");
            }
        }

        [Test]
#if NET20
        public static void RunMultiply_AxiomXX0_NET20()
#elif NET35
        public static void RunMultiply_AxiomXX0_NET35()
#elif NET40
        public static void RunMultiply_AxiomXX0_NET40()
#endif
        {
            Random random = new Random(s_seed);
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];

            // Axiom: X*0 = 0
            VerifyIdentityString(Int32.MaxValue + " " + BigInteger.Zero + " bMultiply", BigInteger.Zero.ToString());
            VerifyIdentityString(Int64.MaxValue + " " + BigInteger.Zero + " bMultiply", BigInteger.Zero.ToString());

            for (int i = 0; i < s_samples; i++)
            {
                String randBigInt = Print(GetRandomByteArray(random));
                VerifyIdentityString(randBigInt + BigInteger.Zero + " bMultiply", BigInteger.Zero.ToString());
            }
        }

        [Test]
#if NET20
        public static void RunMultiply_Commutat_NET20()
#elif NET35
        public static void RunMultiply_Commutat_NET35()
#elif NET40
        public static void RunMultiply_Commutat_NET40()
#endif
        {
            Random random = new Random(s_seed);
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];

            // Axiom: a*b = b*a
            VerifyIdentityString(Int32.MaxValue + " " + Int64.MaxValue + " bMultiply", Int64.MaxValue + " " + Int32.MaxValue + " bMultiply");

            for (int i = 0; i < s_samples; i++)
            {
                String randBigInt1 = Print(GetRandomByteArray(random));
                String randBigInt2 = Print(GetRandomByteArray(random));
                VerifyIdentityString(randBigInt1 + randBigInt2 + "bMultiply", randBigInt2 + randBigInt1 + "bMultiply");
            }
        }

        [Test]
#if NET20
        public static void RunMultiply_Boundary_NET20()
#elif NET35
        public static void RunMultiply_Boundary_NET35()
#elif NET40
        public static void RunMultiply_Boundary_NET40()
#endif
        {
            Random random = new Random(s_seed);
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];

            // Check interesting cases for boundary conditions
            // You'll either be shifting a 0 or 1 across the boundary
            // 32 bit boundary  n2=0
            VerifyMultiplyString(Math.Pow(2, 32) + " 2 bMultiply");

            // 32 bit boundary  n1=0 n2=1
            VerifyMultiplyString(Math.Pow(2, 33) + " 2 bMultiply");
        }

        private static void VerifyMultiplyString(string opstring)
        {
            StackCalc sc = new StackCalc(opstring);
            while (sc.DoNextOperation())
            {
                Assert.AreEqual(sc.snCalc.Peek().ToString(), sc.myCalc.Peek().ToString());
            }
        }

        private static void VerifyIdentityString(string opstring1, string opstring2)
        {
            StackCalc sc1 = new StackCalc(opstring1);
            while (sc1.DoNextOperation())
            {	
                //Run the full calculation
                sc1.DoNextOperation();
            }

            StackCalc sc2 = new StackCalc(opstring2);
            while (sc2.DoNextOperation())
            {	
                //Run the full calculation
                sc2.DoNextOperation();
            }

            Assert.AreEqual(sc1.snCalc.Peek().ToString(), sc2.snCalc.Peek().ToString());
        }

        private static byte[] GetRandomByteArray(Random random)
        {
            return GetRandomByteArray(random, random.Next(0, 100));
        }

        private static byte[] GetRandomByteArray(Random random, int size)
        {
            return MyBigIntImp.GetRandomByteArray(random, size);
        }

        private static String Print(byte[] bytes)
        {
            return MyBigIntImp.Print(bytes);
        }
    }
}
