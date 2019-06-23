using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets the solution to a Sudoku board
        /// </summary>
        /// <param name="board">Int[,]</param>
        /// <param name="availableBoard">List<int>[,]</param>
        /// <returns>The solution to a Sudoku board</returns>
        static int[,] getSudokuSolution(int[,] board, List<int>[,] availableBoard)
        {
            if (isSudokuComplete(board)) return board;
            Tuple<int, int> firstAvailable = getSudokuFirstAvailable(board);
            int r = firstAvailable.Item1;
            int c = firstAvailable.Item2;
            foreach (int i in availableBoard[r, c])
            {
                board[r, c] = i;
                if (isSudokuValid(board))
                {
                    int[,] currentBoard = getSudokuSolution(board, availableBoard);
                    if (isSudokuComplete(board)) return currentBoard;
                }
                board[r, c] = 0;
            }
            return board;
        }

        /// <summary>
        /// Determines if a Sudoku board is complete
        /// </summary>
        /// <param name="board">Int[,]</param>
        /// <returns>True if a Sudoku board is complete</returns>
        static bool isSudokuComplete(int[,] board)
        {
            for (int r = 0; r < board.GetLength(0); r++)
                for (int c = 0; c < board.GetLength(1); c++)
                    if (board[r, c] == 0)
                        return false;
            return true;
        }

        /// <summary>
        /// Gets the first available cell in a Sudoku board
        /// </summary>
        /// <param name="board">Int[,]</param>
        /// <returns>The first available cell in a Sudoku board</returns>
        static Tuple<int, int> getSudokuFirstAvailable(int[,] board)
        {
            for (int r = 0; r < board.GetLength(0); r++)
                for (int c = 0; c < board.GetLength(1); c++)
                    if (board[r, c] == 0)
                        return Tuple.Create(r, c);
            throw new System.ArgumentException("Input board has no available cells");
        }

        /// <summary>
        /// Determines if a Sudoku board is valid
        /// </summary>
        /// <param name="board">Int[,]</param>
        /// <returns>True if a Sudoku board is valid</returns>
        static bool isSudokuValid(int[,] board)
        {
            return isSudokuRowsValid(board) && isSudokuColsValid(board) && isSudokuBlocksValid(board);
        }

        /// <summary>
        /// Determines if a Sudoku board contains valid rows
        /// </summary>
        /// <param name="board">Int[,]</param>
        /// <returns>True if a Sudoku board contains valid rows</returns>
        static bool isSudokuRowsValid(int[,] board)
        {
            for (int r = 0; r < board.GetLength(0); r++)
                if (Functions.hasDuplicates(Functions.GetArrayRow(board, r), new int[] { 0 }))
                    return false;
            return true;
        }

        /// <summary>
        /// Determines if a Sudoku board contains valid columns
        /// </summary>
        /// <param name="board">Int[,]</param>
        /// <returns>True if a Sudoku board contains valid columns</returns>
        static bool isSudokuColsValid(int[,] board)
        {
            for (int c = 0; c < board.GetLength(1); c++)
                if (Functions.hasDuplicates(Functions.GetArrayColumn(board, c), new int[] { 0 }))
                    return false;
            return true;
        }

        /// <summary>
        /// Determines if a Sudoku board contains valid blocks
        /// </summary>
        /// <param name="board">Int[,]</param>
        /// <returns>True if a Sudoku board contains valid blocks</returns>
        static bool isSudokuBlocksValid(int[,] board)
        {
            for (int r = 0; r < 9; r += 3)
                for (int c = 0; c < 9; c += 3)
                {
                    List<int> block = new List<int>();
                    for (int a = 0; a < 3; a++)
                        for (int b = 0; b < 3; b++)
                            block.Add(board[r + a, c + b]);
                    if (Functions.hasDuplicates(block.ToArray(), new int[] { 0 }))
                        return false;
                }
            return true;
        }

        /// <summary>
        /// Updates a Sudoku board and an available Sudoku board
        /// </summary>
        /// <param name="board">Int[,]</param>
        /// <param name="availableBoard">List<int>[,]</param>
        static void updateSudokuBoards(int[,] board, List<int>[,] availableBoard)
        {
            for (int r = 0; r < board.GetLength(0); r++)
                for (int c = 0; c < board.GetLength(1); c++)
                    if (board[r, c] != 0)
                    {
                        removeSudokuAvailableRow(board[r, c], r, availableBoard);
                        removeSudokuAvailableCol(board[r, c], c, availableBoard);
                        removeSudokuAvailableBlock(board[r, c], r, c, availableBoard);
                        availableBoard[r, c] = new List<int>();
                    }
            for (int r = 0; r < availableBoard.GetLength(0); r++)
                for (int c = 0; c < availableBoard.GetLength(1); c++)
                    if (availableBoard[r, c].Count == 1)
                    {
                        board[r, c] = availableBoard[r, c][0];
                        availableBoard[r, c] = new List<int>();
                        updateSudokuBoards(board, availableBoard);
                    }
        }

        /// <summary>
        /// Removes numbers from a row of an available Sudoku board
        /// </summary>
        /// <param name="number">Int</param>
        /// <param name="rowIndex">Int</param>
        /// <param name="availableBoard">List<int>[,]</param>
        static void removeSudokuAvailableRow(int number, int rowIndex, List<int>[,] availableBoard)
        {
            for (int i = 0; i < 9; i++)
                if (availableBoard[rowIndex, i].Contains(number))
                    availableBoard[rowIndex, i].Remove(number);
        }

        /// <summary>
        /// Removes numbers from a column of an available Sudoku board
        /// </summary>
        /// <param name="number">Int</param>
        /// <param name="colIndex">Int</param>
        /// <param name="availableBoard"></param>
        static void removeSudokuAvailableCol(int number, int colIndex, List<int>[,] availableBoard)
        {
            for (int i = 0; i < 9; i++)
                if (availableBoard[i, colIndex].Contains(number))
                    availableBoard[i, colIndex].Remove(number);
        }

        /// <summary>
        /// Removes numbers from a block of an available Sudoku board
        /// </summary>
        /// <param name="number">Int</param>
        /// <param name="rowIndex">Int</param>
        /// <param name="colIndex">Int</param>
        /// <param name="availableBoard">List<int>[,]</param>
        static void removeSudokuAvailableBlock(int number, int rowIndex, int colIndex, List<int>[,] availableBoard)
        {
            int r = 0;
            int c = 0;
            while (rowIndex - 3 >= 0)
            {
                r += 3;
                rowIndex -= 3;
            }
            while (colIndex - 3 >= 0)
            {
                c += 3;
                colIndex -= 3;
            }
            for (int a = 0; a < 3; a++)
                for (int b = 0; b < 3; b++)
                    if (availableBoard[r + a, c + b].Contains(number))
                        availableBoard[r + a, c + b].Remove(number);
        }

        /// <summary>
        /// Gets the Sudoku board from a text file
        /// </summary>
        /// <param name="sudoku">Int[,]</param>
        /// <param name="sudokuFile">StreamReader</param>
        static void ReadSudoku(int[,] sudoku, StreamReader sudokuFile)
        {
            for (int i = 0; i < 9; i++)
            {
                string line = sudokuFile.ReadLine();
                for (int j = 0; j < line.Length; j++)
                    sudoku[i, j] = line[j] - '0';
            }
        }

        /// <summary>
        /// Prints the Sudoku board
        /// </summary>
        /// <param name="sudoku">Int[,]</param>
        static void PrintSudoku(int[,] sudoku)
        {
            for (int r = 0; r < sudoku.GetLength(0); r++)
                Console.WriteLine(String.Join(",", Functions.GetArrayRow(sudoku, r)));
            Console.WriteLine();
        }

        /// <summary>
        /// Calculates the sum of the 3-digit numbers found in the top left corner of each sudoku solution grid
        /// </summary>
        static void P096()
        {
            int ans = 0;
            List<int[,]> sudokus = new List<int[,]>();
            List<int>[,] availableBoardBase = new List<int>[9, 9];
            for (int r = 0; r < availableBoardBase.GetLength(0); r++)
                for (int c = 0; c < availableBoardBase.GetLength(1); c++)
                    availableBoardBase[r, c] = Enumerable.Range(1, 9).ToList();
            using (var sudokuFile = File.OpenText(@"...\...\Resources\p096_sudoku.txt"))
            {
                int[,] sudokuBoard = new int[9, 9];
                while (sudokuFile.ReadLine() != null)
                {
                    ReadSudoku(sudokuBoard, sudokuFile);
                    List<int>[,] availableBoard = Functions.getDeepCopy<List<int>[,]>(availableBoardBase);
                    updateSudokuBoards(sudokuBoard, availableBoard);
                    int[,] solution = getSudokuSolution(sudokuBoard, availableBoard);
                    //PrintSudoku(solution);
                    ans += solution[0, 0] * 100 + solution[0, 1] * 10 + solution[0, 2];
                }
            }
            Console.WriteLine(ans);
        }
    }
}