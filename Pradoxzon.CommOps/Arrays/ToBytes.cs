/**
 * ToBytes.cs
 * 
 * Copyright (c) 2019 Pradoxzon Dev
 * 
 * Author: Shawn Peerenboom (Pradoxzon)
 * 
 * This class implements extensions to base types
 * to convert them to byte arrays.
 */

namespace Pradoxzon.CommOps.Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    /**
     * <summary>Implements extensions to base types
     * to convert them to byte arrays.</summary>
     */
    public static class ToBytes
    {
        #region Strings
        /**
         * <summary>Converts a <see cref="string"/> into
         * a <see cref="byte"/>[] whose length is twice the
         * length of the string.</summary>
         * <param name="str">The string to convert to a <see cref="byte"/>[].</param>
         * <param name="resultLittleEndian">A bool indicating if the resulting array
         * should be stored in little endian.</param>
         */
        public static byte[] GetBytes(this string str, bool resultLittleEndian = false)
        {
            // Check if we need to reverse the arrays
            bool reverse = resultLittleEndian ^ BitConverter.IsLittleEndian;

            // Array to hold the final string and array to hold each char
            byte[] stringAsBytes = new byte[str.Length * 2];
            byte[] charAry = new byte[2];

            // Loop over each char in the array
            for (int i = 0; i < str.Length; i++)
            {
                charAry = BitConverter.GetBytes(str[i]);
                if (reverse) Array.Reverse(charAry);
                stringAsBytes[i * 2] = charAry[0];
                stringAsBytes[(i * 2) + 1] = charAry[1];
            }

            return stringAsBytes;
        }


        /**
         * <summary>Converts a <see cref="List{}"/> into
         * a <see cref="byte"/>[]. whose length is twice the
         * length of the string.</summary>
         * <param name="strList">The list of strings to convert to a <see cref="byte"/>[].</param>
         * <param name="resultLittleEndian">A bool indicating if the resulting array
         * should be stored in little endian.</param>
         */
        public static byte[] GetBytes(this List<string> strList, bool resultLittleEndian = false)
        {
            var bList = new List<byte>();

            // Add the number of strings
            bList.AddRange(strList.Count.GetBytes(resultLittleEndian));

            // Add the length of each string and the string itself
            foreach (var str in strList)
            {
                bList.AddRange(str.Length.GetBytes(resultLittleEndian));
                bList.AddRange(str.GetBytes(resultLittleEndian));
            }

            //return bList.ToArray();

            return strList.Count.GetBytes(resultLittleEndian).Concat(
                strList.SelectMany(
                    x =>
                    x.Length.GetBytes(resultLittleEndian).Concat(
                        x.GetBytes(resultLittleEndian)
                        ).ToArray()
                    ).ToArray()
                ).ToArray();
        }
        #endregion


        #region Integers
        /**
         * <summary>Converts a <see cref="sbyte"/> into
         * a <see cref="byte"/>[] with 1 element.</summary>
         * <param name="num">The sbyte to convert to a <see cref="byte"/>[].</param>
         */
        public static byte[] GetBytes(this sbyte num)
        {
            return new byte[] { (byte)num };
        }


        /**
         * <summary>Converts a <see cref="short"/> into
         * a <see cref="byte"/>[] with 2 elements.</summary>
         * <param name="num">The short to convert to a <see cref="byte"/>[].</param>
         * <param name="resultLittleEndian">A bool indicating if the resulting array
         * should be stored in little endian.</param>
         */
        public static byte[] GetBytes(this short num, bool resultLittleEndian = false)
        {
            // Get a byte array representation of the number
            var numAsBytes = BitConverter.GetBytes(num);

            // Reverse the array if necessary
            if (resultLittleEndian ^ BitConverter.IsLittleEndian)
                Array.Reverse(numAsBytes);

            // Return the array
            return numAsBytes;
        }


        /**
         * <summary>Converts an <see cref="ushort"/> into
         * a <see cref="byte"/>[] with 2 elements.</summary>
         * <param name="num">The ushort to convert to a <see cref="byte"/>[].</param>
         * <param name="resultLittleEndian">A bool indicating if the resulting array
         * should be stored in little endian.</param>
         */
        public static byte[] GetBytes(this ushort num, bool resultLittleEndian = false)
        {
            // Get a byte array representation of the number
            var numAsBytes = BitConverter.GetBytes(num);

            // Reverse the array if necessary
            if (resultLittleEndian ^ BitConverter.IsLittleEndian)
                Array.Reverse(numAsBytes);

            // Return the array
            return numAsBytes;
        }


        /**
         * <summary>Converts an <see cref="int"/> into
         * a <see cref="byte"/>[] with 4 elements.</summary>
         * <param name="num">The int to convert to a <see cref="byte"/>[].</param>
         * <param name="resultLittleEndian">A bool indicating if the resulting array
         * should be stored in little endian.</param>
         */
        public static byte[] GetBytes(this int num, bool resultLittleEndian = false)
        {
            // Get a byte array representation of the number
            var numAsBytes = BitConverter.GetBytes(num);

            // Reverse the array if necessary
            if (resultLittleEndian ^ BitConverter.IsLittleEndian)
                Array.Reverse(numAsBytes);

            // Return the array
            return numAsBytes;
        }


        /**
         * <summary>Converts an <see cref="uint"/> into
         * a <see cref="byte"/>[] with 4 elements.</summary>
         * <param name="num">The uint to convert to a <see cref="byte"/>[].</param>
         * <param name="resultLittleEndian">A bool indicating if the resulting array
         * should be stored in little endian.</param>
         */
        public static byte[] GetBytes(this uint num, bool resultLittleEndian = false)
        {
            // Get a byte array representation of the number
            var numAsBytes = BitConverter.GetBytes(num);

            // Reverse the array if necessary
            if (resultLittleEndian ^ BitConverter.IsLittleEndian)
                Array.Reverse(numAsBytes);

            // Return the array
            return numAsBytes;
        }


        /**
         * <summary>Converts a <see cref="long"/> into
         * a <see cref="byte"/>[] with 8 elements.</summary>
         * <param name="num">The long to convert to a <see cref="byte"/>[].</param>
         * <param name="resultLittleEndian">A bool indicating if the resulting array
         * should be stored in little endian.</param>
         */
        public static byte[] GetBytes(this long num, bool resultLittleEndian = false)
        {
            // Get a byte array representation of the number
            var numAsBytes = BitConverter.GetBytes(num);

            // Reverse the array if necessary
            if (resultLittleEndian ^ BitConverter.IsLittleEndian)
                Array.Reverse(numAsBytes);

            // Return the array
            return numAsBytes;
        }


        /**
         * <summary>Converts an <see cref="ulong"/> into
         * a <see cref="byte"/>[] with 8 elements.</summary>
         * <param name="num">The ulong to convert to a <see cref="byte"/>[].</param>
         * <param name="resultLittleEndian">A bool indicating if the resulting array
         * should be stored in little endian.</param>
         */
        public static byte[] GetBytes(this ulong num, bool resultLittleEndian = false)
        {
            // Get a byte array representation of the number
            var numAsBytes = BitConverter.GetBytes(num);

            // Reverse the array if necessary
            if (resultLittleEndian ^ BitConverter.IsLittleEndian)
                Array.Reverse(numAsBytes);

            // Return the array
            return numAsBytes;
        }
        #endregion


        #region Floats
        /**
         * <summary>Converts a <see cref="float"/> into
         * a <see cref="byte"/>[] with 4 elements.</summary>
         * <param name="num">The float to convert to a <see cref="byte"/>[].</param>
         * <param name="resultLittleEndian">A bool indicating if the resulting array
         * should be stored in little endian.</param>
         */
        public static byte[] GetBytes(this float num, bool resultLittleEndian = false)
        {
            // Get a byte array representation of the number
            var numAsBytes = BitConverter.GetBytes(num);

            // Reverse the array if necessary
            if (resultLittleEndian ^ BitConverter.IsLittleEndian)
                Array.Reverse(numAsBytes);

            // Return the array
            return numAsBytes;
        }


        /**
         * <summary>Converts a <see cref="double"/> into
         * a <see cref="byte"/>[] with 8 elements.</summary>
         * <param name="num">The double to convert to a <see cref="byte"/>[].</param>
         * <param name="resultLittleEndian">A bool indicating if the resulting array
         * should be stored in little endian.</param>
         */
        public static byte[] GetBytes(this double num, bool resultLittleEndian = false)
        {
            // Get a byte array representation of the number
            var numAsBytes = BitConverter.GetBytes(num);

            // Reverse the array if necessary
            if (resultLittleEndian ^ BitConverter.IsLittleEndian)
                Array.Reverse(numAsBytes);

            // Return the array
            return numAsBytes;
        }
        #endregion
    }
}
