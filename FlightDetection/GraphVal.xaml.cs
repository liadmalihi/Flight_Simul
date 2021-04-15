using OxyPlot.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for GraphVal.xaml
    /// </summary>
    public partial class GraphVal : UserControl
    {
        private static readonly PlotView PlotView = new PlotView();
        public GraphVal()
        {
            InitializeComponent();
        }
        private GraphViewModel g_vm;
        public GraphViewModel G_vm
        {
            set
            {
                g_vm = value;
                this.DataContext = g_vm;
            }
        }
        public void GraphVars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            g_vm.VM_FeatureChoosen = graph_choose.SelectedItem.ToString();
        }

        public void AnomalyVars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (anomaly_choose.SelectedItem != null)
            {
                g_vm.VM_AnomalyFeatureChoosen = anomaly_choose.SelectedItem.ToString();
            }
        }

        public void Add_Dll()
        {
            string path = g_vm.VM_DLLPath;
            try
            {
                Assembly dll = Assembly.LoadFile((path));
                Type[] myType = dll.GetExportedTypes();
                string s = "Dll";
                foreach (Type t in myType)
                {
                    if (t.Name == s)
                    {
                        g_vm.VM_DllDynamic = Activator.CreateInstance(t);
                    }
                }
                Console.WriteLine("1");
                graph_dll.Children.Add(g_vm.VM_DllDynamic.Create());
                
            }
            catch (Exception e)
            {
                Console.WriteLine("error loading dll", e);
            }
        }
    }
}
