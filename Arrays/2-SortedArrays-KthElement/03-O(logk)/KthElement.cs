using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_O_logk_
{
  internal class Element
  {
    public static int KthElement(int[] arr1, int[] arr2, int m, int n, int k, int st1 = 0, int st2 =0)
    {
      //if st1 of arr1 has reached end of array 1
      if(st1 == m)
      {
        return arr2[st2 + k - 1];
      }
      //if st2 of arr2 has reached end of array 2
      if(st2 == n)
      {
        return arr1[st1 + k - 1];
      }

      //check for k < 0 or greater than all elements
      if(k < 0 || k > (m-st1) + (n-st2))
      {
        return -1; //or raise and exception
      }

      if(k==1)
      {
        return Math.Min(arr1[st1], arr2[st2]);
      }

      int curr = k / 2;
      //if k/2 is greater than current set of elements in arr1
      if(curr > m-st1)
      {
        if (arr1[m-1] > arr2[st2+curr-1])
        {
          return arr2[st2 + (k - (m - st1) - 1)];
        }
        else
        {
          return KthElement(arr1, arr2, m, n, k - curr, st1, st2 + curr);
        }
      }
      if(curr>n-st2)
      {
        if (arr2[n - 1] > arr1[st2 + curr - 1])
        {
          return arr1[st1 + (k - (n - st2) - 1)];
        }
        else
          return KthElement(arr1, arr2, m, n, k - curr, st1 + curr, st2);
      }

      if (arr1[st1 + curr -1] < arr2[st2 + curr - 1])
      {
        return KthElement(arr1, arr2, m, n, k - curr, st1 + curr, st2);
      }
      else
      {
        return KthElement(arr1, arr2, m, n, k - curr, st1, st2 + curr);
      }
    }
  }
   
}
