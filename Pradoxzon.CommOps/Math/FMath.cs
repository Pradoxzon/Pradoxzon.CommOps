/**
 * FMath.cs
 * 
 * Copyright (c) 2019 Pradoxzon Dev
 * 
 * Author: Shawn Peerenboom (Pradoxzon)
 * 
 * This class implements methods for performing calculations
 * on floating point numbers.
 */

namespace Pradoxzon.CommOps.Math
{
    using System;


    /**
     * <summary>Provides methods for performing calculations
     * on floating point numbers.</summary>
     */
    public static class FMath
    {
        #region Equals
        /**
         * <summary>Checks if two floating point numbers are equal
         * with a tollerance of 0.000000001.</summary>
         * <param name="left">The first float to compare.</param>
         * <param name="right">The second float to compare.</param>
         */
        public static bool Equals(float left, float right)
        {
            return Math.Abs(left - right) < 0.000000001f;
        }

        /**
         * <summary>Checks if two floating point numbers are equal
         * with a given tollerance.</summary>
         * <param name="left">The first float to compare.</param>
         * <param name="right">The second float to compare.</param>
         * <param name="tollerance">The tollerance to use when comparing.</param>
         */
        public static bool Equals(float left, float right, float tollerance)
        {
            return Math.Abs(left - right) < tollerance;
        }
        #endregion


        /**
         * <summary>Gets the square root of a number.</summary>
         * <param name="num">The number to get the square root of.</param>
         */
        public static float Sqrt(float num)
        {
            return (float)Math.Sqrt(num);
        }


        #region Round
        /**
         * <summary>Rounds a floating point number to the nearest integer value.</summary>
         * <param name="num">The number to round.</param>
         */
        public static float Round(float num)
        {
            return (float)Math.Round(num);
        }

        /**
         * <summary>Rounds a floating point number to the specified number of digits.</summary>
         * <param name="num">The number to round.</param>
         * <param name="decimals">The number of decimals to round to.</param>
         */
        public static float Round(float num, int decimals)
        {
            // TODO: Can this be simplified?
            //throw new NotImplementedException($"This function needs to be checked for functionality.");
            double dnum = Convert.ToDouble(Convert.ToDecimal(num));
            return (float)Math.Round(num, decimals);
        }
        #endregion
    }
}
