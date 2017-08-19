using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace XmlDataGenerator
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
                writer.WriteStartElement(SecondLevelElementName + i);
                GenerateAttribute(writer);
                writer.WriteEndElement();
            }
        }

        public void GenerateAttribute(XmlWriter writer)
        {
            var leng = random_.Next(setting_.MaxAttrCount);
            for (var j = 1; j <= leng + 1; j++)
            {
                var attrV = random_.Next(setting_.MaxAttrValue);
                writer.WriteAttributeString(AttrPrefix + j, attrV.ToString());
            }
        }

        public int Read()
        {
            var i = 0;
            var reader = new XmlTextReader("data.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                    {
                        //i++;
                        //var name = reader.Name;
                        break;
                    }
                }
            }
            return i;
        }

        private string GetIdString()
        {
            var cindex = random_.Next(26);
            var num = random_.Next(setting_.ItemCount + 1);

            return IdPrefix[cindex] + num;
        }
    }

    public class XmlSetting
    {
        public int ItemCount { get; set; }

        public int MaxAttrCount { get; set; }

        public int MaxAttrValue { get; set; }

        public int ChildCount { get; set; }
    }
}