using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_O_lgm_lgn_
{
  internal class KthElement
  {
    public static int FetchKthElement(int[] arr1, int[] arr2, int m, int n, int k)
    {
      //Base Cases :
      // If any one of the array has only one element
      if (m == 1 || n == 1)
      {
        //if arr2 has only one element, swap arr2 with arr1 and m with n such that arr1 becomes the array with one element
        if (n == 1)
        {
          int[] temp = arr1;
          arr1 = arr2;
          arr2 = temp;
          n = m;
        }
        //if looking for 1st element, we just need to check first element of both arrays
        if (k == 1)
        {
          return Math.Min(arr1[0], arr2[0]);
        }
        //if looking for last element, we just need to check the last element of arr2 with the only element of arr1
        else if (k == n + 1)
        {
          return Math.Max(arr1[0], arr2[n - 1]);
        }
        else
        {
          //else if kth element in arr2 is less than the only element in arr1, it implies that in the final array, arr1[0] will be placed after kth element.
          if (arr2[k - 1] < arr1[0])
          {
            return arr2[k - 1];
          }
          //else check k-1th element, if less then k-1th element will become kth element as arr1[0] will be placed before k-1th
          else
          {
            return Math.Max(arr1[0], arr2[k - 2]);
          }
        }
      }
      //Otherwise proceed with Divide and Conquer and select Mid points
      int mid1 = (m - 1) / 2;
      int mid2 = (n - 1) / 2;

      if (mid1 + mid2 + 1 < k)
      {
        // if k is greater than the sum of midpoints, discard the smaller half of the arrays and recurse
        if (arr1[mid1] < arr2[mid2])
        {
          return FetchKthElement(
            arr1[(mid1 + 1)..],
            arr2,
            m - (mid1 + 1),
            n,
            k - (mid1 + 1)
          );
        }
        else
        {
          return FetchKthElement(
            arr1,
            arr2[(mid2 + 1)..],
            m,
            n - (mid2 + 1),
            k - (mid2 + 1)
          );
        }
      }
      else
      {
        if (arr1[mid1] < arr2[mid2])
        {
          return FetchKthElement(
            arr1,
            arr2[..(mid2 + 1)],
            m,
            mid2 + 1,
            k
          );
        }
        else
        {
          return FetchKthElement(
            arr1[..(mid1 + 1)],
            arr2,
            mid1 + 1,
            n,
            k
          );
        }
      }
    }
  }
}
