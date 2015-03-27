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
    public partial class Form1 : Form
    {
        string ToolName = "PngSplit";

        ToolsFunction F = new ToolsFunction();  //图像处理相关函数工具
        string[] buildsPicsName;    //各建筑块名称
        Bitmap[] buildsPics;        //各建筑块的对应图像

        Bitmap picTmp;              //临时存储程序运行过程中处理的图像

        public Form1()
        {
            InitializeComponent();
            this.Text = ToolName;
        }

        //拖入文件
        private void panel_DragEnter(object sender, DragEventArgs e)
        {
            F.dragEnter(e);
        }
        //放下文件
        private void panel_DragDrop(object sender, DragEventArgs e)
        {
            string filesName = F.dragDrop(e);            //拖入窗体的文件放下
            updatePics(filesName);                       //使用文件对应的建筑图像
        }

        //对拖入的文件进行相应的处理
        private void updatePics(string filesNames)
        {
            string[] picFiles = filesNames.Split(';');   //分割为所有的文件名

            //以蒙板的形式添加图像
            if (添加蒙板ToolStripMenuItem.Checked)
            {
                try
                {
                    int index = listBox.SelectedIndex;
                    if (index == -1) return;
                    this.Text = ToolName + "使用蒙板处理图像中...";

                    Image pic = buildsPics[index];             //待添加蒙板的图像
                    Image mask = Bitmap.FromFile(picFiles[0]); //蒙板图像

                    picTmp = F.setPicMask(pic, mask);          //添加蒙板到图像上
                    pictureBox.Image = picTmp;                 //临时保存图像
                    buildsPics[index] = picTmp;                //记录添加蒙板后的图像

                    添加蒙板ToolStripMenuItem.Checked = false; //添加蒙板完成，清除标识
                    this.Text = ToolName;
                }
                catch (Exception ex)
                { this.Text = ToolName; }
            }
            //添加图像到列表中
            else
            {
                //获取拖入的建筑块信息
                buildsPicsName = new string[picFiles.Length];
                buildsPics = new Bitmap[picFiles.Length];

                listBox.Items.Clear();
                for (int i = 0; i < picFiles.Length; i++)
                {
                    buildsPicsName[i] = System.IO.Path.GetFileName(picFiles[i]);    //获取文件名
                    buildsPics[i] = F.ToBitmap(Bitmap.FromFile(picFiles[i]));       //获取图像

                    listBox.Items.Add(buildsPicsName[i]);   //添加图像名到列表中
                }

                listBox.SelectedIndex = 0;
            }
        }

        //显示列表中对应的图像
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;  //选择的建筑块图像
            Bitmap pic = buildsPics[index];

            //设置图像的显示样式，大图像拉伸显示、小图像居中显示
            if (pic.Width > pictureBox.Width || pic.Height > pictureBox.Height)
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            else pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;

            pictureBox.Image = pic;             //设置当前使用的建筑块图像
        }

        private void 导出蒙板图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int index = listBox.SelectedIndex;
                if (index == -1) return;
                string name = System.IO.Path.GetFileNameWithoutExtension(buildsPicsName[index]);  //获取文件名
                this.Text = ToolName + "蒙板图像生成中...";

                Bitmap[] pic = F.getPicMask(buildsPics[index]);

                F.SaveToDirectory(pic[0], name + "_1.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                F.SaveToDirectory(pic[1], name + "_2.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

                this.Text = ToolName; 
                MessageBox.Show("成功导出蒙板！");
            }
            catch (Exception ex)
            { this.Text = ToolName; }
        }

        private void 导出图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (picTmp == null) MessageBox.Show("请拖入图像，再进行相应操作！");
            else
            {
                try
                {
                    int index = listBox.SelectedIndex;
                    if (index == -1) return;
                    this.Text = ToolName + "图像导出中...";

                    string name = System.IO.Path.GetFileNameWithoutExtension(buildsPicsName[index]);  //获取文件名
                    F.SaveToDirectory(picTmp, name + ".png", System.Drawing.Imaging.ImageFormat.Png);

                    this.Text = ToolName;
                    MessageBox.Show("成功导出图像");
                }
                catch (Exception ex)
                { this.Text = ToolName; }
            }
        }

        private void 导出子图区域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            if (index == -1) return;
            Rectangle[]buildRects = F.GetRects(buildsPics[index]);      //获取图像的子图区域

            string str = "";
            for (int i = 0; i < buildRects.Length; i++)
                str += (i.ToString() + "," + buildRects[i].ToString() + (i < buildRects.Length - 1 ? ";\r\n" : ""));

            string name = "子图区域_" + buildsPicsName[index].Replace(".", "_");
            F.SaveToFile(str, name, false);
        }

        private void 导出精简数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            if (index == -1) return;
            Rectangle[] buildRects = F.GetRects(buildsPics[index]);     //获取图像的子图区域

            string str = "";
            string str2 = "";
            for (int i = 0; i < buildRects.Length; i++)
            {
                str2 = buildRects[i].X + "," + buildRects[i].Y + "," + buildRects[i].Width + "," + buildRects[i].Height;
                str += (str2 + (i < buildRects.Length - 1 ? ";" : ""));
            }

            string name = "子图区域精简_" + buildsPicsName[index].Replace(".", "_");
            F.SaveToFile(str, name, false);
        }

        private void 导出所有子图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            if (index == -1) return;
            Rectangle[] buildRects = F.GetRects(buildsPics[index]);           //获取图像的子图区域

            //图像的所有子图图像
            Bitmap[] SubPics = new Bitmap[buildRects.Length];
            for (int i = 0; i < buildRects.Length; i++)
                SubPics[i] = F.GetRect(buildsPics[index], buildRects[i]);     //获取所有子图图像

            string directory = "子图_" + buildsPicsName[index].Replace(".", "_");
            for (int i = 0; i < SubPics.Length; i++)       //导出其所有子图
                F.SaveToDirectory(SubPics[i], i + ".png", directory);

            MessageBox.Show("成功导出当前图片所有子图 -> " + directory);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            F.SaveToFile(Properties.Resources.example, "example.png", false);
        }
        
    }
}
