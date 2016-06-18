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
using System.Windows.Threading;

namespace Time_V_5
{
    public partial class MainWindow : Window
    {
        //VAR DEC
        DateTime today;

        int wDaysPassed;
        int zDaysPassed;
        int pDaysPassed;

        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            today = DateTime.Today.Date;

            timer.Interval = TimeSpan.FromMinutes(50);
            timer.Tick += timerTick;

            wDaysGone();
            zDaysGone();
            pDaysGone();
            Warning();
        }

        private void timerTick(object sender, EventArgs e)
        {
            if (today == DateTime.Today.Date) return;
            today = DateTime.Today.Date;
            wDaysGone();
            zDaysGone();
            pDaysGone();
            Warning();
        }
        
        public void wDaysGone()
        {
            //Heute minus gespeichertes Datum = Anzahl vergangener Tage
            //Und die Ausgabe

            wDaysPassed = (today - Properties.Settings.Default.wDateSaverSetting).Days;
            
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

            zDaysPassed = (today - Properties.Settings.Default.zDateSaverSetting).Days;
            
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

            pDaysPassed = (today - Properties.Settings.Default.pDateSaverSetting).Days;
            
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
            //Warnungs IMGs langsam einblenden
            if (wDaysPassed == 1 || zDaysPassed == 1 || pDaysPassed == 1)
            {
                warnimg.Opacity = 0.1;
                deathimg.Opacity = 0.1;
            }

            else if (wDaysPassed == 2 || zDaysPassed == 2 || pDaysPassed == 2)
            {
                warnimg.Opacity = 0.2;
                deathimg.Opacity = 0.2;
            }

            else if (wDaysPassed == 3 || zDaysPassed == 3 || pDaysPassed == 3)
            {
                warnimg.Opacity = 0.3;
                deathimg.Opacity = 0.3;
            }

            //Warnungs IMGs anzeigen
            if (wDaysPassed > 3 && wDaysPassed <= 6 || zDaysPassed > 3 && zDaysPassed <= 6 || pDaysPassed > 3 && pDaysPassed <= 6)
            {
                warnimg.Visibility = Visibility.Visible;
            }

            else if (wDaysPassed > 6 || zDaysPassed > 6 || pDaysPassed > 6)
            {
                warnimg.Visibility = Visibility.Visible;
                deathimg.Visibility = Visibility.Visible;
            }
        }
        
        private void b_waterFilled_Click(object sender, RoutedEventArgs e)
        {
            wBar.Value = 100;
            wDaysGoneField.Content = "Weniger als 24 Stunden";

            //Update Setting
            Properties.Settings.Default.wDateSaverSetting = DateTime.Today.Date;
            Properties.Settings.Default.Save();

            //And Update work VAR
            wDaysPassed = 0;

            //Check Warnings
            Warning();
        }

        private void b_sugarFilled_Click(object sender, RoutedEventArgs e)
        {
            zBar.Value = 100;
            zDaysGoneField.Content = "Weniger als 24 Stunden";

            //Update Setting
            Properties.Settings.Default.zDateSaverSetting = DateTime.Today.Date;
            Properties.Settings.Default.Save();

            //And Update work VAR
            zDaysPassed = 0;

            //Check Warnings
            Warning();
        }

        private void b_proteinFilled_Click(object sender, RoutedEventArgs e)
        {
            pBar.Value = 100;
            pDaysGoneField.Content = "Weniger als 24 Stunden";

            //Update Settings
            Properties.Settings.Default.pDateSaverSetting = DateTime.Today.Date;
            Properties.Settings.Default.Save();

            //And Update work VAR
            pDaysPassed = 0;
            
            //Check Warnings
            Warning();
        }       
    }

}
