/**
 * BitMathTest.cs
 * 
 * Copyright (c) 2019 Pradoxzon Dev
 * 
 * Author: Shawn Peerenboom (Pradoxzon)
 * 
 * Tests for the BitMath class.
 * See Pradoxzon.CommOps.Math.BitMath for the class implementation.
 */

namespace Pradoxzon.CommOps.Testing.Math
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using static CommOps.Math.BitMath;


    [TestClass]
    public class BitMathTest
    {
        [TestMethod]
        public void TestConstants()
        {
            // Sanity check, try and catch if one is ever changed for any reason?
            Assert.IsTrue(NumBytes16Bits == 2,
                $"There are 2 bytes in a 16-bit value, not {NumBytes16Bits} bytes.");

            Assert.IsTrue(NumBytes32Bits == 4,
                $"There are 4 bytes in a 32-bit value, not {NumBytes32Bits} bytes.");

            Assert.IsTrue(NumBytes64Bits == 8,
                $"There are 8 bytes in a 64-bit value, not {NumBytes64Bits} bytes.");

            Assert.IsTrue(Bits8 == 8,
                $"There are 8 bits in an 8-bit value, not {Bits8} bits.");

            Assert.IsTrue(Bits16 == 16,
                $"There are 16 bits in a 16-bit value, not {Bits16} bits.");

            Assert.IsTrue(Bits32 == 32,
                $"There are 32 bits in a 32-bit value, not {Bits32} bits.");

            Assert.IsTrue(Bits64 == 64,
                $"There are 64 bits in a 64-bit value, not {Bits64} bits.");
        }


        #region TestBitShiftRight
        [TestMethod]
        public void TestBitShiftRightSbyte()
        {
            // All 1s
            sbyte test = -1;                    // 1111_1111
            sbyte shift = 5;
            sbyte res = -1;                     // 1111_1111
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 1 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is above clamp range
            test = 0x5A;                        // 0101_1010
            shift = 16;
            res = -76;                          // 1011_0100
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 2 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is inside clamp range
            test = -16;                         // 1111_0000
            shift = 3;
            res = 0x1E;                         // 0001_1110
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 3 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is below clamp range
            test = 0x33;                        // 0011_0011
            shift = -3;
            res = 0x33;                         // 0011_0011
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 4 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // All 0s
            test = 0;                           // 0000_0000
            shift = 1;
            res = 0;                            // 0000_0000
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 5 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");
        }


        [TestMethod]
        public void TestBitShiftRightByte()
        {
            // All 1s
            byte test = byte.MaxValue;          // 1111_1111
            byte shift = 5;
            byte res = byte.MaxValue;           // 1111_1111
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 1 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is above clamp range
            test = 0x5A;                        // 0101_1010
            shift = 16;
            res = 0xB4;                         // 1011_0100
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 2 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is inside clamp range
            test = 0xF0;                        // 1111_0000
            shift = 3;
            res = 0x1E;                         // 0001_1110
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 3 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is below clamp range
            test = 0xCC;                        // 1100_1100
            shift = 0;
            res = 0xCC;                         // 1100_1100
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 4 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // All 0s
            test = 0;                           // 0000_0000
            shift = 1;
            res = 0;                            // 0000_0000
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 5 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");
        }


        [TestMethod]
        public void TestBitShiftRightShort()
        {
            // All 1s
            short test = -1;                    // 1111_1111_1111_1111
            short shift = 5;
            short res = -1;                     // 1111_1111_1111_1111
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 1 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is above clamp range
            test = 0x5A5A;                      // 0101_1010_0101_1010
            shift = 32;
            res = -19276;                       // 1011_0100_1011_0100
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 2 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is inside clamp range
            test = -3856;                       // 1111_0000_1111_0000
            shift = 3;
            res = 0x1E1E;                       // 0001_1110_0001_1110
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 3 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is below clamp range
            test = 0x3333;                      // 0011_0011_0011_0011
            shift = -3;
            res = 0x3333;                       // 0011_0011_0011_0011
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 4 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // All 0s
            test = 0;                           // 0000_0000_0000_0000
            shift = 1;
            res = 0;                            // 0000_0000_0000_0000
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 5 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");
        }


        [TestMethod]
        public void TestBitShiftRightUshort()
        {
            // All 1s
            ushort test = ushort.MaxValue;      // 1111_1111_1111_1111
            ushort shift = 5;
            ushort res = ushort.MaxValue;       // 1111_1111_1111_1111
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 1 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is above clamp range
            test = 0x5A5A;                      // 0101_1010_0101_1010
            shift = 32;
            res = 0xB4B4;                       // 1011_0100_1011_0100
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 2 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is inside clamp range
            test = 0xF0F0;                      // 1111_0000_1111_0000
            shift = 3;
            res = 0x1E1E;                       // 0001_1110_0001_1110
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 3 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is below clamp range
            test = 0x3333;                      // 0011_0011_0011_0011
            shift = 0;
            res = 0x3333;                       // 0011_0011_0011_0011
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 4 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // All 0s
            test = 0;                           // 0000_0000_0000_0000
            shift = 1;
            res = 0;                            // 0000_0000_0000_0000
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 5 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");
        }


        [TestMethod]
        public void TestBitShiftRightInt()
        {
            // All 1s
            int test = -1;                      // 1111_1111_1111_1111_1111_1111_1111_1111
            int shift = 5;
            int res = -1;                       // 1111_1111_1111_1111_1111_1111_1111_1111
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 1 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is above clamp range
            test = 0x5A5A5A5A;                  // 0101_1010_0101_1010_0101_1010_0101_1010
            shift = 64;
            res = -1263225676;                  // 1011_0100_1011_0100_1011_0100_1011_0100
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 2 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is inside clamp range
            test = -252645136;                  // 1111_0000_1111_0000_1111_0000_1111_0000
            shift = 3;
            res = 0x1E1E1E1E;                   // 0001_1110_0001_1110_0001_1110_0001_1110
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 3 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is below clamp range
            test = 0x33333333;                  // 0011_0011_0011_0011_0011_0011_0011_0011
            shift = -3;
            res = 0x33333333;                   // 0011_0011_0011_0011_0011_0011_0011_0011
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 4 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // All 0s
            test = 0;                           // 0000_0000_0000_0000_0000_0000_0000_0000
            shift = 1;
            res = 0;                            // 0000_0000_0000_0000_0000_0000_0000_0000
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 5 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");
        }


        [TestMethod]
        public void TestBitShiftRightUint()
        {
            // All 1s
            uint test = uint.MaxValue;          // 1111_1111_1111_1111_1111_1111_1111_1111
            uint shift = 5;
            uint res = uint.MaxValue;           // 1111_1111_1111_1111_1111_1111_1111_1111
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 1 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is above clamp range
            test = 0x5A5A5A5A;                  // 0101_1010_0101_1010_0101_1010_0101_1010
            shift = 64;
            res = 0xB4B4B4B4;                   // 1011_0100_1011_0100_1011_0100_1011_0100
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 2 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is inside clamp range
            test = 0xF0F0F0F0;                  // 1111_0000_1111_0000_1111_0000_1111_0000
            shift = 3;
            res = 0x1E1E1E1E;                   // 0001_1110_0001_1110_0001_1110_0001_1110
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 3 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is below clamp range
            test = 0x33333333;                  // 0011_0011_0011_0011_0011_0011_0011_0011
            shift = 0;
            res = 0x33333333;                   // 0011_0011_0011_0011_0011_0011_0011_0011
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 4 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // All 0s
            test = 0;                           // 0000_0000_0000_0000_0000_0000_0000_0000
            shift = 1;
            res = 0;                            // 0000_0000_0000_0000_0000_0000_0000_0000
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 5 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");
        }


        [TestMethod]
        public void TestBitShiftRightLong()
        {
            // All 1s
            long test = -1;                     // 1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111
            long shift = 5;
            long res = -1;                      // 1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 1 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is above clamp range
            test = 0x5A5A5A5A5A5A5A5A;          // 0101_1010_0101_1010_0101_1010_0101_1010_0101_1010_0101_1010_0101_1010_0101_1010
            shift = 64;
            res = -5425512962855750476;         // 1011_0100_1011_0100_1011_0100_1011_0100_1011_0100_1011_0100_1011_0100_1011_0100
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 2 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is inside clamp range
            test = -1085102592571150096;        // 1111_0000_1111_0000_1111_0000_1111_0000_1111_0000_1111_0000_1111_0000_1111_0000
            shift = 3;
            res = 0x1E1E1E1E1E1E1E1E;           // 0001_1110_0001_1110_0001_1110_0001_1110_0001_1110_0001_1110_0001_1110_0001_1110
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 3 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is below clamp range
            test = 0x3333333333333333;          // 0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011
            shift = -3;
            res = 0x3333333333333333;           // 0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 4 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // All 0s
            test = 0;                           // 0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000
            shift = 1;
            res = 0;                            // 0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 5 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");
        }


        [TestMethod]
        public void TestBitShiftRightUlong()
        {
            // All 1s
            ulong test = ulong.MaxValue;        // 1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111
            ulong shift = 5;
            ulong res = ulong.MaxValue;         // 1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 1 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is above clamp range
            test = 0x5A5A5A5A5A5A5A5A;          // 0101_1010_0101_1010_0101_1010_0101_1010_0101_1010_0101_1010_0101_1010_0101_1010
            shift = 64;
            res = 0xB4B4B4B4B4B4B4B4;           // 1011_0100_1011_0100_1011_0100_1011_0100_1011_0100_1011_0100_1011_0100_1011_0100
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 2 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is inside clamp range
            test = 0xF0F0F0F0F0F0F0F0;          // 1111_0000_1111_0000_1111_0000_1111_0000_1111_0000_1111_0000_1111_0000_1111_0000
            shift = 3;
            res = 0x1E1E1E1E1E1E1E1E;           // 0001_1110_0001_1110_0001_1110_0001_1110_0001_1110_0001_1110_0001_1110_0001_1110
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 3 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // Shift is below clamp range
            test = 0x3333333333333333;          // 0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011
            shift = 0;
            res = 0x3333333333333333;           // 0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011_0011
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 4 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");

            // All 0s
            test = 0;                           // 0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000
            shift = 1;
            res = 0;                            // 0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000
            Assert.IsTrue(res == BitShiftRight(test, shift),
                $"The values for test 5 did not match:\n" +
                $"BitShiftRight({test}, {shift}) should equal {res}, not {BitShiftRight(test, shift)}");
        }
        #endregion


        #region TestBitShiftLeft
        [TestMethod]
        public void TestBitShiftLeftSbyte()
        {
            // All 1s
            sbyte test = -1;                    // 1111_1111
            sbyte shift = 5;
            sbyte res = -1;                     // 1111_1111
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 1 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is above clamp range
            test = 90;                          // 0101_1010
            shift = 16;
            res = 45;                           // 0010_1101
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 2 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is inside clamp range
            test = -16;                         // 1111_0000
            shift = 3;
            res = -121;                         // 1000_0111
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 3 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is below clamp range
            test = -52;                         // 1100_1100
            shift = -3;
            res = -52;                          // 1100_1100
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 4 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // All 0s
            test = 0;                           // 0000_0000
            shift = 1;
            res = 0;                            // 0000_0000
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 5 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");
        }


        [TestMethod]
        public void TestBitShiftLeftByte()
        {
            // All 1s
            byte test = 255;                    // 1111_1111
            byte shift = 5;
            byte res = 255;                     // 1111_1111
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 1 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is above clamp range
            test = 90;                          // 0101_1010
            shift = 16;
            res = 45;                           // 0010_1101
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 2 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is inside clamp range
            test = 240;                         // 1111_0000
            shift = 3;
            res = 135;                          // 1000_0111
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 3 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is below clamp range
            test = 204;                         // 1100_1100
            shift = 0;
            res = 204;                          // 1100_1100
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 4 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // All 0s
            test = 0;                           // 0000_0000
            shift = 1;
            res = 0;                            // 0000_0000
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 5 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");
        }


        [TestMethod]
        public void TestBitShiftLeftShort()
        {
            // All 1s
            short test = -1;                    // 1111_1111_1111_1111
            short shift = 5;
            short res = -1;                     // 1111_1111_1111_1111
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 1 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is above clamp range
            test = 23130;                       // 0101_1010_0101_1010
            shift = 32;
            res = 11565;                        // 0010_1101_0010_1101
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 2 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is inside clamp range
            test = -3856;                       // 1111_0000_1111_0000
            shift = 3;
            res = -30841;                       // 1000_0111_1000_0111
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 3 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is below clamp range
            test = -13108;                      // 1100_1100_1100_1100
            shift = -3;
            res = -13108;                       // 1100_1100_1100_1100
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 4 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // All 0s
            test = 0;                           // 0000_0000_0000_0000
            shift = 1;
            res = 0;                            // 0000_0000_0000_0000
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 5 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");
        }


        [TestMethod]
        public void TestBitShiftLeftUshort()
        {
            // All 1s
            ushort test = 65535;                // 1111_1111_1111_1111
            ushort shift = 5;
            ushort res = 65535;                 // 1111_1111_1111_1111
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 1 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is above clamp range
            test = 23130;                       // 0101_1010_0101_1010
            shift = 32;
            res = 11565;                        // 0010_1101_0010_1101
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 2 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is inside clamp range
            test = 61680;                       // 1111_0000_1111_0000
            shift = 3;
            res = 34695;                        // 1000_0111_1000_0111
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 3 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is below clamp range
            test = 52428;                       // 1100_1100_1100_1100
            shift = 0;
            res = 52428;                        // 1100_1100_1100_1100
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 4 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // All 0s
            test = 0;                           // 0000_0000_0000_0000
            shift = 1;
            res = 0;                            // 0000_0000_0000_0000
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 5 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");
        }


        [TestMethod]
        public void TestBitShiftLeftInt()
        {
            // All 1s
            int test = -1;                      // 1111_1111_1111_1111_1111_1111_1111_1111
            int shift = 5;
            int res = -1;                       // 1111_1111_1111_1111_1111_1111_1111_1111
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 1 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is above clamp range
            test = 1515870810;                  // 0101_1010_0101_1010_0101_1010_0101_1010
            shift = 64;
            res = 757935405;                    // 0010_1101_0010_1101_0010_1101_0010_1101
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 2 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is inside clamp range
            test = -252645136;                  // 1111_0000_1111_0000_1111_0000_1111_0000
            shift = 3;
            res = -2021161081;                  // 1000_0111_1000_0111_1000_0111_1000_0111
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 3 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is below clamp range
            test = -858993460;                  // 1100_1100_1100_1100_1100_1100_1100_1100
            shift = -3;
            res = -858993460;                   // 1100_1100_1100_1100_1100_1100_1100_1100
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 4 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // All 0s
            test = 0;                           // 0000_0000_0000_0000_0000_0000_0000_0000
            shift = 1;
            res = 0;                            // 0000_0000_0000_0000_0000_0000_0000_0000
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 5 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");
        }


        [TestMethod]
        public void TestBitShiftLeftUint()
        {
            // All 1s
            uint test = uint.MaxValue;          // 1111_1111_1111_1111_1111_1111_1111_1111
            uint shift = 5;
            uint res = uint.MaxValue;           // 1111_1111_1111_1111_1111_1111_1111_1111
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 1 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is above clamp range
            test = 1515870810;                  // 0101_1010_0101_1010_0101_1010_0101_1010
            shift = 64;
            res = 757935405;                    // 0010_1101_0010_1101_0010_1101_0010_1101
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 2 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is inside clamp range
            test = 4042322160;                  // 1111_0000_1111_0000_1111_0000_1111_0000
            shift = 3;
            res = 2273806215;                   // 1000_0111_1000_0111_1000_0111_1000_0111
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 3 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is below clamp range
            test = 3435973836;                  // 1100_1100_1100_1100_1100_1100_1100_1100
            shift = 0;
            res = 3435973836;                   // 1100_1100_1100_1100_1100_1100_1100_1100
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 4 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // All 0s
            test = 0;                           // 0000_0000_0000_0000_0000_0000_0000_0000
            shift = 1;
            res = 0;                            // 0000_0000_0000_0000_0000_0000_0000_0000
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 5 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");
        }


        [TestMethod]
        public void TestBitShiftLeftLong()
        {
            // All 1s
            long test = -1;                     // 1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111
            long shift = 5;
            long res = -1;                      // 1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 1 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is above clamp range
            test = 6510615555426900570;         // 0101_1010_0101_1010_0101_1010_0101_1010_0101_1010_0101_1010_0101_1010_0101_1010
            shift = 128;
            res = 3255307777713450285;          // 0010_1101_0010_1101_0010_1101_0010_1101_0010_1101_0010_1101_0010_1101_0010_1101
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 2 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is inside clamp range
            test = -1085102592571150096;        // 1111_0000_1111_0000_1111_0000_1111_0000_1111_0000_1111_0000_1111_0000_1111_0000
            shift = 3;
            res = -8680820740569200761;         // 1000_0111_1000_0111_1000_0111_1000_0111_1000_0111_1000_0111_1000_0111_1000_0111
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 3 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is below clamp range
            test = -3689348814741910324;        // 1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100
            shift = -3;
            res = -3689348814741910324;         // 1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 4 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // All 0s
            test = 0;                           // 0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000
            shift = 1;
            res = 0;                            // 0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 5 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");
        }


        [TestMethod]
        public void TestBitShiftLeftUlong()
        {
            // All 1s
            ulong test = ulong.MaxValue;        // 1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111
            ulong shift = 5;
            ulong res = ulong.MaxValue;         // 1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 1 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is above clamp range
            test = 6510615555426900570;         // 0101_1010_0101_1010_0101_1010_0101_1010_0101_1010_0101_1010_0101_1010_0101_1010
            shift = 128;
            res = 3255307777713450285;          // 0010_1101_0010_1101_0010_1101_0010_1101_0010_1101_0010_1101_0010_1101_0010_1101
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 2 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is inside clamp range
            test = 0xF0F0F0F0F0F0F0F0;          // 1111_0000_1111_0000_1111_0000_1111_0000_1111_0000_1111_0000_1111_0000_1111_0000
            shift = 3;
            res = 0x8787878787878787;           // 1000_0111_1000_0111_1000_0111_1000_0111_1000_0111_1000_0111_1000_0111_1000_0111
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 3 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is below clamp range
            test = 0xCCCCCCCCCCCCCCCC;          // 1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100
            shift = 0;
            res = 0xCCCCCCCCCCCCCCCC;           // 1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100_1100
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 4 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // All 0s
            test = 0;                           // 0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000
            shift = 1;
            res = 0;                            // 0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 5 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");
        }
        #endregion
    }
}
