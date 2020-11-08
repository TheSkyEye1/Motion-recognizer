using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace Lab6
{
    public partial class Form1 : Form
    {
        private VideoCapture capture;
        private int vframe = 0;
        Image<Gray, byte> background;
        Filter_c fil = new Filter_c();
        int mode = 0;
        BackgroundSubtractorMOG2 subtractor = new BackgroundSubtractorMOG2(1000, 32, true);
        bool web = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void load_Click(object sender, EventArgs e)
        {
            if(web == true)
            {
                web = false;
                capture.Stop();
            }
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter = "(*.mp4)|*.mp4";
            var result = openFileDialog2.ShowDialog();
            vframe = 0;
            subtractor.Clear();
            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog2.FileName;
                capture = new VideoCapture(fileName);
                vtimer.Enabled = true;
                background = null;
            }
        }

        private void vtimer_Tick(object sender, EventArgs e)
        {
            vframe++;
            if (vframe >= capture.GetCaptureProperty(CapProp.FrameCount))
            {
                vtimer.Enabled = false;
            }
            else
            {
                var frame = capture.QueryFrame();
                Image<Bgr, byte> image = frame.ToImage<Bgr, byte>();
                
                
                if (mode == 0)
                {
                    IMG1.Image = image;
                }else
                if (background != null && mode == 1)
                {
                    IMG1.Image = fil.diffusal(image, background);
                }else
                if(mode == 2)
                {
                    var foregroundMask = image.Convert<Gray, byte>().CopyBlank();
                    subtractor.Apply(image.Convert<Gray, byte>(), foregroundMask);
                    var filteredMask = fil.FilterMask(foregroundMask, image);
                    IMG1.Image = filteredMask;
                }
            }
            
        }

        private void backb_Click(object sender, EventArgs e)
        {
            var frame = capture.QueryFrame();
            background = frame.ToImage<Gray, byte>();
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            mode = 0;
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {
            if (background == null)
            {
                mode = 0;
                rb1.Checked = true;
                MessageBox.Show("Background is null");
            }
            else
            {
                mode = 1;
            }
        }

        private void rb3_CheckedChanged(object sender, EventArgs e)
        {
            mode = 2;
        }

        private void webcam_Click(object sender, EventArgs e)
        {
            subtractor.Clear();
            web = true;
            vtimer.Enabled = false;
            capture = new VideoCapture();
            capture.ImageGrabbed += ProcessFrame;
            capture.Start();
            
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if (web == true)
            {
                var frame = new Mat();
                capture.Retrieve(frame);
                Image<Bgr, byte> image = frame.ToImage<Bgr, byte>();
                if (mode == 0)
                {
                    IMG1.Image = image;
                }
                else
                if (background != null && mode == 1)
                {
                    IMG1.Image = fil.diffusal(image, background);
                }
                else
                if (mode == 2)
                {
                    var foregroundMask = image.Convert<Gray, byte>().CopyBlank();
                    subtractor.Apply(image.Convert<Gray, byte>(), foregroundMask);
                    var filteredMask = fil.FilterMask(foregroundMask, image);
                    IMG1.Image = filteredMask;
                }
            }
        }
    }
}
