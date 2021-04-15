using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Runtime.CompilerServices;
using OxyPlot;
using OxyPlot.Series;

namespace FlightDetection
{
    public class MyFlightModel : IFlightModel
    {
        public int i;
        public event PropertyChangedEventHandler PropertyChanged;
        IFlightClient flightClient;
        volatile Boolean stop;
        private string filePath;
        private static List<string> chunks = new List<string>();
        private string[] lines;
        private Boolean run;
        private int speed;
        private static List<List<float>> allDataCsv = new List<List<float>>();
        private static List<List<float>> testDataCsv = new List<List<float>>();
        

        public MyFlightModel(IFlightClient client)
        {
            this.flightClient = client;
            this.stop = false;
            this.run = true;
            this.speed = 100;
        }

        public void connect(string ip, int port)
        {
            flightClient.connect(ip, port);
        }

        public void disconnect()
        {
            stop = true;
            flightClient.disconnect();
        }
        public void NotifyPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }



        public void start()
        {
            new Thread(delegate ()
            {
                while (timeIndex < timeMax)
                {
                    if (run)
                    {
                        varsFromLine(lines[timeIndex]);
                        flightClient.write(lines[timeIndex]);
                        Thread.Sleep(speed);
                        TimeIndex = TimeIndex + 1;
                    }
                }
            }).Start();
        }

        private void varsFromLine(string line)
        {
            string[] words = line.Split(',');

            int altimeterKey = chunks.FindIndex(a => a == "altimeter_indicated-altitude-ft");
            Altimeter = float.Parse(words[altimeterKey]);
            int airspeedKey = chunks.FindIndex(a => a == "airspeed-kt");
            Airspeedr = float.Parse(words[airspeedKey]);
            int headingDegKey = chunks.FindIndex(a => a == "heading-deg");
            HeadingDeg = float.Parse(words[headingDegKey]);
            int rollKey = chunks.FindIndex(a => a == "roll-deg");
            Roll = float.Parse(words[rollKey]);
            int pitchKey = chunks.FindIndex(a => a == "pitch-deg");
            Pitch = float.Parse(words[pitchKey]);
            int yawKey = chunks.FindIndex(a => a == "side-slip-deg");
            Yaw = float.Parse(words[yawKey]);


            int elevatorKey = chunks.FindIndex(a => a == "elevator");
            Elevator = float.Parse(words[elevatorKey]);
            int aileronKey = chunks.FindIndex(a => a == "aileron");
            Aileron = float.Parse(words[aileronKey]);
            int valueRudderKey = chunks.FindIndex(a => a == "rudder");
            Rudder = float.Parse(words[valueRudderKey]);
            int valueThrottleKey = chunks.FindIndex(a => a == "throttle");
            Throttle = float.Parse(words[valueThrottleKey]);
            if (valid != -1)
            {
                update_points_graph(float.Parse(words[index_g]), float.Parse(words[correlated_index]));
                update_regGraph("Linear regression line");
            }

        }
        public void loadCSV(string str)
        {
            filePath = str;
            //parseXML();
            //connect("localhost", 5400);
            lines = System.IO.File.ReadAllLines(filePath);
            parseCSV();
            TimeIndex = 0;
            TimeMax = lines.Length;
            Elevator = 125;
            Aileron = 125;

        }

