using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionTracker.ViewModel
{
    class CoordinateWithFrame
    {
        public double Coordinate { get; set; }
        public int Frame { get; set; }

        public CoordinateWithFrame(double coordinate,int frame)
        {
            this.Coordinate = coordinate;
            this.Frame = frame;
        }
    }

}
