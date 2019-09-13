/**
 * BitMath.cs
 * 
 * Copyright (c) 2019 Pradoxzon Dev
 * 
 * Author: Shawn Peerenboom (Pradoxzon)
 * 
 * This class contains some constants and methods for
 * working with bytes and for treating numbers as bits.
 */


namespace Pradoxzon.CommOps.Math
{
    using System;


    /**
     * <summary>Provides methods and constants for working
     * with bytes and for treating numbers as bits.</summary>
     */
    public static class BitMath
    {
        #region Constants
        /// <summary>The number of bytes in a 16 bit objcet</summary>
        public const int NumBytes16Bits = 2;

        /// <summary>The number of bytes in a 32 bit object</summary>
        public const int NumBytes32Bits = 4;

        /// <summary>The number of bytes in a 64 bit object</summary>
        public const int NumBytes64Bits = 8;


        /// <summary>The number of nits in an 8-bit object</summary>
        public const int Bits8 = 8;

        /// <summary>The number of bits in a 16-bit object</summary>
        public const int Bits16 = 16;

        /// <summary>The number of bits in a 32-bit object</summary>
        public const int Bits32 = 32;

        /// <summary>The number of bits in a 64-bit object</summary>
        public const int Bits64 = 64;
        #endregion


        #region BitShiftRight

        #endregion


        #region BitShiftLeft
        /**
         * <summary>Performs a bitwise shift to the left on a
         * 16-bit integer with wraparound</summary>
         * <param name="number">The short value to shift</param>
         * <param name="positions">How many positions to shift</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static short BitShiftLeft(short number, short positions)
        {
            // Ensure: 0 <= positions <= 15
            positions = positions.Clamp(0, Bits16 - 1);
            
            // Preserve the bits to be discarded
            int wrapped = number >> (Bits16 - positions);
            // Shift and wrap the discarded bits
            return BitConverter.ToInt16(BitConverter.GetBytes((ushort)((number << positions) | wrapped)), 0);
        }


        /**
         * <summary>Performs a bitwise shift to the left on a
         * 16-bit unsigned integer with wraparound</summary>
         * <param name="number">The ushort value to shift</param>
         * <param name="positions">How many positions to shift</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static ushort BitShiftLeft(ushort number, ushort positions)
        {
            // Ensure: 0 <= positions <= 15
            positions = positions.Clamp(0, Bits16 - 1);
            
            // Preserve the bits to be discarded
            int wrapped = number >> (Bits16 - positions);
            // Shift and wrap the discarded bits
            return BitConverter.ToUInt16(BitConverter.GetBytes((ushort)((number << positions) | wrapped)), 0);
        }


        /**
         * <summary>Performs a bitwise shift to the left on a 32-bit integer
         * with wraparound</summary>
         * <param name="value">The integer value to shift</param>
         * <param name="positions">How many positions to shift</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static int BitShiftLeft(int value, int positions)
        {
            // Ensure: 0 <= positions <= 31
            positions = positions.Clamp(0, Bits32 - 1);

            // Save the existing bit pattern as an unsigned integer
            uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
            // Preserve the bits to be discarded
            uint wrapped = number >> (Bits32 - positions);
            // Shift and wrap the discarded bits
            return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
        }
        #endregion
    }
}
