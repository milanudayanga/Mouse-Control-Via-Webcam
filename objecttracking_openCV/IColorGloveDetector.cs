using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Mouse_Control_via_Webcam
{
    public abstract class IColorGloveDetector
    {
        public abstract Image<Gray, Byte> DetectGlove(Image<Bgr, Byte> Img, IColor min, IColor max);
    }
}
