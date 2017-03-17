// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using NUnit.Framework;

namespace System.Numerics.Tests
{
    public class op_decrementTest
    {
        private static int s_samples = 10;
        private static Random s_random = new Random(100);

        [Test]
#if NET20
        public static void RunDecrementTests_NET20()
#elif NET35
        public static void RunDecrementTests_NET35()
#elif NET40
        public static void RunDecrementTests_NET40()
#endif
        {
            byte[] tempByteArray1 = new byte[0];

            // Decrement Method - Large BigIntegers
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random);
                VerifyDecrementString(Print(tempByteArray1) + "u--");
            }

            // Decrement Method - Small BigIntegers
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray1 = GetRandomByteArray(s_random, 2);
                VerifyDecrementString(Print(tempByteArray1) + "u--");
            }

            // Decrement Method - zero
            VerifyDecrementString("0 u--");

            // Decrement Method - -1
            VerifyDecrementString("-1 u--");

            // Decrement Method - 1
            VerifyDecrementString("1 u--");

            // Decrement Method - Int32.MinValue
            VerifyDecrementString(Int32.MinValue.ToString() + " u--");

            // Decrement Method - Int32.MinValue-1
            VerifyDecrementString(Int32.MinValue.ToString() + " -1 b+ u--");

            // Decrement Method - Int32.MinValue+1
            VerifyDecrementString(Int32.MinValue.ToString() + " 1 b+ u--");

            // Decrement Method - Int32.MaxValue
            VerifyDecrementString(Int32.MaxValue.ToString() + " u--");

            // Decrement Method - Int32.MaxValue-1
            VerifyDecrementString(Int32.MaxValue.ToString() + " -1 b+ u--");

            // Decrement Method - Int32.MaxValue+1
            VerifyDecrementString(Int32.MaxValue.ToString() + " 1 b+ u--");

            // Decrement Method - Int64.MinValue
            VerifyDecrementString(Int64.MinValue.ToString() + " u--");

            // Decrement Method - Int64.MinValue-1
            VerifyDecrementString(Int64.MinValue.ToString() + " -1 b+ u--");

            // Decrement Method - Int64.MinValue+1
            VerifyDecrementString(Int64.MinValue.ToString() + " 1 b+ u--");

            // Decrement Method - Int64.MaxValue
            VerifyDecrementString(Int64.MaxValue.ToString() + " u--");

            // Decrement Method - Int64.MaxValue-1
            VerifyDecrementString(Int64.MaxValue.ToString() + " -1 b+ u--");

            // Decrement Method - Int64.MaxValue+1
            VerifyDecrementString(Int64.MaxValue.ToString() + " 1 b+ u--");
        }

        private static void VerifyDecrementString(string opstring)
        {
            StackCalc sc = new StackCalc(opstring);
            while (sc.DoNextOperation())
            {
                Assert.AreEqual(sc.snCalc.Peek().ToString(), sc.myCalc.Peek().ToString());
            }
        }

        private static byte[] GetRandomByteArray(Random random)
        {
            return GetRandomByteArray(random, random.Next(0, 1024));
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
