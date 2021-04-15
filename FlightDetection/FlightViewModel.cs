using FlightDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightDetection
{
    class FlightViewModel : INotifyPropertyChanged
    {
        private IFlightModel model;
        private string filePath;

        public event PropertyChangedEventHandler PropertyChanged;

        public FlightViewModel(IFlightModel model)
        {
            this.model = model;
            this.model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                };
        }

        private void NotifyPropertyChanged(string v)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public void start_flight()
        {
            this.model.connect("localhost", 5400);
            this.model.start();
        }

        public void updatePath(string newPath)
        {
            model.loadCSV(newPath);
        }
        
        public void testPath(string testP)
        {
            model.loadTestCSV(testP);
        }

        public void updatePathXML(string xml_p)
        {
            model.parseXML(xml_p);
        }

    }
}
