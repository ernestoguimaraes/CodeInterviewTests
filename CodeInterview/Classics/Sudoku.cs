using System;

namespace CodeInterview.Classics
{
    /// <summary>
    /// Reference: https://www.geeksforgeeks.org/backtracking-set-7-suduku/
    /// </summary>
    public static class Sudoku
    {
        static int MatrixBoundaries = 9;


        public static bool Solve(int[,] MatrixSudoky)
        {
            int r, c;
            if (!FindUnassignedLocation(MatrixSudoky, out r, out c))
            {
                print(MatrixSudoky);
                return true;
            }

            //Check numbers
            for (int num = 1; num <= 9; num++)
            {
                if (IsSafe(MatrixSudoky, r, c, num))
                {
                 
                    MatrixSudoky[r, c] = num;

                    if (Solve(MatrixSudoky))
                        return true;

                    MatrixSudoky[r, c] = 0;

                }


            }

            return false;

        }

        private static bool IsSafe(int[,] matrixSudoky, int r, int c, int num)
        {

            return !UsedInRow(matrixSudoky, r, num) &&
                   !UsedInCol(matrixSudoky, c, num) &&
                    !UsedInBox(matrixSudoky, r - r % 3, c - c % 3, num);

        }

        private static bool UsedInBox(int[,] matrix, int boxStartRow, int boxStartCol, int num)
        {
          

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    
                    if (matrix[row + boxStartRow, col + boxStartCol] == num)
                        return true;
                }
            }

            return false;
        }

        private static bool UsedInCol(int[,] matrix, int c, int num)
        {

            for (int row = 0; row < MatrixBoundaries; row++)
            {
                if (matrix[row, c] == num)
                    return true;
            }
            return false;
        }

        private static bool UsedInRow(int[,] matrix, int r, int num)
        {
            for (int col = 0; col < MatrixBoundaries; col++)
            {
                if (matrix[r, col] == num)
                    return true;
            }
            return false;
        }

        private static bool FindUnassignedLocation(int[,] matrix, out int r, out int c)
        {
            c = 0;
            for (r = 0; r < MatrixBoundaries; r++)// Row
            {
                for (c = 0; c < MatrixBoundaries; c++) //Col
                {   
                    if (matrix[r, c] == 0)
                        return true;       
                }

            }

            return false;
        }

        private static void print(int[,] matrix)
        {
            for (int r = 0; r < MatrixBoundaries; r++)
            {
                for (int c = 0; c < MatrixBoundaries; c++)
                {
                    Console.Write(matrix[r, c] + " ");
                    if (c == MatrixBoundaries - 1)
                        Console.Write(Environment.NewLine);

                }
            }
        }


    }
}
