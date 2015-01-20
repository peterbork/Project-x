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
    /// Interaction logic for RegisterPerson.xaml
    /// </summary>
    public partial class RegisterPerson : Window {
        Controller _controller;
        public RegisterPerson() {
            InitializeComponent();
            _controller = new Controller();
        }

        private void SetPerson_Click(object sender, RoutedEventArgs e) {
            _controller.RegisterNewPerson(textbox1.Text, textbox2.Text);
        }
    }
}
