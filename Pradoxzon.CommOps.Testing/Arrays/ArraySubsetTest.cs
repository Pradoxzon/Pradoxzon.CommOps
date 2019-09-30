/**
 * ArraySubsetTest.cs
 * 
 * Copyright (c) 2019 Pradoxzon Dev
 * 
 * Author: Shawn Peerenboom (Pradoxzon)
 * 
 * Tests for the ArraySubset class.
 * See Pradoxzon.CommOps.Arrays.ArraySubset for the class implementation.
 */

namespace Pradoxzon.CommOps.Testing.Arrays
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static CommOps.Arrays.ArraySubset;


    [TestClass]
    public class ArraySubsetTest
    {
        #region AreArraysEqual
        public static bool AreArraysEqual<T>(T[] array1, T[] array2) where T : IEquatable<T>
        {
            // Lengths must match
            if (array1.Length != array2.Length)
                return false;

            // Check each item in the arrays
            for (int i = 0; i < array1.Length; i++)
            {
                if (!array1[i].Equals(array2[i]))
                    return false;
            }
            return true;
        }


        [TestMethod]
        public void TestAreArraysEqual()
        {
            // Test for equality
            int[] testA = { -5, 5, -10, 10, -15, 15, -20, 20 };
            int[] testB = { -5, 5, -10, 10, -15, 15, -20, 20 };
            Assert.IsTrue(AreArraysEqual(testA, testB),
                $"The arrays in test 1 should be equal.");

            // Test for inequality
            testB = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            Assert.IsFalse(AreArraysEqual(testA, testB),
                $"The arrays in test 2 should not be equal.");

            // Test unequal lengths
            testB = new int[] { 4, 5, 6 };
            Assert.IsFalse(AreArraysEqual(testA, testB),
                $"The arrays in test 3 should have different lengths:\n" +
                $"array1.Length : {testA.Length}\n" +
                $"array2.Length : {testB.Length}");
        }
        #endregion


        [TestMethod]
        public void TestSubsetLength()
        {
            // Normal operation
            byte[] test = { 0x1A, 0x2B, 0x3C, 0x4D, 0x5E, 0x6F };
            int length = 3;
            byte[] res = { 0x1A, 0x2B, 0x3C };
            Assert.IsTrue(AreArraysEqual(res, test.Subset(length)),
                $"The arrays for test 1 should match.");

            // Null source array
            test = null;
            Assert.ThrowsException<ArgumentNullException>(() => test.Subset(length),
                $"Test 2 should throw an ArgumentNullException.");

            // Bad length of segment to copy
            test = new byte[] { 0x55, 0x66 };
            length = 20;
            Assert.ThrowsException<ArgumentException>(() => test.Subset(length),
                $"Test 4 should throw an ArgumentException.");

            // Test alternate type 1
            int[] test1 = { -5, -3, -1, 1, 3, 5 };
            length = 2;
            int[] res1 = { -5, -3 };
            Assert.IsTrue(AreArraysEqual(res1, test1.Subset(length)),
                $"The arrays for test 5 should match.");

            // Test alternate type 2
            string[] test2 = { "hello", "world", "!" };
            string[] res2 = { "hello", "world" };
            Assert.IsTrue(AreArraysEqual(res2, test2.Subset(length)),
                $"The arrays for test 6 should match.");
        }


        [TestMethod]
        public void TestSubsetIndex()
        {
            // Normal operation
            byte[] test = { 0x1A, 0x2B, 0x3C, 0x4D, 0x5E, 0x6F };
            int index = 2;
            int length = 3;
            byte[] res = { 0x3C, 0x4D, 0x5E };
            Assert.IsTrue(AreArraysEqual(res, test.Subset(index, length)),
                $"The arrays for test 1 should match.");

            // Null source array
            test = null;
            Assert.ThrowsException<ArgumentNullException>(() => test.Subset(index, length),
                $"Test 2 should throw an ArgumentNullException.");

            // Bad starting index
            test = new byte[] { 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77 };
            index = 7;
            Assert.ThrowsException<ArgumentException>(() => test.Subset(index, length),
                $"Test 3 should throw an ArgumentException.");

            // Bad length of segment to copy
            index = 5;
            length = 20;
            Assert.ThrowsException<ArgumentException>(() => test.Subset(index, length),
                $"Test 4 should throw an ArgumentException.");

            // Test alternate type 1
            int[] test1 = { -5, -3, -1, 1, 3, 5 };
            index = 1;
            length = 2;
            int[] res1 = { -3, -1 };
            Assert.IsTrue(AreArraysEqual(res1, test1.Subset(index, length)),
                $"The arrays for test 5 should match.");

            // Test alternate type 2
            string[] test2 = { "hello", "world", "!" };
            index = 0;
            string[] res2 = { "hello", "world" };
            Assert.IsTrue(AreArraysEqual(res2, test2.Subset(index, length)),
                $"The arrays for test 6 should match.");
        }
    }
}
