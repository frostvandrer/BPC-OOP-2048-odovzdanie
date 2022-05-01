using _2048_WPF.Data;
using _2048_WPF.Model;
using System;
using System.Collections.Generic;
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

namespace _2048_WPF.View
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Page
    {
        public Statistics()
        {
            InitializeComponent();
            StatisticsTextbox.Content = LoadStatistics();
        }

        public string LoadStatistics()
        {
            Database db = new Database(new GameDataClassesDataContext());

            Dictionary<string, string> data = db.AllStats();
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> entry in data)
            {
                sb.Append($"{entry.Key}: {entry.Value}\n");
            }

            return sb.ToString();
        }
    }
}
