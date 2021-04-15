using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using OxyPlot;

namespace FlightDetection
{
    public interface IFlightModel : INotifyPropertyChanged
    {
        float Altimeter { get; set; }
        float Airspeedr { get; set; }
        float HeadingDeg { get; set; }
        float Roll { get; set; }
        float Pitch { get; set; }
        float Yaw { get; set; }
        float Elevator { get; set; }
        float Aileron { get; set; }
        float Rudder { get; set; }
        float Throttle { get; set; }

        int TimeIndex { get; set; }
        int TimeMax { get; set; }

        PlotModel PlotModel { get; set; }
        PlotModel PlotModelTwo { get; set; }
        PlotModel RegGraph { get; set; }
        List<string> GraphVars { get; set; }
        List<string> AnomalyVar { get; set; }
        //*******************
        dynamic DllDynamic { get; set; }
        //****************************

        // connect to FlightGear
        void connect(string ip, int port);
        void disconnect();
        void start();
        void loadCSV(string str);
        void loadTestCSV(string testP);
        void parseXML(string path);
        void Play();
        void Pause();

        void chooseAnomaly(string s);
        void Run_forward();
        void Run_back();
        void Stop();
        void chooseGraph(string str);
        void Speed_half();
        void Speed_one();
        void Speed_oneNhalf();
        void Speed_two();
    }
}


