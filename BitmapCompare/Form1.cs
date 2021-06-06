using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitmapCompare
{
    public partial class Form1 : Form
    {
        private string selectedFilePath { get; set; }
        private string[] versions { get; set; }
        private string[] laterVersions { get; set; }
        private string[] availableSheetsDwg1 { get; set; }
        private string[] availableSheetsDwg2 { get; set; }
        private string imgPathFromVersion { get; set; }
        private string imgPathToVersion { get; set; }


        public Form1()
        {
            InitializeComponent();
            
            /*
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

            pictureBox3.Image = diffBmp;*/

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                selectedFilePath = openFileDialog1.FileName;
                textBox1.Text = selectedFilePath;
                versions = DataCollection.getVersions(openFileDialog1.FileName);
                comboBox1.Items.AddRange(versions);
                comboBox1.Enabled = true;

            }
            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //Make sure version comes in as valid int.. 

            string selection = comboBox1.Text;

            var laterQuery = from ver in versions
                            where int.Parse(ver) > int.Parse(selection)
                            select ver;

            laterVersions = laterQuery.ToArray();

            comboBox2.Items.Clear();

            if (laterVersions.Length > 0)
            {
                comboBox2.Items.AddRange(laterVersions);
                comboBox2.Enabled = true;
                comboBox2.SelectedIndex = 0;
            }
            else
            {
                comboBox2.Enabled = false;
                comboBox2.Text = "No Later Version";
                btnLoadDrawings.Enabled = false;
            }
            
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            btnLoadDrawings.Enabled = true;
        }

        private void btnLoadDrawings_Click(object sender, EventArgs e)
        {
            string v1 = comboBox1.Text;
            string v2 = comboBox2.Text;

            //Get v1, make sheet bitmaps, store array of available sheets
            availableSheetsDwg1 = new string[] { "1", "2"};

            //Get v2, make sheet bitmaps, store array of available sheets
            availableSheetsDwg2 = new string[] { "1", "2", "3"};

            if (availableSheetsDwg1.Length > availableSheetsDwg2.Length)
                comboBox3.Items.AddRange(availableSheetsDwg1);
            else
                comboBox3.Items.AddRange(availableSheetsDwg2);

            imgPathFromVersion = Path.Join(@"C:\Users\Nai\Documents\Code\BitmapComparePics\", $"Pic{v1}.bmp");
            pictureBox1.ImageLocation = imgPathFromVersion;

            imgPathToVersion = Path.Join(@"C:\Users\Nai\Documents\Code\BitmapComparePics\", $"Pic{v2}.bmp");
            pictureBox2.ImageLocation = imgPathToVersion;

            btnLoadDrawings.Enabled = false;
            btnCompare.Enabled = true;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)Bitmap.FromFile(imgPathFromVersion);
            Bitmap bmp2 = (Bitmap)Bitmap.FromFile(imgPathToVersion);

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

            btnCompare.Enabled = false;
        }
    }
}
