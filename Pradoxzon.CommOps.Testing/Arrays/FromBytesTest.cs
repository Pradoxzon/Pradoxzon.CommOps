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


            // Normal value - Big endian


            // Min Value - Big endian
        }
        #endregion


        #region Floats

        #endregion
    }
}
