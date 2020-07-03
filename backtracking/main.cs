using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backtracking
{
    class main { 
    static void Main(string[] args)
    {
        char[] set = new char[] { '1', '2', '3', '4','5','6', '7', '8', '9', };
        Graph g = new Graph();
        RecursiveBacktracking(String.Empty, set,g);
        Console.WriteLine("Failure");
        Console.ReadLine();
    }
       public  class csp
        {
           static public bool Verify(Graph g)
            {
      
                foreach (var i in g.graph)
                    if (i == 0)
                        return false;

                int firstSumm = 0;

                firstSumm = g.x1 + g.x3 + g.x7 + g.x9;

                if (firstSumm != g.x4 + g.x2 + g.x6 + g.x8)
                    return false;
                else if (firstSumm != g.x1 + g.x2 + g.x4 + g.x5)
                    return false;
                else if (firstSumm != g.x2 + g.x3 + g.x5 + g.x6)
                    return false;
                else if (firstSumm != g.x4 + g.x5 + g.x7 + g.x8)
                    return false;
                else if (firstSumm != g.x5 + g.x6 + g.x8 + g.x9)
                    return false;

                return true;
            }
            static public bool Verify(string assignment)
            {
                char[] temp = assignment.ToCharArray();
                int summ = 0;

                if (temp.Length == 6)
                {
                    summ = int.Parse(temp[0].ToString()) + int.Parse(temp[1].ToString()) + int.Parse(temp[2].ToString()) + int.Parse(temp[3].ToString());
                    int summ2 = int.Parse(temp[0].ToString()) + int.Parse(temp[1].ToString()) + int.Parse(temp[4].ToString()) + int.Parse(temp[5].ToString());
                    if (summ2 != summ) return false;
                }
                else if (temp.Length == 7)
                {
                    summ = int.Parse(temp[0].ToString()) + int.Parse(temp[1].ToString()) + int.Parse(temp[2].ToString()) + int.Parse(temp[3].ToString());
                    int summ2 = int.Parse(temp[0].ToString()) + int.Parse(temp[1].ToString()) + int.Parse(temp[4].ToString()) + int.Parse(temp[5].ToString());
                    int summ3 = int.Parse(temp[0].ToString()) + int.Parse(temp[4].ToString()) + int.Parse(temp[6].ToString()) + int.Parse(temp[2].ToString());
                    if (summ2 != summ || summ3 != summ) return false;
                }
                else if (temp.Length == 8)
                {
                    summ = int.Parse(temp[0].ToString()) + int.Parse(temp[1].ToString()) + int.Parse(temp[2].ToString()) + int.Parse(temp[3].ToString());
                    int summ2 = int.Parse(temp[0].ToString()) + int.Parse(temp[1].ToString()) + int.Parse(temp[4].ToString()) + int.Parse(temp[5].ToString());
                    int summ3 = int.Parse(temp[0].ToString()) + int.Parse(temp[4].ToString()) + int.Parse(temp[6].ToString()) + int.Parse(temp[2].ToString());
                    int summ4 = int.Parse(temp[1].ToString()) + int.Parse(temp[4].ToString()) + int.Parse(temp[7].ToString()) + int.Parse(temp[3].ToString());
                    if (summ2 != summ || summ3 != summ || summ4!=summ) return false;
                }
                else if(temp.Length == 9)
                {
                    summ = int.Parse(temp[0].ToString()) + int.Parse(temp[1].ToString()) + int.Parse(temp[2].ToString()) + int.Parse(temp[3].ToString());
                    int summ2 = int.Parse(temp[0].ToString()) + int.Parse(temp[1].ToString()) + int.Parse(temp[4].ToString()) + int.Parse(temp[5].ToString());
                    int summ3 = int.Parse(temp[0].ToString()) + int.Parse(temp[4].ToString()) + int.Parse(temp[6].ToString()) + int.Parse(temp[2].ToString());
                    int summ4 = int.Parse(temp[1].ToString()) + int.Parse(temp[4].ToString()) + int.Parse(temp[7].ToString()) + int.Parse(temp[3].ToString());
                    int summ5 = int.Parse(temp[4].ToString()) + int.Parse(temp[2].ToString()) + int.Parse(temp[8].ToString()) + int.Parse(temp[3].ToString());
                    int summ6 = int.Parse(temp[5].ToString()) + int.Parse(temp[6].ToString()) + int.Parse(temp[8].ToString()) + int.Parse(temp[7].ToString());
                    if (summ2 != summ || summ3 != summ || summ4 != summ || summ5!= summ||summ6!= summ) return false;
                }
                return true;
            }
        }
       public class Graph
        {
            public int[,] graph = new int[,]
             {{0,0,0},
             {0,0,0},
             {0,0,0}
            };

            public int x1;
            public int x2;
            public int x3;
            public int x4;
            public int x5;
            public int x6;
            public int x7;
            public int x8;
            public int x9;

            public Dictionary<int, string[]> vertex_connections = new Dictionary<int, string[]>();
            private Dictionary<int, string[]> vertex_busy = new Dictionary<int, string[]>();

            public Graph()
            {
                Update();
                vertex_connections.Add(1, new string[] { "2", "4" });
                vertex_connections.Add(2, new string[] { "1", "3", "5", "4", "6" });
                vertex_connections.Add(3, new string[] { "2", "6" });
                vertex_connections.Add(4, new string[] { "1", "7", "5", "8", "2" });
                vertex_connections.Add(5, new string[] { "2", "4", "6", "8" });
                vertex_connections.Add(6, new string[] { "3", "9", "5", "8", "8", });
                vertex_connections.Add(7, new string[] { "8", "4" });
                vertex_connections.Add(8, new string[] { "7", "9", "5", "4", "6", });
                vertex_connections.Add(9, new string[] { "8", "6" });
            }

            public void Update()
            {
                x1 = graph[0, 0];
                x2 = graph[0, 1];
                x3 = graph[0, 2];
                x4 = graph[1, 0];
                x5 = graph[1, 1];
                x6 = graph[1, 2];
                x7 = graph[2, 0];
                x8 = graph[2, 1];
                x9 = graph[2, 2];
            }

            public void Assign(int value, int row, int col)
            {
                graph[row, col] = value;
                Update();
            }

            public int SelectNextNode()
            {
                int result = 0;
                int nextMax =NextMaxRank();

                result = vertex_connections.FirstOrDefault(x => x.Value.Count() == nextMax).Key;

                return result;
            }

            public int NextMaxRank()
            {
                int res = 0;
                foreach (var v in vertex_connections)
                    if (vertex_busy.Contains(v))
                        continue;
                    else
                    {
                        if (res < v.Value.Count())
                            res = v.Value.Count();
                    }
                return res;
            }

        }

    static void CutTheTree(string assignment,char[] set,Graph g)
    {
            char[] toLast = new char[] { set[set.Length - 1] };

            for (int i = 0; i < set.Length - 1; i++)
                assignment += set[i];

          
            RecursiveBacktracking(assignment, toLast, g);
    }

    static void RecursiveBacktracking(string assignment, char[] set,Graph g)
    {
        int count = 0;
        if (set.Length == 1)
        {
                //Console.WriteLine(permutation +"__"+set[0]);
                char[] chars = assignment.ToCharArray();
                int sum1 = 0;
                int sum2 = 0;
                int sum3 = 0;
                int sum4 = 0;
                int sum5 = 0;
                int sum6 = 0;

                for (int i =0;i<chars.Length;i++)
                {
                    //Bigger squares
                    if(i<chars.Length/2)
                        sum1 += int.Parse(chars[i].ToString());
                    else
                        sum2 += int.Parse(chars[i].ToString());
                }

                //Smaller squares
                sum3 = int.Parse(chars[0].ToString()) + int.Parse(chars[4].ToString())
                    + int.Parse(chars[5].ToString()) + int.Parse(set[0].ToString());

                sum4 = int.Parse(chars[4].ToString()) + int.Parse(chars[1].ToString())
                    + int.Parse(set[0].ToString()) + int.Parse(chars[6].ToString());

                sum5 = int.Parse(chars[5].ToString()) + int.Parse(set[0].ToString())
                    + int.Parse(chars[2].ToString()) + int.Parse(chars[7].ToString());

                sum6 = int.Parse(set[0].ToString()) + int.Parse(chars[6].ToString())
                       + int.Parse(chars[7].ToString()) + int.Parse(chars[3].ToString());

                if (sum1==sum2 && sum1==sum3 && sum1 == sum4&& sum1 == sum5&& sum1 == sum6)
                {
                    //Console.WriteLine(assignment + "__" + set[0]);
                    Console.WriteLine("Success");
                    Console.WriteLine("{0} {1} {2}", chars[0], chars[4], chars[1]);
                    Console.WriteLine("{0} {1} {2}", chars[5], set[0], chars[6]);
                    Console.WriteLine("{0} {1} {2}", chars[2], chars[7], chars[3]);
                    Console.WriteLine();
                    Console.Read();
                    System.Environment.Exit(0);
                }
           return;
        }
            //Select UnassignedVariable
            if (assignment.Length >= 6 && !csp.Verify(assignment))
            {
                char[] toLast = new char[] { set[set.Length - 1] };

                for (int i = 0; i < set.Length-1; i++)
                    assignment += set[i];
               // if (assignment.Length<9)
                //Console.WriteLine(assignment);
                RecursiveBacktracking(assignment,toLast, g);
            }
            else
            {
                for (int i = 0; i < set.Length; i++)
                {
                    char n = set[i];
                    string newAsssignment = assignment + n;
                    char[] subset = new char[set.Length - 1];
                    int j = 0;

                    for (int k = 0; k < set.Length; k++)
                    {
                        if (set[k] != n)
                        {
                            subset[j++] = set[k];
                        }
                    }
                    //Console.WriteLine(newAsssignment);
                    RecursiveBacktracking(newAsssignment, subset, g);
                }
        }
       //}

     }
   }
}
