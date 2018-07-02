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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// Solving the code challenging
    /// reference: https://www.urionlinejudge.com.br/judge/en/problems/view/1331
    /// </summary>
    /// 
    public static class BlocksChallenge
    {

        public static void Run(int[] vetor)
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
            var LargestSegementIndex = Listasegmento.FindIndex(a => a.numbers == LargestSegement.numbers);

            var RemoveNextSegment = ShouldRemoveThenNextSegement(Listasegmento, LargestSegementIndex, LargestSegement);

            Segments segmentToRemove;
            if (RemoveNextSegment)
                segmentToRemove = Listasegmento[LargestSegementIndex + 1];
            else
                segmentToRemove = Listasegmento[LargestSegementIndex];


            points += CalculatePoints(segmentToRemove);
            Listasegmento.Remove(segmentToRemove);
            var newListSeg = CalculateSegements(ConvertListToArray(Listasegmento));
            return Solve(newListSeg, points);
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

        /// <summary>
        /// Always calculates the new segments.
        /// </summary>
        /// <param name="vetor"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Verifies if the next segment should be removed because maybe the next one has equal values from the current, so, removing the next one can create a bigger segment.
        /// </summary>
        /// <param name=""></param>
        /// <param name="LargeSegmentIndex"></param>
        /// <returns></returns>
        static bool ShouldRemoveThenNextSegement(List<Segments> list, int LargeSegmentIndex, Segments LargerSegment)
        {
            //Avoid the out of Bounds
            if (LargeSegmentIndex + 2 < list.Count)
            {
                //If yes, remove the CurrentSegment+1. Check if the next 2 segement is equal to the current 
                if (list[LargeSegmentIndex + 2].numbers.Contains(LargerSegment.numbers[0]))
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }

        }
    }
}
