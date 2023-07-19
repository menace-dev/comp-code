namespace _02_O_lgm_lgn_
{
  internal class Program
  {
    static void Main(string[] args)
    {
      int[] arr1 = { 5, 71, 72 };
      int[] arr2 = { 1, 4, 8, 10 };
      int k = 5;
      Console.WriteLine(KthElement.FetchKthElement(arr1, arr2, 3, 4, k));

    }
  }
}