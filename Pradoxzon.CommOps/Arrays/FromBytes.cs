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
        // Get string LE and BE

        // Get List<string> LE and BE
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
         * <summary>Converts a byte array to a <see cref="short"/>.
         * <para>The array must be 2 bytes long.</para></summary>
         * <param name="source">The byte array to convert to a <see cref="short"/>.</param>
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
         * <summary>Converts a byte array to a <see cref="ushort"/>.
         * <para>The array must be 2 bytes long.</para></summary>
         * <param name="source">The byte array to convert to a <see cref="ushort"/>.</param>
         * <param name="isLittleEndian">A bool indicating if the source array
         * is stored in little endian.</param>
         * <exception cref="InvalidOperationException"></exception>
         */
        public static ushort GetUshort(this byte[] source, bool isLittleEndian = false)
        {
            // Create a ushort from the array and return the value
            return BitConverter.ToUInt16(
                CopyCheck(source, NumBytes16Bits, isLittleEndian),
                0);
        }
        #endregion


        #region Floats
        // Get float LE and BE

        // Get double LE and BE
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
