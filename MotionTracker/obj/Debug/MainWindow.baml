   M S B A M L   `   `   `  ����H  DMotionTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MotionTrackerMotionTracker  5   	       MotionTracker.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:MotionTracker     5   	   ^ ZSparrow.Chart.Wpf.40, Version=13.1.0.118, Culture=neutral, PublicKeyToken=50f33fb8697e9a924sparrow&http://sparrowtoolkit.codeplex.com/wpf  5   	     � Title$  MotionTracker - Kinect v2��5	   	   $	��600��6+   $	��600��68    � Icon$ bone_leftonly.png��6D   .��5
      � $��	0,0,5,0.5q�6    � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $
��170* �6   �� 5      $
��170* �6   �� 5      $
��170* �6   .+�5   
   �� -   5         ��Name$ jointsComboBox��5      $
��Left=�6+   $��
10,10,0,14q�6F   $	��190��6Z   $��26.667(�6f    �� SelectedIndex$ 1��6x   �� 5   
   -   5         ��Name$ trackedLabel��5      $��Tracked��6&   $��0,10,155,14q�68   $��Right=�6M   $��76��6i   
���   �$��13.333(�6�   
�������6�   �� 5   
   -   5        $ inferredLabel��5      $��Inferred��6'   $��
0,10,76,14q�6:   $��Right=�6N   $��74��6j   
���   �$��13.333(�6�   
�������6�   �� 5   
   -   5        $ notTrackedLabel��5      $��Not
Tracked��6)   $��	0,10,0,14q�6H   $��Right=�6[   $��71��6w   
���   �$��13.333(�6�   
�������6�      Sparrow.Chart.SparrowChart  5   
   -   5          Name$ chartX��5      $��0,10,10,0.5q�6/   $��1��6D      XAxis 5        Sparrow.Chart.LinearXAxis  5        Sparrow.Chart.AxisBase   MaxValue$	 400��6&   	   MinValue$	 1��65   
   ShowCrossLines
 . 6B      YAxis 5        Sparrow.Chart.LinearYAxis  5      $ 1��6&   $	 -1��63      Header$
 X(m)��6A      Series. 5        Sparrow.Chart.LineSeries    Sparrow.Chart.SeriesBase   XPath$ Frame��6<   "  Sparrow.Chart.LineSeriesBase   YPath$ 
Coordinate��6J      Stroke �	#FF2B33EC   StrokeThickness$ 2Q�6p      PointsSource 6!   �� *X+6p   5        5   
   -   5        $ chartY��5      $��0,4.5,10,0.5q�6/   $��2��6E    5         5!      
 . $	 400��6<   $	 1��6K    5#        5$      $	 2.5��6&   $
	 -1.5��65   $
 Y(m)��6E   . 5&        $ Frame��6<   $ 
Coordinate��6J    �	#FF2B33EC$ 2Q�6p    6!   �� *Y+6p   5'        5(   
   -   5        $ chartZ��5(      $��3��6/   $��
0,5,10,0.5q�6<    5)        5*      
 . $	 400��6<   $	 1��6K    5,        5-      $	 3.0��6&   $		 1.0��65   $
 Z(m)��6D   . 5/        $ Frame��6<   $ 
Coordinate��6J    �	#FF2B33EC$��0q�6p   $ 2Q�6�    6!   �� *Z+6�   50      �� 51   
   -   5         ��Name$ chartInitButton��51      $��	初期化��6*   $
��Left=�68   $��205,10,0,14q�6S   $��45��6h   6s   �� 52   
   -	   5        $ csvExportButton��52      $	��CSV��6*   $
��Left=�68   $��255,10,0,14q�6S   $��35��6h   6s   �� 53   
   -
   5        $ 
stopButton��53      $��開始��6%   $
��Left=�62   $��295,10,0,14q�6M   $��35��6b   6m   56      57      