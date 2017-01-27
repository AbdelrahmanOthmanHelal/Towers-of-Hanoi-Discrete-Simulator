using System.Collections.Generic;

namespace Towers.Of.Hanoi.Bottom.Up
{
    public static class Solver
    {
        // We need a table that holds the states with the number of plates for each state ..
        public static List<List<List<KeyValuePair<int[], string>>>> memo = new List<List<List<KeyValuePair<int[], string>>>>();

        // Just to proof that memoization has affected the solution 
        public static int memoizationCounter = 0; 

        public static List<KeyValuePair<int[], string>> TowersOfHanoiTopDownMemo(int n, int from, int to, int aux)
        {
            // Check that if we solved that sub-problem -> return the solution 
            if (memo[n - 1].Count != 0 && memo[n - 1][0].Count != 0 && memo[n - 1][1].Count != 0 && memo[n - 1][2].Count != 0 && memo[n - 1][3].Count != 0 && memo[n - 1][4].Count != 0 && memo[n - 1][5].Count != 0)
            {
                memoizationCounter++;
                // From column 1->3 
                if (from == 1 && to == 3)
                    return memo[n - 1][0];
                else if (from == 3 && to == 1)
                    return memo[n - 1][1];
                else if (from == 1 && to == 2)
                    return memo[n - 1][2];
                else if (from == 2 && to == 1)
                    return memo[n - 1][3];
                else if (from == 2 && to == 3)
                    return memo[n - 1][4];
                else if (from == 3 && to == 2)
                    return memo[n - 1][5];
            }

            // We've to solve the problem ..
            else
            {
                if (n == 1)
                {
                    List<KeyValuePair<int[], string>> temp = new List<KeyValuePair<int[], string>>();

                    if (from == 1 && to == 3)
                    {
                        temp.Add(new KeyValuePair<int[], string>(new int[] { -1, 0, 1 }, "Remove a plate from column 1 to column 3"));
                        memo[n - 1][0] = temp;
                    }

                    if (from == 3 && to == 1)
                    {
                        temp.Add(new KeyValuePair<int[], string>(new int[] { 1, 0, -1 }, "Remove a plate from column 3 to column 1"));
                        memo[n - 1][1] = temp;
                    }

                    if (from == 1 && to == 2)
                    {
                        temp.Add(new KeyValuePair<int[], string>(new int[] { -1, 1, 0 }, "Remove a plate from column 1 to column 2"));
                        memo[n - 1][2] = temp;
                    }

                    if (from == 2 && to == 1)
                    {
                        temp.Add(new KeyValuePair<int[], string>(new int[] { 1, -1, 0 }, "Remove a plate from column 2 to column 1"));
                        memo[n - 1][3] = temp;
                    }

                    if (from == 2 && to == 3)
                    {
                        temp.Add(new KeyValuePair<int[], string>(new int[] { 0, -1, 1 }, "Remove a plate from column 2 to column 3"));
                        memo[n - 1][4] = temp;
                    }

                    if (from == 3 && to == 2)
                    {
                        temp.Add(new KeyValuePair<int[], string>(new int[] { 0, 1, -1 }, "Remove a plate from column 3 to column 2"));
                        memo[n - 1][5] = temp;
                    }

                    return temp;
                }

                else
                {
                    List<KeyValuePair<int[], string>> tempMajor = new List<KeyValuePair<int[], string>>();

                    List<KeyValuePair<int[], string>> temp1 = new List<KeyValuePair<int[], string>>();
                    List<KeyValuePair<int[], string>> temp2 = new List<KeyValuePair<int[], string>>();
                    List<KeyValuePair<int[], string>> temp3 = new List<KeyValuePair<int[], string>>();

                    temp1 = TowersOfHanoiTopDownMemo(n - 1, from, aux, to);
                    temp2 = TowersOfHanoiTopDownMemo(1, from, to, aux);
                    temp3 = TowersOfHanoiTopDownMemo(n - 1, aux, to, from);

                    for (int i = 0; i < temp1.Count; i++)
                        tempMajor.Add(temp1[i]);

                    for (int i = 0; i < temp2.Count; i++)
                        tempMajor.Add(temp2[i]);

                    for (int i = 0; i < temp3.Count; i++)
                        tempMajor.Add(temp3[i]);

                    if (from == 1 && to == 3)
                        memo[n - 1][0] = tempMajor;
                    else if (from == 3 && to == 1)
                        memo[n - 1][1] = tempMajor;
                    else if (from == 1 && to == 2)
                        memo[n - 1][2] = tempMajor;
                    else if (from == 2 && to == 1)
                        memo[n - 1][3] = tempMajor;
                    else if (from == 2 && to == 3)
                        memo[n - 1][4] = tempMajor;
                    else if (from == 3 && to == 2)
                        memo[n - 1][5] = tempMajor;

                    return tempMajor;
                }
            }
            return null;
        }
    }
}
