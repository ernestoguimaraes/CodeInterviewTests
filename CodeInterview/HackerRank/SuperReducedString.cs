using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInterview.HackerRank
{
    /// <summary>
    /// From HackerRank
    /// https://www.hackerrank.com/challenges/reduced-string/problem
    /// </summary>
    public class SuperReducedString
    {

        public string ShortString(string s)
        {
            bool executeAgain = true;
            while (executeAgain)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s.Length > i + 1)
                    {
                        if (String.Equals(s[i], s[i + 1]))
                        {
                            s = s.Remove(i, 2);
                            i = 0;
                        }
                    }
                }

                if (s.Length <= 1)
                {
                    return "Empty String";
                }
                else
                {
                    if (!String.Equals(s[0], s[1]))
                    {
                        return s;
                    }

                }
            }

            return s;
        }



    }
}
