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
            //以蒙板的形式添加图像
            if (添加蒙板ToolStripMenuItem.Checked)
            {
                try
                {
                    int index = listBox.SelectedIndex;
                    if (index == -1) return;
                    this.Text = ToolName + "使用蒙板处理图像中...";

                    Image pic = buildsPics(index);             //待添加蒙板的图像
                    picFiles = filesNames.Split(';');          //分割为所有的文件名

                    Image mask = Bitmap.FromFile(picFiles[0]); //蒙板图像

                    picTmp = F.setPicMask(pic, mask);          //添加蒙板到图像上
                    pictureBox.Image = picTmp;                 //临时保存图像

                    添加蒙板ToolStripMenuItem.Checked = false; //添加蒙板完成，清除标识
                    this.Text = ToolName;
                }
                catch (Exception ex)
                { this.Text = ToolName; }
            }
            //添加图像到列表中
            else
            {
                picFiles = filesNames.Split(';');   //分割为所有的文件名

                //获取拖入的建筑块信息
                buildsPicsName = new string[picFiles.Length];

                listBox.Items.Clear();
                for (int i = 0; i < picFiles.Length; i++)
                {
                    buildsPicsName[i] = System.IO.Path.GetFileName(picFiles[i]);    //获取文件名
                    listBox.Items.Add(buildsPicsName[i]);   //添加图像名到列表中
                }

                listBox.SelectedIndex = 0;
            }
        }

        private Bitmap buildsPics(int index)
        {
            return F.ToBitmap(Bitmap.FromFile(picFiles[index])); 
        }

        //显示列表中对应的图像
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;  //选择的建筑块图像
            Bitmap pic = buildsPics(index);

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

                Bitmap[] pic = F.getPicMask(buildsPics(index));

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
            if (picTmp == null) MessageBox.Show("请先拖入蒙板图像_1.jpeg");
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
            Rectangle[]buildRects = F.GetRects(buildsPics(index));      //获取图像的子图区域

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
            Rectangle[] buildRects = F.GetRects(buildsPics(index));     //获取图像的子图区域

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
            Rectangle[] buildRects = F.GetRects(buildsPics(index));           //获取图像的子图区域

            //图像的所有子图图像
            Bitmap[] SubPics = new Bitmap[buildRects.Length];
            for (int i = 0; i < buildRects.Length; i++)
                SubPics[i] = F.GetRect(buildsPics(index), buildRects[i]);     //获取所有子图图像

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

            Bitmap pic = buildsPics(index);                     //获取图像
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

            Bitmap pic = buildsPics(index);                 //获取图像
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
            this.Text = ToolName + (select ? " 请拖入当前图像的蒙板 *_2.jpeg ..." : "");
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

        private void 提取较小资源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获取(原图像 和 蒙板图像)较小文件，形成列表
            List<string>[] List = getMiniCopyList();

            //复制图像资源
            for (int i = 0; i < List.Length; i++)
            {
                while (List[i].Count > 0)
                {
                    string file = List[i].ElementAt(0);
                    string name = System.IO.Path.GetFileName(file);

                    if (i == 1) name = name.Remove(name.LastIndexOf("_")) + ".jpg";
                    System.IO.File.Copy(file, F.getCurDir("较小图像资源") + name, true);
                    List[i].RemoveAt(0);
                }
            }

            F.MessageWithOpen("成功提取较小图像资源！", F.getCurDir("较小图像资源"));
        }

        /// <summary>
        /// 在当前载入的所有图像中，比较原图和其对应的蒙板图像的大小，保留较小的文件名到list中
        /// </summary>
        private List<string>[] getMiniCopyList()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            Dictionary<string, string> dic_1 = new Dictionary<string, string>();
            Dictionary<string, string> dic_2 = new Dictionary<string, string>();
            List<String> list = new List<string>();     //待复制的原图像或png蒙板图像
            List<String> list_1 = new List<string>();     //待复制的原图像或png蒙板图像

            //资源按文件名分类存储
            foreach (string file in picFiles)
            {
                string name = System.IO.Path.GetFileName(file);
                if (name.EndsWith("_1.jpeg") || name.EndsWith("_2.jpeg"))
                    name = name.Remove(name.LastIndexOf("_"));
                else name = System.IO.Path.GetFileNameWithoutExtension(name);

                if (file.EndsWith("_1.jpeg")) dic_1.Add(name, file);
                else if (file.EndsWith("_2.jpeg")) dic_2.Add(name, file);
                else dic.Add(name, file);
            }

            //保留较小资源（原图像、蒙板图像）
            while (dic.Count > 0)
            {
                KeyValuePair<string, string> iteam = dic.ElementAt(0);

                Boolean isPng = iteam.Value.EndsWith(".png");
                if (dic_1.ContainsKey(iteam.Key) && dic_2.ContainsKey(iteam.Key))   //png图像，比较大小，复制值原图或蒙板图像
                {
                    long len = new System.IO.FileInfo(iteam.Value).Length;
                    long len_1 = new System.IO.FileInfo(dic_1[iteam.Key]).Length;
                    long len_2 = !isPng ? 0 : new System.IO.FileInfo(dic_2[iteam.Key]).Length;

                    //原图像较小
                    if (len <= len_1 + len_2) list.Add(iteam.Value); 
                    else
                    {
                        //png图像，复制其对应的两张蒙板图像
                        if (isPng)  
                        {
                            list.Add(dic_1[iteam.Key]);
                            list.Add(dic_2[iteam.Key]);
                        }
                        //其他图像，近复制蒙板图像_1.jpeg
                        else list_1.Add(dic_1[iteam.Key]);
                    }
                }
                else list.Add(iteam.Value);

                dic.Remove(iteam.Key);
                if (dic_1.ContainsKey(iteam.Key)) dic_1.Remove(iteam.Key);
                if (dic_2.ContainsKey(iteam.Key)) dic_2.Remove(iteam.Key);
            }

            //其他资源
            while (dic_1.Count > 0)
            {
                KeyValuePair<string, string> iteam = dic_1.ElementAt(0);
                list.Add(iteam.Value);
                dic_1.Remove(iteam.Key);
            }

            while (dic_2.Count > 0)
            {
                KeyValuePair<string, string> iteam = dic_2.ElementAt(0);
                list.Add(iteam.Value);
                dic_2.Remove(iteam.Key);
            }

            return new List<string>[]{ list, list_1 };
        }

        private void 导出两倍尺寸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String Dir = "";
            foreach (string file in picFiles)
            {
                Image pic = Bitmap.FromFile(file);
                string name = System.IO.Path.GetFileName(file);
                pic = F.shrinkTo(pic, 2);
                Dir = F.SaveToDirectory(pic, name, "两倍尺寸图像");
            }

            F.MessageWithOpen("成功导出两倍尺寸图像", Dir);
        }

        private void 尺寸缩放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            Form2.imge = buildsPics(index);
            Form2.fileName = System.IO.Path.GetFileNameWithoutExtension(buildsPicsName[index]);
            
            Form form = new Form2();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

    }
}
