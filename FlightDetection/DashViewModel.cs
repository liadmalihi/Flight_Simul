using FlightDetection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// /////////////////////////////////////
/// </summary>
namespace FlightDetection
{
    public class DashViewModel : INotifyPropertyChanged

    {
        /// <summary>
        /// ////
        /// </summary>
        private IFlightModel model;
        private string filePath;

        public event PropertyChangedEventHandler PropertyChanged;

        public DashViewModel(IFlightModel model)
        {
            this.model = model;
            this.model.PropertyChanged +=
                delegate(Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                };
        }

        public void NotifyPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        
        public float VM_Altimeter
        {
            get { return this.model.Altimeter; }
        }
         public float VM_Airspeedr
        {
            get { return this.model.Airspeedr; }
        }
        public float VM_HeadingDeg
        {
            get { return this.model.HeadingDeg; }
        }
        public float VM_Roll
        {
            get { return this.model.Airspeedr; }
        }
        public float VM_Pitch
        {
            get { return this.model.Pitch; }
        }
        public float VM_Yaw
        {
            get { return this.model.Yaw; }
        }
    }
}
