using MotionTracker.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionTracker
{
    class ThreeDimensionalCoordinates
    {
        public ObservableCollection<CoordinateWithFrame> X { get; set; }
        public ObservableCollection<CoordinateWithFrame> Y { get; set; }
        public ObservableCollection<CoordinateWithFrame> Z { get; set; }

        public ThreeDimensionalCoordinates()
        {
            this.X = new ObservableCollection<CoordinateWithFrame>();
            this.Y = new ObservableCollection<CoordinateWithFrame>();
            this.Z = new ObservableCollection<CoordinateWithFrame>();
        }
    }
}
