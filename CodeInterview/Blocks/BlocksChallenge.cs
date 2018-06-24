using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeInterview.Blocks
{

    class Segments : IEquatable<Segments>
    {
        public List<int> numbers { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Segments);
        }

        public bool Equals(Segments other)
        {
            return other != null &&
                   EqualityComparer<List<int>>.Default.Equals(numbers, other.numbers);
        }
    }

    /// <summary>
    /// Try to solve the Blocks Challenge
    /// reference: https://www.urionlinejudge.com.br/judge/en/problems/view/1331
    /// </summary>
    /// 
    public static class BlocksChallenge
    {

        public static void Run (int[] vetor)
        {
            var Listasegmento = CalculateSegements(vetor);
            var total = Solve(Listasegmento, 0);
            Console.WriteLine("Total Points:" + total);            
        }

        static int Solve(List<Segments> Listasegmento, int points)
        {

            //if true, thats there is no More Segments
            if (Listasegmento.Count == 0)
            {
                return points;
            }

            //Look for the largest segement
            var LargestSegement = Listasegmento.OrderByDescending(a => a.numbers.Count).First();

            //Check if the 2nd Segement from the current one is the same value. If yes, remove the 
            //next segment and run again
            var CurrentSegmentOfLargestSegment = Listasegmento.FindIndex(a => a.numbers == LargestSegement.numbers);

            //Avoid any problems with the array Lenght
            if (CurrentSegmentOfLargestSegment + 2 < Listasegmento.Count)
            {
                //If yes, remove the CurrentSegment+1. Check if the next 2 segement is equal to the current 
                if (Listasegmento[CurrentSegmentOfLargestSegment + 2].numbers.Contains(LargestSegement.numbers[0]))
                {
                    var segmentToRemove = Listasegmento[CurrentSegmentOfLargestSegment + 1];
                    points += CalculatePoints(segmentToRemove);
                    Listasegmento.Remove(segmentToRemove);
                    var newListSeg = CalculateSegements(ConvertListToArray(Listasegmento));
                    return Solve(newListSeg, points);
                }
                else//If no, remove the Largest on
                {
                    var segmentToRemove = Listasegmento[CurrentSegmentOfLargestSegment];
                    points += CalculatePoints(segmentToRemove);
                    Listasegmento.Remove(segmentToRemove);
                    var newListSeg = CalculateSegements(ConvertListToArray(Listasegmento));
                    return Solve(newListSeg, points);
                }

            }
            else //remove the largest
            {
                var segmentToRemove = Listasegmento[CurrentSegmentOfLargestSegment];
                points += CalculatePoints(segmentToRemove);
                Listasegmento.Remove(segmentToRemove);
                var newListSeg = CalculateSegements(ConvertListToArray(Listasegmento));
                return Solve(newListSeg, points);
            }

        }

        static int[] ConvertListToArray(List<Segments> list)
        {
            var arrayLst = new List<int>();
            foreach (var item in list)
            {
                arrayLst.AddRange(item.numbers);
            }

            return arrayLst.ToArray();
        }

        static List<Segments> CalculateSegements(int[] vetor)
        {
            var Listasegmento = new List<Segments>();

            for (int i = 0; i < vetor.Length; i++)
            {
                if (Listasegmento.Count == 0)
                {
                    Listasegmento.Add(new Segments()
                    {
                        numbers = new List<int>() {
                            vetor[i]
                        }
                    });
                }
                else
                {
                    var currentNumber = vetor[i];
                    if (!Listasegmento.Last().numbers.Contains(currentNumber))
                    {
                        Listasegmento.Add(new Segments()
                        {
                            numbers = new List<int>() {
                            vetor[i]
                        }
                        });
                    }
                    else
                    {
                        Listasegmento.Last().numbers.Add(currentNumber);

                    }
                }
            }

            return Listasegmento;

        }

        /// <summary>
        /// According with the rule, if on segment has X of length, the total points will be X*X
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        static int CalculatePoints(Segments segment)
        {
            return segment.numbers.Count * segment.numbers.Count;
        }

    }
}
