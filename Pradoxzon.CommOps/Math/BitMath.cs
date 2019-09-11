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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


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
        #endregion



    }
}
