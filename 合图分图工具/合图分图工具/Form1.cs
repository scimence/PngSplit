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
        string ToolName = "PngSplit ";

        ToolsFunction F = new ToolsFunction();  //图像处理相关函数工具
        string[] buildsPicsName;    //各建筑块名称
        Bitmap[] buildsPics;        //各建筑块的对应图像
        string[] picFiles;          //各建筑块的文件名

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
            picFiles = filesNames.Split(';');   //分割为所有的文件名

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

        Boolean mute = false;
        private void 导出蒙板图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int index = listBox.SelectedIndex;
                if (index == -1) return;
                string name = System.IO.Path.GetFileNameWithoutExtension(buildsPicsName[index]);  //获取文件名
                this.Text = ToolName + "蒙板图像生成中...";

                Bitmap[] pic = F.getPicMask(buildsPics[index]);

                String subDir = "导出蒙板";
                F.SaveToDirectory(pic[0], name + "_1.jpeg", subDir, System.Drawing.Imaging.ImageFormat.Jpeg);
                String Dir = F.SaveToDirectory(pic[1], name + "_2.jpeg", subDir, System.Drawing.Imaging.ImageFormat.Jpeg);

                this.Text = ToolName;
                if (!mute) F.MessageWithOpen("成功导出蒙板！", Dir + name + "_1.jpeg");
            }
            catch (Exception ex)
            { this.Text = ToolName; }
        }

        private void 导出图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (picTmp == null) MessageBox.Show("请先拖入一个图像文件，再进行操作！");
            else
            {
                try
                {
                    int index = listBox.SelectedIndex;
                    if (index == -1) return;
                    this.Text = ToolName + "图像导出中...";

                    //获取文件名
                    string name = buildsPicsName[index];
                    if(name.EndsWith("_1.jpeg")) name = name.Remove(name.LastIndexOf("_1.jpeg"));
                    else name = System.IO.Path.GetFileNameWithoutExtension(name);  
                    
                    String Dir = F.SaveToDirectory(picTmp, name + ".png", "蒙板合成图像", System.Drawing.Imaging.ImageFormat.Png);

                    this.Text = ToolName;
                    F.MessageWithOpen("成功导出图像", Dir + name + ".png");
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
            F.SaveToFile(str, @"导出数据\", name, false);
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
            F.SaveToFile(str, @"导出数据\", name, false);
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
            string Dir = "";
            for (int i = 0; i < SubPics.Length; i++)       //导出其所有子图
                Dir = F.SaveToDirectory(SubPics[i], i + ".png", directory);

            F.MessageWithOpen("成功导出当前图片所有子图", Dir);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            F.SaveToFile(Properties.Resources.example, "example.png", false);
        }

        private void 全部导出蒙板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = listBox.Items.Count;

            for (int i = 0; i < count; i++ )
            {
                listBox.SelectedIndex = i;
                mute = (i < count-1);
                导出蒙板图像ToolStripMenuItem_Click(null, null);
            }
        }

        private void 左上尺寸裁剪ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clipPic(2);     //截取左上点开始的最小尺寸
        }

        private void 最适尺寸裁剪ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clipPic(1);     //截取最小尺寸
        }
        
        /// <summary>
        /// 根据设定进行图像裁切
        /// </summary>
        private String clipPic(int i)
        {
            int index = listBox.SelectedIndex;
            if (index == -1) return "";
            string name = System.IO.Path.GetFileName(buildsPicsName[index]);//获取文件名
            string Ext = System.IO.Path.GetExtension(name).ToLower();       //获取拓展名
            this.Text = ToolName + "图像" + name + ",裁切中...";

            int C = 0;
            if(Ext.Equals(".jpg") || Ext.Equals(".jpeg")) C = Color.White.ToArgb(); //jpg图像设置白色为透明色

            Bitmap pic = buildsPics[index];                     //获取图像
            Rectangle Rect = new Rectangle();
            if (i == 1) Rect = F.GetMiniRect(pic, C);           //获取图像pic的最小非透明像素矩形区域
            else if (i == 2) Rect = F.GetMiniLeftRect(pic, C);  //获取从左上点开始的图像pic的最小非透明像素矩形区域

            String subDir = null;
            if (i == 1) subDir = "最适尺寸裁切";
            else if (i == 2) subDir = "左上尺寸裁切";

            pic = F.GetRect(pic, Rect);                         //截取pic中的指定区域Rect
            String Dir = F.SaveToDirectory(pic, name, subDir, (System.Drawing.Imaging.ImageFormat)null); //保存图像到文件

            this.Text = ToolName;
            if (!mute) F.MessageWithOpen("图像裁切完成！", Dir + name);
            return Dir;
        }

        private void 左上尺寸裁切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clipPicAll(2);
        }

        private void 最适尺寸裁切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clipPicAll(1);
        }

        /// <summary>
        /// 根据设定进行图像裁切
        /// </summary>
        private void clipPicAll(int index)
        {
            int count = listBox.Items.Count;
            if (count == 0) return;

            String Dir = "";
            for (int i = 0; i < count; i++)
            {
                listBox.SelectedIndex = i;
                mute = true;
                Dir = clipPic(index);
            }

            mute = false;
            F.MessageWithOpen("所有图像裁切完成！", Dir);
        }

        private void 导出10进制颜色值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getPixelData(10);
        }

        private void 导出16进制颜色值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getPixelData(16);
        }

        /// <summary>
        /// 保存当前图像的所有像素颜色值为toBase进制
        /// </summary>
        private void getPixelData(int toBase)
        {
            int index = listBox.SelectedIndex;
            if (index == -1) return;

            Bitmap pic = buildsPics[index];                 //获取图像
            string picName = System.IO.Path.GetFileName(buildsPicsName[index]);  //获取文件名
            this.Text = ToolName + "图像" + picName + ",像素数据导出中...";

            String str = F.getPixelsData(pic, toBase);      //获取当前显示图像的所有像素颜色值数据
            string name = toBase + "进制颜色值_" + picName.Replace(".", "_");
            this.Text = ToolName;
            F.SaveToFile(str, @"导出数据\", name, false);  //保存数据到文件
        }

        /// <summary>
        /// 打开工具界面
        /// </summary>
        private void pictureBox_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://git.oschina.net/scimence/PngSplit");

            //创建新的进程，打开指定网页
            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //process.StartInfo.FileName = "iexplore.exe";            //IE浏览器，可以更换
            //process.StartInfo.Arguments = "http://www.baidu.com";
            //process.Start();
        }

        private void 添加蒙板ToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            bool select = 添加蒙板ToolStripMenuItem.Checked;
            this.Text = ToolName + (select ? " 请拖入当前图像的蒙板..." : "");
        }

        private void 合并蒙板图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (picFiles == null) return;

            List<String> picsName = new List<string>();
            foreach (String name in picFiles) picsName.Add(name);

            this.Text = ToolName + "合并蒙板图像中...";
            String Dir = "";
            while (picsName.Count > 0)
            {
                String name1 = picsName.ElementAt(0), name2 = "";
                picsName.Remove(name1);

                //获取同名蒙板图像
                if(name1.EndsWith("_1.jpeg")) name2 = name1.Remove(name1.LastIndexOf("_1.jpeg")) + "_2.jpeg";
                else if (name1.EndsWith("_2.jpeg")) name2 = name1.Remove(name1.LastIndexOf("_2.jpeg")) + "_1.jpeg";

                //合并蒙板图像
                if (picsName.Contains(name2))
                {
                    picsName.Remove(name2);
                    Dir = comeBine(name1, name2);    
                }
            }

            this.Text = ToolName;
            F.MessageWithOpen("成功合并所有蒙板图像！", Dir);
        }

        //从工具导出的蒙板图像,合成png, pic1和pic2名称为"*_1.jpeg"或"*_1.jpeg"
        private String comeBine(String pic1, String pic2)
        {
            String Dir = "";

            bool ext_1 = pic1.EndsWith("_1.jpeg");
            String name = System.IO.Path.GetFileName(pic1);
            name = name.Remove(name.LastIndexOf("_"));

            Image pic = Bitmap.FromFile(ext_1 ? pic1 : pic2);   //待添加蒙板的图像
            Image mask = Bitmap.FromFile(ext_1 ? pic2 : pic1);  //蒙板图像

            picTmp = F.setPicMask(pic, mask);                   //添加蒙板到图像上
            Dir = F.SaveToDirectory(picTmp, name + ".png", "蒙板合成图像", System.Drawing.Imaging.ImageFormat.Png);
            
            return Dir;
        }

    }
}
