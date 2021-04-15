using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDetection
{
    public class JoyStickViewModel : INotifyPropertyChanged
    {
        private IFlightModel model;
        public event PropertyChangedEventHandler PropertyChanged;
        public JoyStickViewModel(IFlightModel model)
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
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        public float VM_Elevator
        {
            get { return this.model.Elevator; }
        }
        public float VM_Aileron
        {
            get { return this.model.Aileron; }
        }
        
        public float VM_Rudder
        {
            get { return this.model.Rudder; }
        }
        
        
        public float VM_Throttle
        {
            get { return this.model.Throttle; }
        }
    }
}
