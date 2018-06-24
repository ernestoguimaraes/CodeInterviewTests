using System;

namespace CodeInterview.Classics
{
    /// <summary>
    /// https://www.geeksforgeeks.org/backttracking-set-2-rat-in-a-maze/
    /// </summary>
    public static class RatRace
    {
        static int MatrixBoundaries = 4;

        public static bool Solve(int[,] maze)
        {
            var sol= new int[,]{    {0, 0, 0, 0},
                                    {0, 0, 0, 0},
                                    {0, 0, 0, 0},
                                    {0, 0, 0, 0} };

            if(SolveMazeUtil(maze, 0, 0, sol) == false)
            {
                Console.WriteLine("No solution Found");
                return false;
            }

            print(sol);
            return true;

        }


        static bool SolveMazeUtil(int[,] maze, int x, int y, int[,] sol)
        {
            if(x == MatrixBoundaries-1 && y == MatrixBoundaries - 1)
            {
                sol[x, y] = 1;
                return true;
            }

            if(isSafe(maze, x, y))
            {
                sol[x, y] = 1;

                //move foward
                if (SolveMazeUtil(maze, x+1, y, sol))
                    return true;

                if (SolveMazeUtil(maze, x, y+1, sol))
                    return true;

                sol[x, y] = 0;
                return false; //backTracking

            }

            return false; //There is no solution
        }


        static bool isSafe(int[,] maze, int x, int y)
        {
            // if (x,y outside maze) return false
            if (x >= 0 && x < MatrixBoundaries && 
                y >= 0 && y < MatrixBoundaries && 
                maze[x,y] == 1) //This line checks if it's a valid path to follow
                return true;

            return false;
        }

        private static void print(int[,] maze)
        {
            for (int r = 0; r < MatrixBoundaries; r++)
            {
                for (int c = 0; c < MatrixBoundaries; c++)
                {
                    Console.Write(maze[r, c] + " ");
                    if (c == MatrixBoundaries - 1)
                        Console.Write(Environment.NewLine);

                }
            }
        }

    }
}
