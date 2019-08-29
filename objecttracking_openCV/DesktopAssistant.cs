using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

using System.Runtime.InteropServices;
using Mouse_Control_via_Webcam;

namespace objecttracking_openCV
{
    public partial class Form1 : Form
    {
        Ycc YCrCb_min;
        Ycc YCrCb_max;
        IColorGloveDetector gloveDetector;

        Capture WebCam;

        Seq<MCvConvexityDefect> Found_defects;
        MCvConvexityDefect[] ArrayOfDefects;

        MCvBox2D OutLine_box;
        MemStorage storage = new MemStorage();

       
        Seq<Point> Hull;
        Seq<Point> filteredHull;
        Image<Bgr, byte> Orignal_img;
         
        int Brightness_Store = 0;
        int Contrast_Store = 0;
        int Sharpness_Store = 0;

        bool PressedButtonState = false;
      

        public Form1()
        {
            InitializeComponent();
            YCrCb_min = new Ycc(0, 139, 0);                             //139 or 145
            YCrCb_max = new Ycc(193, 255, 193);
           
        }

        private void DesktopAssistant_Load(object sender, EventArgs e)
        {

            // capturing a vedio input device
            try
            {
                WebCam = new Capture();
               
            }
            catch (NullReferenceException except)
            {
                label2.Text= except.Message;
                return;
            }

            Application.Idle += CountingFingersAndUpdateGUI;
        }

        //transferring mouse control to webcam
        private void btmPauseOrResum_Click(object sender, EventArgs e)
        {
            if (!PressedButtonState)
            {
                PressedButtonState = true;                                              // Set Flag
                btmPauseOrResum.Text = "Shift Mouse Control to Mouse Device";       // Change button text
            }
            else
            {
                btmPauseOrResum.Text = "Shift Mouse Control to Webcam";             // Change text
                PressedButtonState = false;                                             // Unset flag
            }

        }

        private void DesktopAssistant_Closed(object sender, FormClosedEventArgs e)
        {
            if (WebCam != null)
            {
                WebCam.Dispose();
            }
        }

