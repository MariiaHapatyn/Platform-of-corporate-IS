﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Task3
{
    /// <summary>
	/// Interaction logic for OrderWindow.xaml
	/// </summary>
	public partial class OrderWindow : Window
    {
       
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private DateTime startTime;
        private TimeSpan elapsedTime;
        public OrderWindow()
        {
            InitializeComponent();
           
        }
        private void startTimer()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            startTime = DateTime.Now;
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            elapsedTime = DateTime.Now - startTime;
            timerDesc.Content = elapsedTime.ToString();
        }
        private void startRoad_Click(object sender, RoutedEventArgs e)
        {
            startTimer();
        }
        private void endRoad_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}