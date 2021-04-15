using FlightDetection;
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
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : UserControl
    {

        public DashBoard()
        {
            InitializeComponent();
        }
        private DashViewModel d_vm;
        public DashViewModel D_vm
        {
            set 
            { 
                d_vm = value;
                this.DataContext = d_vm;
            }
        }

        
    }
}
