using Codility.Checkers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckersTests
{
    [TestClass]
    public class BoardPatternsTest
    {
        /// <summary>
        /// Provided sample pattern 1
        /// </summary>
        [TestMethod]
        public void TestPattern1()
        {
            string[] B = new string[6];
            //      012345
            B[0] = "..X...";
            B[1] = "......";
            B[2] = "....X.";
            B[3] = ".X....";
            B[4] = "..X.X.";
            B[5] = "...O..";

            Solution gameOfCheckers = new Solution();
            int result = gameOfCheckers.solution(B);

            Assert.AreEqual(expected: 2, actual: result);
        }

        /// <summary>
        /// Provided sample pattern 2; beating opponent's pawn in downwards direction is disallowed due to test condition
        /// </summary>
        [TestMethod]
        public void TestPattern2()
        {
            string[] B = new string[5];
            //      01234
            B[0] = "X....";
            B[1] = ".X...";
            B[2] = "..O..";
            B[3] = "...X.";
            B[4] = ".....";

            Solution gameOfCheckers = new Solution();
            int result = gameOfCheckers.solution(B);

            Assert.AreEqual(expected: 0, actual: result);
        }

        /// <summary>
        /// Pattern tests whether the correct path is chosen
        /// </summary>
        [TestMethod]
        public void TestPattern3()
        {
            string[] B = new string[6];
            //      0123456
            B[0] = "..X...";
            B[1] = "......";
            B[2] = "....X.";
            B[3] = "......";
            B[4] = "..X.X.";
            B[5] = "...O..";

            Solution gameOfCheckers = new Solution();
            int result = gameOfCheckers.solution(B);

            Assert.AreEqual(expected: 2, actual: result);
        }

        /// <summary>
        /// Pattern tests extreme condition
        /// </summary>
        [TestMethod]
        public void TestPattern4()
        {
            string[] B = new string[1];
            //      0
            B[0] = "O";

            Solution gameOfCheckers = new Solution();
            int result = gameOfCheckers.solution(B);

            Assert.AreEqual(expected: 0, actual: result);
        }

        /// <summary>
        /// Pattern tests multiple path choices, best illustratated when pawn-beating move is allowed in all four directions (6 consecutive moves)
        /// </summary>
        [TestMethod]
        public void TestPattern5()
        {
            string[] B = new string[10];
            //      0123456789
            B[0] = "..........";
            B[1] = ".....X.X..";
            B[2] = "....X.....";
            B[3] = ".....X.X..";
            B[4] = "..........";
            B[5] = ".X...X.X..";
            B[6] = "..........";
            B[7] = ".X.X.X.X..";
            B[8] = "..O.......";
            B[9] = "...X......";
            //      0123456789

            Solution gameOfCheckers = new Solution();
            int result = gameOfCheckers.solution(B);

            Assert.AreEqual(expected: 4, actual: result);
        }
    }
}
