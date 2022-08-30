using System;
using System.Collections.Generic;
using System.Text;

namespace week2
{
    public class LruCache
    {
        private Dictionary<int, string> cache;
        private Dictionary<int, int> casheUsed;
        private int size;
        private int index=0;
      //  private int minKey;

        public LruCache(int num)
        {
            size = num;
            cache = new Dictionary<int, string>();
            casheUsed = new Dictionary<int, int>();
            
        }

        public string get(int key)
        {
            if(cache.ContainsKey(key))
            {
                casheUsed[key]=++index;
                return cache[key];
            }
            return "key not exsist";
         }
        public void add(int key,string val)
        {
            //if (index == 0)
            //    minKey = key;
            if (cache.Count >= size)
            {
                int leasUsedVal = int.MaxValue;
                int leasUsedKey = 0;
                foreach (var item in casheUsed)
                {
                    if (item.Value < leasUsedVal)
                    {
                        leasUsedVal = item.Value;
                        leasUsedKey = item.Key;
                    }
                }
                cache.Remove(leasUsedKey);
                casheUsed.Remove(leasUsedKey);

                //int temp = casheUsed[minKey];
                //cache.Remove(minKey);
                //casheUsed.Remove(minKey);
                //minKey = temp ;
            }

            cache.Add(key, val);
            casheUsed.Add(key, ++index);
        }
    }
}