        public void parseXML(string path)
        {
            //string path = "C:\\Users\\User\\Downloads\\playback_small.xml";
            XmlDocument Xdoc = new XmlDocument();
            Xdoc.Load(path);

            List<string> temp = new List<string>();
            XmlTextReader xtr = new XmlTextReader(path);
            string name = "";
            while (xtr.Read())
            {
                if (xtr.Name == "input")
                {
                    break;
                }

                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "name")
                {
                    name = xtr.ReadElementString();
                    temp.Add(name);
                }

            }
            GraphVars = temp;

        }


        public void parseCSV()
        {
            int size = lines.Count();
            int j = 0;
            string[] oneLine = lines[0].Split(',');
            int sizeOfLine = oneLine.Length;
            for (int k = 0; k < sizeOfLine; k++)
            {
                allDataCsv.Add(new List<float>());
            }
            foreach (string line in lines)
            {
                oneLine = line.Split(',');
                for (int k = 0; k < sizeOfLine; k++)
                {
                    allDataCsv[k].Add(float.Parse(oneLine[k]));
                }
            }
        }

        public void loadTestCSV(string testP)
        {
            string[] t_lines = System.IO.File.ReadAllLines(testP);
            //int size = t_lines.Count();
            string[] oneLine = t_lines[0].Split(',');
            int sizeOfLine = oneLine.Length;
            for (int k = 0; k < sizeOfLine; k++)
            {
                testDataCsv.Add(new List<float>());
            }
            foreach (string line in t_lines)
            {
                oneLine = line.Split(',');
                for (int k = 0; k < sizeOfLine; k++)
                {
                    testDataCsv[k].Add(float.Parse(oneLine[k]));
                }
            }
        }
        // this is the index for the correlated feature . 
        private int correlated_index = -1;

        private LineSeries line_series_two = new LineSeries();
        public void update_graph_two(string str)
        {
            PlotModel pm = new PlotModel();
            pm.Title = str;
            //Graphical graph settings
            line_series_two = new LineSeries();
            line_series_two.Color = OxyColors.BlueViolet;

            //Supplementing data
            for (int j = 0; j < timeIndex; j++)
                line_series_two.Points.Add(new DataPoint(j, allDataCsv[correlated_index][j]));

            pm.Series.Add(line_series_two);

            this.PlotModelTwo = pm;
            this.PlotModelTwo.InvalidatePlot(true);
        }

        private ScatterSeries scatter_series = new ScatterSeries();
        private LineSeries line_series_regGraph = new LineSeries();
        public void update_regGraph(string str)
        {
            PlotModel pm = new PlotModel();
            pm.Title = str;

            scatter_series = new ScatterSeries();
            scatter_series.MarkerFill = OxyColor.FromAColor(100, OxyColors.CornflowerBlue);
            scatter_series.MarkerType = MarkerType.Circle;
            line_series_regGraph = new LineSeries();
            line_series_regGraph.Color = OxyColors.BlueViolet;


            int j;
            if (timeIndex < 300)
                j = 0;
            else
                j = timeIndex - 300;

            Point[] points = new Point[300];
            float Xmin = allDataCsv[index_g][j];
            float Xmax = allDataCsv[index_g][j];
            int k = 0;
            for (; j < timeIndex; j++)
            {
                scatter_series.Points.Add(new ScatterPoint(allDataCsv[index_g][j], allDataCsv[correlated_index][j], 2, 0));
                points[k++] = new Point(allDataCsv[index_g][j], allDataCsv[correlated_index][j]);
                if (allDataCsv[index_g][j] < Xmin)
                    Xmin = allDataCsv[index_g][j];

                if (allDataCsv[index_g][j] > Xmax)
                    Xmax = allDataCsv[index_g][j];
            }

            Line reg_line = Pearson.linear_reg(points, k - 1);
            line_series_regGraph.Points.Add(new DataPoint(Xmin, reg_line.f(Xmin)));
            line_series_regGraph.Points.Add(new DataPoint(Xmax, reg_line.f(Xmax)));
            
            pm.Series.Add(line_series_regGraph);
            pm.Series.Add(scatter_series);

            this.RegGraph = pm;
            this.RegGraph.InvalidatePlot(true);
        }

        private LineSeries line_series = new LineSeries();
        public void update_graph(string str)
        {
            PlotModel pm = new PlotModel();
            pm.Title = str;

            line_series = new LineSeries();
            line_series.Color = OxyColors.BlueViolet;

            for (int j = 0; j < timeIndex; j++)
                line_series.Points.Add(new DataPoint(j, allDataCsv[index_g][j]));

            pm.Series.Add(line_series);

            this.PlotModel = pm;
            this.PlotModel.InvalidatePlot(true);
        }


        private void update_points_graph(float f1, float f2)
        {
            line_series.Points.Add(new DataPoint(timeIndex, f1));
            this.plotModel.Series.Append(line_series);
            this.plotModel.InvalidatePlot(true);
            NotifyPropertyChanged("PlotModel");
            line_series_two.Points.Add(new DataPoint(timeIndex, f2));
            this.plotModelTwo.Series.Append(line_series_two);
            this.plotModelTwo.InvalidatePlot(true);
            NotifyPropertyChanged("PlotModelTwo");
        }

        private int index_g = -1;
        private int valid = -1;

        // a graph has been chosen.
        public void chooseGraph(string str)
        {
            Dictionary<int, Tuple<float, float>> anomalys;
            Title_Orig = str;
            index_g = chunks.FindIndex(a => a == str);
            correlated_index = Pearson.bestCore(allDataCsv, index_g);
            update_graph(str);
            update_graph_two(chunks[correlated_index]);
            update_regGraph("Linear regression line");
            valid = 1;
            if (dllDynamic != null)
            {
                anomalys = dllDynamic.Update(testDataCsv[index_g], testDataCsv[correlated_index], allDataCsv[index_g], allDataCsv[correlated_index]);
                toGraph(anomalys);
            }
        }
        static private Dictionary<string, int> anomaly_vars;
        public void toGraph(Dictionary<int, Tuple<float, float>> a)
        {
            if (a.Count != 0)
            {
                anomaly_vars = new Dictionary<string, int>();
                anomalyVars = new List<string>();
                foreach (KeyValuePair<int, Tuple<float, float>> entry in a)
                {
                    string s = $"x :  { entry.Value.Item1}, y : { entry.Value.Item2} ";
                    if (!anomaly_vars.ContainsKey(s))
                    {
                        anomaly_vars.Add(s, entry.Key);
                        anomalyVars.Add(s);
                    }

                }
                AnomalyVar = new List<string>();
            } else
            {
                anomalyVars = new List<string>();
                anomalyVars.Clear();
                AnomalyVar = new List<string>();
            }
            
            
        }

        private List<string> anomalyVars;
        public List<string> AnomalyVar
        {
            get { return anomalyVars; }
            set
            {
                NotifyPropertyChanged("AnomalyVar");
            }
        }

        public void chooseAnomaly(string s)
        {
            TimeIndex = anomaly_vars[s];
            update_graph(title_Orig);
            update_graph_two(chunks[correlated_index]);
            update_regGraph("Linear regression line");
        }

        public void Play()
        {
            this.run = true;
        }
        public void Pause()
        {
            this.run = false;
        }

        private void plot_update()
        {
            this.plotModel.Series.Append(line_series);
            this.plotModel.InvalidatePlot(true);
            NotifyPropertyChanged("PlotModel");
            this.plotModelTwo.Series.Append(line_series_two);
            this.plotModelTwo.InvalidatePlot(true);
            NotifyPropertyChanged("PlotModelTwo");
        }
        public void Run_forward()
        {
            if (timeMax - timeIndex > 100)
            {
                if (index_g != -1)
                {
                    List<DataPoint> tmp1 = new List<DataPoint>();
                    List<DataPoint> tmp2 = new List<DataPoint>();
                    for (int i = timeIndex; i < timeIndex + 100; i++)
                    {
                        line_series.Points.Add(new DataPoint(i, allDataCsv[index_g][i]));
                        line_series_two.Points.Add(new DataPoint(i, allDataCsv[correlated_index][i]));
                    }
                    plot_update();
                }
                TimeIndex = TimeIndex + 100;
            }
            else
            {
                TimeIndex = TimeIndex - 1;
            }
        }
        public void Run_back()
        {
            if (timeIndex > 100)
            {
                TimeIndex = TimeIndex - 100;
                if (index_g != -1)
                {
                    Predicate<DataPoint> match = isBigger;
                    line_series.Points.RemoveAll(match);
                    line_series_two.Points.RemoveAll(match);
                    plot_update();
                }
            }
            else
            {
                TimeIndex = 0;
            }

        }
        private bool isBigger(DataPoint db)
        {
            if (db.X > timeIndex)
            {
                return false;
            }
            return true;
        }
        public void Stop()
        {
            TimeIndex = 0;
        }

        public void Speed_half()
        {
            this.speed = 100 * 2;
        }

        public void Speed_one()
        {
            this.speed = 100;
        }

        public void Speed_oneNhalf()
        {
            this.speed = 200 / 3;
        }

        public void Speed_two()
        {
            this.speed = 50;
        }

        private int timeMax;
        public int TimeMax
        {
            get { return timeMax; }
            set
            {
                timeMax = value;
                NotifyPropertyChanged("TimeMax");
            }
        }

        private int timeIndex;
        public int TimeIndex
        {
            get { return timeIndex; }
            set
            {
                timeIndex = value;
                NotifyPropertyChanged("TimeIndex");
            }
        }



        private float altimeter;

        public float Altimeter
        {
            get { return altimeter; }
            set
            {
                altimeter = value;
                NotifyPropertyChanged("Altimeter");
            }
        }

        private float airspeed;
        public float Airspeedr
        {
            get { return airspeed; }
            set
            {
                airspeed = value;
                NotifyPropertyChanged("Airspeedr");
            }
        }

        private float headingDeg;
        public float HeadingDeg
        {
            get { return headingDeg; }
            set
            {
                headingDeg = value;
                NotifyPropertyChanged("HeadingDeg");
            }
        }

        private float roll;
        public float Roll
        {
            get { return roll; }
            set
            {
                roll = value;
                NotifyPropertyChanged("Roll");
            }
        }
        private float pitch;
        public float Pitch
        {
            get { return pitch; }
            set
            {
                pitch = value;
                NotifyPropertyChanged("Pitch");
            }
        }

        private float yaw;
        public float Yaw
        {
            get { return yaw; }
            set
            {
                yaw = value;
                NotifyPropertyChanged("Yaw");
            }
        }

        private float elevator = 125;
        public float Elevator
        {
            get { return elevator; }
            set
            {
                elevator = 125 + 100 * value;
                NotifyPropertyChanged("Elevator");
            }
        }
        private float aileron = 125;
        public float Aileron
        {
            get { return aileron; }
            set
            {
                aileron = 125 + 100 * value;
                NotifyPropertyChanged("Aileron");
            }
        }
        private float rudder;
        public float Rudder
        {
            get { return rudder; }
            set
            {
                rudder = value;
                NotifyPropertyChanged("Rudder");
            }
        }
        private float throttle;
        public float Throttle
        {
            get { return throttle; }
            set
            {
                throttle = value;
                NotifyPropertyChanged("Throttle");
            }
        }

        public List<string> GraphVars
        {
            get { return chunks; }
            set
            {
                chunks = new List<string>(value);
                NotifyPropertyChanged("GraphVars");
            }
        }
        private string title_Orig;
        public string Title_Orig
        {
            get { return title_Orig; }
            set
            {
                title_Orig = value;
                NotifyPropertyChanged("Title_Orig");
            }
        }

        private PlotModel plotModel;
        public PlotModel PlotModel
        {
            get
            {
                return plotModel;
            }
            set
            {
                plotModel = value;
                plotModel.TextColor = OxyColors.Transparent;
                plotModel.TitleColor = OxyColors.BlueViolet; 
                NotifyPropertyChanged("PlotModel");
            }
        }

        private PlotModel plotModelTwo;
        public PlotModel PlotModelTwo
        {
            get
            {
                return plotModelTwo;
            }
            set
            {
                plotModelTwo = value;
                plotModelTwo.TextColor = OxyColors.Transparent;
                plotModelTwo.TitleColor = OxyColors.BlueViolet;
                NotifyPropertyChanged("PlotModelTwo");
            }
        }

        private PlotModel regGraph;
        public PlotModel RegGraph
        {
            get
            {
                return regGraph;
            }
            set
            {
                regGraph = value;
                regGraph.TextColor = OxyColors.Transparent;
                regGraph.TitleColor = OxyColors.BlueViolet;
                NotifyPropertyChanged("RegGraph");
            }
        }
        public dynamic dllDynamic;
        public dynamic DllDynamic
        {
            get
            {
                return dllDynamic;
            }
            set
            {
                dllDynamic = value;
            }
        }



    }


}
