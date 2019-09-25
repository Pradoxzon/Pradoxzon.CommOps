/**
 * FromBytesTest.cs
 * 
 * Copyright (c) 2019 Pradoxzon Dev
 * 
 * Author: Shawn Peerenboom (Pradoxzon)
 * 
 * Tests for the FromBytes class.
 * See Pradoxzon.CommOps.Arrays.FromBytes for the class implementation.
 */

namespace Pradoxzon.CommOps.Testing.Arrays
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static CommOps.Arrays.FromBytes;


    [TestClass]
    public class FromBytesTest
    {
        #region AreListsEqual
        private static bool AreListsEqual<T>(List<T> list1, List<T> list2) where T : IEquatable<T>
        {
            // Lengths must match
            if (list1.Count != list2.Count)
                return false;

            // Check each item in the arrays
            for (int i = 0; i < list1.Count; i++)
            {
                if (!list1[i].Equals(list2[i]))
                    return false;
            }
            return true;
        }


        [TestMethod]
        public void TestAreListsEqual()
        {
            // Equality
            List<string> testA = new List<string>() { "List", "of", "strings" };
            List<string> testB = new List<string>() { "List", "of", "strings" };
            Assert.IsTrue(AreListsEqual(testA, testB),
                $"The lists in test 1 should be equal.");

            // Inequality
            testA = new List<string>() { "wrong", "STRING", "list" };
            Assert.IsFalse(AreListsEqual(testA, testB),
                $"The lists in test 2 should not be equal.");

            // Unequal count
            testB = new List<string>() { "a", "b", "c", "d" };
            Assert.IsFalse(AreListsEqual(testA, testB),
                $"The lists in test 3 should have different counts.");
        }
        #endregion


        #region Strings
        [TestMethod]
        public void TestGetString()
        {
            // Empty string
            byte[] test = { };
            string res = "";
            Assert.IsTrue(res == test.GetString(),
                $"The values for test 1 did not match:\n" +
                $"The array should equal \"{res}\", not \"{test.GetString()}\"");

            // Little Endian
            test = new byte[] {
                0x48, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x6C, 0x00, 0x6F, 0x00,
                0x20, 0x00,
                0x57, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x6C, 0x00, 0x64, 0x00,
                0x21, 0x00 };
            res = "Hello World!";
            Assert.IsTrue(res == test.GetString(true),
                $"The values for test 2 did not match:\n" +
                $"The array should equal \"{res}\", not \"{test.GetString(true)}\"");

            // Big Endian
            test = new byte[] {
                0x00, 0x48, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x6C, 0x00, 0x6F,
                0x00, 0x20,
                0x00, 0x57, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x6C, 0x00, 0x64,
                0x00, 0x21, };
            Assert.IsTrue(res == test.GetString(),
                $"The values for test 3 did not match:\n" +
                $"The array should equal \"{res}\", not \"{test.GetString()}\"");

            // Wrong bytes
            test = new byte[] { 0x00, 0x21, 0x00, 0x21, 0x00, 0x21 };
            Assert.IsTrue(res != test.GetString(),
                $"The values for test 4 did not match:\n" +
                $"The array should equal \"{res}\", not \"{test.GetString()}\"");

            // Bad array length
            test = new byte[] { 0x00, 0x21, 0x00, 0x21, 0x00 };
            Assert.ThrowsException<InvalidOperationException>(() => test.GetString(),
                $"Test 5 should throw an InvalidOperationException.");
        }


        [TestMethod]
        public void TestGetListString()
        {
            // Empty list
            byte[] test = { 0x00, 0x00, 0x00, 0x00 };
            List<string> res = new List<string>();
            Assert.IsTrue(AreListsEqual(res, test.GetListString()),
                $"The values for test 1 did not match:\n" +
                $"The List should equal \"{res.ToString()}\", " +
                $"not \"{test.GetListString().ToString()}\"");

            // Little Endian
            test = new byte[] {
                0x02, 0x00, 0x00, 0x00,
                0x05, 0x00, 0x00, 0x00,
                0x48, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x6C, 0x00, 0x6F, 0x00,
                0x05, 0x00, 0x00, 0x00,
                0x57, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x6C, 0x00, 0x64, 0x00, };
            res = new List<string>() { "Hello", "World" };
            Assert.IsTrue(AreListsEqual(res, test.GetListString(true)),
                $"The values for test 2 did not match:\n" +
                $"The List should equal \"{res.ToString()}\", " +
                $"not \"{test.GetListString(true).ToString()}\"");

            // Big Endian
            test = new byte[] {
                0x00, 0x00, 0x00, 0x02,
                0x00, 0x00, 0x00, 0x05,
                0x00, 0x48, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x6C, 0x00, 0x6F,
                0x00, 0x00, 0x00, 0x05,
                0x00, 0x57, 0x00, 0x6F, 0x00, 0x72, 0x00, 0x6C, 0x00, 0x64, };
            Assert.IsTrue(AreListsEqual(res, test.GetListString()),
                $"The values for test 3 did not match:\n" +
                $"The array should equal \"{res}\", not \"{test.GetString()}\"");

            // Wrong bytes
            test = new byte[] {
                0x00, 0x00, 0x00, 0x01,
                0x00, 0x00, 0x00, 0x03,
                0x00, 0x21, 0x00, 0x21, 0x00, 0x21 };
            Assert.IsTrue(res != test.GetListString(),
                $"The values for test 4 did not match:\n" +
                $"The array should equal \"{res}\", not \"{test.GetString()}\"");
        }
        #endregion


        #region Integers
        [TestMethod]
        public void TestGetSbyte()
        {
            // Max value - Little endian
            byte[] test = { 0x7f };
            var res = sbyte.MaxValue;
            Assert.IsTrue(res == test.GetSbyte(),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetSbyte()}");

            // Normal value - Big endian
            test = new byte[] { 0xAA };
            res = -86;
            Assert.IsTrue(res == test.GetSbyte(),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetSbyte()}");

            // Min Value - Big endian
            test = new byte[] { 0x80 };
            res = sbyte.MinValue;
            Assert.IsTrue(res == test.GetSbyte(),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetSbyte()}");

            // Wrong size array
            test = new byte[] { 0x11, 0x22 };
            Assert.ThrowsException<InvalidOperationException>(() => test.GetSbyte());
        }


        [TestMethod]
        public void TestGetShort()
        {
            // Max value - Big endian
            byte[] test = { 0x7F, 0xFF };
            var res = short.MaxValue;
            Assert.IsTrue(res == test.GetShort(),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetShort()}");

            // Normal value - Little endian
            test = new byte[] { 0xBB, 0xAA };
            res = -21829;
            Assert.IsTrue(res == test.GetShort(true),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetShort(true)}");

            // Min Value - Big endian
            test = new byte[] { 0x80, 0x00 };
            res = short.MinValue;
            Assert.IsTrue(res == test.GetShort(),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetShort()}");

            // Wrong size array
            test = new byte[] { 0x11, 0x22, 0x33 };
            Assert.ThrowsException<InvalidOperationException>(() => test.GetShort());
        }


        [TestMethod]
        public void TestGetUshort()
        {
            // Max value - Big endian
            byte[] test = { 0xFF, 0xFF };
            var res = ushort.MaxValue;
            Assert.IsTrue(res == test.GetUshort(),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetUshort()}");

            // Normal value - Little endian
            test = new byte[] { 0xAA, 0xBB };
            res = 0xBBAA;
            Assert.IsTrue(res == test.GetUshort(true),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetUshort(true)}");

            // Min Value - Big endian
            test = new byte[] { 0x00, 0x00 };
            res = ushort.MinValue;
            Assert.IsTrue(res == test.GetUshort(),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetUshort()}");

            // Wrong size array
            test = new byte[] { 0x11, 0x22, 0x33 };
            Assert.ThrowsException<InvalidOperationException>(() => test.GetUshort());
        }


        [TestMethod]
        public void TestGetInt()
        {
            // Max value - Big endian
            byte[] test = { 0x7F, 0xFF, 0xFF, 0xFF };
            var res = int.MaxValue;
            Assert.IsTrue(res == test.GetInt(),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetInt()}");

            // Normal value - Little endian
            test = new byte[] { 0xDD, 0xCC, 0xBB, 0xAA };
            res = -1430532899;
            Assert.IsTrue(res == test.GetInt(true),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetInt(true)}");

            // Min Value - Big endian
            test = new byte[] { 0x80, 0x00, 0x00, 0x00 };
            res = int.MinValue;
            Assert.IsTrue(res == test.GetInt(),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetInt()}");

            // Wrong size array
            test = new byte[] { 0x11, 0x22, 0x33 };
            Assert.ThrowsException<InvalidOperationException>(() => test.GetInt());
        }


        [TestMethod]
        public void TestGetUint()
        {
            // Max value - Big endian
            byte[] test = { 0xFF, 0xFF, 0xFF, 0xFF };
            var res = uint.MaxValue;
            Assert.IsTrue(res == test.GetUint(),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetUint()}");

            // Normal value - Little endian
            test = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD };
            res = 0xDDCCBBAA;
            Assert.IsTrue(res == test.GetUint(true),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetUint(true)}");

            // Min Value - Big endian
            test = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            res = uint.MinValue;
            Assert.IsTrue(res == test.GetUint(),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetUint()}");

            // Wrong size array
            test = new byte[] { 0x11, 0x22, 0x33 };
            Assert.ThrowsException<InvalidOperationException>(() => test.GetUshort());
        }


        [TestMethod]
        public void TestGetLong()
        {
            // Max value - Big endian
            byte[] test = { 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            var res = long.MaxValue;
            Assert.IsTrue(res == test.GetLong(),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetLong()}");

            // Normal value - Little endian
            test = new byte[] { 0xDD, 0xCC, 0xBB, 0xAA, 0x44, 0x33, 0x22, 0x11 };
            res = 0x11223344AABBCCDD;
            Assert.IsTrue(res == test.GetLong(true),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetLong(true)}");

            // Min Value - Big endian
            test = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            res = long.MinValue;
            Assert.IsTrue(res == test.GetLong(),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetLong()}");

            // Wrong size array
            test = new byte[] { 0x11, 0x22, 0x33 };
            Assert.ThrowsException<InvalidOperationException>(() => test.GetLong());
        }


        [TestMethod]
        public void TestGetUlong()
        {
            // Max value - Big endian
            byte[] test = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            var res = ulong.MaxValue;
            Assert.IsTrue(res == test.GetUlong(),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetUlong()}");

            // Normal value - Little endian
            test = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0x11, 0x22, 0x33, 0x44 };
            res = 0x44332211DDCCBBAA;
            Assert.IsTrue(res == test.GetUlong(true),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetUlong(true)}");

            // Min Value - Big endian
            test = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            res = ulong.MinValue;
            Assert.IsTrue(res == test.GetUlong(),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetUlong()}");

            // Wrong size array
            test = new byte[] { 0x11, 0x22, 0x33 };
            Assert.ThrowsException<InvalidOperationException>(() => test.GetUlong());
        }
        #endregion


        #region Floats
        [TestMethod]
        public void TestGetFloat()
        {
            // Positive Infinity - Big endian
            byte[] test = { 0x7F, 0x80, 0x00, 0x00 };
            var res = float.PositiveInfinity;
            Assert.IsTrue(float.IsPositiveInfinity(test.GetFloat()),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetFloat()}");

            // Max value - Big endian
            test = new byte[] { 0x7F, 0x7F, 0xFF, 0xFF };
            res = float.MaxValue;
            Assert.IsTrue(res == test.GetFloat(),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetFloat()}");

            // Normal value - Little endian
            test = new byte[] { 0x49, 0x46, 0x83, 0x05 };
            res = 1.2345E-35f;
            Assert.IsTrue(res == test.GetFloat(true),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetFloat(true)}");

            // Epsilon - Big endian
            test = new byte[] { 0x00, 0x00, 0x00, 0x01 };
            res = float.Epsilon;
            Assert.IsTrue(res == test.GetFloat(),
                $"The values for test 4 did not match:\n" +
                $"The array should equal {res}, not {test.GetFloat()}");

            // Min value - Big endian
            test = new byte[] { 0xFF, 0x7F, 0xFF, 0xFF };
            res = float.MinValue;
            Assert.IsTrue(res == test.GetFloat(),
                $"The values for test 5 did not match:\n" +
                $"The array should equal {res}, not {test.GetFloat()}");

            // Negative Infinity - Big endian
            test = new byte[] { 0xFF, 0x80, 0x00, 0x00 };
            res = float.NegativeInfinity;
            Assert.IsTrue(float.IsNegativeInfinity(test.GetFloat()),
                $"The values for test 6 did not match:\n" +
                $"The array should equal {res}, not {test.GetFloat()}");

            // NaN - Big endian
            test = new byte[] { 0xFF, 0xC0, 0x00, 0x00 };
            res = float.NaN;
            Assert.IsTrue(float.IsNaN(test.GetFloat()),
                $"The values for test 7 did not match:\n" +
                $"The array should equal {res}, not {test.GetFloat()}");
        }


        [TestMethod]
        public void TestGetDouble()
        {
            // Positive Infinity - Big endian
            byte[] test = { 0x7F, 0xF0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            var res = double.PositiveInfinity;
            Assert.IsTrue(double.IsPositiveInfinity(test.GetDouble()),
                $"The values for test 1 did not match:\n" +
                $"The array should equal {res}, not {test.GetDouble()}");

            // Max value - Big endian
            test = new byte[] { 0x7F, 0xEF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            res = double.MaxValue;
            Assert.IsTrue(res == test.GetDouble(),
                $"The values for test 2 did not match:\n" +
                $"The array should equal {res}, not {test.GetDouble()}");

            // Normal value - Little endian
            test = new byte[] { 0x00, 0x00, 0xE0, 0xFF, 0xFF, 0xFF, 0xEF, 0x41 };
            res = 4.294967295E9;
            Assert.IsTrue(res == test.GetDouble(true),
                $"The values for test 3 did not match:\n" +
                $"The array should equal {res}, not {test.GetDouble(true)}");

            // Epsilon - Big endian
            test = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 };
            res = double.Epsilon;
            Assert.IsTrue(res == test.GetDouble(),
                $"The values for test 4 did not match:\n" +
                $"The array should equal {res}, not {test.GetDouble()}");

            // Min value - Big endian
            test = new byte[] { 0xFF, 0xEF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            res = double.MinValue;
            Assert.IsTrue(res == test.GetDouble(),
                $"The values for test 5 did not match:\n" +
                $"The array should equal {res}, not {test.GetDouble()}");

            // Negative Infinity - Big endian
            test = new byte[] { 0xFF, 0xF0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            res = double.NegativeInfinity;
            Assert.IsTrue(double.IsNegativeInfinity(test.GetDouble()),
                $"The values for test 6 did not match:\n" +
                $"The array should equal {res}, not {test.GetDouble()}");

            // NaN - Big endian
            test = new byte[] { 0xFF, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            res = double.NaN;
            Assert.IsTrue(double.IsNaN(test.GetDouble()),
                $"The values for test 7 did not match:\n" +
                $"The array should equal {res}, not {test.GetDouble()}");
        }
        #endregion
    }
}
