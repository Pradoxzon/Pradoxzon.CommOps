/**
 * ToBytesTest.cs
 * 
 * Copyright (c) 2019 Pradoxzon Dev
 * 
 * Author: Shawn Peerenboom (Pradoxzon)
 * 
 * Tests for the ToBytes class.
 * See Pradoxzon.CommOps.Arrays.ToBytes for the class implementation.
 */

namespace Pradoxzon.CommOps.Testing.Arrays
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static CommOps.Arrays.ToBytes;
    using static ArraySubsetTest;


    [TestClass]
    public class ToBytesTest
    {
        #region Strings
        [TestMethod]
        public void TestGetBytesString()
        {
            // Empty string
            string test = "";
            byte[] res = { };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // Little Endian
            test = "Hello World!";
            res = new byte[] {
                0x48, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x6C, 0x00, 0x6F, 0x00,
                0x20, 0x00,
                0x57, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x6C, 0x00, 0x64, 0x00,
                0x21, 0x00 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes(true)),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes(true)}");

            // Big Endian
            res = new byte[] {
                0x00, 0x48, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x6C, 0x00, 0x6F,
                0x00, 0x20,
                0x00, 0x57, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x6C, 0x00, 0x64,
                0x00, 0x21, };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");
        }


        [TestMethod]
        public void TestGetBytesListString()
        {
            // Empty list
            var test = new List<string>();
            byte[] res = { 0x00, 0x00, 0x00, 0x00 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // Little Endian
            test = new List<string>() { "Hello", "World" };
            res = new byte[] {
                0x02, 0x00, 0x00, 0x00,
                0x05, 0x00, 0x00, 0x00,
                0x48, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x6C, 0x00, 0x6F, 0x00,
                0x05, 0x00, 0x00, 0x00,
                0x57, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x6C, 0x00, 0x64, 0x00, };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes(true)),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes(true)}");

            // Big Endian
            res = new byte[] {
                0x00, 0x00, 0x00, 0x02,
                0x00, 0x00, 0x00, 0x05,
                0x00, 0x48, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x6C, 0x00, 0x6F,
                0x00, 0x00, 0x00, 0x05,
                0x00, 0x57, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x6C, 0x00, 0x64, };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");
        }
        #endregion


        #region Integers
        [TestMethod]
        public void TestGetBytesSbyte()
        {
            // Max value - Little endian
            var test = sbyte.MaxValue;
            byte[] res = { 0x7f };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // Normal value - Big endian
            test = -86;
            res = new byte[] { 0xAA };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // Min Value - Big endian
            test = sbyte.MinValue;
            res = new byte[] { 0x80 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");
        }


        [TestMethod]
        public void TestGetBytesShort()
        {
            // Max value - Big endian
            short test = short.MaxValue;
            byte[] res = { 0x7F, 0xFF };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // Normal value - Little endian
            test = -21829;
            res = new byte[] { 0xBB, 0xAA };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes(true)),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes(true)}");

            // Min Value - Big endian
            test = short.MinValue;
            res = new byte[] { 0x80, 0x00 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");
        }


        [TestMethod]
        public void TestGetBytesUshort()
        {
            // Max value - Big endian
            ushort test = ushort.MaxValue;
            byte[] res = { 0xFF, 0xFF };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // Normal value - Little endian
            test = 0xBBAA;
            res = new byte[] { 0xAA, 0xBB };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes(true)),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes(true)}");

            // Min Value - Big endian
            test = ushort.MinValue;
            res = new byte[] { 0x00, 0x00 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");
        }


        [TestMethod]
        public void TestGetBytesInt()
        {
            // Max value - Big endian
            int test = int.MaxValue;
            byte[] res = { 0x7F, 0xFF, 0xFF, 0xFF };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // Normal value - Little endian
            test = -1430532899;
            res = new byte[] { 0xDD, 0xCC, 0xBB, 0xAA };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes(true)),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes(true)}");

            // Min Value - Big endian
            test = int.MinValue;
            res = new byte[] { 0x80, 0x00, 0x00, 0x00 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");
        }


        [TestMethod]
        public void TestGetBytesUint()
        {
            // Max value - Big endian
            uint test = uint.MaxValue;
            byte[] res = { 0xFF, 0xFF, 0xFF, 0xFF };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // Normal value - Little endian
            test = 0xDDCCBBAA;
            res = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes(true)),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes(true)}");

            // Min Value - Big endian
            test = uint.MinValue;
            res = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");
        }


        [TestMethod]
        public void TestGetBytesLong()
        {
            // Max value - Big endian
            long test = long.MaxValue;
            byte[] res = { 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // Normal value - Little endian
            test = 0x11223344AABBCCDD;
            res = new byte[] { 0xDD, 0xCC, 0xBB, 0xAA, 0x44, 0x33, 0x22, 0x11 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes(true)),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes(true)}");

            // Min Value - Big endian
            test = long.MinValue;
            res = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");
        }


        [TestMethod]
        public void TestGetBytesUlong()
        {
            // Max value - Big endian
            ulong test = ulong.MaxValue;
            byte[] res = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // Normal value - Little endian
            test = 0x44332211DDCCBBAA;
            res = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0x11, 0x22, 0x33, 0x44 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes(true)),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes(true)}");

            // Min Value - Big endian
            test = ulong.MinValue;
            res = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");
        }
        #endregion


        #region Floats
        [TestMethod]
        public void TestGetBytesFloat()
        {
            // Positive Infinity - Big endian
            float test = float.PositiveInfinity;
            byte[] res = { 0x7F, 0x80, 0x00, 0x00 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // Max value - Big endian
            test = float.MaxValue;
            res = new byte[] { 0x7F, 0x7F, 0xFF, 0xFF };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // Normal value - Little endian
            test = 1.2345E-35f;
            res = new byte[] { 0x49, 0x46, 0x83, 0x05 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes(true)),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes(true)}");

            // Epsilon - Big endian
            test = float.Epsilon;
            res = new byte[] { 0x00, 0x00, 0x00, 0x01 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 4 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // Min value - Big endian
            test = float.MinValue;
            res = new byte[] { 0xFF, 0x7F, 0xFF, 0xFF };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 5 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // Negative Infinity - Big endian
            test = float.NegativeInfinity;
            res = new byte[] { 0xFF, 0x80, 0x00, 0x00 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 6 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // NaN - Big endian
            test = float.NaN;
            res = new byte[] { 0xFF, 0xC0, 0x00, 0x00 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 7 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");
        }


        [TestMethod]
        public void TestGetBytesDouble()
        {
            // Positive Infinity - Big endian
            double test = double.PositiveInfinity;
            byte[] res = { 0x7F, 0xF0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // Max value - Big endian
            test = double.MaxValue;
            res = new byte[] { 0x7F, 0xEF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // Normal value - Little endian
            test = 4.294967295E9;
            res = new byte[] { 0x00, 0x00, 0xE0, 0xFF, 0xFF, 0xFF, 0xEF, 0x41 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes(true)),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes(true)}");

            // Epsilon - Big endian
            test = double.Epsilon;
            res = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 4 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // Min value - Big endian
            test = double.MinValue;
            res = new byte[] { 0xFF, 0xEF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 5 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // Negative Infinity - Big endian
            test = double.NegativeInfinity;
            res = new byte[] { 0xFF, 0xF0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 6 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");

            // NaN - Big endian
            test = double.NaN;
            res = new byte[] { 0xFF, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            Assert.IsTrue(AreArraysEqual(res, test.GetBytes()),
                $"The values for test 7 did not match:\n" +
                $"The array should equal {res}, not {test.GetBytes()}");
        }
        #endregion
    }
}
