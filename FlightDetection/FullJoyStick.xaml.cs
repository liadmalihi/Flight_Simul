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

namespace FlightDetection
{
    /// <summary>
    /// Interaction logic for FullJoyStick.xaml
    /// </summary>
    public partial class FullJoyStick : UserControl
    {
        public FullJoyStick()
        {
            InitializeComponent();
        }

        private JoyStickViewModel js_vm;
        public JoyStickViewModel Js_vm
        {
            set
            {
                js_vm = value;
                this.DataContext = js_vm;
            }
        }
        
    }
}
