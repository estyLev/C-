using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace week2
{
    public class BoxList
    {
        private List<Box> boxList { get; set; }
        private double[] sortHight { get; set; }
        private double[] sortDepth { get; set; }
        private double[] sortWidth { get; set; }


        public BoxList(List<Box> boxList)
        {
            this.boxList = boxList;
            sortByDepth();
            sortByHight();
            sortByWidth();
        }

        private void sortByDepth()
        {
            double[] keys = new double[boxList.Count];
            sortDepth = new double[boxList.Count];

            for (int i = 0; i < boxList.Count; i++)
            {
                keys[i] = boxList[i].depth;
                sortDepth[i] = i;
            }
            Array.Sort(keys, sortDepth);
            Array.Reverse(sortDepth);
        }
        private void sortByHight()
        {
            sortHight = new double[boxList.Count];
            double[] keys = new double[boxList.Count];

            for (int i = 0; i < boxList.Count; i++)
            {
                keys[i] = boxList[i].hight;

                sortHight[i] = i;
            }
            Array.Sort(keys, sortHight);
            Array.Reverse(sortHight);
        }
        private void sortByWidth()
        {
            sortWidth = new double[boxList.Count];
            double[] keys = new double[boxList.Count];

            for (int i = 0; i < boxList.Count; i++)
            {
                keys[i] = boxList[i].width;

                sortWidth[i] = i;
            }
            Array.Sort(keys, sortWidth);
            Array.Reverse(sortWidth);
        }
        private int minSum(int[] arr)
        {
            int min = arr[0];
            int minIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
        public double sumHight()
        {
            int[] hightDepth = new int[boxList.Count];
            int[] hightWidth = new int[boxList.Count];
            int[] depthWidth = new int[boxList.Count];
            double res = 0;
            int[] total = new int[boxList.Count];
            List<Box> temp = new List<Box>();
            List<Box> t = new List<Box>();
            foreach (var item in boxList)
            {
                Box newbox = new Box(item.hight, item.width, item.depth);
                temp.Add(newbox);
            }

            int max = 0;
            for (int i = 0; i < hightWidth.Length; i++)
            {
                max = 0;
                hightWidth[i] = intersection(sortHight, sortWidth, i);
                hightDepth[i] = intersection(sortHight, sortDepth, i);
                depthWidth[i] = intersection(sortWidth, sortDepth, i);

                max = Math.Max(max, hightWidth[i]);
                max = Math.Max(max, hightDepth[i]);
                max = Math.Max(max, depthWidth[i]);

                total[i] = max;
            }
            int nextMin;
            double sumNextMin = 0;
            double sumMin = 0;
            int tempTotal;
            Box box;

            while (temp.Count > 0)
            { 
                int min = minSum(total);
                tempTotal = total[min];
                total[min] = int.MaxValue;
                box = boxList[min];
                temp.Remove(box);
                nextMin = minSum(total);
              
                while (total[nextMin] == tempTotal)
                {
                    sumMin = hightWidth[min] + hightDepth[min] + depthWidth[min];
                    sumNextMin = hightWidth[nextMin] + hightDepth[nextMin] + depthWidth[nextMin];
                    if (sumNextMin < sumMin)
                    {
                        box = boxList[nextMin];
                        tempTotal = total[nextMin];
                        
                    }

                    else
                    {
                        box = boxList[min];
                        temp.Remove(boxList[nextMin]);
                    }


                    total[nextMin] = int.MaxValue;
                    nextMin = minSum(total);
                }

                res += box.hight;
                
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i].depth >= box.depth || temp[i].hight >= box.hight || temp[i].width >= box.width)
                    {
                        
                        Box b = temp[i];
                        int ind = boxList.IndexOf(b);
                        total[ind] = int.MaxValue;
                        t.Add(b);
                        //temp.Remove(temp[i]);
                    }
                }
                foreach (var item in t)
                {
                    temp.Remove(item);
                   
                }
                t.Clear();
            }

            return res;
        }
        private static int intersection(double[] a, double[] b, int val)
        {
            int m = 0, n = 0;
            for (int k = 0; k < a.Length; k++)
            {
                if (a[k] == val)
                {
                    m = k;
                    break;
                }

            }
            for (int k = 0; k < b.Length; k++)
            {
                if (b[k] == val)
                {
                    n = k;
                    break;
                }

            }
            double[] sortA = new double[m];
            double[] sortB = new double[n];

            Array.Copy(a, sortA, m);
            Array.Copy(b, sortB, n);

            Array.Sort(sortB);
            Array.Sort(sortA);
            int res = 0;


            int i = 0, j = 0;

            while (i < m && j < n)
            {
                if (sortA[i] == sortB[j])
                {
                    res++;
                    i++;
                    j++;
                }
                else if (sortA[i] > sortB[j])
                    j++;
                else
                    i++;
            }
            return m + n - res;
        }
    }
}
