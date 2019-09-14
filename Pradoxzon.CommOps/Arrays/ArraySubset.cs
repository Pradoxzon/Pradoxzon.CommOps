

namespace Pradoxzon.CommOps.Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public static class ArraySubset
    {
        /**
         * <summary>Creates an array from a source array using
         * <see cref="Array.Copy(Array, int, Array, int, int)"/>.
         * <para>The resulting array is returned by the function instead of
         * being passed in as a parameter.</para></summary>
         * <param name="source">The array to copy from.</param>
         * <param name="index">The index to start copying from.</param>
         * <param name="length">The number of elements to copy.</param>
         * <exception cref="ArgumentNullException"></exception>
         * <exception cref="RankException"></exception>
         * <exception cref="ArgumentOutOfRangeException"></exception>
         * <exception cref="ArgumentException"></exception>
         */
        public static T[] Subset<T>(this T[] source, int index, int length)
        {
            var result = new T[length];
            Array.Copy(source, index, result, 0, length);
            return result;
        }
    }
}
