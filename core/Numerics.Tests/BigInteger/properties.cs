// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Globalization;
using NUnit.Framework;

namespace System.Numerics.Tests
{
    public class propertiesTest
    {
        private static int s_samples = 10;
        private static Random s_random = new Random(100);

        [Test]
        public static void RunZeroTests()
        {
            BigInteger bigInteger;
            byte[] tempByteArray;

            // BigInteger.Zero == 0
            Assert.AreEqual("0", BigInteger.Zero.ToString());
            Assert.AreEqual(new BigInteger((Int64)(0)), BigInteger.Zero);
            Assert.AreEqual(new BigInteger((Double)(0)), BigInteger.Zero);
            Assert.AreEqual(new BigInteger(new byte[] { 0, 0, 0, 0 }), BigInteger.Zero);
            Assert.AreEqual(BigInteger.One + BigInteger.MinusOne, BigInteger.Zero);
            Assert.AreEqual(BigInteger.One - BigInteger.One, BigInteger.Zero);
            Assert.AreEqual(BigInteger.MinusOne - BigInteger.MinusOne, BigInteger.Zero);

            // Identities with BigInteger.Zero
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray = GetRandomByteArray(s_random);
                bigInteger = new BigInteger(tempByteArray);

                Assert.AreEqual(BigInteger.Zero, BigInteger.Zero * bigInteger);
                Assert.AreEqual(bigInteger, bigInteger - BigInteger.Zero);
                Assert.AreEqual(BigInteger.MinusOne * bigInteger, BigInteger.Zero - bigInteger);
                Assert.AreEqual(bigInteger, bigInteger + BigInteger.Zero);
                Assert.AreEqual(bigInteger, BigInteger.Zero + bigInteger);

                Assert.Throws<DivideByZeroException>(() =>
                {
                    BigInteger tempBigInteger = bigInteger / BigInteger.Zero;
                });

                if (!MyBigIntImp.IsZero(tempByteArray))
                {
                    Assert.AreEqual(BigInteger.Zero, BigInteger.Zero / bigInteger);
                }
            }
        }

        [Test]
        public static void RunOneTests()
        {
            BigInteger bigInteger;
            byte[] tempByteArray;

            // BigInteger.One == 1
            Assert.AreEqual("1", BigInteger.One.ToString());
            Assert.AreEqual(new BigInteger((Int64)(1)), BigInteger.One);
            Assert.AreEqual(new BigInteger((Double)(1)), BigInteger.One);
            Assert.AreEqual(new BigInteger(new byte[] { 1, 0, 0, 0 }), BigInteger.One);
            Assert.AreEqual(BigInteger.Zero - BigInteger.MinusOne, BigInteger.One);
            Assert.AreEqual((BigInteger)671832 / (BigInteger)671832, BigInteger.One);

            // Identities with BigInteger.One
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray = GetRandomByteArray(s_random);

                bigInteger = new BigInteger(tempByteArray);

                Assert.AreEqual(bigInteger, BigInteger.One * bigInteger);
                Assert.AreEqual(bigInteger, bigInteger / BigInteger.One);
            }
        }

        [Test]
        public static void RunMinusOneTests()
        {
            BigInteger bigInteger;
            byte[] tempByteArray;

            // BigInteger.MinusOne == -1
            Assert.AreEqual(
                CultureInfo.CurrentCulture.NumberFormat.NegativeSign + "1",
                BigInteger.MinusOne.ToString()
            );
            Assert.AreEqual(new BigInteger((Int64)(-1)), BigInteger.MinusOne);
            Assert.AreEqual(new BigInteger((Double)(-1)), BigInteger.MinusOne);
            Assert.AreEqual(new BigInteger(new byte[] { 0xff, 0xff, 0xff, 0xff }), BigInteger.MinusOne);
            Assert.AreEqual(BigInteger.Zero - BigInteger.One, BigInteger.MinusOne);
            Assert.AreEqual((BigInteger)671832 / (BigInteger)(-671832), BigInteger.MinusOne);

            // Identities with BigInteger.MinusOne
            for (int i = 0; i < s_samples; i++)
            {
                tempByteArray = GetRandomByteArray(s_random);

                bigInteger = new BigInteger(tempByteArray);

                Assert.AreEqual(
                     BigInteger.Negate(new BigInteger(tempByteArray)),
                     BigInteger.MinusOne * bigInteger
                );

                Assert.AreEqual(
                    BigInteger.Negate(new BigInteger(tempByteArray)),
                    bigInteger / BigInteger.MinusOne
                );
            }
        }

        private static byte[] GetRandomByteArray(Random random)
        {
            return MyBigIntImp.GetRandomByteArray(random, random.Next(0, 1024));
        }
    }
}
