   M S B A M L   `   `   `  ����J  FFlightDetection, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:FlightDetectionFlightDetection  5   	   1clr-namespace:FlightDetectionFlightDetection  5   	   1clr-namespace:FlightDetectionFlightDetection  5   	   1clr-namespace:FlightDetectionFlightDetection  5	   	   1clr-namespace:FlightDetectionFlightDetection  5
   	        FlightDetection.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:FlightDetection     5   	   ,Dbclr-namespace:FlightDetection     5   	   ,Slclr-namespace:FlightDetection     5   	   -Joyclr-namespace:FlightDetection     5	   	   ,Grclr-namespace:FlightDetection     5
   	     � Title$  
MainWindow��5   	   $	��500��6   $
��1200��6,   $
��1200��69   .��5      � ��5   
   �� 5       �� ImageSource$ Images/backround.jpeg��6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $��* �6   �� 5"      $��20 �6   .+�5%   
   ��  �� Orientation$ Vertical=�6   $��1��6,   $��1��6<   $��3��6I   .+�5&      �� $��1��6   $��1��6)   $��3��66   $ 
Horizontal=�6K   .+�5'      �� $��WElCOME !  ��6   $��7q�6/   $��Ravie)�6:   $��20(�6M   ���	#FFA83BCC$
��Left=�6r   $��Center=�6�   �� 5(      $ 
Horizontal=�6   ���	#FFF6EDFA J� Opacity$	 0.8Q�6M   .+�5)      �� -   5        $��btnOpenFile1��5)      $��5q�61   
������ 
������ .��5*      �� .+�5+      �� $��Images/import-csv.png��6$   $��40��6C   $��40��6N   �� 5,      $��0q�6$   .��60   	Reg CSV69   5-      5.      �� 5/      -   5        $��btnOpenFile2��5/      $��5q�61   
������ 
������ .��50      �� .+�51      �� $��Images/import-csv.png��6$   $��40��6C   $��40��6N   �� 52      $��0q�6$   .��60   
Flight CSV6<   53      54      �� 55      -   5        $��btnOpenFileXML��55      $��5q�63   
������ 
������ .��56      �� .+�57      �� $��Images/xml-64.png��6$   $��40��6?   $��40��6J   �� 58      $��0q�6$   .��60   XML65   59      5:      �� 5;      -   5        $��btnOpenFileDLL��5;      $��5q�63   
������ 
������ .��5<      �� .+�5=      �� $��Images/dll-64.png��6$   $��40��6?   $��40��6J   �� 5>      $��0q�6$   .��61   DLL66   5?      5@      �� 5A      -   5        $��btnStart��5A      $��5q�6-   
������ 
������ .��5B      �� .+�5C      �� $��Images/play-64.png��6$   $��40��6@   $��40��6K   �� 5D      $��0q�6$   .��60   Start Flight6>   5E      5F      5G      5H      �� 5I      $ Vertical=�6   $��1��60   $��2��6@   $��2��6M   .+�5J      �� $ 
Horizontal=�6   .+�5K         FlightDetection.DashBoard  -   5          Name$ 	dashboard��5K   #   $��10q�66   ���	#FFF6EDFA$	 0.8Q�6Y   (� 5L      $	��250��6   $	��130��6*   .��5M      "   FlightDetection.FullJoyStick  -   5          Name$ fulljoy��5M   +   5N      5O         FlightDetection.Slider  5P      -   5          Name$ slide��5P      ���	#FFF6EDFA$	 0.8Q�6B   $��10q�6P   5Q      5S         FlightDetection.GraphVal  5V   
   -	   5        	  Name$	 graphv��5V      $��4��6&   $��1��66   $��5��6C   $��5��6X   $	 0.7Q�6i   5W      5Y      