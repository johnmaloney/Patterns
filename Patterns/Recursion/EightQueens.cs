using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Recursion
{
    /// <summary>
    /// Given a chess board 8 x 8 with 8 Queens on the board can I place
    /// all the queens on the board with none being threatened.
    /// Queens can attack in straight line, horizontally, vertically and diagonally
    /// </summary>
    public class EightQueens
    {
        private readonly ChessBoard chessBoard;

        public EightQueens(ChessBoard board)
        {
            this.chessBoard = board;
        }

        public bool Solve(int column)
        {
            // Base case //
            if (column >= chessBoard.Columns)
                return true;

            for (int rowToTry = 0; rowToTry < chessBoard.Rows; rowToTry++)
            {
                if (chessBoard.IsSafe(column, rowToTry))
                {
                    chessBoard.PlaceQueen(column, rowToTry);

                    // Done ?? //
                    if (Solve(column + 1))
                        return true;

                    chessBoard.RemoveQueen(column, rowToTry);
                }
            }
            return false;
        }
    }

    [System.Runtime.InteropServices.Guid("92C70B78-8B5F-4472-BF6C-3B632D275B86")]
    public class ChessBoard
    {
        private bool[,] board;
        private readonly int columns;
        private readonly int rows;

        public int Columns { get { return columns; } }

        public int Rows { get { return rows; } }

        public ChessBoard(int columnsCount, int rowsCount)
        {
            columns = columnsCount;
            rows = rowsCount;

            board = new bool[columnsCount, rowsCount];
        }

        public bool IsSafe(int columnIndex, int rowIndex)
        {
            try
            {
                // in the single case where the board is clean //
                if (this.boardIsBlank())
                    return true;

                // Go back through the columns of this row I am currently on //
                for (int currColumnIndex = 0; 
                    currColumnIndex < Columns; 
                    currColumnIndex++)
                {
                    // if there are any trues (i.e. Queens) fail //
                    if (board[currColumnIndex, rowIndex])
                        return false;
                }

                // check each row and column for other queens //
                for (int currRowIndex = 0;
                    currRowIndex < Rows;
                    currRowIndex++)
                {
                    // if there are any trues (i.e. Queens) fail //
                    if (board[columnIndex, currRowIndex])
                        return false;
                }

                // Upper Left Diagonal Check END is y == 0//
                if(rowIndex > 0)
                {
                    int currRowIndex = rowIndex;
                    int currColumnIndex = columnIndex;

                    // Upper Left Diagonal Check END is y == 0 or x == 0//
                    while (currRowIndex > -1 && currColumnIndex > -1)
                    {
                        if (this.board[currColumnIndex, currRowIndex])
                            return false;

                        // When moving Upper Left the equation is //
                        // x-1 and y-1
                        currRowIndex--;
                        currColumnIndex--;
                    }

                    // RESET //
                    currRowIndex = rowIndex;
                    currColumnIndex = columnIndex;

                    // Upper Left Diagonal Check END is x == Rows Count//
                    while (currRowIndex != -1 && currColumnIndex < Columns)
                    {
                        if (this.board[currColumnIndex, currRowIndex])
                            return false;

                        // When moving Upper Right the equation is //
                        // x+1 and y-1, the intent is to get to the last column //
                        currRowIndex--;
                        currColumnIndex++;
                    } 
                }
            }
            catch (Exception)
            {
                throw;
            }


            return true;
        }

        public void PlaceQueen(int columnIndex, int rowIndex)
        {
            this.board[columnIndex, rowIndex] = true;
        }

        public void RemoveQueen(int columnIndex, int rowIndex)
        {
            this.board[columnIndex, rowIndex] = false;
        }

        public void ClearBoard()
        {
            this.board = new bool[Columns, Rows];
        }

        private bool boardIsBlank()
        {
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (this.board[i, j])
                        return false;
                }
            }
            return true;
        }
    }
}
