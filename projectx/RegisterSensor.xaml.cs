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
    /// Interaction logic for RegisterSensor.xaml
    /// </summary>
    public partial class RegisterSensor : Window {
        Controller _controller;
        public RegisterSensor() {
            InitializeComponent();
            _controller = new Controller();
        }

        private void SetSensor_Click(object sender, RoutedEventArgs e) {
            _controller.RegisterNewSensor(textbox3.Text, PersonList.Text, textbox5.Text, Convert.ToDateTime(textbox6.Text));
        }
    }
}
