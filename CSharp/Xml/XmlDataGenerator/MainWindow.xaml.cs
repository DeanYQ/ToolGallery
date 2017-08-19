using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Newtonsoft.Json;

namespace XmlDataGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private XmlSetting LoadSetting()
        {
            var json = File.ReadAllText("Param.json");
            return JsonConvert.DeserializeObject<XmlSetting>(json);
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            var setting = LoadSetting();
            var helper = new XmlHelper(setting);

            helper.Generate();
        }

        private void btnXmlDocLoad_Click(object sender, RoutedEventArgs e)
        {
            //var doc = new XmlDocument();
            //doc.Load("data.xml");
            var setting = LoadSetting();
            var helper = new XmlHelper(setting);

            var i = helper.Read();
        }
    }
}
