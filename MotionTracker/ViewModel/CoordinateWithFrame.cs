using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionTracker.ViewModel
{
    class CoordinateWithFrame
    {
        public static double Count = 0;
        public double Coordinate { get; set; }
        public double Frame { get; set; }

        public CoordinateWithFrame(double coordinate,double frame)
        {
            Count++;
            this.Coordinate = coordinate;
            this.Frame = frame;
        }

        public CoordinateWithFrame(double coordinate)
        {
            Count++;
            this.Frame = Count;
        }
    }

}
