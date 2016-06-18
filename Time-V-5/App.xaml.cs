﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Time_V_5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void closeApplicationMethod()
        {
            Console.WriteLine("Shutting down by users demand!");
            Application.Current.Shutdown();
        }
    }
}
