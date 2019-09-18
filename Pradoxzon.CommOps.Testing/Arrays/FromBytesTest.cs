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
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static CommOps.Arrays.FromBytes;


    [TestClass]
    public class FromBytesTest
    {
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
    }
}
