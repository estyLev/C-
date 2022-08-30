using System;
using System.Collections;
using System.Collections.Generic;

namespace week1
{
    class Program
    {
        //-----------------
        //part 1
        //-----------------

        # region exercise 1
        public static void allFib(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i + " => " + fib(i));
            }
        }

        public static int fib(int n)
        {
            if (n <= 0)
                return 0;
            if (n == 1)
                return 1;
            return fib(n - 1) + fib(n - 2);
        }

        //prints all Fibonacci numbers from 0 to n in o(n) run time
        public static void fibLoop(int n)
        {
            int sum, a, b;
            a = 0;
            b = 1;
            Console.WriteLine("0 => 0");
            Console.WriteLine("1 => 1");

            for (int i = 2; i < n; i++)
            {
                sum = a + b;
                Console.WriteLine(i + " => " + sum);
                a = b;
                b = sum;

            }
        }
        #endregion
        #region exercise 2
        //1
        public static int assign(int a)
        {
            int b = 0;
            //loop a
            for (int i = 0; i < a; i++)
            {
                b++;
            }

            return b;
        }

        //2
        public static int mult(int a, int b)
        {
            int c, sum = 0;
            //loop b
            for (int i = 0; i < b; i++)
            {
                c = assign(a);
                sum += c;
            }
            return sum;
        }

        //3
        public static int decrement(int a)
        {
            int b = 0;
            int c = 0;
            for (int i = 0; i < a; i++)
            {
                b = assign(c);
                c++;
            }
            a = assign(b);
            return a;
        }
        #endregion
        #region exercise 3
        public static bool isPrime(int num)
        {
            int div = num / 2;
            return isPrime(num, div);

        }

        private static bool isPrime(int num, int div)
        {
            if (div == 1)
                return true;
            if (num % div == 0)
                return false;
            return isPrime(num, --div);
        }

        //option 2
        public static bool isPrime2(int num)
        {
            int mode = num / 2 - 1;
            return isPrime2(num, mode);

        }
        private static bool isPrime2(int num, int mode)
        {
            if (mode == 0)
                return false;
            if (mode == 1)
                return true;

            return isPrime2(num, num % mode);

        }
        #endregion

        //-----------------
        //part 2
        //-----------------
        #region exercise 1
        public static ArrayList intersection(int[] a, int[] b)
        {
            int m = a.Length;
            int n = b.Length;
            Array.Sort(a);
            Array.Sort(b);
            ArrayList res = new ArrayList();

            int i = 0, j = 0;

            while (i < m && j < n)
            {
                if (a[i] == b[j])
                {
                    res.Add(a[i]);
                    i++;
                    j++;
                }
                else if (a[i] > b[j])
                    j++;
                else
                    i++;
            }
            return res;
        }
        #endregion
        #region exercise 2
        public static bool isZero(int[] arr)
        {
            
            int[] temp= new int[arr.Length-1];
            
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (j == i)
                        break;
                    temp[j] = arr[j];
                }
                if (twoSumToZero(temp, -arr[i]))
                    return true;   
            }
            return false;
        }
        private static bool twoSumToZero(int[] nums,int target )
        {
            
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            int difference = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                difference = target - nums[i];
                if (dictionary.ContainsKey(difference))
                {
                    int[] solution = new int[2] { nums[dictionary[difference]], nums[i] };
                    return true;
                }
                else
                {
                    if (!dictionary.ContainsKey(nums[i]))
                    {
                        dictionary.Add(nums[i], i);
                    }
                }
            }
            return false;
        }
        #endregion
        #region exercise 3
        //a
        public static int oneMissing(int[] arr)
        {
            int sum = 0, sumN = 0, n = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                n = Math.Max(n, arr[i]);
            }
            for (int i = 1; i <= n; i++)
            {
                sumN += i;
            }
            return sumN - sum;
        }

        //b
        public static int[] twoMissing(int[] arr)
        {
            int sum = 0, sumN = 0, n = 0, doubleArr = 1, doubleArrN = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                doubleArr *= arr[i];
                n = Math.Max(n, arr[i]);
            }

            int[] complete = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                sumN += i;
                doubleArrN *= i;
                complete[i - 1] = i;
            }
            sum = sumN - sum;
            doubleArr = doubleArrN / doubleArr;

            List<int[]> resSum = twoSum(complete, sum);
            List<int[]> resDouble = twoDouble(complete, doubleArr);

            foreach (var itemS in resSum)
            {
                foreach (var itemD in resDouble)
                {
                    if (itemD.Equals(itemD))
                        return itemD;
                }
            }

            return null;
        }
        private static List<int[]> twoSum(int[] nums, int target)
        {
            List<int[]> res = new List<int[]>();
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            int difference = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                difference = target - nums[i];
                if (dictionary.ContainsKey(difference))
                {
                    int[] solution = new int[2] { nums[dictionary[difference]], nums[i] };
                    res.Add(solution);
                }
                else
                {
                    if (!dictionary.ContainsKey(nums[i]))
                    {
                        dictionary.Add(nums[i], i);
                    }
                }
            }
            return res;
        }
        private static List<int[]> twoDouble(int[] nums, int target)
        {
            List<int[]> res = new List<int[]>();
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            int difference = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                    difference = target / nums[i];
                if (dictionary.ContainsKey(difference))
                {
                    int[] solution = new int[2] { nums[dictionary[difference]], nums[i] };
                    res.Add(solution);
                }
                else
                {
                    if (!dictionary.ContainsKey(nums[i]))
                    {
                        dictionary.Add(nums[i], i);
                    }
                }
            }
            return res;
        }
        #endregion
        #region exercise 4
        public static int random(List<int> exclusionList, int low, int high)
        {
            List<int> permittedList = new List<int>();
            for (int i = low; i < high; i++)
            {
                if (!exclusionList.Contains(i))
                    permittedList.Add(i);
            }
            Random rnd = new Random();
            int index = rnd.Next(permittedList.Count);
            return permittedList[index];
        }
        #endregion
        #region exercise 5
        //i will use a hash table.
        //put- o(1)
        //sumExists- o(n)
        #endregion
        #region exercise 6
        public static HashSet<int> searchPools(int[][] mat)
        {
            int r = mat.Length + 2;
            int c = mat[0].Length + 2;
            int max = 0;
            int[][] temp = new int[r][];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = new int[c];
                for (int j = 0; j < temp[i].Length; j++)
                {
                    temp[i][j] = 0;
                }
            }

            for (int i = 1; i < temp.Length - 1; i++)
            {

                for (int j = 1; j < temp[i].Length - 1; j++)
                {
                    if (mat[i - 1][j - 1] != 0)
                        temp[i][j] = 0;
                    else
                    {
                        max = 0;
                        max = Math.Max(temp[i][j - 1], max);
                        max = Math.Max(temp[i - 1][j - 1], max);
                        max = Math.Max(temp[i - 1][j], max);
                        max = Math.Max(temp[i - 1][j + 1], max);
                        temp[i][j] = max + 1;
                    }
                }
            }
            HashSet<int> res = new HashSet<int>();
            for (int i = 1; i < temp.Length - 1; i++)
            {

                for (int j = 1; j < temp[i].Length - 1; j++)
                {
                    if (temp[i][j] > 0)
                    {
                        if (temp[i + 1][j] == 0 && temp[i + 1][j + 1] == 0 && temp[i][j + 1] == 0)
                            res.Add(temp[i][j]);
                    }
                }
            }
            return res;

        }
        #endregion
        #region exercise 7
        public static int maxSum(int[] arr)
        {
            int r = arr.Length;
            int c = arr.Length;
            int max = int.MinValue;
            int[][] temp = new int[r][];
            int maxI = 0, maxJ = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = new int[c];
                temp[i][i] = arr[i];
                max = Math.Max(arr[i], max);
                maxI = i;
                maxJ = i;
            }
            for (int j = 1; j < temp.Length; j++)
            {
                for (int i = j-1; i >= 0; i--)
                {
                    temp[i][j] = temp[i][j - 1] + temp[i + 1][j] - temp[i + 1][j - 1];
                    max = Math.Max(temp[i][j], max);
                    if(max== temp[i][j])
                    {
                        maxI = i;
                        maxJ = j;
                    }
                }
            }
            for (int i = maxI; i <= maxJ; i++)
            {
                Console.Write(arr[i] + ",");
            }
            return max;
        }
           
      
        #endregion
        static void Main(string[] args)
        {

            //allFib(10);
            //Console.WriteLine("===============");
            //fibLoop(10);
            //Console.WriteLine(assign(6));
            //Console.WriteLine(mult(6,3));
            //Console.WriteLine(decrement(6));
            // Console.WriteLine(isPrime(130));
            //Console.WriteLine(isPrime2(130));
            int[] a = {  -6, -3, 0, 2, 3, 4, 9, -9,15 };
            int[] b = { -9, -1, 0, 7, 9, 15, 10 };
            //ArrayList res = intersection(a, b);
            //foreach (int item in res)
            //{
            //    Console.Write(item + ",");
            //}
            //int[] a = { -1, 2, 5, 6 ,-3,4};
            //Console.WriteLine(oneMissing(a));
            //int[] b = twoMissing(a);
            //Console.WriteLine(b[0] + "," + b[1]);
            //int[][] arr = {
            //                new int[4]{0,12,13,0},
            //                new int[4]{0,22,0,24},
            //                new int[4]{31,32,0,1},
            //                new int[4]{0,32,0,1}
            //               };

            //HashSet<int> resPools = searchPools(arr);
            //foreach (var item in resPools)
            //{
            //    Console.Write(item + ",");
            //}
            List<int> exclusionList = new List<int> { 0, 9, 15, 5, 40 };
            Console.WriteLine(random(exclusionList,1,10));
            Console.WriteLine(random(exclusionList, 1, 10));
            Console.WriteLine(random(exclusionList, 1, 10));
            Console.WriteLine(random(exclusionList, 1, 10));
            Console.WriteLine(random(exclusionList, 1, 10));
            //Console.WriteLine(isZero(a));
            //int[] a = { 2, -8, 3, -2, 4, -4,25 };
           // Console.WriteLine(" ="+maxSum(a));
        }
    }
}


