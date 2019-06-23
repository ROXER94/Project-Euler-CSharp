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
        /// <param name="candidateBoard">List<int>[,]</param>
        /// <returns>The solution to a Sudoku board</returns>
        static int[,] getSudokuSolution(int[,] board, List<int>[,] candidateBoard)
        {
            if (isSudokuComplete(board)) return board;
            Tuple<int, int> firstAvailableCell = getSudokuFirstAvailableCell(board);
            int r = firstAvailableCell.Item1;
            int c = firstAvailableCell.Item2;
            foreach (int i in candidateBoard[r, c])
            {
                board[r, c] = i;
                if (isSudokuValid(board))
                {
                    int[,] currentBoard = getSudokuSolution(board, candidateBoard);
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
        static Tuple<int, int> getSudokuFirstAvailableCell(int[,] board)
        {
            for (int r = 0; r < board.GetLength(0); r++)
                for (int c = 0; c < board.GetLength(1); c++)
                    if (board[r, c] == 0)
                        return Tuple.Create(r, c);
            throw new System.ArgumentException("Sudoku board has no available cells");
        }

        /// <summary>
        /// Determines if a Sudoku board is valid
        /// </summary>
        /// <param name="board">Int[,]</param>
        /// <returns>True if a Sudoku board is valid</returns>
        static bool isSudokuValid(int[,] board)
        {
            return isSudokuRowsValid(board) && isSudokuColumnsValid(board) && isSudokuBlocksValid(board);
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
        static bool isSudokuColumnsValid(int[,] board)
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
        /// Updates a Sudoku board and a candidate Sudoku board
        /// </summary>
        /// <param name="board">Int[,]</param>
        /// <param name="candidateBoard">List<int>[,]</param>
        static void updateSudokuBoards(int[,] board, List<int>[,] candidateBoard)
        {
            for (int r = 0; r < board.GetLength(0); r++)
                for (int c = 0; c < board.GetLength(1); c++)
                    if (board[r, c] != 0)
                    {
                        removeSudokuCandidateRow(board[r, c], r, candidateBoard);
                        removeSudokuCandidateColumn(board[r, c], c, candidateBoard);
                        removeSudokuCandidateBlock(board[r, c], r, c, candidateBoard);
                        candidateBoard[r, c] = new List<int>();
                    }
            for (int r = 0; r < candidateBoard.GetLength(0); r++)
                for (int c = 0; c < candidateBoard.GetLength(1); c++)
                    if (candidateBoard[r, c].Count == 1)
                    {
                        board[r, c] = candidateBoard[r, c][0];
                        candidateBoard[r, c] = new List<int>();
                        updateSudokuBoards(board, candidateBoard);
                    }
        }

        /// <summary>
        /// Removes numbers from a row of a candidate Sudoku board
        /// </summary>
        /// <param name="number">Int</param>
        /// <param name="rowIndex">Int</param>
        /// <param name="candidateBoard">List<int>[,]</param>
        static void removeSudokuCandidateRow(int number, int rowIndex, List<int>[,] candidateBoard)
        {
            for (int i = 0; i < 9; i++)
                if (candidateBoard[rowIndex, i].Contains(number))
                    candidateBoard[rowIndex, i].Remove(number);
        }

        /// <summary>
        /// Removes numbers from a column of a candidate Sudoku board
        /// </summary>
        /// <param name="number">Int</param>
        /// <param name="colIndex">Int</param>
        /// <param name="candidateBoard">List<int>[,]</param>
        static void removeSudokuCandidateColumn(int number, int columnIndex, List<int>[,] candidateBoard)
        {
            for (int i = 0; i < 9; i++)
                if (candidateBoard[i, columnIndex].Contains(number))
                    candidateBoard[i, columnIndex].Remove(number);
        }

        /// <summary>
        /// Removes numbers from a block of a candidate Sudoku board
        /// </summary>
        /// <param name="number">Int</param>
        /// <param name="rowIndex">Int</param>
        /// <param name="colIndex">Int</param>
        /// <param name="candidateBoard">List<int>[,]</param>
        static void removeSudokuCandidateBlock(int number, int rowIndex, int columnIndex, List<int>[,] candidateBoard)
        {
            int r = 0;
            int c = 0;
            while (rowIndex - 3 >= 0)
            {
                r += 3;
                rowIndex -= 3;
            }
            while (columnIndex - 3 >= 0)
            {
                c += 3;
                columnIndex -= 3;
            }
            for (int a = 0; a < 3; a++)
                for (int b = 0; b < 3; b++)
                    if (candidateBoard[r + a, c + b].Contains(number))
                        candidateBoard[r + a, c + b].Remove(number);
        }

        /// <summary>
        /// Gets a Sudoku board from a text file
        /// </summary>
        /// <param name="sudoku">Int[,]</param>
        /// <param name="sudokuFile">StreamReader</param>
        static void readSudokuBoard(int[,] sudoku, StreamReader sudokuFile)
        {
            for (int i = 0; i < 9; i++)
            {
                string line = sudokuFile.ReadLine();
                for (int j = 0; j < line.Length; j++)
                    sudoku[i, j] = line[j] - '0';
            }
        }

        /// <summary>
        /// Prints a Sudoku board
        /// </summary>
        /// <param name="sudoku">Int[,]</param>
        static void printSudoku(int[,] sudoku)
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
            List<int>[,] candidateBoardBase = new List<int>[9, 9];
            for (int r = 0; r < candidateBoardBase.GetLength(0); r++)
                for (int c = 0; c < candidateBoardBase.GetLength(1); c++)
                    candidateBoardBase[r, c] = Enumerable.Range(1, 9).ToList();
            using (var sudokuFile = File.OpenText(@"...\...\Resources\p096_sudoku.txt"))
            {
                int[,] sudokuBoard = new int[9, 9];
                while (sudokuFile.ReadLine() != null)
                {
                    readSudokuBoard(sudokuBoard, sudokuFile);
                    List<int>[,] candidateBoard = Functions.getDeepCopy<List<int>[,]>(candidateBoardBase);
                    updateSudokuBoards(sudokuBoard, candidateBoard);
                    int[,] solution = getSudokuSolution(sudokuBoard, candidateBoard);
                    //printSudoku(solution);
                    ans += solution[0, 0] * 100 + solution[0, 1] * 10 + solution[0, 2];
                }
            }
            Console.WriteLine(ans);
        }
    }
}
