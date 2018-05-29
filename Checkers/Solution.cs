using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// A solution to a Codility game of checkers between Jafar and Aladdin.
/// Aladdin's pawns are marked with "X", Jafar's pawn is marked with "O".
/// Assume that Jafar has only single pawn on the board.
/// Returns maximum number of consecutive moves Jafar can make beating one of Aladdin’s pawns with each move.
/// </summary>
namespace Codility.Checkers
{
    // simulating Codility Solution class
    public class Solution
    {
        // _path string key will reflect a sequence of Jafar's pawn coordinate pairs within each path
        private Dictionary<string, int> _paths;
        private int _boardSize;

        // naming convention violation due to test condition
        public int solution(string[] B)
        {
            _paths = new Dictionary<string, int>();
            _boardSize = B.Length;

            // find Jafar
            int xJafar = -1;
            int yJafar = -1;

            for (int i = 0; i <= B.Length - 1; i++)
            {
                xJafar = B[i].IndexOf("O");
                if (xJafar > -1)
                {
                    yJafar = i;
                    break;
                }
            }

            // start walking and explore all paths recursively
            Move(B, xJafar, yJafar, string.Format("{0}, {1}", xJafar, yJafar));

            int maxMoves = 0;

            // get highest number of moves in a single path
            if (_paths.Count > 0)
            {
                KeyValuePair<string, int> longestPath = _paths.OrderByDescending(x => x.Value).First();
                maxMoves = longestPath.Value;
            }

            return maxMoves;
        }

        // make a move that consumes opponent's pawn
        private void Move(string[] board, int x, int y, string pathSignature)
        {
            string[] newBoard = new string[_boardSize];
            int newX = -1;
            int newY = -1;
            string newSignature;
            int movesMade = !string.IsNullOrEmpty(pathSignature) && _paths.ContainsKey(pathSignature) ? _paths[pathSignature] : 0;

            #region up-left direction
            if (x > 1 && y > 1
                && board[y - 1].Substring(x - 1, 1) == "X"
                && board[y - 2].Substring(x - 2, 1) == ".")
            {
                newX = x - 2;
                newY = y - 2;
                Array.Copy(board, newBoard, _boardSize);
                // remove Aladdin's checker
                newBoard[y - 1] = newBoard[y - 1].Remove(x - 1, 1).Insert(x - 1, ".");
                // move Jafar's checker
                newBoard[y] = newBoard[y].Remove(x, 1).Insert(x, ".");
                newBoard[newY] = newBoard[newY].Remove(newX, 1).Insert(newX, "O");
                // record path taken
                newSignature = string.Format("{0} > {1}, {2}", pathSignature, newX, newY);
                if (!_paths.ContainsKey(newSignature))
                    _paths.Add(newSignature, movesMade + 1);
                // make next move
                Move(newBoard, newX, newY, newSignature);
            }
            #endregion

            #region up-right direction
            if (x < _boardSize - 2 && y > 1
                && board[y - 1].Substring(x + 1, 1) == "X"
                && board[y - 2].Substring(x + 2, 1) == ".")
            {
                newX = x + 2;
                newY = y - 2;
                Array.Copy(board, newBoard, _boardSize);
                // remove Aladdin's checker
                newBoard[y - 1] = newBoard[y - 1].Remove(x + 1, 1).Insert(x + 1, ".");
                // move Jafar's checker
                newBoard[y] = newBoard[y].Remove(x, 1).Insert(x, ".");
                newBoard[newY] = newBoard[newY].Remove(newX, 1).Insert(newX, "O");
                // record path taken
                newSignature = string.Format("{0} > {1}, {2}", pathSignature, newX, newY);
                if (!_paths.ContainsKey(newSignature))
                    _paths.Add(newSignature, movesMade + 1);
                // make next move
                Move(newBoard, newX, newY, newSignature);
            }
            #endregion

            #region down-left direction
            /* direction is disabled due to test condition
            if (x > 1 && y < _boardSize - 2
                && board[y + 1].Substring(x - 1, 1) == "X"
                && board[y + 2].Substring(x - 2, 1) == ".")
            {
                newX = x - 2;
                newY = y + 2;
                Array.Copy(board, newBoard, _boardSize);
                // remove Aladdin's checker
                newBoard[y + 1] = newBoard[y + 1].Remove(x - 1, 1).Insert(x - 1, ".");
                // move Jafar's checker
                newBoard[y] = newBoard[y].Remove(x, 1).Insert(x, ".");
                newBoard[newY] = newBoard[newY].Remove(newX, 1).Insert(newX, "O");
                // record path taken
                newSignature = string.Format("{0} > {1}, {2}", pathSignature, newX, newY);
                if (!_paths.ContainsKey(newSignature))
                    _paths.Add(newSignature, movesMade + 1);
                // make next move
                Move(newBoard, newX, newY, newSignature);
            }
            */
            #endregion

            #region down-right direction
            /* direction is disabled due to test condition
            if (x < _boardSize - 2 && y < _boardSize - 2
                && board[y + 1].Substring(x + 1, 1) == "X"
                && board[y + 2].Substring(x + 2, 1) == ".")
            {
                newX = x + 2;
                newY = y + 2;
                Array.Copy(board, newBoard, _boardSize);
                // remove Aladdin's checker
                newBoard[y + 1] = newBoard[y + 1].Remove(x + 1, 1).Insert(x + 1, ".");
                // move Jafar's checker
                newBoard[y] = newBoard[y].Remove(x, 1).Insert(x, ".");
                newBoard[newY] = newBoard[newY].Remove(newX, 1).Insert(newX, "O");
                // record path taken
                newSignature = string.Format("{0} > {1}, {2}", pathSignature, newX, newY);
                if (!_paths.ContainsKey(newSignature))
                    _paths.Add(newSignature, movesMade + 1);
                // make next move
                Move(newBoard, newX, newY, newSignature);
            }
            */
            #endregion
        }
    }
}
