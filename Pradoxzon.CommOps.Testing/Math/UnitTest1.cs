/**
 * IntMathTest.cs
 * 
 * Author: Pradoxzon
 * 
 * Tests for the IntMath class.
 * See Pradoxzon.CommOps.Math.IntMath for the class implementation.
 */

namespace Pradoxzon.CommOps.Testing.Math
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static CommOps.Math.IntMath;


    [TestClass]
    public class IntMathTest
    {
        #region TestRound
        [TestMethod]
        public void TestRoundSbyte()
        {
            // Overflow
            sbyte test1 = 127;
            sbyte inc1 = 10;
            sbyte res1 = -126;
            Assert.IsTrue(res1 == test1.Round(inc1),
                $"The values for test 1 did not match:\n" +
                $"{test1} rounded to {inc1} should equal {res1}, not {test1.Round(inc1)}");

            // Positive - away from 0
            sbyte test2 = 80;
            sbyte inc2 = 12;
            sbyte res2 = 84;
            Assert.IsTrue(res2 == test2.Round(inc2),
                $"The values for test 2 did not match:\n" +
                $"{test2} rounded to {inc2} should equal {res2}, not {test2.Round(inc2)}");

            // Positive - toward 0
            sbyte test3 = 46;
            sbyte inc3 = 11;
            sbyte res3 = 44;
            Assert.IsTrue(res3 == test3.Round(inc3),
                $"The values for test 3 did not match:\n" +
                $"{test3} rounded to {inc3} should equal {res3}, not {test3.Round(inc3)}");

            // Zero
            sbyte test4 = 0;
            sbyte inc4 = 6;
            sbyte res4 = 0;
            Assert.IsTrue(res4 == test4.Round(inc4),
                $"The values for test 4 did not match:\n" +
                $"{test4} rounded to {inc4} should equal {res4}, not {test4.Round(inc4)}");

            // Negative - toward 0
            sbyte test5 = -46;
            sbyte inc5 = 11;
            sbyte res5 = -44;
            Assert.IsTrue(res5 == test5.Round(inc5),
                $"The values for test 5 did not match:\n" +
                $"{test5} rounded to {inc5} should equal {res5}, not {test5.Round(inc5)}");

            // Negative - away from 0
            sbyte test6 = -80;
            sbyte inc6 = -12;
            sbyte res6 = -84;
            Assert.IsTrue(res6 == test6.Round(inc6),
                $"The values for test 6 did not match:\n" +
                $"{test6} rounded to {inc6} should equal {res6}, not {test6.Round(inc6)}");

            // Underflow
            sbyte test7 = -128;
            sbyte inc7 = 10;
            sbyte res7 = 126;
            Assert.IsTrue(res7 == test7.Round(inc7),
                $"The values for test 7 did not match:\n" +
                $"{test7} rounded to {inc7} should equal {res7}, not {test7.Round(inc7)}");
        }


        [TestMethod]
        public void TestRoundByte()
        {
            // Overflow
            byte test1 = 255;
            byte inc1 = 13;
            byte res1 = 4;
            Assert.IsTrue(res1 == test1.Round(inc1),
                $"The values for test 1 did not match:\n" +
                $"{test1} rounded to {inc1} should equal {res1}, not {test1.Round(inc1)}");

            // Away from 0
            byte test2 = 101;
            byte inc2 = 3;
            byte res2 = 102;
            Assert.IsTrue(res2 == test2.Round(inc2),
                $"The values for test 2 did not match:\n" +
                $"{test2} rounded to {inc2} should equal {res2}, not {test2.Round(inc2)}");

            // Towards 0
            byte test3 = 13;
            byte inc3 = 10;
            byte res3 = 10;
            Assert.IsTrue(res3 == test3.Round(inc3),
                $"The values for test 3 did not match:\n" +
                $"{test3} rounded to {inc3} should equal {res3}, not {test3.Round(inc3)}");

            // Zero
            byte test4 = 0;
            byte inc4 = 20;
            byte res4 = 0;
            Assert.IsTrue(res4 == test4.Round(inc4),
                $"The values for test 4 did not match:\n" +
                $"{test4} rounded to {inc4} should equal {res4}, not {test4.Round(inc4)}");
        }


        [TestMethod]
        public void TestRoundShort()
        {
            // Overflow
            short test1 = 32767;
            short inc1 = 10;
            short res1 = -32766;
            Assert.IsTrue(res1 == test1.Round(inc1),
                $"The values for test 1 did not match:\n" +
                $"{test1} rounded to {inc1} should equal {res1}, not {test1.Round(inc1)}");

            // Positive - away from 0
            short test2 = 1234;
            short inc2 = 31;
            short res2 = 1240;
            Assert.IsTrue(res2 == test2.Round(inc2),
                $"The values for test 2 did not match:\n" +
                $"{test2} rounded to {inc2} should equal {res2}, not {test2.Round(inc2)}");

            // Positive - toward 0
            short test3 = 10000;
            short inc3 = 7777;
            short res3 = 7777;
            Assert.IsTrue(res3 == test3.Round(inc3),
                $"The values for test 3 did not match:\n" +
                $"{test3} rounded to {inc3} should equal {res3}, not {test3.Round(inc3)}");

            // Zero
            short test4 = 0;
            short inc4 = 40;
            short res4 = 0;
            Assert.IsTrue(res4 == test4.Round(inc4),
                $"The values for test 4 did not match:\n" +
                $"{test4} rounded to {inc4} should equal {res4}, not {test4.Round(inc4)}");

            // Negative - toward 0
            short test5 = -10000;
            short inc5 = 7777;
            short res5 = -7777;
            Assert.IsTrue(res5 == test5.Round(inc5),
                $"The values for test 5 did not match:\n" +
                $"{test5} rounded to {inc5} should equal {res5}, not {test5.Round(inc5)}");

            // Negative - away from 0
            short test6 = -1234;
            short inc6 = -31;
            short res6 = -1240;
            Assert.IsTrue(res6 == test6.Round(inc6),
                $"The values for test 6 did not match:\n" +
                $"{test6} rounded to {inc6} should equal {res6}, not {test6.Round(inc6)}");

            // Underflow
            short test7 = -32768;
            short inc7 = 15;
            short res7 = 32761;
            Assert.IsTrue(res7 == test7.Round(inc7),
                $"The values for test 7 did not match:\n" +
                $"{test7} rounded to {inc7} should equal {res7}, not {test7.Round(inc7)}");
        }


        [TestMethod]
        public void TestRoundUshort()
        {
            // Overflow
            ushort test1 = 65535;
            ushort inc1 = 98;
            ushort res1 = 26;
            Assert.IsTrue(res1 == test1.Round(inc1),
                $"The values for test 1 did not match:\n" +
                $"{test1} rounded to {inc1} should equal {res1}, not {test1.Round(inc1)}");

            // Away from 0
            ushort test2 = 6666;
            ushort inc2 = 777;
            ushort res2 = 6993;
            Assert.IsTrue(res2 == test2.Round(inc2),
                $"The values for test 2 did not match:\n" +
                $"{test2} rounded to {inc2} should equal {res2}, not {test2.Round(inc2)}");

            // Towards 0
            ushort test3 = 2468;
            ushort inc3 = 20;
            ushort res3 = 2460;
            Assert.IsTrue(res3 == test3.Round(inc3),
                $"The values for test 3 did not match:\n" +
                $"{test3} rounded to {inc3} should equal {res3}, not {test3.Round(inc3)}");

            // Zero
            ushort test4 = 0;
            ushort inc4 = 7;
            ushort res4 = 0;
            Assert.IsTrue(res4 == test4.Round(inc4),
                $"The values for test 4 did not match:\n" +
                $"{test4} rounded to {inc4} should equal {res4}, not {test4.Round(inc4)}");
        }


        [TestMethod]
        public void TestRoundInt()
        {
            // Overflow
            int test1 = int.MaxValue;
            int inc1 = 10;
            int res1 = int.MinValue + 2;
            Assert.IsTrue(res1 == test1.Round(inc1),
                $"The values for test 1 did not match:\n" +
                $"{test1} rounded to {inc1} should equal {res1}, not {test1.Round(inc1)}");

            // Positive - away from 0
            int test2 = 200400600;
            int inc2 = 1130;
            int res2 = 200400980;
            Assert.IsTrue(res2 == test2.Round(inc2),
                $"The values for test 2 did not match:\n" +
                $"{test2} rounded to {inc2} should equal {res2}, not {test2.Round(inc2)}");

            // Positive - toward 0
            int test3 = 868644;
            int inc3 = 311;
            int res3 = 868623;
            Assert.IsTrue(res3 == test3.Round(inc3),
                $"The values for test 3 did not match:\n" +
                $"{test3} rounded to {inc3} should equal {res3}, not {test3.Round(inc3)}");

            // Zero
            int test4 = 0;
            int inc4 = 1212;
            int res4 = 0;
            Assert.IsTrue(res4 == test4.Round(inc4),
                $"The values for test 4 did not match:\n" +
                $"{test4} rounded to {inc4} should equal {res4}, not {test4.Round(inc4)}");

            // Negative - toward 0
            int test5 = -868644;
            int inc5 = 311;
            int res5 = -868623;
            Assert.IsTrue(res5 == test5.Round(inc5),
                $"The values for test 5 did not match:\n" +
                $"{test5} rounded to {inc5} should equal {res5}, not {test5.Round(inc5)}");

            // Negative - away from 0
            int test6 = -200400600;
            int inc6 = -1130;
            int res6 = -200400980;
            Assert.IsTrue(res6 == test6.Round(inc6),
                $"The values for test 6 did not match:\n" +
                $"{test6} rounded to {inc6} should equal {res6}, not {test6.Round(inc6)}");

            // Underflow
            int test7 = int.MinValue;
            int inc7 = 15;
            int res7 = int.MaxValue - 6;
            Assert.IsTrue(res7 == test7.Round(inc7),
                $"The values for test 7 did not match:\n" +
                $"{test7} rounded to {inc7} should equal {res7}, not {test7.Round(inc7)}");
        }


        [TestMethod]
        public void TestRoundUint()
        {
            // Overflow
            uint test1 = uint.MaxValue;
            uint inc1 = 10;
            uint res1 = 4;
            Assert.IsTrue(res1 == test1.Round(inc1),
                $"The values for test 1 did not match:\n" +
                $"{test1} rounded to {inc1} should equal {res1}, not {test1.Round(inc1)}");

            // Positive - away from 0
            uint test2 = 200400600;
            uint inc2 = 1130;
            uint res2 = 200400980;
            Assert.IsTrue(res2 == test2.Round(inc2),
                $"The values for test 2 did not match:\n" +
                $"{test2} rounded to {inc2} should equal {res2}, not {test2.Round(inc2)}");

            // Positive - toward 0
            uint test3 = 868644;
            uint inc3 = 311;
            uint res3 = 868623;
            Assert.IsTrue(res3 == test3.Round(inc3),
                $"The values for test 3 did not match:\n" +
                $"{test3} rounded to {inc3} should equal {res3}, not {test3.Round(inc3)}");

            // Zero
            uint test4 = 0;
            uint inc4 = 1212;
            uint res4 = 0;
            Assert.IsTrue(res4 == test4.Round(inc4),
                $"The values for test 4 did not match:\n" +
                $"{test4} rounded to {inc4} should equal {res4}, not {test4.Round(inc4)}");
        }


        [TestMethod]
        public void TestRoundLong()
        {
            // Overflow
            long test1 = long.MaxValue;
            long inc1 = 10;
            long res1 = long.MinValue + 2;
            Assert.IsTrue(res1 == test1.Round(inc1),
                $"The values for test 1 did not match:\n" +
                $"{test1} rounded to {inc1} should equal {res1}, not {test1.Round(inc1)}");

            // Positive - away from 0
            long test2 = 200400600;
            long inc2 = 1130;
            long res2 = 200400980;
            Assert.IsTrue(res2 == test2.Round(inc2),
                $"The values for test 2 did not match:\n" +
                $"{test2} rounded to {inc2} should equal {res2}, not {test2.Round(inc2)}");

            // Positive - toward 0
            long test3 = 868644;
            long inc3 = 311;
            long res3 = 868623;
            Assert.IsTrue(res3 == test3.Round(inc3),
                $"The values for test 3 did not match:\n" +
                $"{test3} rounded to {inc3} should equal {res3}, not {test3.Round(inc3)}");

            // Zero
            long test4 = 0;
            long inc4 = 1212;
            long res4 = 0;
            Assert.IsTrue(res4 == test4.Round(inc4),
                $"The values for test 4 did not match:\n" +
                $"{test4} rounded to {inc4} should equal {res4}, not {test4.Round(inc4)}");

            // Negative - toward 0
            long test5 = -868644;
            long inc5 = 311;
            long res5 = -868623;
            Assert.IsTrue(res5 == test5.Round(inc5),
                $"The values for test 5 did not match:\n" +
                $"{test5} rounded to {inc5} should equal {res5}, not {test5.Round(inc5)}");

            // Negative - away from 0
            long test6 = -200400600;
            long inc6 = -1130;
            long res6 = -200400980;
            Assert.IsTrue(res6 == test6.Round(inc6),
                $"The values for test 6 did not match:\n" +
                $"{test6} rounded to {inc6} should equal {res6}, not {test6.Round(inc6)}");

            // Underflow
            long test7 = long.MinValue;
            long inc7 = 15;
            long res7 = long.MaxValue - 6;
            Assert.IsTrue(res7 == test7.Round(inc7),
                $"The values for test 7 did not match:\n" +
                $"{test7} rounded to {inc7} should equal {res7}, not {test7.Round(inc7)}");
        }


        [TestMethod]
        public void TestRoundUlong()
        {
            // Overflow
            ulong test1 = ulong.MaxValue;
            ulong inc1 = 10;
            ulong res1 = ulong.MinValue + 4;
            Assert.IsTrue(res1 == test1.Round(inc1),
                $"The values for test 1 did not match:\n" +
                $"{test1} rounded to {inc1} should equal {res1}, not {test1.Round(inc1)}");

            // Positive - away from 0
            ulong test2 = 200400600;
            ulong inc2 = 1130;
            ulong res2 = 200400980;
            Assert.IsTrue(res2 == test2.Round(inc2),
                $"The values for test 2 did not match:\n" +
                $"{test2} rounded to {inc2} should equal {res2}, not {test2.Round(inc2)}");

            // Positive - toward 0
            ulong test3 = 868644;
            ulong inc3 = 311;
            ulong res3 = 868623;
            Assert.IsTrue(res3 == test3.Round(inc3),
                $"The values for test 3 did not match:\n" +
                $"{test3} rounded to {inc3} should equal {res3}, not {test3.Round(inc3)}");

            // Zero
            ulong test4 = 0;
            ulong inc4 = 1212;
            ulong res4 = 0;
            Assert.IsTrue(res4 == test4.Round(inc4),
                $"The values for test 4 did not match:\n" +
                $"{test4} rounded to {inc4} should equal {res4}, not {test4.Round(inc4)}");
        }
        #endregion


        #region TestCeiling
        [TestMethod]
        public void TestCeilingSbyte()
        {
            // Overflow
            sbyte test1 = sbyte.MaxValue;
            sbyte val1 = 32;
            sbyte res1 = sbyte.MinValue;
            Assert.IsTrue(res1 == test1.Ceiling(val1),
                $"The values for test1 did not match:\n" +
                $"{test1}.Ceiling({val1}) should equal {res1}, not {test1.Ceiling(val1)}");

            // Positive - round up
            sbyte test2 = 33;
            sbyte val2 = 12;
            sbyte res2 = 36;
            Assert.IsTrue(res2 == test2.Ceiling(val2),
                $"The values for test 2 did not match:\n" +
                $"{test2}.Ceiling({val2}) should equal {res2}, not {test2.Ceiling(val2)}");

            // Positive - no change
            sbyte test3 = 15;
            sbyte val3 = 15;
            sbyte res3 = 15;
            Assert.IsTrue(res3 == test3.Ceiling(val3),
                $"The values for test 3 did not match:\n" +
                $"{test3}.Ceiling({val3}) should equal {res3}, not {test3.Ceiling(val3)}");

            // Zero
            sbyte test4 = 0;
            sbyte val4 = 2;
            sbyte res4 = 0;
            Assert.IsTrue(res4 == test4.Ceiling(val4),
                $"The values for test 4 did not match:\n" +
                $"{test4}.Ceiling({val4}) should equal {res4}, not {test4.Ceiling(val4)}");

            // Negative - round up
            sbyte test5 = -101;
            sbyte val5 = -60;
            sbyte res5 = -60;
            Assert.IsTrue(res5 == test5.Ceiling(val5),
                $"The values for test 5 did not match:\n" +
                $"{test5}.Ceiling({val5}) should equal {res5}, not {test5.Ceiling(val5)}");

            // Negative - no change
            sbyte test6 = -21;
            sbyte val6 = 21;
            sbyte res6 = -21;
            Assert.IsTrue(res6 == test6.Ceiling(val6),
                $"The values for test 6 did not match:\n" +
                $"{test6}.Ceiling({val6}) should equal {res6}, not {test6.Ceiling(val6)}");
        }


        [TestMethod]
        public void TestCeilingByte()
        {
            // Overflow
            byte test1 = byte.MaxValue;
            byte val1 = 32;
            byte res1 = byte.MinValue;
            Assert.IsTrue(res1 == test1.Ceiling(val1),
                $"The values for test1 did not match:\n" +
                $"{test1}.Ceiling({val1}) should equal {res1}, not {test1.Ceiling(val1)}");

            // Positive - round up
            byte test2 = 33;
            byte val2 = 12;
            byte res2 = 36;
            Assert.IsTrue(res2 == test2.Ceiling(val2),
                $"The values for test 2 did not match:\n" +
                $"{test2}.Ceiling({val2}) should equal {res2}, not {test2.Ceiling(val2)}");

            // Positive - no change
            byte test3 = 15;
            byte val3 = 15;
            byte res3 = 15;
            Assert.IsTrue(res3 == test3.Ceiling(val3),
                $"The values for test 3 did not match:\n" +
                $"{test3}.Ceiling({val3}) should equal {res3}, not {test3.Ceiling(val3)}");


            // Zero
            byte test4 = 0;
            byte val4 = 2;
            byte res4 = 0;
            Assert.IsTrue(res4 == test4.Ceiling(val4),
                $"The values for test 3 did not match:\n" +
                $"{test4}.Ceiling({val4}) should equal {res4}, not {test4.Ceiling(val4)}");
        }


        [TestMethod]
        public void TestCeilingShort()
        {
            // Overflow
            short test1 = short.MaxValue;
            short val1 = 32;
            short res1 = short.MinValue;
            Assert.IsTrue(res1 == test1.Ceiling(val1),
                $"The values for test1 did not match:\n" +
                $"{test1}.Ceiling({val1}) should equal {res1}, not {test1.Ceiling(val1)}");

            // Positive - round up
            short test2 = 33;
            short val2 = 12;
            short res2 = 36;
            Assert.IsTrue(res2 == test2.Ceiling(val2),
                $"The values for test 2 did not match:\n" +
                $"{test2}.Ceiling({val2}) should equal {res2}, not {test2.Ceiling(val2)}");

            // Positive - no change
            short test3 = 15;
            short val3 = 15;
            short res3 = 15;
            Assert.IsTrue(res3 == test3.Ceiling(val3),
                $"The values for test 3 did not match:\n" +
                $"{test3}.Ceiling({val3}) should equal {res3}, not {test3.Ceiling(val3)}");

            // Zero
            short test4 = 0;
            short val4 = 2;
            short res4 = 0;
            Assert.IsTrue(res4 == test4.Ceiling(val4),
                $"The values for test 4 did not match:\n" +
                $"{test4}.Ceiling({val4}) should equal {res4}, not {test4.Ceiling(val4)}");

            // Negative - round up
            short test5 = -101;
            short val5 = -60;
            short res5 = -60;
            Assert.IsTrue(res5 == test5.Ceiling(val5),
                $"The values for test 5 did not match:\n" +
                $"{test5}.Ceiling({val5}) should equal {res5}, not {test5.Ceiling(val5)}");

            // Negative - no change
            short test6 = -21;
            short val6 = 21;
            short res6 = -21;
            Assert.IsTrue(res6 == test6.Ceiling(val6),
                $"The values for test 6 did not match:\n" +
                $"{test6}.Ceiling({val6}) should equal {res6}, not {test6.Ceiling(val6)}");
        }


        [TestMethod]
        public void TestCeilingUshort()
        {
            // Overflow
            ushort test1 = ushort.MaxValue;
            ushort val1 = 32;
            ushort res1 = ushort.MinValue;
            Assert.IsTrue(res1 == test1.Ceiling(val1),
                $"The values for test1 did not match:\n" +
                $"{test1}.Ceiling({val1}) should equal {res1}, not {test1.Ceiling(val1)}");

            // Positive - round up
            ushort test2 = 33;
            ushort val2 = 12;
            ushort res2 = 36;
            Assert.IsTrue(res2 == test2.Ceiling(val2),
                $"The values for test 2 did not match:\n" +
                $"{test2}.Ceiling({val2}) should equal {res2}, not {test2.Ceiling(val2)}");

            // Positive - no change
            ushort test3 = 15;
            ushort val3 = 15;
            ushort res3 = 15;
            Assert.IsTrue(res3 == test3.Ceiling(val3),
                $"The values for test 3 did not match:\n" +
                $"{test3}.Ceiling({val3}) should equal {res3}, not {test3.Ceiling(val3)}");


            // Zero
            ushort test4 = 0;
            ushort val4 = 2;
            ushort res4 = 0;
            Assert.IsTrue(res4 == test4.Ceiling(val4),
                $"The values for test 3 did not match:\n" +
                $"{test4}.Ceiling({val4}) should equal {res4}, not {test4.Ceiling(val4)}");
        }


        [TestMethod]
        public void TestCeilingInt()
        {
            // Overflow
            int test1 = int.MaxValue;
            int val1 = 32;
            int res1 = int.MinValue;
            Assert.IsTrue(res1 == test1.Ceiling(val1),
                $"The values for test1 did not match:\n" +
                $"{test1}.Ceiling({val1}) should equal {res1}, not {test1.Ceiling(val1)}");

            // Positive - round up
            int test2 = 33;
            int val2 = 12;
            int res2 = 36;
            Assert.IsTrue(res2 == test2.Ceiling(val2),
                $"The values for test 2 did not match:\n" +
                $"{test2}.Ceiling({val2}) should equal {res2}, not {test2.Ceiling(val2)}");

            // Positive - no change
            int test3 = 15;
            int val3 = 15;
            int res3 = 15;
            Assert.IsTrue(res3 == test3.Ceiling(val3),
                $"The values for test 3 did not match:\n" +
                $"{test3}.Ceiling({val3}) should equal {res3}, not {test3.Ceiling(val3)}");

            // Zero
            int test4 = 0;
            int val4 = 2;
            int res4 = 0;
            Assert.IsTrue(res4 == test4.Ceiling(val4),
                $"The values for test 4 did not match:\n" +
                $"{test4}.Ceiling({val4}) should equal {res4}, not {test4.Ceiling(val4)}");

            // Negative - round up
            int test5 = -101;
            int val5 = -60;
            int res5 = -60;
            Assert.IsTrue(res5 == test5.Ceiling(val5),
                $"The values for test 5 did not match:\n" +
                $"{test5}.Ceiling({val5}) should equal {res5}, not {test5.Ceiling(val5)}");

            // Negative - no change
            int test6 = -21;
            int val6 = 21;
            int res6 = -21;
            Assert.IsTrue(res6 == test6.Ceiling(val6),
                $"The values for test 6 did not match:\n" +
                $"{test6}.Ceiling({val6}) should equal {res6}, not {test6.Ceiling(val6)}");
        }


        [TestMethod]
        public void TestCeilingUint()
        {
            // Overflow
            uint test1 = uint.MaxValue;
            uint val1 = 32;
            uint res1 = uint.MinValue;
            Assert.IsTrue(res1 == test1.Ceiling(val1),
                $"The values for test1 did not match:\n" +
                $"{test1}.Ceiling({val1}) should equal {res1}, not {test1.Ceiling(val1)}");

            // Positive - round up
            uint test2 = 33;
            uint val2 = 12;
            uint res2 = 36;
            Assert.IsTrue(res2 == test2.Ceiling(val2),
                $"The values for test 2 did not match:\n" +
                $"{test2}.Ceiling({val2}) should equal {res2}, not {test2.Ceiling(val2)}");

            // Positive - no change
            uint test3 = 15;
            uint val3 = 15;
            uint res3 = 15;
            Assert.IsTrue(res3 == test3.Ceiling(val3),
                $"The values for test 3 did not match:\n" +
                $"{test3}.Ceiling({val3}) should equal {res3}, not {test3.Ceiling(val3)}");


            // Zero
            uint test4 = 0;
            uint val4 = 2;
            uint res4 = 0;
            Assert.IsTrue(res4 == test4.Ceiling(val4),
                $"The values for test 3 did not match:\n" +
                $"{test4}.Ceiling({val4}) should equal {res4}, not {test4.Ceiling(val4)}");
        }


        [TestMethod]
        public void TestCeilingLong()
        {
            // Overflow
            long test1 = long.MaxValue;
            long val1 = 32;
            long res1 = long.MinValue;
            Assert.IsTrue(res1 == test1.Ceiling(val1),
                $"The values for test1 did not match:\n" +
                $"{test1}.Ceiling({val1}) should equal {res1}, not {test1.Ceiling(val1)}");

            // Positive - round up
            long test2 = 33;
            long val2 = 12;
            long res2 = 36;
            Assert.IsTrue(res2 == test2.Ceiling(val2),
                $"The values for test 2 did not match:\n" +
                $"{test2}.Ceiling({val2}) should equal {res2}, not {test2.Ceiling(val2)}");

            // Positive - no change
            long test3 = 15;
            long val3 = 15;
            long res3 = 15;
            Assert.IsTrue(res3 == test3.Ceiling(val3),
                $"The values for test 3 did not match:\n" +
                $"{test3}.Ceiling({val3}) should equal {res3}, not {test3.Ceiling(val3)}");

            // Zero
            long test4 = 0;
            long val4 = 2;
            long res4 = 0;
            Assert.IsTrue(res4 == test4.Ceiling(val4),
                $"The values for test 4 did not match:\n" +
                $"{test4}.Ceiling({val4}) should equal {res4}, not {test4.Ceiling(val4)}");

            // Negative - round up
            long test5 = -101;
            long val5 = -60;
            long res5 = -60;
            Assert.IsTrue(res5 == test5.Ceiling(val5),
                $"The values for test 5 did not match:\n" +
                $"{test5}.Ceiling({val5}) should equal {res5}, not {test5.Ceiling(val5)}");

            // Negative - no change
            long test6 = -21;
            long val6 = 21;
            long res6 = -21;
            Assert.IsTrue(res6 == test6.Ceiling(val6),
                $"The values for test 6 did not match:\n" +
                $"{test6}.Ceiling({val6}) should equal {res6}, not {test6.Ceiling(val6)}");
        }


        [TestMethod]
        public void TestCeilingUlong()
        {
            // Overflow
            ulong test1 = ulong.MaxValue;
            ulong val1 = 32;
            ulong res1 = ulong.MinValue;
            Assert.IsTrue(res1 == test1.Ceiling(val1),
                $"The values for test1 did not match:\n" +
                $"{test1}.Ceiling({val1}) should equal {res1}, not {test1.Ceiling(val1)}");

            // Positive - round up
            ulong test2 = 33;
            ulong val2 = 12;
            ulong res2 = 36;
            Assert.IsTrue(res2 == test2.Ceiling(val2),
                $"The values for test 2 did not match:\n" +
                $"{test2}.Ceiling({val2}) should equal {res2}, not {test2.Ceiling(val2)}");

            // Positive - no change
            ulong test3 = 15;
            ulong val3 = 15;
            ulong res3 = 15;
            Assert.IsTrue(res3 == test3.Ceiling(val3),
                $"The values for test 3 did not match:\n" +
                $"{test3}.Ceiling({val3}) should equal {res3}, not {test3.Ceiling(val3)}");


            // Zero
            ulong test4 = 0;
            ulong val4 = 2;
            ulong res4 = 0;
            Assert.IsTrue(res4 == test4.Ceiling(val4),
                $"The values for test 3 did not match:\n" +
                $"{test4}.Ceiling({val4}) should equal {res4}, not {test4.Ceiling(val4)}");
        }
        #endregion


        #region TestFloor
        [TestMethod]
        public void TestFloorSbyte()
        {
            // Positive - no change
            sbyte test1 = 36;
            sbyte val1 = 12;
            sbyte res1 = 36;
            Assert.IsTrue(res1 == test1.Floor(val1),
                $"The values for test 1 did not match:\n" +
                $"{test1}.Floor({val1}) should equal {res1}, not {test1.Floor(val1)}");

            // Positive - round down
            sbyte test2 = 20;
            sbyte val2 = 15;
            sbyte res2 = 15;
            Assert.IsTrue(res2 == test2.Floor(val2),
                $"The values for test 2 did not match:\n" +
                $"{test2}.Floor({val2}) should equal {res2}, not {test2.Floor(val2)}");

            // Zero
            sbyte test3 = 0;
            sbyte val3 = 2;
            sbyte res3 = 0;
            Assert.IsTrue(res3 == test3.Floor(val3),
                $"The values for test 3 did not match:\n" +
                $"{test3}.Floor({val3}) should equal {res3}, not {test3.Floor(val3)}");

            // Negative - no change
            sbyte test4 = -60;
            sbyte val4 = -60;
            sbyte res4 = -60;
            Assert.IsTrue(res4 == test4.Floor(val4),
                $"The values for test 4 did not match:\n" +
                $"{test4}.Floor({val4}) should equal {res4}, not {test4.Floor(val4)}");

            // Negative - round down
            sbyte test5 = -2;
            sbyte val5 = 21;
            sbyte res5 = -21;
            Assert.IsTrue(res5 == test5.Floor(val5),
                $"The values for test 5 did not match:\n" +
                $"{test5}.Floor({val5}) should equal {res5}, not {test5.Floor(val5)}");

            // Underflow
            sbyte test6 = sbyte.MinValue;
            sbyte val6 = 3;
            sbyte res6 = sbyte.MaxValue;
            Assert.IsTrue(res6 == test6.Floor(val6),
                $"The values for test 6 did not match:\n" +
                $"{test6}.Floor({val6}) should equal {res6}, not {test6.Floor(val6)}");
        }


        [TestMethod]
        public void TestFloorByte()
        {
            // Positive - no change
            byte test1 = 36;
            byte val1 = 12;
            byte res1 = 36;
            Assert.IsTrue(res1 == test1.Floor(val1),
                $"The values for test 1 did not match:\n" +
                $"{test1}.Floor({val1}) should equal {res1}, not {test1.Floor(val1)}");

            // Positive - round down
            byte test2 = 20;
            byte val2 = 15;
            byte res2 = 15;
            Assert.IsTrue(res2 == test2.Floor(val2),
                $"The values for test 2 did not match:\n" +
                $"{test2}.Floor({val2}) should equal {res2}, not {test2.Floor(val2)}");

            // Zero
            byte test3 = 0;
            byte val3 = 2;
            byte res3 = 0;
            Assert.IsTrue(res3 == test3.Floor(val3),
                $"The values for test 3 did not match:\n" +
                $"{test3}.Floor({val3}) should equal {res3}, not {test3.Floor(val3)}");
        }


        [TestMethod]
        public void TestFloorShort()
        {
            // Positive - no change
            short test1 = 36;
            short val1 = 12;
            short res1 = 36;
            Assert.IsTrue(res1 == test1.Floor(val1),
                $"The values for test 1 did not match:\n" +
                $"{test1}.Floor({val1}) should equal {res1}, not {test1.Floor(val1)}");

            // Positive - round down
            short test2 = 20;
            short val2 = 15;
            short res2 = 15;
            Assert.IsTrue(res2 == test2.Floor(val2),
                $"The values for test 2 did not match:\n" +
                $"{test2}.Floor({val2}) should equal {res2}, not {test2.Floor(val2)}");

            // Zero
            short test3 = 0;
            short val3 = 2;
            short res3 = 0;
            Assert.IsTrue(res3 == test3.Floor(val3),
                $"The values for test 3 did not match:\n" +
                $"{test3}.Floor({val3}) should equal {res3}, not {test3.Floor(val3)}");

            // Negative - no change
            short test4 = -60;
            short val4 = -60;
            short res4 = -60;
            Assert.IsTrue(res4 == test4.Floor(val4),
                $"The values for test 4 did not match:\n" +
                $"{test4}.Floor({val4}) should equal {res4}, not {test4.Floor(val4)}");

            // Negative - round down
            short test5 = -2;
            short val5 = 21;
            short res5 = -21;
            Assert.IsTrue(res5 == test5.Floor(val5),
                $"The values for test 5 did not match:\n" +
                $"{test5}.Floor({val5}) should equal {res5}, not {test5.Floor(val5)}");

            // Underflow
            short test6 = short.MinValue;
            short val6 = 3;
            short res6 = short.MaxValue;
            Assert.IsTrue(res6 == test6.Floor(val6),
                $"The values for test 6 did not match:\n" +
                $"{test6}.Floor({val6}) should equal {res6}, not {test6.Floor(val6)}");
        }


        [TestMethod]
        public void TestFloorUshort()
        {
            // Positive - no change
            ushort test1 = 36;
            ushort val1 = 12;
            ushort res1 = 36;
            Assert.IsTrue(res1 == test1.Floor(val1),
                $"The values for test 1 did not match:\n" +
                $"{test1}.Floor({val1}) should equal {res1}, not {test1.Floor(val1)}");

            // Positive - round down
            ushort test2 = 20;
            ushort val2 = 15;
            ushort res2 = 15;
            Assert.IsTrue(res2 == test2.Floor(val2),
                $"The values for test 2 did not match:\n" +
                $"{test2}.Floor({val2}) should equal {res2}, not {test2.Floor(val2)}");

            // Zero
            ushort test3 = 0;
            ushort val3 = 2;
            ushort res3 = 0;
            Assert.IsTrue(res3 == test3.Floor(val3),
                $"The values for test 3 did not match:\n" +
                $"{test3}.Floor({val3}) should equal {res3}, not {test3.Floor(val3)}");
        }


        [TestMethod]
        public void TestFloorInt()
        {
            // Positive - no change
            int test1 = 36;
            int val1 = 12;
            int res1 = 36;
            Assert.IsTrue(res1 == test1.Floor(val1),
                $"The values for test 1 did not match:\n" +
                $"{test1}.Floor({val1}) should equal {res1}, not {test1.Floor(val1)}");

            // Positive - round down
            int test2 = 20;
            int val2 = 15;
            int res2 = 15;
            Assert.IsTrue(res2 == test2.Floor(val2),
                $"The values for test 2 did not match:\n" +
                $"{test2}.Floor({val2}) should equal {res2}, not {test2.Floor(val2)}");

            // Zero
            int test3 = 0;
            int val3 = 2;
            int res3 = 0;
            Assert.IsTrue(res3 == test3.Floor(val3),
                $"The values for test 3 did not match:\n" +
                $"{test3}.Floor({val3}) should equal {res3}, not {test3.Floor(val3)}");

            // Negative - no change
            int test4 = -60;
            int val4 = -60;
            int res4 = -60;
            Assert.IsTrue(res4 == test4.Floor(val4),
                $"The values for test 4 did not match:\n" +
                $"{test4}.Floor({val4}) should equal {res4}, not {test4.Floor(val4)}");

            // Negative - round down
            int test5 = -2;
            int val5 = 21;
            int res5 = -21;
            Assert.IsTrue(res5 == test5.Floor(val5),
                $"The values for test 5 did not match:\n" +
                $"{test5}.Floor({val5}) should equal {res5}, not {test5.Floor(val5)}");

            // Underflow
            int test6 = int.MinValue;
            int val6 = 3;
            int res6 = int.MaxValue;
            Assert.IsTrue(res6 == test6.Floor(val6),
                $"The values for test 6 did not match:\n" +
                $"{test6}.Floor({val6}) should equal {res6}, not {test6.Floor(val6)}");
        }


        [TestMethod]
        public void TestFloorUint()
        {
            // Positive - no change
            uint test1 = 36;
            uint val1 = 12;
            uint res1 = 36;
            Assert.IsTrue(res1 == test1.Floor(val1),
                $"The values for test 1 did not match:\n" +
                $"{test1}.Floor({val1}) should equal {res1}, not {test1.Floor(val1)}");

            // Positive - round down
            uint test2 = 20;
            uint val2 = 15;
            uint res2 = 15;
            Assert.IsTrue(res2 == test2.Floor(val2),
                $"The values for test 2 did not match:\n" +
                $"{test2}.Floor({val2}) should equal {res2}, not {test2.Floor(val2)}");

            // Zero
            uint test3 = 0;
            uint val3 = 2;
            uint res3 = 0;
            Assert.IsTrue(res3 == test3.Floor(val3),
                $"The values for test 3 did not match:\n" +
                $"{test3}.Floor({val3}) should equal {res3}, not {test3.Floor(val3)}");
        }


        [TestMethod]
        public void TestFloorLong()
        {
            // Positive - no change
            long test1 = 36;
            long val1 = 12;
            long res1 = 36;
            Assert.IsTrue(res1 == test1.Floor(val1),
                $"The values for test 1 did not match:\n" +
                $"{test1}.Floor({val1}) should equal {res1}, not {test1.Floor(val1)}");

            // Positive - round down
            long test2 = 20;
            long val2 = 15;
            long res2 = 15;
            Assert.IsTrue(res2 == test2.Floor(val2),
                $"The values for test 2 did not match:\n" +
                $"{test2}.Floor({val2}) should equal {res2}, not {test2.Floor(val2)}");

            // Zero
            long test3 = 0;
            long val3 = 2;
            long res3 = 0;
            Assert.IsTrue(res3 == test3.Floor(val3),
                $"The values for test 3 did not match:\n" +
                $"{test3}.Floor({val3}) should equal {res3}, not {test3.Floor(val3)}");

            // Negative - no change
            long test4 = -60;
            long val4 = -60;
            long res4 = -60;
            Assert.IsTrue(res4 == test4.Floor(val4),
                $"The values for test 4 did not match:\n" +
                $"{test4}.Floor({val4}) should equal {res4}, not {test4.Floor(val4)}");

            // Negative - round down
            long test5 = -2;
            long val5 = 21;
            long res5 = -21;
            Assert.IsTrue(res5 == test5.Floor(val5),
                $"The values for test 5 did not match:\n" +
                $"{test5}.Floor({val5}) should equal {res5}, not {test5.Floor(val5)}");

            // Underflow
            long test6 = long.MinValue;
            long val6 = 3;
            long res6 = long.MaxValue;
            Assert.IsTrue(res6 == test6.Floor(val6),
                $"The values for test 6 did not match:\n" +
                $"{test6}.Floor({val6}) should equal {res6}, not {test6.Floor(val6)}");
        }


        [TestMethod]
        public void TestFloorUlong()
        {
            // Positive - no change
            ulong test1 = 36;
            ulong val1 = 12;
            ulong res1 = 36;
            Assert.IsTrue(res1 == test1.Floor(val1),
                $"The values for test 1 did not match:\n" +
                $"{test1}.Floor({val1}) should equal {res1}, not {test1.Floor(val1)}");

            // Positive - round down
            ulong test2 = 20;
            ulong val2 = 15;
            ulong res2 = 15;
            Assert.IsTrue(res2 == test2.Floor(val2),
                $"The values for test 2 did not match:\n" +
                $"{test2}.Floor({val2}) should equal {res2}, not {test2.Floor(val2)}");

            // Zero
            ulong test3 = 0;
            ulong val3 = 2;
            ulong res3 = 0;
            Assert.IsTrue(res3 == test3.Floor(val3),
                $"The values for test 3 did not match:\n" +
                $"{test3}.Floor({val3}) should equal {res3}, not {test3.Floor(val3)}");
        }
        #endregion
    }
}
