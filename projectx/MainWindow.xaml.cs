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

        private void SetPerson_Click(object sender, RoutedEventArgs e) {
            _controller.RegisterNewPerson(textbox1.Text, textbox2.Text);
        }
        private void SetSensor_Click(object sender, RoutedEventArgs e) {
            _controller.RegisterNewSensor(textbox3.Text, textbox4.Text, textbox5.Text, Convert.ToDateTime(textbox6.Text));
        }


        private void loaded(object sender, RoutedEventArgs e) {
            sensors = _controller.GetSensors();
            foreach (Sensor s in sensors) {
                listbox1.Items.Add(s.Id + ": " + s.BatteryLastChanged);
            }
        }

        
    }
}
