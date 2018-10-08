﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Shapes;
using Task2.BL;

namespace Hexagone_Tests
{
    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public void Test_ViwModelCurentColorProperty()
        {
            MainViewModel viewModel = new MainViewModel();
            viewModel.CurrentColor = Colors.Gold;
            Assert.AreEqual(viewModel.CurrentColor, Colors.Gold);
        }

        [TestMethod]
        public void Test_ViewModelObseverableCollection()
        {
            MainViewModel viewModel = new MainViewModel();
            ObservableCollection<Polygon> collection = new ObservableCollection<Polygon>();
            collection.Add(new Polygon());
            collection.Add(new Polygon());
            viewModel.Hexagones = collection;
            Assert.AreEqual(viewModel.Hexagones.Count, 2);
        }

        [TestMethod]
        public void Test_ViewModelClearWindow()
        {
            MainViewModel viewModel = new MainViewModel();
            ObservableCollection<Polygon> collection = new ObservableCollection<Polygon>();
            collection.Add(new Polygon());
            collection.Add(new Polygon());
            collection.Add(new Polygon());
            collection.Add(new Polygon());
            viewModel.Hexagones = collection;
            viewModel.Hexagones.Clear();
            Assert.AreEqual(viewModel.Hexagones.Count, 0);
        }
    }
}