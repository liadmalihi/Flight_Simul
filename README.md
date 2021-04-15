# Flight_Simul
# FlightInspectionApp - using WPF

This is an app which connects to the external software named FlightGear simulator.
The app shows all kinds of data, such as information on the status of the rudders, joystic controler movement, speed, direction and more.
The app allows the user to select features and displays real-time graphics of the chosen features.

*Collaborators*:

The program was developed by four computer science students at Bar Ilan University, Israel - Ashira Major, Yeheli Frangi, Liad Malihi and Shiraz Ayash.

*General Description*:

The program connects to the [flight simulator](https://www.flightgear.org/) as a client, and sends him information through the csv file - a file that shows the flight values.
This file is uploaded to the program by the user.
The flight is simulated by the values given in the CSV file and the app presents important data from the flight visualised and offers control of the flight times.

*Code Degins*:

The FlightInseptionApp programmed with the MVVM design using data binding of the C # language, and xmal.
You can see the division between the view of a feature and its corresponding viewModel that is connected to the model of the whole program.

*Features*:
* Slider:
You can use the slider to control the flight display times - go forward, backward, stop and play the flight in any speed you would like.

* Joy Stick:
You can see the joy stick movment according to the real joy stick of the plane dring the flight.

* Dashboard:
You can watch the dashboard's values during the flight, the values will be update all the time and according to the specific tome of the flight.
The dashboard includes - Altimeter, Direction, Air Speed, Pitch, Roll, Heading and more.

* Graphs:
There will be 4 kinds of graphs.
If you choose one specific feature form the list, you will see his values according to the time in the first graph, the values according to the time in the second graph of the most correlative feature to the one you have choseמ.
The third grapg will present אhe regression line between the feature you have chosen and the feature that is most correlative to it, in addition, you can see the values of the last thirty seconds in red.

The fourth graph - DLL graph:
presert anomalies according to an dynamically loaded external anomaly detection algorithm.

*How to Load DLL:*
There is a possability to load a DLL file - you can click the button and upload an DLL file, then you can choose a feature and see the fourth graph.
How it works?
There are two algorithms that learn a regular flight from one CSV file, and present the anomalies in red on the other flight - the other CSV file.
The algorithms:
1. Line_Alg -  learning the farest distance between the line regression to all the points, and find the points that have bigger distance from the test flight.
2. Circle_Alg - find the minimum cirlce that includs all the points, and find the points that not include in the circle from the test flight.

*Make your own DLL:*
There is a possability to write your own DLL file - your own algorithm, load it to the program in running time without compile.
All you need to do is to implement class that calld Dll with two methods - Create: that returns the View of the graph, and Update:that returns a dictionary. The key will be int - the number of line in the test file, and the value will be pair of floats - the point's values.

*Structure project*:

In the main window you can see all the code's files for the app.

Also you can see the UML of the hole project.

In the Images folder you have all the feature to run the app.

In the dll folder you have the algorithms for the dll.

In the files folder you have the xml and csv files to upload in the app.

In the packages folder there is the Oxplot libary - download it to your project.

*How to run the app?*:
* Download the FlightGear app from [here](https://www.flightgear.org/) and open the app.
* In the settings of the app, add those line to the command line:

--generic=socket,in,10,127.0.0.1,5400,tcp,playback_small

--fdm=null.

* Download [this project](https://github.com/ashira-major/FlightDetection) using git clone.
* you will need a XML file with the propertys of the flight. You need to have :   Altimeter, Direction, Air Speed, Pitch, Roll, HeadingDeg, Rudder, Yaw.
* you will need a CSV file of a correct flight in order to check for anomalys.
* A CSV file of the flight you want to inspect for anomalys.
* Make sure you have the Oxplot lib in your project.
* Build the app on x64 only.
* Load and provide a XML file with all the features of the flight.
* Run the program and follow the instructions to upload two CSV files.

Documentation:
![Image of UML](https://github.com/ashira-major/FlightDetection/blob/master/UML.jpg)
You can see in the UML the MVVM architecture.
for each feature there is a View all the Views are include in the MainWindow View.
Each feature also has his own ViewModel that connect between the view and the model.
Each VireModel has the fuction NotifyPropertyChanged that sends information to the View.If there is a change in the view on the screen or a button was pushed the view tells the model via the viewModel about it.

The model includes a client - this client connect between the Flight Gear Simulator and our app.
You can see the Data Binding and the Property Changed connection in the UML.
https://youtu.be/AGYCmEJU_LM
[Demo of the app running]()
Enjoy!
