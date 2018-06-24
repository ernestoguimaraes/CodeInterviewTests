
using System;

namespace CodeInterview
{
    class Program
    {
        static void Main(string[] args)
        {

            Program o = new Program();

            //SOLVE SUDOKU
            //o.Sudoku();


            //SOLVE RAT IN RACE
            //o.RatInARace();

            //SOLVE BLOCKS
            //o.RunBlocks();

            //BTS - Binary Tree Search
            //o.BTS();


            Console.ReadKey();

        }

        private void BTS()
        {
            var BTS = new  CodeInterview.bts.tree();
            Random rnd = new Random();
            rnd.Next(100);

            for (int i = 0; i < 99; i++)
            {
                BTS.AddValue(rnd.Next(100));
            }

            BTS.Search(BTS.ReturnRoot(), 7);
            BTS.Transverse(BTS.ReturnRoot());
        }
        private void Sudoku()
        {

            var grid = new int[,]{{3, 0, 6, 5, 0, 8, 4, 0, 0},
                                  {5, 2, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 8, 7, 0, 0, 0, 0, 3, 1},
                                  {0, 0, 3, 0, 1, 0, 0, 8, 0},
                                  {9, 0, 0, 8, 6, 3, 0, 0, 5},
                                  {0, 5, 0, 0, 9, 0, 6, 0, 0},
                                  {1, 3, 0, 0, 0, 0, 2, 5, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 7, 4},
                                  {0, 0, 5, 2, 0, 6, 3, 0, 0}};

            //var solved = Classics.Sudoku.Solve(grid);
            var solved = Classics.Sudoku.Solve(grid);
            Console.WriteLine(solved);

        }

        private void RatInARace()
        {
            //1 are the valid Paths
            var grid = new int[,]{{ 1, 0, 0, 0 },
                                  { 1, 1, 1, 0},
                                  { 0, 1, 0, 0},
                                  { 1, 1, 1, 1} };

            var solved = Classics.RatRace.Solve(grid);
            Console.WriteLine(solved);
        }

        private void RunBlocks()
        {
            int[] vetor = { 1, 2, 2, 2, 2, 3, 3, 3, 1 };
            Blocks.BlocksChallenge.Run(vetor);
        }


    }
}
