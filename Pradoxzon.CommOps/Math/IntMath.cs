/**
 * IntMath.cs
 * 
 * Author: Pradoxzon
 * 
 * This class defines extensions to the base integer types
 * for common math operations.
 */

namespace Pradoxzon.CommOps.Math
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    /**
     * <summary>Defines extensions to the base integer types
     * for common math operations.</summary>
     */
    public static class IntMath
    {
        #region Round
        /// <summary>Round a <see cref="sbyte"/> to the specified increment.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="increment">The increment to round to.</param>
        public static sbyte Round(this sbyte num, sbyte increment)
        {
            increment = Math.Abs(increment);

            int remainder = Math.Abs(num % increment);
            float diff = remainder - (increment / 2.0f);

            return diff >= 0.0f
                ? (sbyte)((num > 0) ? num + (increment - remainder) : num - (increment - remainder))
                : (sbyte)((num > 0) ? num - remainder : num + remainder);
        }


        /// <summary>Round a <see cref="byte"/> to the specified increment.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="increment">The increment to round to.</param>
        public static byte Round(this byte num, byte increment)
        {
            int remainder = num % increment;
            float diff = remainder - (increment / 2.0f);

            return diff >= 0.0f
                ? (byte)(num + (increment - remainder))
                : (byte)(num - remainder);
        }


        /// <summary>Round a <see cref="short"/> to the specified increment.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="increment">The increment to round to.</param>
        public static short Round(this short num, short increment)
        {
            increment = Math.Abs(increment);

            int remainder = Math.Abs(num % increment);
            float diff = remainder - (increment / 2.0f);

            return diff >= 0.0f
                ? (short)((num > 0) ? num + (increment - remainder) : num - (increment - remainder))
                : (short)((num > 0) ? num - remainder : num + remainder);
        }


        /// <summary>Round a <see cref="ushort"/> to the specified increment.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="increment">The increment to round to.</param>
        public static ushort Round(this ushort num, ushort increment)
        {
            int remainder = num % increment;
            float diff = remainder - (increment / 2.0f);

            return diff >= 0.0f
                ? (ushort)(num + (increment - remainder))
                : (ushort)(num - remainder);
        }


        /// <summary>Round a <see cref="int"/> to the specified increment.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="increment">The increment to round to.</param>
        public static int Round(this int num, int increment)
        {
            increment = Math.Abs(increment);

            int remainder = Math.Abs(num % increment);
            float diff = remainder - (increment / 2.0f);

            return diff >= 0
                ? (num > 0) ? num + (increment - remainder) : num - (increment - remainder)
                : (num > 0) ? num - remainder : num + remainder;
        }


        /// <summary>Round a <see cref="uint"/> to the specified increment.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="increment">The increment to round to.</param>
        public static uint Round(this uint num, uint increment)
        {
            uint remainder = num % increment;
            float diff = remainder - (increment / 2.0f);

            return diff >= 0
                ? num + (increment - remainder)
                : num - remainder;
        }


        /// <summary>Round a <see cref="long"/> to the specified increment.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="increment">The increment to round to.</param>
        public static long Round(this long num, long increment)
        {
            increment = Math.Abs(increment);

            long remainder = Math.Abs(num % increment);
            double diff = remainder - (increment / 2.0);

            return diff >= 0
                ? (num > 0) ? num + (increment - remainder) : num - (increment - remainder)
                : (num > 0) ? num - remainder : num + remainder;
        }


        /// <summary>Round a <see cref="ulong"/> to the specified increment.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="increment">The increment to round to.</param>
        public static ulong Round(this ulong num, ulong increment)
        {
            ulong remainder = num % increment;
            double diff = remainder - (increment / 2.0);

            return diff >= 0
                ? num + (increment - remainder)
                : num - remainder;
        }
        #endregion


        #region Ceiling
        /// <summary>Rounds a <see cref="sbyte"/> up to the
        /// nearest multiple of the given value.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="val">The value to find a multiple of.</param>
        public static sbyte Ceiling(this sbyte num, sbyte val)
        {
            val = Math.Abs(val);

            int multiple = Math.Abs(num / val) + ((num > 0) ? 1 : 0);
            int remainder = Math.Abs(num % val);

            return remainder > 0
                ? (sbyte)((num > 0) ? val * multiple : val * -multiple)
                : num;
        }


        /// <summary>Rounds a <see cref="byte"/> up to the
        /// nearest multiple of the given value.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="val">The value to find a multiple of.</param>
        public static byte Ceiling(this byte num, byte val)
        {
            int multiple = (num / val) + 1;
            int remainder = num % val;

            return remainder > 0
                ? (byte)(val * multiple)
                : num;
        }


        /// <summary>Rounds a <see cref="short"/> up to the
        /// nearest multiple of the given value.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="val">The value to find a multiple of.</param>
        public static short Ceiling(this short num, short val)
        {
            val = Math.Abs(val);

            int multiple = Math.Abs(num / val) + ((num > 0) ? 1 : 0);
            int remainder = Math.Abs(num % val);

            return remainder > 0
                ? (short)((num > 0) ? val * multiple : val * -multiple)
                : num;
        }


        /// <summary>Rounds a <see cref="ushort"/> up to the
        /// nearest multiple of the given value.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="val">The value to find a multiple of.</param>
        public static ushort Ceiling(this ushort num, ushort val)
        {
            int multiple = (num / val) + 1;
            int remainder = num % val;

            return remainder > 0
                ? (ushort)(val * multiple)
                : num;
        }


        /// <summary>Rounds a <see cref="int"/> up to the
        /// nearest multiple of the given value.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="val">The value to find a multiple of.</param>
        public static int Ceiling(this int num, int val)
        {
            val = Math.Abs(val);

            int multiple = Math.Abs(num / val) + ((num > 0) ? 1 : 0);
            int remainder = Math.Abs(num % val);

            return remainder > 0
                ? (num > 0) ? val * multiple : val * -multiple
                : num;
        }


        /// <summary>Rounds a <see cref="uint"/> up to the
        /// nearest multiple of the given value.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="val">The value to find a multiple of.</param>
        public static uint Ceiling(this uint num, uint val)
        {
            uint multiple = (num / val) + 1;
            uint remainder = num % val;

            return remainder > 0
                ? val * multiple
                : num;
        }


        /// <summary>Rounds a <see cref="long"/> up to the
        /// nearest multiple of the given value.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="val">The value to find a multiple of.</param>
        public static long Ceiling(this long num, long val)
        {
            val = Math.Abs(val);

            long multiple = Math.Abs(num / val) + ((num > 0) ? 1 : 0);
            long remainder = Math.Abs(num % val);

            return remainder > 0
                ? (num > 0) ? val * multiple : val * -multiple
                : num;
        }


        /// <summary>Rounds a <see cref="ulong"/> up to the
        /// nearest multiple of the given value.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="val">The value to find a multiple of.</param>
        public static ulong Ceiling(this ulong num, ulong val)
        {
            ulong multiple = (num / val) + 1;
            ulong remainder = num % val;

            return remainder > 0
                ? val * multiple
                : num;
        }
        #endregion


        #region Floor
        /// <summary>Rounds a <see cref="sbyte"/> down to the
        /// nearest multiple of the given value.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="val">The value to find a multiple of.</param>
        public static sbyte Floor(this sbyte num, sbyte val)
        {
            val = Math.Abs(val);

            int multiple = Math.Abs(num / val) + ((num > 0) ? 0 : 1);
            int remainder = Math.Abs(num % val);

            return remainder > 0
                ? (sbyte)((num > 0) ? val * multiple : val * -multiple)
                : num;
        }


        /// <summary>Rounds a <see cref="byte"/> down to the
        /// nearest multiple of the given value.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="val">The value to find a multiple of.</param>
        public static byte Floor(this byte num, byte val)
        {
            int multiple = num / val;
            int remainder = num % val;

            return remainder > 0
                ? (byte)(val * multiple)
                : num;
        }


        /// <summary>Rounds a <see cref="short"/> down to the
        /// nearest multiple of the given value.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="val">The value to find a multiple of.</param>
        public static short Floor(this short num, short val)
        {
            val = Math.Abs(val);

            int multiple = Math.Abs(num / val) + ((num > 0) ? 0 : 1);
            int remainder = Math.Abs(num % val);

            return remainder > 0
                ? (short)((num > 0) ? val * multiple : val * -multiple)
                : num;
        }


        /// <summary>Rounds a <see cref="ushort"/> down to the
        /// nearest multiple of the given value.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="val">The value to find a multiple of.</param>
        public static ushort Floor(this ushort num, ushort val)
        {
            int multiple = num / val;
            int remainder = num % val;

            return remainder > 0
                ? (ushort)(val * multiple)
                : num;
        }


        /// <summary>Rounds a <see cref="int"/> down to the
        /// nearest multiple of the given value.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="val">The value to find a multiple of.</param>
        public static int Floor(this int num, int val)
        {
            val = Math.Abs(val);

            int multiple = Math.Abs(num / val) + ((num > 0) ? 0 : 1);
            int remainder = Math.Abs(num % val);

            return remainder > 0
                ? (num > 0) ? val * multiple : val * -multiple
                : num;
        }


        /// <summary>Rounds a <see cref="uint"/> down to the
        /// nearest multiple of the given value.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="val">The value to find a multiple of.</param>
        public static uint Floor(this uint num, uint val)
        {
            uint multiple = num / val;
            uint remainder = num % val;

            return remainder > 0
                ? val * multiple
                : num;
        }


        /// <summary>Rounds a <see cref="long"/> down to the
        /// nearest multiple of the given value.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="val">The value to find a multiple of.</param>
        public static long Floor(this long num, long val)
        {
            val = Math.Abs(val);

            long multiple = Math.Abs(num / val) + ((num > 0) ? 0 : 1);
            long remainder = Math.Abs(num % val);

            return remainder > 0
                ? (num > 0) ? val * multiple : val * -multiple
                : num;
        }


        /// <summary>Rounds a <see cref="ulong"/> down to the
        /// nearest multiple of the given value.</summary>
        /// <param name="num">The number to be rounded.</param>
        /// <param name="val">The value to find a multiple of.</param>
        public static ulong Floor(this ulong num, ulong val)
        {
            ulong multiple = num / val;
            ulong remainder = num % val;

            return remainder > 0
                ? val * multiple
                : num;
        }
        #endregion
    }
}
