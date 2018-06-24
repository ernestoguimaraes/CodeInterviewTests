using System;

namespace CodeInterview.Classics
{
    public static class SudokuMe
    {

        static int MatrixBoundaries = 9;
        public static bool Solve(int[,] matrix)
        {
            int r, c;
            if (!FindGoodPosition(matrix, out r, out c))
            {
                Console.WriteLine("Sudoku ok");
                print(matrix);
                return true;
            }

            //Testar os numeros
            for (int num = 1; num <= 9; num++)
            {
                if (isSafe(matrix, r, c, num))
                {


                    matrix[r, c] = num;

                    if (Solve(matrix))
                        return true;

                    matrix[r, c] = 0;

                }
                
            }

            return false;

        }

        private static bool isSafe(int[,] matrix, int r, int c, int num)
        {

            //Verificar se por adicionar na linha

            //verificar se pode adicionar na coluna

            // verificar se pode adicionar no quadrande

            if (!UsedInRow(matrix, r, num) && !UsedInCol(matrix, c, num) && !UsedInQuad(matrix, r - r % 3, c - c % 3, num))
                return true;

            return false;

        }

        private static bool UsedInQuad(int[,] matrix, int v1, int v2, int num)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {

                    if (matrix[row + v1, col + v2] == num)
                        return true;

                }

            }

            return false;

        }

        private static bool UsedInCol(int[,] matrix, int c, int num)
        {
            for (int i = 0; i < MatrixBoundaries; i++)
            {
                if (matrix[i, c] == num)
                    return true;
            }

            return false;
        }

        private static bool UsedInRow(int[,] matrix, int r, int num)
        {
            for (int i = 0; i < MatrixBoundaries; i++)
            {
                if (matrix[r, i] == num)
                    return true;
            }

            return false;
        }

        private static bool FindGoodPosition(int[,] matrix, out int r, out int c)
        {
            c = 0;
            for (r = 0; r < MatrixBoundaries; r++)
            {
                for (c = 0; c < MatrixBoundaries; c++)
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
