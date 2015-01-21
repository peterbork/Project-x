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

        }


        private void swag_Click(object sender, RoutedEventArgs e) {
            System.Windows.MessageBox.Show(_controller.GetSensorFromCPRNR(MainWindow.selectedSensor).Id);
            List<Location> locations = _controller.GetIntervalLocationFromSensorID(_controller.GetSensorFromCPRNR(MainWindow.selectedSensor).Id, Convert.ToDateTime(startDate.Text), Convert.ToDateTime(endDate.Text));
            foreach (Location l in locations) {
                AllLocations.Items.Add(l.DateTime + ": " + l.Latitude + " - " + l.Longitude);
            }
        }
    }
}
