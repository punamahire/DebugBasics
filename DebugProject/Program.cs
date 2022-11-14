using System;
using System.Collections.Generic;

namespace CSharpFundamentals
{
    class Program
    {
        public static void Main(string[] args)
        {
            var numbers = new List<int> { 80, 70, 90, 60, 10, 50 };
            var smallests = GetSmallests(numbers, 3);

            foreach (var number in smallests)
                Console.WriteLine(number);

            Console.ReadLine();
        }

        public static List<int> GetSmallests(List<int> list, int count)
        {
            // Handle the edge cases when:
            // 1) the list is null 
            // 2) list is either empty or
            // 3) number of elements in the list are smaller than the count or
            // 4) the count itself is 0 or negative number
            if (list == null)
                throw new ArgumentNullException("list");

            if (count > list.Count || count <= 0)
                throw new ArgumentOutOfRangeException("count", "should be between 1 and the number of elements in the list");

            // use buffer to remove the side effect of using list param.
            // This way we pass the buffer to GetSmallest() and
            // also, do not remove elements from the original list but from buffer
            var buffer = new List<int>(list);   
            var smallests = new List<int>();

            while (smallests.Count < count)
            {
                var min = GetSmallest(buffer);
                smallests.Add(min);
                buffer.Remove(min);
            }

            return smallests;
        }

        public static int GetSmallest(List<int> list)
        {
            //return list.Min(x => x);

            // assume the first element is the smallest
            var min = list[0];
            for (var i = 1; i < list.Count; i++)
            {
                if (list[i] < min)
                {
                    min = list[i];
                }
            }

            return min;
        }
    }
}
