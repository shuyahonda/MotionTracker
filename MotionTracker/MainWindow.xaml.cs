using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MotionTracker
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private KinectSensor kinect;
        private BodyFrameReader bodyFrameReader;
        private Body[] bodies;
        ThreeDimensionalCoordinates coordinates;
        int i = 6;

        public MainWindow()
        {
            InitializeComponent();

            // データバインド
            coordinates = new ThreeDimensionalCoordinates();
            this.chartX.DataContext = coordinates;
            this.chartY.DataContext = coordinates;
            this.chartZ.DataContext = coordinates;

            // test
            coordinates.X.Add(new ViewModel.CoordinateWithFrame(0.5, 1));
            coordinates.X.Add(new ViewModel.CoordinateWithFrame(0.6, 2));
            coordinates.X.Add(new ViewModel.CoordinateWithFrame(0.2, 3));
            coordinates.X.Add(new ViewModel.CoordinateWithFrame(0.8, 4));
            coordinates.X.Add(new ViewModel.CoordinateWithFrame(0.1, 5));


            kinect = KinectSensor.GetDefault();
            if (kinect == null)
            {
                throw new Exception("Kinectを開けませんでした。");
            }

            kinect.Open();
            bodyFrameReader = kinect.BodyFrameSource.OpenReader();
            bodyFrameReader.FrameArrived += bodyFrameReader_FrameArrived;

            //this.DataContext = new 
        }

        /* フレームが来る度に呼び出される。距離の単位はメートル。*/
        private void bodyFrameReader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            //グラフに座標をプロットする

            using (var bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame == null)
                {
                    return;
                }
                // ボディデータを取得する
                bodyFrame.GetAndRefreshBodyData(bodies);
                //認識しているBodyに対して
                foreach (var body in bodies.Where(b => b.IsTracked))
                {
                    //左手のX座標を取得
                    System.Diagnostics.Debug.WriteLine("X=" + body.Joints[JointType.HandLeft].Position.X);
                }
            }
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            for (int i = 6; i<100 ; i++) {
                
                coordinates.X.Add(new ViewModel.CoordinateWithFrame(0.6, i));
            }
        }

        private void Window_TouchMove(object sender, TouchEventArgs e)
        {
            Console.WriteLine("TouchMove");
            coordinates.X.Add(new ViewModel.CoordinateWithFrame(0.6, i));

        }
    }
}