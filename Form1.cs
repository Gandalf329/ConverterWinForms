using ImageMagick;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converter
{
    public partial class Form1 : Form
    {
        string filename1 = "";
        string filenameResult = "";
        string selectedState = "";
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Image Files(*.JPG;*.PNG;*.JPEG)|*.PNG;*.JPG;*.JPEG;|All files (*.*)|*.*";
            comboBox1.Items.AddRange(new string[] { "PNG", "JPG", "ICO" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            filename1 = openFileDialog1.FileName;

            textBox1.Text = filename1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = "";
            var convertLetter = Convert.ToChar(@"\");
            string[] words = filename1.Split(new char[] { convertLetter });
            for (int i = 0; i < words.Length - 1; i++)
            {
                path += words[i] + @"\";
            }
            textBox2.Text = path;
            switch (selectedState)
            {
                case "JPG":
                    using (var image = new MagickImage(filename1))
                    {
                        image.Format = MagickFormat.Jpeg;
                        image.Write($"{path}test1.jpeg");
                        MessageBox.Show("To .jpeg Done!");
                    }
                    break;

                case "PNG":
                    using (var image = new MagickImage(filename1))
                    {
                        image.Format = MagickFormat.Png;
                        image.Write($"{path}test1.png");
                        MessageBox.Show("To .png Done!");
                    }
                    break;

                case "ICO":
                    using (var image = new MagickImage(filename1))
                    {
                        image.Settings.SetDefine(MagickFormat.Icon, "auto-resize", "256,128");
                        image.Write($"{path}test1.ico");
                        MessageBox.Show("To .ico Done!");
                    }
                    break;
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedState = comboBox1.SelectedItem.ToString();
        }
    }
}
