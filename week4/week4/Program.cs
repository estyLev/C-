using System;

namespace week4
{
    class Program
    {
        #region exercise1
        public static bool isUniqe(string str)
        {
            int[] arr = new int[26];
            str = str.ToLower();
            for (int i = 0; i < str.Length; i++)
            {
                if (arr[i] < 97 || arr[i] > 122)
                    i++;
                else
                    arr[str[i] - 97]++;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 1)
                    return false;
            }
            return true;
        }
        #endregion
        #region exercise2

        #endregion
        #region exercise3
        public static string URLify(string str)
        {
            string temp = "";
            for (int i = 0; i < str.Length; i++)
            {
                while (i < str.Length && str[i] != ' ')
                {
                    temp = temp + str[i];
                    i++;
                }
                if(i < str.Length)
                temp = temp + "%20";
            }
            return temp;
        }
        #endregion
        #region exercise4

        #endregion
        #region exercise5
        public static string compression(string str)
        {
            int sum = 0;
            string temp = "";
            char current = ' ';
            for (int i = 0; i < str.Length;)
            {
                current = str[i];
                while (i < str.Length && str[i] == current)
                {
                    sum++;
                    i++;
                }
                temp += current;
                temp += sum;
                sum = 0;
            }
            if (str.Length <= temp.Length)
                return str;
            return temp;
        }
        #endregion
        #region exercise6

        #endregion
        static void Main(string[] args)
        {
            Console.WriteLine(compression("abca"));
        }
    }
}
