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
        int frameSkip = 0;

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
            /*
            // test
            coordinates.X.Add(new ViewModel.CoordinateWithFrame(0.5, 1));
            coordinates.X.Add(new ViewModel.CoordinateWithFrame(0.6, 2));
            coordinates.X.Add(new ViewModel.CoordinateWithFrame(0.2, 3));
            coordinates.X.Add(new ViewModel.CoordinateWithFrame(0.8, 4));
            coordinates.X.Add(new ViewModel.CoordinateWithFrame(0.1, 5));
            */
            // Init Kinect
            kinect = KinectSensor.GetDefault();
            if (kinect == null)
            {
                throw new Exception("Kinectを開けませんでした。");
            }

            kinect.Open();
            this.bodies = new Body[kinect.BodyFrameSource.BodyCount];
            bodyFrameReader = kinect.BodyFrameSource.OpenReader();
            bodyFrameReader.FrameArrived += bodyFrameReader_FrameArrived;
        }

        /* フレームが来る度に呼び出される.距離の単位はメートル.*/
        private void bodyFrameReader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            this.frameSkip++;
            if (this.frameSkip != 6) return;
            this.frameSkip = 0;

            if (CoordinateWithFrame.Count >= 400)
            {
                this.coordinates.X.Clear();
                this.coordinates.Y.Clear();
                this.coordinates.Z.Clear();
                CoordinateWithFrame.initCount();
                //return;
            }
            //this.chartX.XAxis.MinValue = coordinates.X.Count - 70;
            //this.chartY.XAxis.MinValue = coordinates.Y.Count - 70;
            //this.chartZ.XAxis.MinValue = coordinates.Z.Count - 70;

            JointType selectedJoint = (JointType)Enum.Parse(typeof(JointType), this.jointsComboBox.SelectedItem.ToString());

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
                    CoordinateWithFrame x = new CoordinateWithFrame((double)body.Joints[selectedJoint].Position.X);
                    CoordinateWithFrame y = new CoordinateWithFrame((double)body.Joints[selectedJoint].Position.Y);
                    CoordinateWithFrame z = new CoordinateWithFrame((double)body.Joints[selectedJoint].Position.Z);
                    //Console.WriteLine((double)body.Joints[selectedJoint].Position.Z);
                    x.countUp();
                    y.countUp();
                    z.countUp();

                    /*
                    if (coordinates.X.Count == 80) coordinates.X.Clear();
                    if (coordinates.Y.Count == 80) coordinates.Y.Clear();
                    if (coordinates.Z.Count == 80) coordinates.Z.Clear();
                      */
                      /*
                    if (this.coordinates.X.Count >= 50)
                    {
                        Console.WriteLine("100以上");
                        this.chartX.XAxis.MinValue = (int)this.chartX.XAxis.MaxValue - 50;
                    }
                    Console.WriteLine();
                    */


                    this.coordinates.X.Add(x);
                    this.coordinates.Y.Add(y);
                    this.coordinates.Z.Add(z);

                    if (body.Joints[selectedJoint].TrackingState == TrackingState.Tracked)
                    {
                        setTrackingStateLabelColor(true, false, false);
                    }else if(body.Joints[selectedJoint].TrackingState == TrackingState.Inferred)
                    {
                        setTrackingStateLabelColor(false, true, false);
                    }else if(body.Joints[selectedJoint].TrackingState == TrackingState.NotTracked)
                    {
                        setTrackingStateLabelColor(false, false, true);
                    }

                }
            }
        }

        private void setTrackingStateLabelColor(Boolean tracked, Boolean inferred, Boolean notTracked)
        {
            if(tracked == true)
            {
                this.trackedLabel.Background = Brushes.Green;
                this.inferredLabel.Background = Brushes.LightGray;
                this.notTrackedLabel.Background = Brushes.LightGray;
            }else if(inferred == true)
            {
                this.trackedLabel.Background = Brushes.LightGray;
                this.inferredLabel.Background = Brushes.Blue;
                this.notTrackedLabel.Background = Brushes.LightGray;
            }else if(notTracked == true)
            {
                this.trackedLabel.Background = Brushes.LightGray;
                this.trackedLabel.Background = Brushes.LightGray;
                this.trackedLabel.Background = Brushes.Red;
            }
        }

        private void chartInitButton_Click(object sender, RoutedEventArgs e)
        {
            this.coordinates.X.Clear();
            this.coordinates.Y.Clear();
            this.coordinates.Z.Clear();
            CoordinateWithFrame.initCount();
       
        }
    }
}