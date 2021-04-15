using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDetection 
{
    
    public class SliderViewModel : INotifyPropertyChanged
    {
        private IFlightModel model;
        public SliderViewModel(IFlightModel model)
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
        public void VM_Play()
        {
            model.Play();
        }
        public void VM_RunForward()
        {
            model.Run_forward();
        }
        public void VM_Pause()
        {
            model.Pause();
        }
        public void VM_RunBack()
        {
            model.Run_back();
        }
        public void VM_Stop()
        {
            model.Stop();
        }

        public void VM_Speed_half()
        {
            model.Speed_half();
        }

        public void VM_Speed_one()
        {
            model.Speed_one();
        }

        public void VM_Speed_oneNhalf()
        {
            model.Speed_oneNhalf();
        }

        public void VM_Speed_two()
        {
            model.Speed_two();
        }
        public int VM_TimeIndex
        {
            get { return this.model.TimeIndex; }
            set
            {
                this.model.TimeIndex = value;
            }
        }

        public int VM_TimeMax
        {
            get { return this.model.TimeMax; }
        }

    }
}
