using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmguCV_capture_camera
{
    public partial class Form1 : Form
    {
        VideoCapture capture; 
        public Form1()
        {
            InitializeComponent();
        }
        
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (capture== null) { capture = new Emgu.CV.VideoCapture(0); }
            capture.ImageGrabbed += Capture_ImageGrabbed;
            capture.Start();
        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                capture.Retrieve(m);
                pictureBox1.Image = m.ToImage<Bgr, byte>().Bitmap;
            }
            catch(Exception)
            {

            }
        }
        //webcam
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(capture!= null) { capture = null; }
        }

        //video file
        private void startToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    capture = new Emgu.CV.VideoCapture(ofd.FileName);
                }            
                
            }
            capture.ImageGrabbed += Capture_ImageGrabbed1;
            capture.Start();
        }
      
        private void Capture_ImageGrabbed1(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                capture.Retrieve(m);
                pictureBox1.Image = m.ToImage<Bgr, byte>().Bitmap;
                Thread.Sleep((int)capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps));
            }
            catch (Exception)
            {

            }
        }

        private void stopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (capture != null) { capture = null; /*capture.Stop();*/ }
        }

        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                capture = new Emgu.CV.VideoCapture(ofd.FileName);
            }
        }
    }
}