        void CountingFingersAndUpdateGUI(object Sender, EventArgs agr)
        {
            int Num_Fingers = 0;
                
            Double FirstResult = 0;
            Double SecondResult = 0;
            //querying image

            Orignal_img = WebCam.QueryFrame().Resize(621, 446, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            if (Orignal_img == null) return;
            //Applying YCrCb filter
            //Image<Ycc, Byte> currentYCrCbFrame = imgOrignal.Convert<Ycc, byte>();
            //Image<Gray, byte> GloveColor = new Image<Gray, byte>(imgOrignal.Width, imgOrignal.Height);

            //skin = currentYCrCbFrame.InRange(new Ycc(0,139,0), new Ycc(193, 255, 193));

            gloveDetector = new YCrCbGloveDetector();

           Image<Gray, Byte> GloveColor = gloveDetector.DetectGlove(Orignal_img, YCrCb_min, YCrCb_max);

            OrignalCopy.Image = GloveColor.Resize(190, 167, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            iborignal.Image = Orignal_img;

            StructuringElementEx Shape_rect_12 = new StructuringElementEx(10, 10, 5, 5, Emgu.CV.CvEnum.CV_ELEMENT_SHAPE.CV_SHAPE_RECT);
            //Eroding the source image using the specified structuring element
            CvInvoke.cvErode(GloveColor, GloveColor, Shape_rect_12, 1);  

           StructuringElementEx Shape_rect_6 = new StructuringElementEx(6, 6, 3, 3, Emgu.CV.CvEnum.CV_ELEMENT_SHAPE.CV_SHAPE_RECT);
            //dilating the source image using the specified structuring element
           CvInvoke.cvDilate(GloveColor, GloveColor, Shape_rect_6, 1);

            GloveColor = GloveColor.Flip(FLIP.HORIZONTAL); //by uncmommenting this can stop flipping the image

            GloveColor = GloveColor.SmoothGaussian(9); //smoothing the filterd , eroded and dilated image.

            Orignal_img = Orignal_img.Flip(FLIP.HORIZONTAL); //**by uncmommenting this can stop flip the image

            //extracting contours,applying convexty defect allgoritm to find the count of fingers
            
            Contour<Point> Detectedcontours = GloveColor.FindContours();
            Contour<Point> LargestContour = null;
            //extracting the biggest contour.


            while (Detectedcontours != null)
            {

                FirstResult = Detectedcontours.Area;
                if (FirstResult > SecondResult)
                {
                    SecondResult = FirstResult;
                    LargestContour = Detectedcontours;
                }
                Detectedcontours = Detectedcontours.HNext;
            }

            //applying convexty defect allgoritm to find the count of fingers
            
            if (LargestContour != null)
            {
                Num_Fingers = 0; //number of Finger

                LargestContour = LargestContour.ApproxPoly((0.000025));
                Orignal_img.Draw(LargestContour, new Bgr(Color.LimeGreen), 2);

                Hull = LargestContour.GetConvexHull(ORIENTATION.CV_CLOCKWISE);

                Found_defects = LargestContour.GetConvexityDefacts(storage, ORIENTATION.CV_CLOCKWISE);
                Orignal_img.DrawPolyline(Hull.ToArray(), true, new Bgr(0, 0, 256), 3);

                Orignal_img.Draw(new CircleF(new PointF(OutLine_box.center.X, OutLine_box.center.Y), 5), new Bgr(200, 125, 75), 3);
                OutLine_box = LargestContour.GetMinAreaRect();

                filteredHull = new Seq<Point>(storage);
                for (int i = 0; i < Hull.Total; i++)
                {
                    if (Math.Sqrt(Math.Pow(Hull[i].X - Hull[i + 1].X, 2) + Math.Pow(Hull[i].Y - Hull[i + 1].Y, 2)) > OutLine_box.size.Width / 10)
                    {
                        filteredHull.Push(Hull[i]);
                    }
                }

                ArrayOfDefects = Found_defects.ToArray();

                for (int i = 0; i < Found_defects.Total; i++)
                {
                    PointF PointOfStart = new PointF((float)ArrayOfDefects[i].StartPoint.X,
                                                (float)ArrayOfDefects[i].StartPoint.Y);

                    PointF PointOfdepth = new PointF((float)ArrayOfDefects[i].DepthPoint.X,
                                                    (float)ArrayOfDefects[i].DepthPoint.Y);

                    PointF PointOfend = new PointF((float)ArrayOfDefects[i].EndPoint.X,
                                                    (float)ArrayOfDefects[i].EndPoint.Y);


                    CircleF CircleOfStart = new CircleF(PointOfStart, 10f);
                    CircleF CircleOfDepth = new CircleF(PointOfdepth, 10f);
                    CircleF CircleOfEnd = new CircleF(PointOfend, 10f);


                    if ((CircleOfStart.Center.Y < OutLine_box.center.Y || CircleOfDepth.Center.Y < OutLine_box.center.Y) &&
                            (CircleOfStart.Center.Y < CircleOfDepth.Center.Y) &&
                            (Math.Sqrt(Math.Pow(CircleOfStart.Center.X - CircleOfDepth.Center.X, 2) +
                                       Math.Pow(CircleOfStart.Center.Y - CircleOfDepth.Center.Y, 2)) >
                                       OutLine_box.size.Height / 6.5))
                    {
                      
                        Num_Fingers++;
                    }

                    Orignal_img.Draw(CircleOfStart, new Bgr(Color.SkyBlue), 2);
                    Orignal_img.Draw(CircleOfDepth, new Bgr(Color.Yellow), 2);
                }

                label2.Text = Num_Fingers.ToString();            // updating finger count

            }//End of convexty defect allgoritm

            // Finding the center of contour

            MCvMoments handMovements = new MCvMoments();               // a new MCvMoments object

            try
            {
                handMovements = LargestContour.GetMoments();           // Moments of biggestContour
            }

            catch (NullReferenceException except)
            {
                 //label2.Text = except.Message;
                return;
            }

            CvInvoke.cvMoments(LargestContour, ref handMovements, 0);

            double m_00 = CvInvoke.cvGetSpatialMoment(ref handMovements, 0, 0);
            double m_10 = CvInvoke.cvGetSpatialMoment(ref handMovements, 1, 0);
            double m_01 = CvInvoke.cvGetSpatialMoment(ref handMovements, 0, 1);

            int current_X = Convert.ToInt32(m_10 / m_00) /10;      // X location of centre of contour              
            int current_Y = Convert.ToInt32(m_01 / m_00) /10;      // Y location of center of contour

            // transfer control to webcam only if button has already been clicked

            if (PressedButtonState)
            {
                // move cursor to center of contour only if Finger count is 1 or 0 (finger_num<=1)
                // i.e. palm is closed

                if (Num_Fingers <= 1)
                {
                    Cursor.Position = new Point(current_X * 20, current_Y * 20);
                }

                // Leave the cursor where it was and Do mouse click, if finger count >= 4

                if (Num_Fingers == 5)
                {
                    DoMouseRightClick();                     //  mouse left button click funtion
                }

                if (Num_Fingers == 4)
                {
                    DoMouseDoubleClick();                     //  mouse left button  click funtion
                }


            }

            iborignal.Image = Orignal_img;               // display orignal image
        }

        // function for mouse clicks

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData,
           int dwExtraInfo);

    
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;          // mouse left button pressed 
        private const int MOUSEEVENTF_LEFTUP = 0x04;            // mouse left button unpressed
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;         // mouse right button pressed
        private const int MOUSEEVENTF_RIGHTUP = 0x10;           // mouse right button unpressed

        //this function will click the mouse using the parameters assigned to it
        public void DoMouseDoubleClick()
        {
            //Call the imported function with the cursor's current position
            uint X = Convert.ToUInt32(Cursor.Position.X);
            uint Y = Convert.ToUInt32(Cursor.Position.Y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        public void DoMouseRightClick()
        {       
            //Call the imported function with the cursor's current position
            uint X = Convert.ToUInt32(Cursor.Position.X);
            uint Y = Convert.ToUInt32(Cursor.Position.Y);
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
        }


        private void Brigtness_SLD_Scroll(object sender, EventArgs e)
        {
            Brigthness_LBL.Text = Brigtness_SLD.Value.ToString();
            if (WebCam != null) WebCam.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_BRIGHTNESS, Brigtness_SLD.Value*10.0f);
        }

        private void Contrast_SLD_Scroll(object sender, EventArgs e)
        {
            Contrast_LBL.Text = Contrast_SLD.Value.ToString();
            if (WebCam != null) WebCam.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_CONTRAST, Contrast_SLD.Value * 10.0f);
        }

        private void Sharpness_SLD_Scroll(object sender, EventArgs e)
        {
            Sharpness_LBL.Text = Sharpness_SLD.Value.ToString();
            if (WebCam != null) WebCam.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_SHARPNESS, Sharpness_SLD.Value*10.0f);
        }

      
        private void Reset_Cam_Settings_Click(object sender, EventArgs e)
        {
            if (WebCam != null)
            {
                WebCam.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_BRIGHTNESS, Brightness_Store);
                Sharpness_SLD.Value = 0;
                Brigthness_LBL.Text = "0";
                WebCam.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_CONTRAST, Contrast_Store);
                Contrast_SLD.Value = 0;
                Sharpness_LBL.Text = "0";
                WebCam.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_SHARPNESS, Sharpness_Store);
                Brigtness_SLD.Value = 0;
                Contrast_LBL.Text = "0";
            }
        }


        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
   
    }

}
