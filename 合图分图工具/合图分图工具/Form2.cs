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
        public static Image imge;       //待缩放的图像
        public static Size size;        //图像缩放后的尺寸
        private Boolean loading = false;//标识当前是否处于载入状态
        public static string fileName;  //图像名称

        ToolsFunction F = new ToolsFunction();  //图像处理相关函数工具

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loading = true;
            picWH = panel1.Width;

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

            loading = false;
            restSize();
        }

        //显示设置信息
        private void showSeeting()
        {
            textBox1.Text = size.Width.ToString();
            textBox2.Text = size.Height.ToString();
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
                restSize();
            }
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
                restSize();
            }
        }

        //根据宽高值，设置pictureBox1尺寸
        private void restSize()
        {
            if (loading) return;

            int w = size.Width, h = size.Height;

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

            pictureBox1.Width = w;
            pictureBox1.Height = h;

            pictureBox1.Left = (picWH - w) / 2;
            pictureBox1.Top = (picWH - h) / 2;
        }

        private Bitmap getPic()
        {
            return F.shrinkTo(imge, size, checkBox2.Checked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = fileName + "_" + size.Width + "x" + size.Height + ".png";
            String Dir = F.SaveToDirectory(getPic(), name, "图像缩放");
            F.MessageWithOpen("成功导出图像", Dir + name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = fileName + "_" + size.Width + "x" + size.Height + ".jpg";
            String Dir = F.SaveToDirectory(getPic(), name, "图像缩放");
            F.MessageWithOpen("成功导出图像", Dir + name);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap pic = getPic();      //获取图像
            Icon icon = F.ToIcon(pic);  //转化为Icon

            //保存Icon
            string name = fileName + "_" + size.Width + "x" + size.Height + ".ico";

            //string curDir = F.SaveToDirectory(pic, name, "图像缩放");
            string curDir = F.SaveToDirectory(icon, name, "图像缩放");
            F.MessageWithOpen("成功导出icon图像", curDir);
        }
    }
}
