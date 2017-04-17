using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Resizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Image Resize_withas(Image image, int mw, int mh)
        {
            var ratioX = (double)mw / image.Width;
            var ratioY = (double)mh / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var nw = (int)(image.Width * ratio);
            var nh = (int)(image.Height * ratio);

            var resized = new Bitmap(nw, nh);

            using (var graphics = Graphics.FromImage(resized))
                graphics.DrawImage(image, 0, 0, nw, nh);

            return resized;
        }

        public static Image Resize_woas(Image image, int mw, int mh)
        {
            var ratioX = (double)mw / image.Width;
            var ratioY = (double)mh / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var nw = (int)(image.Width * ratio);
            var nh = (int)(image.Height * ratio);

            var resized = new Bitmap(nw, nh);

            var newImagewo = new Bitmap(nw, nh);
            Graphics.FromImage(newImagewo).DrawImage(image, 0, 0, nw, nh);
            Bitmap bmp = new Bitmap(newImagewo);
            return bmp;
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            pictureBox1.ImageLocation = openFileDialog1.FileName;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            x = int.Parse(textBox1.Text);

            int y = Convert.ToInt32(textBox2.Text);
            y = int.Parse(textBox2.Text);

            if (checkBox1.Checked == true)
            {
                using (var image = Image.FromFile(openFileDialog1.FileName))
                using (var newImage = Resize_withas(image, x, y))
                {
                    newImage.Save(openFileDialog1.InitialDirectory + openFileDialog1.FileName + "_resized", ImageFormat.Png);
                }
            }
            else
            {
                using (var image = Image.FromFile(openFileDialog1.FileName))
                using (var newImage = Resize_woas(image, x, y))
                {
                    newImage.Save(openFileDialog1.InitialDirectory + openFileDialog1.FileName + "_resized", ImageFormat.Png);
                }
            }


           
        }
    }
}
