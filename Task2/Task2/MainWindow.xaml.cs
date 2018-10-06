using Microsoft.Win32;
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
using Task2.Classes;
using Task2.BL;
using System.Collections.ObjectModel;

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // public ObservableCollection<Polygon> Hexagones { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        //private void Click_New(object sender, RoutedEventArgs e)
        //{
        //    if (Hexagones != null)
        //    {
        //        Hexagones.Clear();
        //    }
        //    //OnPropertyChanged("Hexagones");
        //}

        //private void Click_Open(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.DefaultExt = ".xml";
        //    openFileDialog.Filter = "XML documents (.xml)|*.xml";
        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        string fileName = openFileDialog.FileName;
        //        List<Hexagone> hexagones = HexagoneBL.DeserializeList(fileName);
        //        Hexagones.Clear();
        //        for (int i = 0; i < hexagones.Count; ++i)
        //        {
        //            Hexagones.Add(new Polygon() { Name = String.Format("Hexagone_{0}", i + 1), Stroke = Brushes.Black, Points = hexagones[i].Points, Fill = new SolidColorBrush(hexagones[i].HexagoneColor) });
        //        }
        //        //OnPropertyChanged("Hexagones");
        //    }
        //}

        //private void Click_Save(object sender, RoutedEventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.DefaultExt = ".xml";
        //    saveFileDialog.FileName = "New_shapes.xml";
        //    saveFileDialog.Filter = "XML documents (.xml)|*.xml";
        //    if (saveFileDialog.ShowDialog() == true)
        //    {
        //        string fileName = saveFileDialog.FileName;
        //        List<Hexagone> hexagones = new List<Hexagone>();
        //        foreach (var elem in Hexagones)
        //        {
        //            hexagones.Add(new Hexagone(elem));
        //        }
        //        HexagoneBL.SerializeList(hexagones, fileName);
        //    }
        //}

        //private void Click_Exit(object sender, RoutedEventArgs e)
        //{
        //    Close();
        //}
    }
}
