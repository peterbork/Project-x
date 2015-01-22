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
        public static string selectedSensor = "";
        Controller _controller;
        List<Sensor> sensors = new List<Sensor>();
        public MainWindow() {
            _controller = new Controller();
            InitializeComponent();
            batteryChanged.IsEnabled = false;
            locationInPeriod.IsEnabled = false;
            temperaturInPeriod.IsEnabled = false;

        }

        private void loaded(object sender, RoutedEventArgs e) {
            updateSensors();
        }
        public void updateSensors() {
            sensors = _controller.GetSensors();
            DateTime today = DateTime.Today;
            foreach (Sensor s in sensors) {

                int SensorValue = _controller.GetNewestTemperatureFromSensorID(s.Id).SensorValueInOhm;
                var diff = today - s.BatteryLastChanged;
                double daysdiff = diff.Days;
                
                string SensorInfo = "";
                if (daysdiff > 240) {
                    SensorInfo += "[battery] ";
                }

                if (SensorValue < 800 || SensorValue > 20000)
                {
                    SensorInfo += "[Temperatur] ";
                }
                
                listbox1.Items.Add(SensorInfo + _controller.getName(s.CprNr).Name + " - " + daysdiff + " Dage");
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
                batteryChanged.IsEnabled = true;
                locationInPeriod.IsEnabled = true;
                temperaturInPeriod.IsEnabled = true;
                sensorInfo.Text = "Navn: " + _controller.getName(sensors[listbox1.SelectedIndex].CprNr).Name + "\n";
                sensorInfo.Text += "CPR: " + sensors[listbox1.SelectedIndex].CprNr + "\n";
                sensorInfo.Text += "Latitude: " + _controller.GetNewestLocationFromSensorID(sensors[listbox1.SelectedIndex].Id).Latitude;
                sensorInfo.Text += " Longitude: " +_controller.GetNewestLocationFromSensorID(sensors[listbox1.SelectedIndex].Id).Longitude + "\n";
                sensorInfo.Text += "Positions tid: " + _controller.GetNewestLocationFromSensorID(sensors[listbox1.SelectedIndex].Id).DateTime + "\n";
                sensorInfo.Text += "\nSensor: \n";
                sensorInfo.Text += sensors[listbox1.SelectedIndex].Id + "\n";
                sensorInfo.Text += sensors[listbox1.SelectedIndex].Model + "\n";
                sensorInfo.Text += sensors[listbox1.SelectedIndex].BatteryLastChanged.Date;
                selectedSensor = sensors[listbox1.SelectedIndex].CprNr;
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
