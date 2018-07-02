
using System;

namespace CodeInterview
{
    class Program
    {
        static void Main(string[] args)
        {
          

            Program o = new Program();

            //SOLVE BLOCKS
            //o.RunBlocks();

            
            //SOLVE SUDOKU
            //o.Sudoku();


            //SOLVE RAT IN RACE
            //o.RatInARace();

           
            //BTS - Binary Tree Search
            o.BTS();


            Console.ReadKey();

        }

        private void BTS()
        {
            var BTS = new  bts.tree();
            
            //Generataing random values for tree
            var rnd = new Random();
            
            for (int i = 0; i < 99; i++)
            {
                //Explore this method to understand how to add values to a Binary Tree 
                BTS.AddValue(rnd.Next(100));
            }

            //This methode shows how to search for a value
            BTS.Search(BTS.ReturnRoot(), 7);

            //This one tranverse a tree
            BTS.Transverse(BTS.ReturnRoot());
        }
        private void Sudoku()
        {
            Console.WriteLine("Using Backtracking algorith to solve SODOKU. See reference on Source Code");

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
            Console.WriteLine("Using Backtracking algorith to solve a RAT Race. See reference on Source Code");
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
            Console.WriteLine("Running Blocks. See the reference on Source Code");

            int[] vetor = { 1, 2, 2, 2, 2, 3, 3, 3, 1 };
            Blocks.BlocksChallenge.Run(vetor);
        }


    }
}
