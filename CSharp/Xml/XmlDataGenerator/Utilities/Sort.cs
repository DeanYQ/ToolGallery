using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utilities
{
    public static class SortHelper
    {
        /// <summary>
        ///  Sort by array
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static XmlItem[] Sort(XmlItem[] items)
        {
            return null;
        }

        /// <summary>
        ///  Sort by default
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Dictionary<int, XmlItem> Sort(Dictionary<int, XmlItem> items)
        {
            return null;
        }

        public static void QuickSort(XmlItem[] src, int low, int high)
        {
            //await Task.Run(() =>
            //{
            //    if (low < high)
            //    {
            //        int pivotloc = Partition(src, low, high);

            //        var t1 = QuickSort(src, low, pivotloc - 1);
            //        var t2 = QuickSort(src, pivotloc + 1, high);

            //        Task.WaitAll(t1, t2);
            //    }
            //});

            if (low < high)
            {
                int pivotloc = Partition(src, low, high);

                var l = low;
                var h = high;

                QuickSort(src, l, pivotloc - 1);
                QuickSort(src, pivotloc + 1, h);

                //var t1 = QuickSort(src, l, pivotloc - 1);
                //var t2 = QuickSort(src, pivotloc + 1, h);
                //Parallel.Invoke(() => { QuickSort(src, l, pivotloc - 1); }, () => { QuickSort(src, pivotloc + 1, h); });

                //var t1 = Task.Run(() =>
                //{
                //    QuickSort(src, l, pivotloc - 1);
                //});
                //var t2 = Task.Run(() =>
                //{
                //    QuickSort(src, pivotloc + 1, h);
                //});
                //Task.WaitAll(t1, t2);

                //Task.WaitAll(t1, t2);
            }
        }

        public static int Partition(XmlItem[] src, int low, int high)
        {
            XmlItem v = src[low];
            int k = low;
            while (low < high)
            {
                while (low < high && src[high].Value >= v.Value)
                    --high;

                src[low] = src[high];

                while (low < high && src[low].Value <= v.Value)
                    ++low;

                src[high] = src[low];
            }

            src[low] = v;

            return low;
        }

        public static void MergeSort(XmlItem[] a, int f, int e)
        {
            if (f < e)
            {
                int mid = (f + e) / 2;
                MergeSort(a, f, mid);
                MergeSort(a, mid + 1, e);
                MergeMethid(a, f, mid, e);
            }
        }
        private static void MergeMethid(XmlItem[] a, int f, int mid, int e)
        {
            XmlItem[] t = new XmlItem[e - f + 1];
            int m = f, n = mid + 1, k = 0;
            while (n <= e && m <= mid)
            {
                if (a[m].Value > a[n].Value) t[k++] = a[n++];
                else t[k++] = a[m++];
            }
            while (n < e + 1) t[k++] = a[n++];
            while (m < mid + 1) t[k++] = a[m++];
            for (k = 0, m = f; m < e + 1; k++, m++) a[m] = t[k];
        }
    }
}
