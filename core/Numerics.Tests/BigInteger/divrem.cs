// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using NUnit.Framework;

namespace System.Numerics.Tests
{
    public class divremTest
    {
        private static int s_samples = 10;
        private static Random s_random = new Random(100);

        [Test]
#if NET20
        public static void RunDivRem_TwoLargeBI_NET20()
#elif NET35
        public static void RunDivRem_TwoLargeBI_NET35()
#elif NET40
        public static void RunDivRem_TwoLargeBI_NET40()
#endif
        {
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];

            // DivRem Method - Two Large BigIntegers
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random);
                tempByteArray2 = GetRandomByteArray(s_random);
                VerifyDivRemString(Print(tempByteArray1) + Print(tempByteArray2) + "bDivRem");
            }
        }

        [Test]
#if NET20
        public static void RunDivRem_TwoSmallBI_NET20()
#elif NET35
        public static void RunDivRem_TwoSmallBI_NET35()
#elif NET40
        public static void RunDivRem_TwoSmallBI_NET40()
#endif
        {
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];

            // DivRem Method - Two Small BigIntegers
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random, 2);
                tempByteArray2 = GetRandomByteArray(s_random, 2);
                VerifyDivRemString(Print(tempByteArray1) + Print(tempByteArray2) + "bDivRem");
            }
        }
        
        [Test]
#if NET20
        public static void RunDivRem_OneSmallOneLargeBI_NET20()
#elif NET35
        public static void RunDivRem_OneSmallOneLargeBI_NET35()
#elif NET40
        public static void RunDivRem_OneSmallOneLargeBI_NET40()
#endif
        {
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];

            // DivRem Method - One Large and one small BigIntegers
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random);
                tempByteArray2 = GetRandomByteArray(s_random, 2);
                VerifyDivRemString(Print(tempByteArray1) + Print(tempByteArray2) + "bDivRem");

                tempByteArray1 = GetRandomByteArray(s_random, 2);
                tempByteArray2 = GetRandomByteArray(s_random);
                VerifyDivRemString(Print(tempByteArray1) + Print(tempByteArray2) + "bDivRem");
            }
        }

        [Test]
#if NET20
        public static void RunDivRem_OneLargeOne0BI_NET20()
#elif NET35
        public static void RunDivRem_OneLargeOne0BI_NET35()
#elif NET40
        public static void RunDivRem_OneLargeOne0BI_NET40()
#endif
        {
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];

            // DivRem Method - One Large BigIntegers and zero
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random);
                tempByteArray2 = new byte[] { 0 };
                VerifyDivRemString(Print(tempByteArray1) + Print(tempByteArray2) + "bDivRem");

                Assert.Throws<DivideByZeroException>(() =>
                {
                    VerifyDivRemString(Print(tempByteArray2) + Print(tempByteArray1) + "bDivRem");
                });
            }
        }

        [Test]
#if NET20
        public static void RunDivRem_OneSmallOne0BI_NET20()
#elif NET35
        public static void RunDivRem_OneSmallOne0BI_NET35()
#elif NET40
        public static void RunDivRem_OneSmallOne0BI_NET40()
#endif
        {
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];

            // DivRem Method - One small BigIntegers and zero
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random, 2);
                tempByteArray2 = new byte[] { 0 };
                VerifyDivRemString(Print(tempByteArray1) + Print(tempByteArray2) + "bDivRem");

                Assert.Throws<DivideByZeroException>(() =>
                {
                    VerifyDivRemString(Print(tempByteArray2) + Print(tempByteArray1) + "bDivRem");
                });
            }
        }

        [Test]
#if NET20
        public static void Boundary_NET20()
#elif NET35
        public static void Boundary_NET35()
#elif NET40
        public static void Boundary_NET40()
#endif
        {
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];

            // Check interesting cases for boundary conditions
            // You'll either be shifting a 0 or 1 across the boundary
            // 32 bit boundary  n2=0
            VerifyDivRemString(Math.Pow(2, 32) + " 2 bDivRem");

            // 32 bit boundary  n1=0 n2=1
            VerifyDivRemString(Math.Pow(2, 33) + " 2 bDivRem");
        }

        [Test]
#if NET20
        public static void RunDivRemTests_NET20()
#elif NET35
        public static void RunDivRemTests_NET35()
#elif NET40
        public static void RunDivRemTests_NET40()
#endif
        {
            byte[] tempByteArray1 = new byte[0];
            byte[] tempByteArray2 = new byte[0];

            // DivRem Method - Two Large BigIntegers
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random);
                tempByteArray2 = GetRandomByteArray(s_random);
                VerifyDivRemString(Print(tempByteArray1) + Print(tempByteArray2) + "bDivRem");
            }

            // DivRem Method - Two Small BigIntegers
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random, 2);
                tempByteArray2 = GetRandomByteArray(s_random, 2);
                VerifyDivRemString(Print(tempByteArray1) + Print(tempByteArray2) + "bDivRem");
            }

            // DivRem Method - One Large and one small BigIntegers
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random);
                tempByteArray2 = GetRandomByteArray(s_random, 2);
                VerifyDivRemString(Print(tempByteArray1) + Print(tempByteArray2) + "bDivRem");

                tempByteArray1 = GetRandomByteArray(s_random, 2);
                tempByteArray2 = GetRandomByteArray(s_random);
                VerifyDivRemString(Print(tempByteArray1) + Print(tempByteArray2) + "bDivRem");
            }

            // DivRem Method - One Large BigIntegers and zero
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random);
                tempByteArray2 = new byte[] { 0 };
                VerifyDivRemString(Print(tempByteArray1) + Print(tempByteArray2) + "bDivRem");

                Assert.Throws<DivideByZeroException>(() => { VerifyDivRemString(Print(tempByteArray2) + Print(tempByteArray1) + "bDivRem"); });
            }

            // DivRem Method - One small BigIntegers and zero
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random, 2);
                tempByteArray2 = new byte[] { 0 };
                VerifyDivRemString(Print(tempByteArray1) + Print(tempByteArray2) + "bDivRem");

                Assert.Throws<DivideByZeroException>(() => { VerifyDivRemString(Print(tempByteArray2) + Print(tempByteArray1) + "bDivRem"); });
            }


            // Check interesting cases for boundary conditions
            // You'll either be shifting a 0 or 1 across the boundary
            // 32 bit boundary  n2=0
            VerifyDivRemString(Math.Pow(2, 32) + " 2 bDivRem");

            // 32 bit boundary  n1=0 n2=1
            VerifyDivRemString(Math.Pow(2, 33) + " 2 bDivRem");
        }

        private static void VerifyDivRemString(string opstring)
        {
            StackCalc sc = new StackCalc(opstring);
            while (sc.DoNextOperation())
            {
                Assert.AreEqual(sc.snCalc.Peek().ToString(), sc.myCalc.Peek().ToString());
                sc.VerifyOutParameter();
            }
        }

        private static byte[] GetRandomByteArray(Random random)
        {
            return GetRandomByteArray(random, random.Next(1, 100));
        }

        private static byte[] GetRandomByteArray(Random random, int size)
        {
            return MyBigIntImp.GetNonZeroRandomByteArray(random, size);
        }
        
        private static String Print(byte[] bytes)
        {
            return MyBigIntImp.Print(bytes);
        }
    }
}
