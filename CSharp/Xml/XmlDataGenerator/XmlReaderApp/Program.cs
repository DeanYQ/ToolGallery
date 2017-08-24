using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Utilities;
using System.IO;

namespace XmlReaderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Generate();
            ArrayTest();
            //HashSetTest();
            //DictionaryTest();
            //ListTest();
            Console.Read();
        }

        static void ListTest()
        {
            var watcher1 = new Stopwatch();
            var watcher2 = new Stopwatch();
            var watcher3 = new Stopwatch();
            var setting = LoadSetting();
            var helper = new XmlHelper(setting);

            watcher1.Start();
            List<XmlItem> list = helper.ReadToList();
            Console.WriteLine("List: Read: {0}", watcher1.ElapsedMilliseconds);
            watcher1.Stop();

            watcher2.Start();
            var ordered = list.OrderBy(i => i.Value).ToArray();
            Console.WriteLine("List: OrderBy: {0}", watcher2.ElapsedMilliseconds);
            watcher2.Stop();

            watcher3.Start();
            list.Sort(Comparison);
            Console.WriteLine("List: Sort: {0}", watcher3.ElapsedMilliseconds);
            watcher3.Stop();
            Console.WriteLine("----------------------------------");
        }

        static void DictionaryTest()
        {
            var watcher1 = new Stopwatch();
            var watcher2 = new Stopwatch();
            var setting = LoadSetting();
            var helper = new XmlHelper(setting);

            watcher1.Start();
            var dict = helper.ReadToDict();
            Console.WriteLine("Dictionary: Read: {0}", watcher1.ElapsedMilliseconds);
            watcher1.Stop();

            watcher2.Start();
            //var ordered = dict.OrderBy(i => i.Value.Value).ToDictionary(i => i.Key, i => i.Value);
            var ordered = dict.OrderBy(i => i.Value.Value).ToArray();
            Console.WriteLine("Dictionary: OrderBy: {0}", watcher2.ElapsedMilliseconds);
            watcher2.Stop();
            Console.WriteLine("----------------------------------");

        }

        static void HashSetTest()
        {
            var watcher1 = new Stopwatch();
            var watcher2 = new Stopwatch();
            var setting = LoadSetting();
            var helper = new XmlHelper(setting);

            watcher1.Start();
            var set = helper.ReadToHashSet();
            Console.WriteLine("HashSet: Read: {0}", watcher1.ElapsedMilliseconds);
            watcher1.Stop();

            watcher2.Start();
            var ordered = set.OrderBy(i => i.Value).ToArray();
            Console.WriteLine("HashSet: OrderBy: {0}", watcher2.ElapsedMilliseconds);
            watcher2.Stop();
            Console.WriteLine("----------------------------------");

        }

        static void ArrayTest()
        {
            var watcher1 = new Stopwatch();
            var watcher2 = new Stopwatch();
            var watcher3 = new Stopwatch();
            var watcher4 = new Stopwatch();
            var setting = LoadSetting();
            var helper = new XmlHelper(setting);

            watcher1.Start();
            var array = helper.ReadToArray();
            Console.WriteLine("Array: Read: {0}", watcher1.ElapsedMilliseconds);
            watcher1.Stop();

            //watcher2.Start();
            //var ordered = array.OrderBy(i => i.Value).ToArray();
            //Console.WriteLine("Array: OrderBy: {0}", watcher2.ElapsedMilliseconds);
            //watcher2.Stop();

            XmlItem[] copy1 = (XmlItem[])array.Clone();
            watcher3.Start();
            SortHelper.QuickSort(copy1, 0, array.Length - 1);
            Console.WriteLine("Array: QuickSort: {0}", watcher3.ElapsedMilliseconds);
            watcher3.Stop();

            XmlItem[] copy2 = (XmlItem[])array.Clone();
            watcher4.Start();
            SortHelper.MergeSort(copy2, 0, array.Length - 1);
            Console.WriteLine("Array: MergeSort: {0}", watcher4.ElapsedMilliseconds);
            watcher4.Stop();
            Console.WriteLine("----------------------------------");

        }

        public static int Comparison(XmlItem x, XmlItem y)
        {
            return x.Value - y.Value;
        }

        private static XmlSetting LoadSetting()
        {
            var json = File.ReadAllText("Param.json");
            return JsonConvert.DeserializeObject<XmlSetting>(json);
        }

        private static void Generate()
        {
            var watcher = new Stopwatch();
            var setting = LoadSetting();
            var helper = new XmlHelper(setting);
            watcher.Start();
            Console.WriteLine("Generating...");
            helper.Generate();
            Console.WriteLine("Generated completed: {0}", watcher.Elapsed);
        }
    }
}
