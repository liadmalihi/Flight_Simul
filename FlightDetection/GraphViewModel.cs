using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;


namespace FlightDetection
{
    public class GraphViewModel : INotifyPropertyChanged
    {
        private IFlightModel model;
        public GraphViewModel(IFlightModel model)
        {
            this.model = model;
            this.model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                };

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public List<string> VM_GraphVars
        {
            get
            {
                return this.model.GraphVars;
            }
        }

        public string VM_FeatureChoosen
        {
            set
            {
                this.model.chooseGraph(value);
            }
        }

        public List<string> VM_AnomalyVar
        {
            get
            {
                return this.model.AnomalyVar;
            }
        }

        public string VM_AnomalyFeatureChoosen
        {
            set
            {
                this.model.chooseAnomaly(value);
            }
        }


        public PlotModel VM_PlotModel
        {
            get
            {
                return this.model.PlotModel;
            }
        }

        public PlotModel VM_PlotModelTwo
        {
            get
            {
                return this.model.PlotModelTwo;
            }
        }
        public PlotModel VM_RegGraph
        {
            get
            {
                return this.model.RegGraph;
            }
        }
        private string dllPath;
        public string VM_DLLPath
        {
            set
            {
                dllPath = value;
            }
            get
            {
                return dllPath;
            }
        }

        public dynamic VM_DllDynamic
        {
            get
            {
                return this.model.DllDynamic;
            }
            set
            {
                this.model.DllDynamic = value;
            }
        }




    }
}
