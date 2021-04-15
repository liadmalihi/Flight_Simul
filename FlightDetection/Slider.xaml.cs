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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Slider : UserControl
    {

        public Slider()
        {
            InitializeComponent();
        }
        private SliderViewModel s_vm;
        public SliderViewModel S_vm
        {
            set
            {
                s_vm = value;
                this.DataContext = value;
            }
        }

        private void Stop(object sender, RoutedEventArgs e)
        {
            s_vm.VM_Stop();
        }

        private void play(object sender, RoutedEventArgs e)
        {
            s_vm.VM_Play();
        }

        private void pause(object sender, RoutedEventArgs e)
        {
            s_vm.VM_Pause();
        }

        private void run_forward(object sender, RoutedEventArgs e)
        {
            s_vm.VM_RunForward();
        }

        private void run_back(object sender, RoutedEventArgs e)
        {
            s_vm.VM_RunBack();
        }
        private void ComboBoxItem_Selected_half(object sender, RoutedEventArgs e)
        {
            s_vm.VM_Speed_half();
        }
        private void ComboBoxItem_Selected_one(object sender, RoutedEventArgs e)
        {
            s_vm.VM_Speed_one();
        }
        private void ComboBoxItem_Selected_oneNhalf(object sender, RoutedEventArgs e)
        {
            s_vm.VM_Speed_oneNhalf();
        }
        private void ComboBoxItem_Selected_two(object sender, RoutedEventArgs e)
        {
            s_vm.VM_Speed_two();
        }

        private void speed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
