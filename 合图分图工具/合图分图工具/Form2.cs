using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PngSplit
{
    public partial class Form2 : Form
    {
        private int picWH = 1;          //记录初始时PicBox的尺寸
        public static int Mode = 1;     //图像缩放模式 1、最适缩放 2、满屏缩放
        public static Image imge;       //待缩放的图像
        public static Size size;        //图像缩放后的尺寸
        public static float scale = 1;  //在size的基础上放大的倍数

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            picWH = panel1.Width;

            if (Mode == 1) radioButton1.Checked = true;
            else radioButton2.Checked = true;

            //根据图像大小设置初始尺寸
            if (imge != null)
            {
                pictureBox1.Image = imge;
                size.Width = imge.Width;
                size.Height = imge.Height;
            }
            else size = new Size(1, 1);

            LinkLabel.Visible = checkBox1.Checked;

            showSeeting();
        }

        //显示设置信息
        private void showSeeting()
        {
            textBox1.Text = size.Width.ToString();
            textBox2.Text = size.Height.ToString();
            textBox3.Text = scale.ToString();
        }

        //长宽比例约束
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            LinkLabel.Visible = checkBox1.Checked;
        }

        float parse(String str)
        {
            try { return float.Parse(str); }
            catch (Exception) { return -1; }
        }

        //宽度变动
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int n = (int)parse(textBox1.Text);
            if (n > 0 && n != size.Width)
            {
                if (checkBox1.Checked)
                {
                    size.Height = (size.Height * n / size.Width);
                    textBox2.Text = size.Height.ToString();
                }
                size.Width = n;
            }
            restSize();
        }

        //高度变动
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int n = (int)parse(textBox2.Text);
            if (n > 0 && n != size.Height)
            {
                if (checkBox1.Checked)
                {
                    size.Width = (size.Width * n / size.Height);
                    textBox1.Text = size.Width.ToString();
                }
                size.Height = n;
            }
            restSize();
        }

        private void restSize()
        {
            int w = size.Width, h = size.Height;

            if (Mode == 1)
            {
                if (w > h)
                {
                    h = h * picWH / w;
                    w = picWH;
                }
                else
                {
                    w = w * picWH / h;
                    h = picWH;
                }
            }
            //else if (Mode == 2)
            //{
            //    if ((w < h))
            //    {
            //        h = h * picWH / w;
            //        w = picWH;
            //    }
            //    else
            //    {
            //        w = w * picWH / h;
            //        h = picWH;
            //    }
            //}


            if (Mode == 1)
            {
                pictureBox1.Width = w;
                pictureBox1.Height = h;
            }

            pictureBox1.Left = (picWH - w) / 2;
            pictureBox1.Top = (picWH - h) / 2;
        }

        //缩放倍数变动
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            float n = parse(textBox3.Text);
            if (n >= 0) textBox3.Text = n.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Mode = 1;
            restSize();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Mode = 2;
            restSize();
        }
    }
}
