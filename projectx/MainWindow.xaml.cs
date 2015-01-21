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

namespace projectx {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        Controller _controller;
        List<Sensor> sensors = new List<Sensor>();
        public MainWindow() {
            _controller = new Controller();
            InitializeComponent();
        }

        private void loaded(object sender, RoutedEventArgs e) {
            updateSensors();
        }
        public void updateSensors() {
            sensors = _controller.GetSensors();
            foreach (Sensor s in sensors) {
                DateTime today = DateTime.Today;
                var diff = today - s.BatteryLastChanged;
                double daysdiff = diff.Days;
                if (daysdiff > 240) {
                    listbox1.Items.Add("*Outdated: " + _controller.getName(s.CprNr).Name + " - " + daysdiff + " Dage");
                }
                else {
                    listbox1.Items.Add(_controller.getName(s.CprNr).Name + " - " + daysdiff + " Dage");
                }
            }
        }

        private void personWindow_Click(object sender, RoutedEventArgs e) {
            RegisterPerson window = new RegisterPerson();
            window.Show();
        }

        private void sensorWindow_Click(object sender, RoutedEventArgs e) {
            RegisterSensor window = new RegisterSensor();
            window.Show();
        }

        private void listbox1_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            try {
                sensorInfo.Text = _controller.getName(sensors[listbox1.SelectedIndex].CprNr).Name + "\n";
                sensorInfo.Text += sensors[listbox1.SelectedIndex].CprNr + "\n";
                sensorInfo.Text += _controller.GetNewestLocationFromSensorID(sensors[listbox1.SelectedIndex].Id).Latitude + "\n";
                sensorInfo.Text += _controller.GetNewestLocationFromSensorID(sensors[listbox1.SelectedIndex].Id).Longitude + "\n";
                sensorInfo.Text += _controller.GetNewestLocationFromSensorID(sensors[listbox1.SelectedIndex].Id).DateTime + "\n";
                sensorInfo.Text += sensors[listbox1.SelectedIndex].Id + "\n";
                sensorInfo.Text += sensors[listbox1.SelectedIndex].Model + "\n";
                sensorInfo.Text += sensors[listbox1.SelectedIndex].BatteryLastChanged;
            }
            catch {
            
            }
        }

        private void batteryChanged_Click(object sender, RoutedEventArgs e) {
            int selected = listbox1.SelectedIndex;
            _controller.UpdateBatteryStatusOnSensorFromSensorID(sensors[listbox1.SelectedIndex].Id);
            listbox1.Items.Clear();
            updateSensors();
            listbox1.SelectedIndex = selected;
        }

        private void locationInPeriod_Click(object sender, RoutedEventArgs e) {
            LocationInPeriod window = new LocationInPeriod();
            window.Show();
        }




        
    }
}
