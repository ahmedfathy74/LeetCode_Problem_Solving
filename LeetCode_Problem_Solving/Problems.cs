using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_Problem_Solving
{
    public class Problems: IDisposable
    {
        // free managed and unmaged resources
        private bool _disposedValue;
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _safeHandle.Dispose();
                }

                _disposedValue = true;
            }
        }
        //
     
        // every function is a new problem

        public int RemoveElement(int[] nums, int val)
        {
            int LengthAfterRemove=nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i]==val)
                {
                   
                    nums[i] = 100001;
                    LengthAfterRemove--;
                }
            }
            Array.Sort(nums);
            return LengthAfterRemove;
        }

        public int StrStr(string haystack, string needle)
        {
            int index = -1;
            index  =haystack.IndexOf(needle);
            return index;
        }

        public int MaxProfit(int[] prices)
        {
            int maxi = 0;
            int mini = prices[0];
            for (int i =0; i < prices.Length;i++)
            {
                mini = Math.Min(mini, prices[i]);
                maxi = Math.Max(maxi, prices[i]-mini);
            } 
            return maxi;
        }

        public bool IsAnagram(string s, string t)
        {
            char[] arr = s.ToArray();
            char[] arr2 = t.ToArray();
            if (s.Length==t.Length)
            {
                for(int i=0; i<t.Length;i++)
                {
                    if (arr.Contains(t[i]))
                    {
                        int index = Array.IndexOf(arr, t[i]);
                        arr[index] = '%';
                        continue;
                    }
                    else { return false; }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool WordPattern(string pattern, string s)
        {
            var arrOFWords = s.Split(' ');
            if (arrOFWords.Length != pattern.Length)
            {
                return false;
            }

            Dictionary<char, string> words = new Dictionary<char, string>();

            for (int i = 0; i < pattern.Length; i++)
            {
                if (!words.ContainsKey(pattern[i]))
                {
                    if (words.ContainsValue(arrOFWords[i]))
                    {
                        return false;
                    }
                    words.Add(pattern[i], arrOFWords[i]);
                }
                else
                {
                    var currentItem = words[pattern[i]];
                    if (currentItem != arrOFWords[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}
