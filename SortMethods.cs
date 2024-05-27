using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOnellect
{
    public class SortMethods
    {
        public void BubbleSort(List<int> array)
        {
            for (var i = 0; i < array.Count - 1; i++)
                for (var j = 0; j < array.Count - i - 1; j++)
                    if (array[j] > array[j + 1])
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
        }

        public void QuickSort(List<int> array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot) i++;

                while (array[j] > pivot) j--;

                if (i <= j)
                {
                    (array[i], array[j]) = (array[j], array[i]);
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                QuickSort(array, leftIndex, j);
            if (i < rightIndex)
                QuickSort(array, i, rightIndex);
        }

        public void QuickSort(List<int> array)
        {
            QuickSort(array, 0, array.Count - 1);
        }

        public void RandomSort(List<int> array)
        {
            SortMethod[] sortMethods = [QuickSort, BubbleSort];

            var r = new Random();
            var randomMethod = sortMethods[r.Next(sortMethods.Length)];
            Console.WriteLine(randomMethod.Method.Name);
            randomMethod(array);
        }

        private delegate void SortMethod(List<int> arr);
    }
}
