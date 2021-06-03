using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitmapCompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.ImageLocation = @"C:\Users\Nai\Documents\Code\BitmapComparePics\Pic1.bmp";
            pictureBox2.ImageLocation = @"C:\Users\Nai\Documents\Code\BitmapComparePics\Pic2.bmp";

            //Image pic = Image.FromFile(@"C:\Users\Nai\Documents\Code\BitmapComparePics\Pic1.bmp");
            //pictureBox1.Image = pic;
            Bitmap bmp1 = (Bitmap)Bitmap.FromFile(@"C:\Users\Nai\Documents\Code\BitmapComparePics\Pic1.bmp");
            Bitmap bmp2 = (Bitmap)Bitmap.FromFile(@"C:\Users\Nai\Documents\Code\BitmapComparePics\Pic2.bmp");

            Bitmap diffBmp = new Bitmap(bmp1.Width, bmp1.Height);

            for (int y = 0; y < diffBmp.Height; y++)
            {
                for (int x = 0; x < diffBmp.Width; x++)
                {
                    diffBmp.SetPixel(x, y, Color.Black);
                    if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                    {
                        diffBmp.SetPixel(x, y, Color.White);
                    }
                }
            }

            pictureBox3.Image = diffBmp;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
