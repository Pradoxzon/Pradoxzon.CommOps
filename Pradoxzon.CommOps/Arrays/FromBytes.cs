/**
 * FromBytes.cs
 * 
 * Copyright (c) 2019 Pradoxzon Dev
 * 
 * Author: Shawn Peerenboom (Pradoxzon)
 * 
 * This class implements extensions to byte arrays that
 * convert the arrays to other types.
 */

namespace Pradoxzon.CommOps.Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using static Math.BitMath;


    /**
     * <summary>Implements extensions to byte arrays that
     * convert the arrays to other types.</summary>
     */
    public static class FromBytes
    {
        #region Strings
        /**
         * <summary>Converts a byte array into an UTF-16 <see cref="string"/>.
         * <para>The array must be a multiple of 2 bytes long.</para></summary>
         * <param name="source">The byte array to convert into a <see cref="string"/>.</param>
         * <param name="isLittleEndian">A bool indicating if the source array
         * is stored in little endian.</param>
         * <exception cref="InvalidOperationException"></exception>
         */
        public static string GetString(this byte[] source, bool isLittleEndian = false)
        {
            // Only convert if the source array is length bytes
            if (source.Length % NumBytes16Bits != 0)
                ThrowArrayLengthException(
                    $"The array should contain a multiple of {NumBytes16Bits} bytes.");
            
            // Reverse the byte[]s if the system is Little Endian
            bool reverse = isLittleEndian ^ BitConverter.IsLittleEndian;

            // Build an array of chars from the byte array
            int numChars = source.Length / NumBytes16Bits;
            byte[] chBytes = new byte[NumBytes16Bits];
            char[] charAry = new char[numChars];
            for (int i = 0; i < numChars; i++)
            {
                chBytes[0] = source[i * 2];
                chBytes[1] = source[(i * 2) + 1];

                if (reverse) Array.Reverse(chBytes);

                charAry[i] = BitConverter.ToChar(chBytes, 0);
            }

            // Create an string from the char array and return the value
            return new string(charAry);
        }


        /**
         * <summary>Converts a byte array into a <see cref="List{T}"/>
         * of UTF-16 strings.</summary>
         * <param name="source">The byte array to convert into a
         * <see cref="List{T}"/>.</param>
         * <param name="isLittleEndian">A bool indicating if the source array
         * is stored in little endian.</param>
         * <exception cref="InvalidOperationException"></exception>
         */
        public static List<string> GetListString(this byte[] source, bool isLittleEndian = false)
        {
            var result = new List<string>();
            int readIndex = 0;

            // Get the number of strings in the byte array
            int numStrings = source.Subset(NumBytes32Bits).GetInt();
            readIndex += NumBytes32Bits;

            // Get all of the strings from the byte array
            int strLen = 0;
            for (int i = 0; i < numStrings; i++)
            {
                strLen = source.Subset(readIndex, NumBytes32Bits).GetInt();
                readIndex += NumBytes32Bits;

                result.Add(source.Subset(readIndex, strLen * 2).GetString());
                readIndex += strLen * 2;
            }

            // Return the list of strings
            return result;
        }
        #endregion


        #region Integers
        /**
         * <summary>Converts a byte array to a <see cref="sbyte"/>.
         * <para>The array must be 1 byte long.</para></summary>
         * <param name="source">The byte array to convert to a <see cref="sbyte"/>.</param>
         * <exception cref="InvalidOperationException"></exception>
         */
        public static sbyte GetSbyte(this byte[] source)
        {
            // Only convert if the source array is 1 byte
            if (source.Length != NumBytes8Bits)
            {
                ThrowArrayLengthException(NumBytes8Bits);
            }

            // Cast to a sbyte and return the value
            return (sbyte)source[0];
        }


        /**
         * <summary>Converts a byte array into a <see cref="short"/>.
         * <para>The array must be 2 bytes long.</para></summary>
         * <param name="source">The byte array to convert into a <see cref="short"/>.</param>
         * <param name="isLittleEndian">A bool indicating if the source array
         * is stored in little endian.</param>
         * <exception cref="InvalidOperationException"></exception>
         */
        public static short GetShort(this byte[] source, bool isLittleEndian = false)
        {
            // Create a short from the array and return the value
            return BitConverter.ToInt16(
                CopyCheck(source, NumBytes16Bits, isLittleEndian),
                0);
        }


        /**
         * <summary>Converts a byte array into an <see cref="ushort"/>.
         * <para>The array must be 2 bytes long.</para></summary>
         * <param name="source">The byte array to convert into an <see cref="ushort"/>.</param>
         * <param name="isLittleEndian">A bool indicating if the source array
         * is stored in little endian.</param>
         * <exception cref="InvalidOperationException"></exception>
         */
        public static ushort GetUshort(this byte[] source, bool isLittleEndian = false)
        {
            // Create an ushort from the array and return the value
            return BitConverter.ToUInt16(
                CopyCheck(source, NumBytes16Bits, isLittleEndian),
                0);
        }


        /**
         * <summary>Converts a byte array into an <see cref="int"/>.
         * <para>The array must be 4 bytes long.</para></summary>
         * <param name="source">The byte array to convert into an <see cref="int"/>.</param>
         * <param name="isLittleEndian">A bool indicating if the source array
         * is stored in little endian.</param>
         * <exception cref="InvalidOperationException"></exception>
         */
        public static int GetInt(this byte[] source, bool isLittleEndian = false)
        {
            // Create an int from the array and return the value
            return BitConverter.ToInt32(
                CopyCheck(source, NumBytes32Bits, isLittleEndian),
                0);
        }


        /**
         * <summary>Converts a byte array into an <see cref="uint"/>.
         * <para>The array must be 4 bytes long.</para></summary>
         * <param name="source">The byte array to convert into an <see cref="uint"/>.</param>
         * <param name="isLittleEndian">A bool indicating if the source array
         * is stored in little endian.</param>
         * <exception cref="InvalidOperationException"></exception>
         */
        public static uint GetUint(this byte[] source, bool isLittleEndian = false)
        {
            // Create an uint from the array and return the value
            return BitConverter.ToUInt32(
                CopyCheck(source, NumBytes32Bits, isLittleEndian),
                0);
        }


        /**
         * <summary>Converts a byte array into a <see cref="long"/>.
         * <para>The array must be 8 bytes long.</para></summary>
         * <param name="source">The byte array to convert into a <see cref="long"/>.</param>
         * <param name="isLittleEndian">A bool indicating if the source array
         * is stored in little endian.</param>
         * <exception cref="InvalidOperationException"></exception>
         */
        public static long GetLong(this byte[] source, bool isLittleEndian = false)
        {
            // Create a long from the array and return the value
            return BitConverter.ToInt64(
                CopyCheck(source, NumBytes64Bits, isLittleEndian),
                0);
        }


        /**
         * <summary>Converts a byte array into an <see cref="ulong"/>.
         * <para>The array must be 8 bytes long.</para></summary>
         * <param name="source">The byte array to convert into an <see cref="ulong"/>.</param>
         * <param name="isLittleEndian">A bool indicating if the source array
         * is stored in little endian.</param>
         * <exception cref="InvalidOperationException"></exception>
         */
        public static ulong GetUlong(this byte[] source, bool isLittleEndian = false)
        {
            // Create an ulong from the array and return the value
            return BitConverter.ToUInt64(
                CopyCheck(source, NumBytes64Bits, isLittleEndian),
                0);
        }
        #endregion


        #region Floats
        /**
         * <summary>Converts a byte array into an <see cref="float"/>.
         * <para>The array must be 4 bytes long.</para></summary>
         * <param name="source">The byte array to convert into an <see cref="float"/>.</param>
         * <param name="isLittleEndian">A bool indicating if the source array
         * is stored in little endian.</param>
         * <exception cref="InvalidOperationException"></exception>
         */
        public static float GetFloat(this byte[] source, bool isLittleEndian = false)
        {
            // Create an float from the array and return the value
            return BitConverter.ToSingle(
                CopyCheck(source, NumBytes32Bits, isLittleEndian),
                0);
        }


        /**
         * <summary>Converts a byte array into an <see cref="double"/>.
         * <para>The array must be 8 bytes long.</para></summary>
         * <param name="source">The byte array to convert into an <see cref="double"/>.</param>
         * <param name="isLittleEndian">A bool indicating if the source array
         * is stored in little endian.</param>
         * <exception cref="InvalidOperationException"></exception>
         */
        public static double GetDouble(this byte[] source, bool isLittleEndian = false)
        {
            // Create an double from the array and return the value
            return BitConverter.ToDouble(
                CopyCheck(source, NumBytes64Bits, isLittleEndian),
                0);
        }
        #endregion


        /**
         * <summary>Returns a checked and formatted copy of the source array for
         * use in the extension methods converting byte arrays to other types.</summary>
         * <param name="source">The original byte array.</param>
         * <param name="length">The length the source array should match.</param>
         * <param name="isLittleEndian">A bool indicating if the source array
         * is stored in little endian.</param>
         * <exception cref="InvalidOperationException"></exception>
         */
        private static byte[] CopyCheck(byte[] source, int length, bool isLittleEndian)
        {
            // Only convert if the source array is length bytes
            if (source.Length != length)
                ThrowArrayLengthException(length);

            // Create a copy of the array that we can modify
            var srcCopy = source.Subset(length);

            // Reverse the array if necessary
            if (isLittleEndian ^ BitConverter.IsLittleEndian)
                srcCopy.Reverse();
            
            // Return the copy of the array
            return srcCopy;
        }


        #region Exceptions
        /// <summary>Throws an <see cref="InvalidOperationException"/> for an array
        /// that was not the proper length.</summary>
        /// <param name="properLength">The length the array should have been.</param>
        /// <exception cref="InvalidOperationException"></exception>
        private static void ThrowArrayLengthException(int properLength)
        {
            throw new InvalidOperationException(
                $"The array should contain exactly {properLength} bytes.");
        }


        /// <summary>Throws an <see cref="InvalidOperationException"/> for an array
        /// that was not the proper length.</summary>
        /// <param name="message">The message for the exception.</param>
        /// <exception cref="InvalidOperationException"></exception>
        private static void ThrowArrayLengthException(string message)
        {
            throw new InvalidOperationException(message);
        }
        #endregion
    }
}
