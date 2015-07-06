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
using System.Timers;
//using System.Data.SqlClient;
//test

namespace Time_V_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

     


    public partial class MainWindow : Window
    {

        //VAR DEC
        DateTime thisDay = DateTime.Today;
        

        DateTime wSavedDate;
        DateTime zSavedDate;
        DateTime pSavedDate;


        int wDaysPassed;
        int zDaysPassed;
        int pDaysPassed;


        public MainWindow()
        {
            InitializeComponent();


            LoadSettingsMethod();


            wDaysGone();
            zDaysGone();
            pDaysGone();

            Warning();
            //Datechanged();
            

            
           
        }


        public void Datechanged()
        {
        while (true)
            {

                String CurrentDate;

                CurrentDate = DateTime.Now.ToString();

                if (CurrentDate.Contains("00:00:00 AM")) //"00:00:00"
                {
                    wDaysGone();
                    zDaysGone();
                    pDaysGone();

                    Warning();
                }

            }
        }


        public void LoadSettingsMethod()
        {
            //Daten laden
            wSavedDate = Properties.Settings.Default.wDateSaverSetting;
            zSavedDate = Properties.Settings.Default.zDateSaverSetting;
            pSavedDate = Properties.Settings.Default.pDateSaverSetting;
        }



        public void wDaysGone()
        {
           
            //Heute minus gespeichertes Datum = Anzahl vergangener Tage
            //Und die Ausgabe

            wDaysPassed = (thisDay - wSavedDate).Days;


            if (wDaysPassed == 0)
            {
                wDaysGoneField.Content = "Weniger als 24 Stunden";
                wBar.Value = 100;
            }
            else if (wDaysPassed == 1)
            {
                wDaysGoneField.Content = "Vor einem Tag";
                wBar.Value = 66;
            }
            else if (wDaysPassed == 2)
            {
                wDaysGoneField.Content = "Vor " + wDaysPassed + " Tagen";
                wBar.Value = 33;
            }
            else
            {
                wDaysGoneField.Content = "Vor " + wDaysPassed + " Tagen";
                wBar.Value = 0;
            }
        }



        public void zDaysGone()
        {
            
            //Heute minus gespeichertes Datum = Anzahl vergangener Tage
            //Und die Ausgabe

            zDaysPassed = (thisDay - zSavedDate).Days;


            if (zDaysPassed == 0)
            {
                zDaysGoneField.Content = "Weniger als 24 Stunden";
                zBar.Value = 100;
            }
            else if (zDaysPassed == 1)
            {
                zDaysGoneField.Content = "Vor einem Tag";
                zBar.Value = 66;
            }
            else if (zDaysPassed == 2)
            {
                zDaysGoneField.Content = "Vor " + wDaysPassed + " Tagen";
                zBar.Value = 33;
            }
            else
            {
                zDaysGoneField.Content = "Vor " + wDaysPassed + " Tagen";
                zBar.Value = 0;
            }
        }



        public void pDaysGone()
        {
            
            //Heute minus gespeichertes Datum = Anzahl vergangener Tage
            //Und die Ausgabe

            pDaysPassed = (thisDay - pSavedDate).Days;


            if (pDaysPassed == 0)
            {
                pDaysGoneField.Content = "Weniger als 24 Stunden";
                pBar.Value = 100;
            }
            else if (pDaysPassed == 1)
            {
                pDaysGoneField.Content = "Vor einem Tag";
                pBar.Value = 66;
            }
            else if (pDaysPassed == 2)
            {
                pDaysGoneField.Content = "Vor " + wDaysPassed + " Tagen";
                pBar.Value = 33;
            }
            else
            {
                pDaysGoneField.Content = "Vor " + wDaysPassed + " Tagen";
                pBar.Value = 0;
            }
        }


        public void Warning()
        {
            if (wDaysPassed == 1)
            {
                warnimg.Opacity = 0.1;
                deathimg.Opacity = 0.1;
            }

            else if (wDaysPassed == 2)
            {
                warnimg.Opacity = 0.2;
                deathimg.Opacity = 0.2;
            }

            else if (wDaysPassed == 3)
            {
                warnimg.Opacity = 0.3;
                deathimg.Opacity = 0.3;
            }

            //Warnungsfeld anzeigen
            if (wDaysPassed > 3 && wDaysPassed <= 6)
            {
                warnimg.Visibility = Visibility.Visible;
            }
            else if (wDaysPassed > 6)
            {
                warnimg.Visibility = Visibility.Visible;
                deathimg.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wBar.Value = 100;
            wDaysGoneField.Content = "Weniger als 24 Stunden";

            Properties.Settings.Default.wDateSaverSetting = thisDay;
            Properties.Settings.Default.Save();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            zBar.Value = 100;
            zDaysGoneField.Content = "Weniger als 24 Stunden";

            Properties.Settings.Default.zDateSaverSetting = thisDay;
            Properties.Settings.Default.Save();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            pBar.Value = 100;
            pDaysGoneField.Content = "Weniger als 24 Stunden";

            Properties.Settings.Default.pDateSaverSetting = thisDay;
            Properties.Settings.Default.Save();

        }
    }

}
