/**
 * FMathTest.cs
 * 
 * Copyright (c) 2019 Pradoxzon Dev
 * 
 * Author: Shawn Peerenbom (Pradoxzon)
 * 
 * Tests for the FMath class.
 * See Pradoxzon.CommOps.Math.FMath for the class implentation.
 */

namespace Pradoxzon.CommOps.Testing.Math
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using CommOps.Math;


    [TestClass]
    public class FMathTets
    {
        [TestMethod]
        public void TestFMathEquals()
        {
            float test1 = 3.14159f;
            float result1 = 3.14159f;
            Assert.IsTrue(FMath.Equals(result1, test1), $"The floats should be equal");

            float test2 = 0f;
            float result2A = 0.0000000009f;
            float result2B = -0.0000000009f;
            Assert.IsTrue(FMath.Equals(result2A, test2) && FMath.Equals(result2B, test2),
                $"The floats should be within tollerance");

            float test3 = 21.12345f;
            float toll3 = 0.00001f;
            float result3A = 21.12346f;
            float result3B = 21.123456789f;
            float result3C = 21.12343f;
            float result3D = 21.123441f;
            Assert.IsTrue(!FMath.Equals(result3A, test3, toll3)
                && FMath.Equals(result3B, test3, toll3)
                && !FMath.Equals(result3C, test3, toll3)
                && FMath.Equals(result3D, test3, toll3),
                $"The float equality checks should work with a given tollerance");
        }


        [TestMethod]
        public void TestFMathSqrt()
        {
            float test1 = 9f;
            float expected1 = 3f;
            Assert.IsTrue(expected1 == FMath.Sqrt(test1),
                $"The float should be a perfect square and come out with no decimal");

            float test2 = 16f;
            float expected2 = 4.01f;
            Assert.IsTrue(expected2 != FMath.Sqrt(test2),
                $"The float should have no value after the decimal");

            float test3 = 10.01f;
            float expected3 = 3.163858403f;
            Assert.IsTrue(FMath.Equals(expected3, FMath.Sqrt(test3)),
                $"The float should be the square root of the original value");
        }


        [TestMethod]
        public void TestFMathRound()
        {
            float test1 = 3.1486f;
            float expected1 = 3f;
            Assert.IsTrue(expected1 == FMath.Round(test1),
                $"The float should round down");

            float test2 = 77.777f;
            float expected2A = 78f;
            float expected2B = 77f;
            Assert.IsTrue(expected2A == FMath.Round(test2)
                && expected2B != FMath.Round(test2),
                $"The float should round up");

            float test3 = 30.163388f;
            int decim3 = 5;
            float expected3A = 30.16339f;
            float expected3B = 30.16338f;
            Assert.IsTrue(expected3A == FMath.Round(test3, decim3)
                && expected3B != FMath.Round(test3, decim3),
                $"The float should round to the nearest specified decimal place");

            float test4 = 0.555555f;
            int decim4 = 5;
            float expected4A = 0.55556f;
            float expected4B = 0.55555f;
            Assert.IsTrue(expected4A == FMath.Round(test4, decim4)
                && expected4B != FMath.Round(test4, decim4),
                $"The float should round up: {FMath.Round(test4, 5)}");
        }
    }
}
