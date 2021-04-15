using FlightDetection;
using Microsoft.Win32;
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
using System.IO;


namespace FlightDetection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FlightViewModel vm;
        private DashViewModel d_vm;
        private SliderViewModel s_vm;
        private JoyStickViewModel js_vm;
        private GraphViewModel g_vm;
        private string FilePath;
        private int flag_t = 0;
        private int flag_csv = 0;
        private int flag_xml = 0;
        public MainWindow()
        {
            InitializeComponent();
            IFlightModel fm = new MyFlightModel(new MyFlightClient());
            vm = new FlightViewModel(fm);
            d_vm = new DashViewModel(fm);
            s_vm = new SliderViewModel(fm);
            js_vm = new JoyStickViewModel(fm);
            g_vm = new GraphViewModel(fm);
            graphv.G_vm = g_vm;
            fulljoy.Js_vm = js_vm;
            slide.S_vm = s_vm;
            dashboard.D_vm = d_vm;
            this.DataContext = vm;

        }

        // open test CSV
        private void btnOpenFile1_Click(object sender, RoutedEventArgs e)
        {
            string path;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
                vm.testPath(path);
            }
            flag_t = 1;
        }

        // open regular CSV
        private void btnOpenFile2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                vm.updatePath(FilePath);
            }
            flag_csv = 1;
        }

        // load XML
        private void btnOpenFileXML_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == true)
            {
                string xml_path = openFileDialog.FileName;
                vm.updatePathXML(xml_path);
            }
            flag_xml = 1;
        }

        private void btnOpenFileDLL_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "DLL files (*.dll)|*.dll";
            if (openFileDialog.ShowDialog() == true)
            {
                g_vm.VM_DLLPath = openFileDialog.FileName;
                graphv.Add_Dll();
               // vm.updatePath(FilePath);
            }
        }


        // start flight
        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (flag_t == 1 && flag_csv == 1 && flag_xml == 1)
            {
                this.vm.start_flight();
            }
            else
            {
                MessageBox.Show($"Missing Files!");
            }
        }
    }
}
