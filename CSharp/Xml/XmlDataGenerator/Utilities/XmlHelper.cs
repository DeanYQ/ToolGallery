using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Utilities
{
    public class XmlHelper
    {
        public XmlHelper(XmlSetting setting)
        {
            setting_ = setting;
            IdStub = new List<int>();
            IdPrefix = new string[]
            {
                "A", "B", "C", "D","E", "F", "G","H","I", "J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"
            };

            IdStub.AddRange(Enumerable.Range(1, setting.ItemCount));

        }

        private XmlSetting setting_ { get; set; }

        public List<int> IdStub { get; set; }

        private Random random_ = new Random();

        private string[] IdPrefix { get; set; }

        public const string FirstLevelElementName = "Item";
        public const string SecondLevelElementName = "ChildItem";

        public const string IdAttr = "ID";
        public const string AttrPrefix = "Attr";

        public const string ChildAttrPrefix = "ChildAttr";

        public void Generate()
        {
            using (var fileStream = File.Create("data.xml"))
            {
                var settings = new XmlWriterSettings { Async = true, Indent = true };
                using (var writer = XmlWriter.Create(fileStream, settings))
                {
                    writer.WriteStartElement("Items");

                    for (var i = 0; i < setting_.ItemCount; i++)
                    {
                        GenerateFirstLevel(writer);
                    }
                    writer.WriteEndElement();
                }
            }
        }

        public void GenerateFirstLevel(XmlWriter writer)
        {
            writer.WriteStartElement("Item");
            var idStr = GetIdString();
            writer.WriteAttributeString(IdAttr, idStr);
            GenerateAttribute(writer);
            GenerateChildElement(writer);
            writer.WriteEndElement();
        }

        public void GenerateChildElement(XmlWriter writer)
        {
            var childCount = random_.Next(0, setting_.ChildCount);
            for (var i = 1; i <= childCount + 1; i++)
            {
                var idStr = GetIdString();
                writer.WriteStartElement(SecondLevelElementName);
                writer.WriteAttributeString(IdAttr, idStr);
                GenerateAttribute(writer);
                writer.WriteEndElement();
            }
        }

        public void GenerateAttribute(XmlWriter writer)
        {
            var leng = random_.Next(1, setting_.MaxAttrCount);
            for (var j = 1; j <= leng + 1; j++)
            {
                var attrV = random_.Next(setting_.MaxAttrValue);
                writer.WriteAttributeString(AttrPrefix + j, attrV.ToString());
            }
        }

        public XmlDataManager manager = new XmlDataManager();

        //public int ReadToDict()
        //{
        //    var i = 0;
        //    var reader = new XmlTextReader("data.xml");
        //    while (reader.Read())
        //    {
        //        switch (reader.NodeType)
        //        {
        //            case XmlNodeType.Element:
        //                {
        //                    if (reader.Name.Equals("ChildItem"))
        //                    {
        //                        var id = reader.GetAttribute("ID");
        //                        var val = int.Parse(reader.GetAttribute("Attr1"));
        //                        var item = new XmlItem()
        //                        {
        //                            Id = id,
        //                            Value = val
        //                        };
        //                        manager.Dict.Add(id, item);
        //                    }
        //                    break;
        //                }
        //        }
        //    }
        //    return i;
        //}

        public Dictionary<string, XmlItem> ReadToDict()
        {
            var dict = new Dictionary<string, XmlItem>();
            var reader = new XmlTextReader("data.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        {
                            if (reader.Name.Equals("ChildItem"))
                            {
                                var id = reader.GetAttribute("ID");
                                var val = int.Parse(reader.GetAttribute("Attr1"));
                                var item = new XmlItem()
                                {
                                    Id = id,
                                    Value = val
                                };
                                dict.Add(id, item);
                            }
                            break;
                        }
                }
            }
            return dict;
        }

        public HashSet<XmlItem> ReadToHashSet()
        {
            var set = new HashSet<XmlItem>();
            var reader = new XmlTextReader("data.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        {
                            if (reader.Name.Equals("ChildItem"))
                            {
                                var id = reader.GetAttribute("ID");
                                var val = int.Parse(reader.GetAttribute("Attr1"));
                                var item = new XmlItem()
                                {
                                    Id = id,
                                    Value = val
                                };
                                set.Add(item);
                            }
                            break;
                        }
                }
            }
            return set;
        }

        public List<XmlItem> ReadToList()
        {
            var items = new List<XmlItem>();
            var reader = new XmlTextReader("data.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        {
                            if (reader.Name.Equals("ChildItem"))
                            {
                                var id = reader.GetAttribute("ID");
                                var val = int.Parse(reader.GetAttribute("Attr1"));
                                var item = new XmlItem()
                                {
                                    Id = id,
                                    Value = val
                                };
                                items.Add(item);
                            }
                            break;
                        }
                }
            }
            return items;
        }

        private long arrayIndex = 0;

        public XmlItem[] ReadToArray()
        {
            var length = 0;
            var items = new XmlItem[10000000];
            var reader = new XmlTextReader("data.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        {
                            if (reader.Name.Equals("ChildItem"))
                            {
                                var id = reader.GetAttribute("ID");
                                var val = int.Parse(reader.GetAttribute("Attr1"));
                                var item = new XmlItem()
                                {
                                    Id = id,
                                    Value = val
                                };
                                items[arrayIndex] = item;
                                arrayIndex++;
                                length++;
                            }
                            break;
                        }
                }
            }
            var newArr = new XmlItem[length];
            Array.Copy(items, newArr, length);
            return newArr;
        }

        ////public int ReadByDefinedParam()
        ////{
        ////    var i = 0;
        ////    var reader = new XmlTextReader("data.xml");
        ////    while (reader.Read())
        ////    {
        ////        switch (reader.NodeType)
        ////        {
        ////            case XmlNodeType.Element:
        ////                {
        ////                    if (reader.Name.Equals("ChildItem"))
        ////                    {

        ////                    }
        ////                }
        ////        }
        ////    }
        ////    return i;
        ////}

        private string GetIdString()
        {
            //var cindex = random_.Next(26);
            //var num = random_.Next(setting_.ItemCount + 1);
            //
            //return IdPrefix[cindex] + num;
            return id++.ToString();
        }

        private long id = 0;
    }
}
