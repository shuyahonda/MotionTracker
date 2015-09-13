using Microsoft.Kinect;
using MotionTracker.ViewModel;
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

        public MainWindow()
        {
            InitializeComponent();

            // データバインド
            coordinates = new ThreeDimensionalCoordinates();
            this.chartX.DataContext = coordinates;
            this.chartY.DataContext = coordinates;
            this.chartZ.DataContext = coordinates;

            // JointType
            foreach (JointType joint in Enum.GetValues(typeof(JointType)))
            {
                this.jointsComboBox.Items.Add(joint.ToString());
            }

            // test
            coordinates.X.Add(new ViewModel.CoordinateWithFrame(0.5, 1));
            coordinates.X.Add(new ViewModel.CoordinateWithFrame(0.6, 2));
            coordinates.X.Add(new ViewModel.CoordinateWithFrame(0.2, 3));
            coordinates.X.Add(new ViewModel.CoordinateWithFrame(0.8, 4));
            coordinates.X.Add(new ViewModel.CoordinateWithFrame(0.1, 5));

            // Init Kinect
            kinect = KinectSensor.GetDefault();
            if (kinect == null)
            {
                throw new Exception("Kinectを開けませんでした。");
            }

            kinect.Open();
            bodyFrameReader = kinect.BodyFrameSource.OpenReader();
            bodyFrameReader.FrameArrived += bodyFrameReader_FrameArrived;
        }

        /* フレームが来る度に呼び出される.距離の単位はメートル.*/
        private void bodyFrameReader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            // Collectionにデータを追加する
            using (var bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame == null)
                {
                    return;
                }
                // ボディデータを取得する
                bodyFrame.GetAndRefreshBodyData(bodies);

                //ボディがトラッキングできている
                foreach (var body in bodies.Where(b => b.IsTracked))
                {
                    //左手のX座標を取得
                    System.Diagnostics.Debug.WriteLine("X=" + body.Joints[JointType.HandLeft].Position.X);
                }
            }
        }

        
    }
}