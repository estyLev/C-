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
        public static bool checkPermutation(string str1,string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            int[] arr1 = new int[129];
            int[] arr2 = new int[129];
            for (int i = 0; i < str1.Length; i++)
            {
                arr1[str1[i]]++;
                arr2[str2[i]]++;
            }
            for (int i = 0; i < 129; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }
            return true;
        }
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
        public static bool PalindromePermutation(string str)
        {
            int[] arr = new int[129];
            bool flag = false;
            for (int i = 0; i < str.Length; i++)
            {
                if(str[i]!=' ')
                 arr[str[i]]++;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i]%2!=0)
                {
                    if (!flag)
                        flag = true;
                    else
                        return false;
                }
                    
            }
            return true;
        }
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
        //public static bool stringRotation(string str1,string str2)
        //{
        //    string temp1 = "";
        //    string temp2 = "";


        //}
        #endregion
        static void Main(string[] args)
        {
            Console.WriteLine(checkPermutation("sod","Dos"));
        }
    }
}
