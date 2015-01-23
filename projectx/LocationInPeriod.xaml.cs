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
using System.Windows.Shapes;

namespace projectx {
    /// <summary>
    /// Interaction logic for LocationInPeriod.xaml
    /// </summary>
    public partial class LocationInPeriod : Window {
        Controller _controller;
        public LocationInPeriod() {
            _controller = new Controller();
            InitializeComponent();
            selectedPerson.Content = _controller.getName(MainWindow.selectedSensor).Name;
            endDate.Text = DateTime.Now.ToString();
        }


        private void swag_Click(object sender, RoutedEventArgs e) {
            List<Location> locations = _controller.GetIntervalLocationFromSensorID(_controller.GetSensorFromCPRNR(MainWindow.selectedSensor).Id, Convert.ToDateTime(startDate.Text), Convert.ToDateTime(endDate.Text));
            foreach (Location l in locations) {
                AllLocations.Items.Add(l.DateTime + ": " + l.Latitude + " - " + l.Longitude);
            }
            int distance = int.Parse(maxDistance.Text);
            int haveLeftCounter = 0;
            foreach (Location l in locations) {
                if ((int.Parse(l.Latitude) > distance || int.Parse(l.Latitude) < -distance) || (int.Parse(l.Longitude) > distance || int.Parse(l.Longitude) < -distance)) {
                    haveLeftCounter++;
                    back.Content = "Ja";
                }
                else {
                    back.Content = "Nej";
                }
                if (haveLeftCounter > 0) {
                    haveLeft.Content = "Ja";
                }
                else {
                    haveLeft.Content = "Nej";
                }
                haveLeftCount.Content = haveLeftCounter.ToString();
            }
          
            
            
            //Location newest = locations[locations.Count - 1];
            //if (int.Parse(newest.Latitude) < distance && int.Parse(newest.Latitude) > -distance && int.Parse(newest.Longitude) < distance && int.Parse(newest.Longitude) > -distance) {
            //    back.Content = "Ja";
            //}else{
            //    back.Content = "Nej";
            //}
        }
    }
}
