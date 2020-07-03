using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace backtracking
{
    class Program
    {
        public static readonly List<int> NUMBERS = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private static void GetCombinationsRec<T>(IList<IEnumerable<T>> sources, T[] chain, int index, ICollection<T[]> combinations)
        {
            foreach (var element in sources[index])
            {
                chain[index] = element;
                if (index == sources.Count - 1)
                {
                    var finalChain = new T[chain.Length];
                    chain.CopyTo(finalChain, 0);
                    combinations.Add(finalChain);
                }
                else
                {
                    GetCombinationsRec(sources: sources, chain: chain, index: index + 1, combinations: combinations);
                }
            }
        }

        public static List<T[]> GetCombinations<T>(params IEnumerable<T>[] enumerables)
        {
            var combinations = new List<T[]>(enumerables.Length);
            if (enumerables.Length > 0)
            {
                var chain = new T[enumerables.Length];
                GetCombinationsRec(sources: enumerables, chain: chain, index: 0, combinations: combinations);
            }
            return combinations;
        }


        static void Main333(string[] args)
        {
            List<int> test = new List<int>();

            var list1 = new[] { 1 };
            var list2 = new[] { 2,3,4,5,6,7,8,9};
            var result = GetCombinations(list1, list2);
            foreach (var r in result)
            {
                Console.Write(string.Join(" ", r));
            }


            Console.Read();

        }


        public static void RecursiveAssign(Numbers numbers, int startVaule,List<int> result)
        {
            const int copacity = 4;
            if(result.Count == copacity && numbers.numbers.Count==0)
            {
                foreach (var r in result)
                    Console.Write(r + " ");
                Console.WriteLine();
            }
            else if(result.Count == copacity)
            {
                result.Remove(result.Last());
                result.Add(numbers.TakeFirstNotIncluded(result));

                foreach (var r in result)
                    Console.Write(r + " ");
                Console.WriteLine();

                RecursiveAssign(numbers, startVaule, result);

            }
            else
            {
                if (result.Count == 0)
                {
                    result.Add(numbers.TakeValue(startVaule));
                    RecursiveAssign(numbers,startVaule, result);
                }
                else
                {
                    result.Add(numbers.TakeFirstNotIncluded(result));
                    RecursiveAssign(numbers, startVaule, result);
                }
            }
        }

        public static List<int> Backtracking(ref List<int> assign,int offset,Numbers numbers)
        {
            const int capacity = 4;

            if (assign.Count == capacity)
            {
                return assign;
            }
            else
            {
                assign.Add(AssignVariable(assign, offset, numbers));
                Backtracking(ref assign, offset, numbers);
            }
            return new List<int>();
        }

        public static int AssignVariable(List<int> assign,int offset,Numbers numbers)
        {
            return numbers.TakeFirstNotIncluded(assign);
        }

        public static List<int> ShiftRight(List<int> lst)
        {
            int[] arr = lst.ToArray();
            int[] demo = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                demo[(i + 1) % demo.Length] = arr[i];
            }
            return demo.ToList<int>();
        }

        class Square
        {
            public List<int> numbers;
            
            public Square()
            {
                numbers = new List<int>(4);
            }
            public Square(List<int> n)
            {
                numbers = new List<int>(4);
                for (int i = 0; i < 4; i++)
                    numbers.Add(n[i]);
            }
        }

        public class Numbers
        {
            public List<int> numbers;

            public Numbers()
            {
                numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            }

            public Numbers(List<int> nums)
            {
                numbers = nums;
            }

            public Numbers(int offset)
            {
                for (int i = 0; i < offset; i++)
                    numbers = ShiftRight(numbers);
            }

            public int TakeFirstNotIncluded(List<int> already)
            {
                int res =  numbers.FirstOrDefault(x => !already.Contains(x));
                numbers.Remove(res);
                return res;
            }

            public int TakeValue(int val)
            {
                numbers.Remove(val);
                return val;
            }
        }
    }
}
