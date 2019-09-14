

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

        #endregion


        #region TestBitShiftLeft
        [TestMethod]
        public void TestBitShiftLeftSbyte()
        {
            // All 1s
            sbyte test = -1;        // 1111_1111
            sbyte shift = 5;
            sbyte res = -1;         // 1111_1111
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 1 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is above clamp range
            test = 90;              // 0101_1010
            shift = 16;
            res = 45;               // 0010_1101
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 2 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is inside clamp range
            test = -16;             // 1111_0000
            shift = 3;
            res = -121;             // 1000_0111
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 3 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // Shift is below clamp range
            test = -52;             // 1100_1100
            shift = -3;
            res = -52;              // 1100_1100
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 4 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");

            // All 0s
            test = 0;               // 0000_0000
            shift = 1;
            res = 0;                // 0000_0000
            Assert.IsTrue(res == BitShiftLeft(test, shift),
                $"The values for test 5 did not match:\n" +
                $"BitShiftLeft({test}, {shift}) should equal {res}, not {BitShiftLeft(test, shift)}");
        }
        #endregion
    }
}
