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
        /**
         * <summary>Performs a bitwise shift to the right on a <see cref="sbyte"/> with wraparound.
         * <para>The <paramref name="positions"/> parameter is clamped to the range
         * 0 to 7 inclusive.</para></summary>
         * <param name="number">The value to shift.</param>
         * <param name="positions">How many positions to shift.</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static sbyte BitShiftRight(sbyte number, sbyte positions)
        {
            // Ensure: 0 <= positions <= 7
            positions = positions.Clamp(0, Bits8 - 1);

            // Save the bit pattern in a 32-bit unsigned int
            uint number32 = (byte)number;
            // Preserve the bits to be discarded
            uint wrapped = (byte)(number32 << (Bits8 - positions));
            // Shift and wrap the discarded bits
            return (sbyte)((number32 >> positions) | wrapped);
        }


        /**
         * <summary>Performs a bitwise shift to the right on a <see cref="byte"/> with wraparound.
         * <para>The <paramref name="positions"/> parameter is clamped to the range
         * 0 to 7 inclusive.</para></summary>
         * <param name="number">The value to shift.</param>
         * <param name="positions">How many positions to shift.</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static byte BitShiftRight(byte number, byte positions)
        {
            // Ensure: 0 <= positions <= 7
            positions = positions.Clamp(0, Bits8 - 1);

            // Save the bit pattern in a 32-bit unsigned int
            uint number32 = number;
            // Preserve the bits to be discarded
            uint wrapped = (byte)(number32 << (Bits8 - positions));
            // Shift and wrap the discarded bits
            return (byte)((number32 >> positions) | wrapped);
        }


        /**
         * <summary>Performs a bitwise shift to the right on a <see cref="short"/> with wraparound.
         * <para>The <paramref name="positions"/> parameter is clamped to the range
         * 0 to 15 inclusive.</para></summary>
         * <param name="number">The value to shift.</param>
         * <param name="positions">How many positions to shift.</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static short BitShiftRight(short number, short positions)
        {
            // Ensure: 0 <= positions <= 15
            positions = positions.Clamp(0, Bits16 - 1);

            // Save the bit pattern in a 32-bit unsigned int
            uint number32 = (ushort)number;
            // Preserve the bits to be discarded
            uint wrapped = (ushort)(number32 << (Bits16 - positions));
            // Shift and wrap the discarded bits
            return (short)((number32 >> positions) | wrapped);
        }


        /**
         * <summary>Performs a bitwise shift to the right on a <see cref="ushort"/> with wraparound.
         * <para>The <paramref name="positions"/> parameter is clamped to the range
         * 0 to 15 inclusive.</para></summary>
         * <param name="number">The value to shift.</param>
         * <param name="positions">How many positions to shift.</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static ushort BitShiftRight(ushort number, ushort positions)
        {
            // Ensure: 0 <= positions <= 15
            positions = positions.Clamp(0, Bits16 - 1);

            // Save the bit pattern in a 32-bit unsigned int
            uint number32 = number;
            // Preserve the bits to be discarded
            uint wrapped = (ushort)(number32 << (Bits16 - positions));
            // Shift and wrap the discarded bits
            return (ushort)((number32 >> positions) | wrapped);
        }


        /**
         * <summary>Performs a bitwise shift to the right on a <see cref="int"/> with wraparound.
         * <para>The <paramref name="positions"/> parameter is clamped to the range
         * 0 to 31 inclusive.</para></summary>
         * <param name="number">The value to shift.</param>
         * <param name="positions">How many positions to shift.</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static int BitShiftRight(int number, int positions)
        {
            // Ensure: 0 <= positions <= 31
            positions = positions.Clamp(0, Bits32 - 1);

            // Save the bit pattern in a 32-bit unsigned int
            uint number32 = (uint)number;
            // Preserve the bits to be discarded
            uint wrapped = number32 << (Bits32 - positions);
            // Shift and wrap the discarded bits
            return (int)((number32 >> positions) | wrapped);
        }


        /**
         * <summary>Performs a bitwise shift to the right on a <see cref="uint"/> with wraparound.
         * <para>The <paramref name="positions"/> parameter is clamped to the range
         * 0 to 31 inclusive.</para></summary>
         * <param name="number">The value to shift.</param>
         * <param name="positions">How many positions to shift.</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static uint BitShiftRight(uint number, uint positions)
        {
            // Ensure: 0 <= positions <= 15
            positions = positions.Clamp(0, Bits32 - 1);
            int intPos = (int)positions;
            
            // Preserve the bits to be discarded
            uint wrapped = number << (Bits32 - intPos);
            // Shift and wrap the discarded bits
            return (number >> intPos) | wrapped;
        }


        /**
         * <summary>Performs a bitwise shift to the right on a <see cref="long"/> with wraparound.
         * <para>The <paramref name="positions"/> parameter is clamped to the range
         * 0 to 63 inclusive.</para></summary>
         * <param name="number">The value to shift.</param>
         * <param name="positions">How many positions to shift.</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static long BitShiftRight(long number, long positions)
        {
            // Ensure: 0 <= positions <= 63
            positions = positions.Clamp(0, Bits64 - 1);
            int intPos = (int)positions;

            // Save the bit pattern in a 32-bit unsigned int
            ulong number32 = (ulong)number;
            // Preserve the bits to be discarded
            ulong wrapped = number32 << (Bits64 - intPos);
            // Shift and wrap the discarded bits
            return (long)((number32 >> intPos) | wrapped);
        }


        /**
         * <summary>Performs a bitwise shift to the right on a <see cref="ulong"/> with wraparound.
         * <para>The <paramref name="positions"/> parameter is clamped to the range
         * 0 to 63 inclusive.</para></summary>
         * <param name="number">The value to shift.</param>
         * <param name="positions">How many positions to shift.</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static ulong BitShiftRight(ulong number, ulong positions)
        {
            // Ensure: 0 <= positions <= 63
            positions = positions.Clamp(0, Bits64 - 1);
            int intPos = (int)positions;
            
            // Preserve the bits to be discarded
            ulong wrapped = number << (Bits64 - intPos);
            // Shift and wrap the discarded bits
            return (number >> intPos) | wrapped;
        }
        #endregion


        #region BitShiftLeft
        /**
         * <summary>Performs a bitwise shift to the left on a <see cref="sbyte"/> with wraparound.
         * <para>The <paramref name="positions"/> parameter is clamped to the range
         * 0 to 7 inclusive.</para></summary>
         * <param name="number">The value to shift.</param>
         * <param name="positions">How many positions to shift.</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static sbyte BitShiftLeft(sbyte number, sbyte positions)
        {
            // Ensure: 0 <= positions <= 7
            positions = positions.Clamp(0, Bits8 - 1);

            // Save the bit pattern in a 32-bit unsigned int
            uint number32 = (byte)number;
            // Preserve the bits to be discarded
            uint wrapped = number32 >> (Bits8 - positions);
            // Shift and wrap the discarded bits
            return (sbyte)((number32 << positions) | wrapped);
        }


        /**
         * <summary>Performs a bitwise shift to the left on a <see cref="byte"/> with wraparound.
         * <para>The <paramref name="positions"/> parameter is clamped to the range
         * 0 to 7 inclusive.</para></summary>
         * <param name="number">The value to shift.</param>
         * <param name="positions">How many positions to shift.</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static byte BitShiftLeft(byte number, byte positions)
        {
            // Ensure: 0 <= positions <= 7
            positions = positions.Clamp(0, Bits8 - 1);

            // Save the bit pattern in a 32-bit unsigned int
            uint number32 = number;
            // Preserve the bits to be discarded
            uint wrapped = number32 >> (Bits8 - positions);
            // Shift and wrap the discarded bits
            return (byte)((number32 << positions) | wrapped);
        }


        /**
         * <summary>Performs a bitwise shift to the left on a <see cref="short"/> with wraparound.
         * <para>The <paramref name="positions"/> parameter is clamped to the range
         * 0 to 15 inclusive.</para></summary>
         * <param name="number">The value to shift.</param>
         * <param name="positions">How many positions to shift.</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static short BitShiftLeft(short number, short positions)
        {
            // Ensure: 0 <= positions <= 15
            positions = positions.Clamp(0, Bits16 - 1);

            // Save the bit pattern in a 32-bit unsigned int
            uint number32 = (ushort)number;
            // Preserve the bits to be discarded
            uint wrapped = number32 >> (Bits16 - positions);
            // Shift and wrap the discarded bits
            return (short)((number32 << positions) | wrapped);
        }


        /**
         * <summary>Performs a bitwise shift to the left on a <see cref="ushort"/> with wraparound.
         * <para>The <paramref name="positions"/> parameter is clamped to the range
         * 0 to 15 inclusive.</para></summary>
         * <param name="number">The value to shift.</param>
         * <param name="positions">How many positions to shift.</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static ushort BitShiftLeft(ushort number, ushort positions)
        {
            // Ensure: 0 <= positions <= 15
            positions = positions.Clamp(0, Bits16 - 1);

            // Save the bit pattern in a 32-bit unsigned int
            uint number32 = number;
            // Preserve the bits to be discarded
            int wrapped = number >> (Bits16 - positions);
            // Shift and wrap the discarded bits
            return (ushort)((number << positions) | wrapped);
        }


        /**
         * <summary>Performs a bitwise shift to the left on a <see cref="int"/> with wraparound.
         * <para>The <paramref name="positions"/> parameter is clamped to the range
         * 0 to 31 inclusive.</para></summary>
         * <param name="number">The value to shift.</param>
         * <param name="positions">How many positions to shift.</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static int BitShiftLeft(int number, int positions)
        {
            // Ensure: 0 <= positions <= 31
            positions = positions.Clamp(0, Bits32 - 1);

            // Save the bit pattern in an unsigned int
            uint number32 = (uint)number;
            // Preserve the bits to be discarded
            uint wrapped = number32 >> (Bits32 - positions);
            // Shift and wrap the discarded bits
            return (int)((number32 << positions) | wrapped);
        }


        /**
         * <summary>Performs a bitwise shift to the left on a <see cref="uint"/> with wraparound.
         * <para>The <paramref name="positions"/> parameter is clamped to the range
         * 0 to 31 inclusive.</para></summary>
         * <param name="number">The value to shift.</param>
         * <param name="positions">How many positions to shift.</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static uint BitShiftLeft(uint number, uint positions)
        {
            // Ensure: 0 <= positions <= 31
            positions = positions.Clamp(0, Bits32 - 1);
            int intPos = (int)positions;

            // Preserve the bits to be discarded
            uint wrapped = number >> (Bits32 - intPos);
            // Shift and wrap the discarded bits
            return (number << intPos) | wrapped;
        }


        /**
         * <summary>Performs a bitwise shift to the left on a <see cref="long"/> with wraparound.
         * <para>The <paramref name="positions"/> parameter is clamped to the range
         * 0 to 63 inclusive.</para></summary>
         * <param name="number">The value to shift.</param>
         * <param name="positions">How many positions to shift.</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static long BitShiftLeft(long number, long positions)
        {
            // Ensure: 0 <= positions <= 63
            positions = positions.Clamp(0, Bits64 - 1);
            int intPos = (int)positions;

            // Save the bit pattern in an unsigned int
            ulong number64 = (ulong)number;
            // Preserve the bits to be discarded
            ulong wrapped = number64 >> (Bits64 - intPos);
            // Shift and wrap the discarded bits
            return (long)((number64 << intPos) | wrapped);
        }


        /**
         * <summary>Performs a bitwise shift to the left on a <see cref="ulong"/> with wraparound.
         * <para>The <paramref name="positions"/> parameter is clamped to the range
         * 0 to 63 inclusive.</para></summary>
         * <param name="number">The value to shift.</param>
         * <param name="positions">How many positions to shift.</param>
         * <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2"/>
         */
        public static ulong BitShiftLeft(ulong number, ulong positions)
        {
            // Ensure: 0 <= positions <= 63
            positions = positions.Clamp(0, Bits64 - 1);
            int intPos = (int)positions;

            // Preserve the bits to be discarded
            ulong wrapped = number >> (Bits64 - intPos);
            // Shift and wrap the discarded bits
            return (number << intPos) | wrapped;
        }
        #endregion
    }
}
