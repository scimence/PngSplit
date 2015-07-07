namespace PngSplit
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel = new System.Windows.Forms.Panel();
            this.listBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.全部导出蒙板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.左上尺寸裁切ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最适尺寸裁切ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.合并蒙板图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.提取较小资源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.导出两倍尺寸ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.导出所有子图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出子图区域ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出精简数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.导出遮罩图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加蒙板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.左上尺寸裁剪ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最适尺寸裁剪ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.导出10进制颜色值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出16进制颜色值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.尺寸缩放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.AllowDrop = true;
            this.panel.Controls.Add(this.listBox);
            this.panel.Controls.Add(this.pictureBox);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(519, 400);
            this.panel.TabIndex = 85;
            this.panel.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel_DragDrop);
            this.panel.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // listBox
            // 
            this.listBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBox.ContextMenuStrip = this.contextMenuStrip2;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 12;
            this.listBox.Location = new System.Drawing.Point(400, 0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(120, 400);
            this.listBox.TabIndex = 87;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全部导出蒙板ToolStripMenuItem,
            this.左上尺寸裁切ToolStripMenuItem,
            this.最适尺寸裁切ToolStripMenuItem,
            this.toolStripSeparator4,
            this.合并蒙板图像ToolStripMenuItem,
            this.提取较小资源ToolStripMenuItem,
            this.toolStripSeparator5,
            this.导出两倍尺寸ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(149, 148);
            // 
            // 全部导出蒙板ToolStripMenuItem
            // 
            this.全部导出蒙板ToolStripMenuItem.Name = "全部导出蒙板ToolStripMenuItem";
            this.全部导出蒙板ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.全部导出蒙板ToolStripMenuItem.Text = "全部导出蒙板";
            this.全部导出蒙板ToolStripMenuItem.ToolTipText = "对当前拖入的所有图像，执行导出蒙板操作";
            this.全部导出蒙板ToolStripMenuItem.Click += new System.EventHandler(this.全部导出蒙板ToolStripMenuItem_Click);
            // 
            // 左上尺寸裁切ToolStripMenuItem
            // 
            this.左上尺寸裁切ToolStripMenuItem.Name = "左上尺寸裁切ToolStripMenuItem";
            this.左上尺寸裁切ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.左上尺寸裁切ToolStripMenuItem.Text = "左上尺寸裁切";
            this.左上尺寸裁切ToolStripMenuItem.ToolTipText = "对当前拖入的所有图像，执行左上尺寸裁切";
            this.左上尺寸裁切ToolStripMenuItem.Click += new System.EventHandler(this.左上尺寸裁切ToolStripMenuItem_Click);
            // 
            // 最适尺寸裁切ToolStripMenuItem
            // 
            this.最适尺寸裁切ToolStripMenuItem.Name = "最适尺寸裁切ToolStripMenuItem";
            this.最适尺寸裁切ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.最适尺寸裁切ToolStripMenuItem.Text = "最适尺寸裁切";
            this.最适尺寸裁切ToolStripMenuItem.ToolTipText = "对当前拖入的所有图像，执行最适寸裁切";
            this.最适尺寸裁切ToolStripMenuItem.Click += new System.EventHandler(this.最适尺寸裁切ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // 合并蒙板图像ToolStripMenuItem
            // 
            this.合并蒙板图像ToolStripMenuItem.Name = "合并蒙板图像ToolStripMenuItem";
            this.合并蒙板图像ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.合并蒙板图像ToolStripMenuItem.Text = "合并蒙板图像";
            this.合并蒙板图像ToolStripMenuItem.ToolTipText = "在当前拖入的所有图像资源中，搜索是否为导出蒙板图像，\r\n是则合并2张jpeg蒙板图像，为1张新的png图像";
            this.合并蒙板图像ToolStripMenuItem.Click += new System.EventHandler(this.合并蒙板图像ToolStripMenuItem_Click);
            // 
            // 提取较小资源ToolStripMenuItem
            // 
            this.提取较小资源ToolStripMenuItem.Name = "提取较小资源ToolStripMenuItem";
            this.提取较小资源ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.提取较小资源ToolStripMenuItem.Text = "提取较小资源";
            this.提取较小资源ToolStripMenuItem.ToolTipText = "拖入所有（原图像 和 蒙板图像），自动对比二者的文件大小，\r\n复制较小的图像资源";
            this.提取较小资源ToolStripMenuItem.Click += new System.EventHandler(this.提取较小资源ToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(145, 6);
            // 
            // 导出两倍尺寸ToolStripMenuItem
            // 
            this.导出两倍尺寸ToolStripMenuItem.Name = "导出两倍尺寸ToolStripMenuItem";
            this.导出两倍尺寸ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.导出两倍尺寸ToolStripMenuItem.Text = "导出两倍尺寸";
            this.导出两倍尺寸ToolStripMenuItem.Click += new System.EventHandler(this.导出两倍尺寸ToolStripMenuItem_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox.BackgroundImage = global::PngSplit.Properties.Resources.TransBg;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox.Image = global::PngSplit.Properties.Resources.PngSplit_help2;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(400, 400);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 82;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出所有子图ToolStripMenuItem,
            this.导出子图区域ToolStripMenuItem,
            this.导出精简数据ToolStripMenuItem,
            this.toolStripSeparator2,
            this.导出遮罩图像ToolStripMenuItem,
            this.导出图像ToolStripMenuItem,
            this.添加蒙板ToolStripMenuItem,
            this.toolStripSeparator1,
            this.左上尺寸裁剪ToolStripMenuItem,
            this.最适尺寸裁剪ToolStripMenuItem,
            this.toolStripSeparator3,
            this.导出10进制颜色值ToolStripMenuItem,
            this.导出16进制颜色值ToolStripMenuItem,
            this.toolStripSeparator6,
            this.尺寸缩放ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(175, 292);
            // 
            // 导出所有子图ToolStripMenuItem
            // 
            this.导出所有子图ToolStripMenuItem.Name = "导出所有子图ToolStripMenuItem";
            this.导出所有子图ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.导出所有子图ToolStripMenuItem.Text = "导出所有子图";
            this.导出所有子图ToolStripMenuItem.ToolTipText = "将当前png合图图像，按透明像素，\r\n自动分割为若个子图(TexturePacker逆处理)";
            this.导出所有子图ToolStripMenuItem.Click += new System.EventHandler(this.导出所有子图ToolStripMenuItem_Click);
            // 
            // 导出子图区域ToolStripMenuItem
            // 
            this.导出子图区域ToolStripMenuItem.Name = "导出子图区域ToolStripMenuItem";
            this.导出子图区域ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.导出子图区域ToolStripMenuItem.Text = "导出子图区域";
            this.导出子图区域ToolStripMenuItem.ToolTipText = "将当前png合图图像，按透明像素，自动分割为若个子图，\r\n导出各子区域的区域信息为文本";
            this.导出子图区域ToolStripMenuItem.Click += new System.EventHandler(this.导出子图区域ToolStripMenuItem_Click);
            // 
            // 导出精简数据ToolStripMenuItem
            // 
            this.导出精简数据ToolStripMenuItem.Name = "导出精简数据ToolStripMenuItem";
            this.导出精简数据ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.导出精简数据ToolStripMenuItem.Text = "导出精简数据";
            this.导出精简数据ToolStripMenuItem.ToolTipText = "将当前png合图图像，按透明像素，自动分割为若个子图，\r\n导出各子区域的区域精简信息为文本";
            this.导出精简数据ToolStripMenuItem.Click += new System.EventHandler(this.导出精简数据ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // 导出遮罩图像ToolStripMenuItem
            // 
            this.导出遮罩图像ToolStripMenuItem.Name = "导出遮罩图像ToolStripMenuItem";
            this.导出遮罩图像ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.导出遮罩图像ToolStripMenuItem.Text = "导出蒙板";
            this.导出遮罩图像ToolStripMenuItem.ToolTipText = "将当前包含透明度信息的图像，分解为两张jpeg蒙板图像";
            this.导出遮罩图像ToolStripMenuItem.Click += new System.EventHandler(this.导出蒙板图像ToolStripMenuItem_Click);
            // 
            // 导出图像ToolStripMenuItem
            // 
            this.导出图像ToolStripMenuItem.Name = "导出图像ToolStripMenuItem";
            this.导出图像ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.导出图像ToolStripMenuItem.Text = "导出图像";
            this.导出图像ToolStripMenuItem.ToolTipText = "为蒙板图像_1.jpeg添加蒙板_2.jpeg后，\r\n导出合成的png图像";
            this.导出图像ToolStripMenuItem.Click += new System.EventHandler(this.导出图像ToolStripMenuItem_Click);
            // 
            // 添加蒙板ToolStripMenuItem
            // 
            this.添加蒙板ToolStripMenuItem.CheckOnClick = true;
            this.添加蒙板ToolStripMenuItem.Name = "添加蒙板ToolStripMenuItem";
            this.添加蒙板ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.添加蒙板ToolStripMenuItem.Text = "添加蒙板";
            this.添加蒙板ToolStripMenuItem.ToolTipText = "拖入蒙板图像_1.jpeg -> 添加蒙板 -> 拖入蒙板图像_2.jpeg";
            this.添加蒙板ToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.添加蒙板ToolStripMenuItem_CheckStateChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // 左上尺寸裁剪ToolStripMenuItem
            // 
            this.左上尺寸裁剪ToolStripMenuItem.Name = "左上尺寸裁剪ToolStripMenuItem";
            this.左上尺寸裁剪ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.左上尺寸裁剪ToolStripMenuItem.Text = "左上尺寸裁剪";
            this.左上尺寸裁剪ToolStripMenuItem.ToolTipText = "从左上点开始，对当前图像进行裁切，\r\n裁切掉图像右下侧多余的透明像素区域";
            this.左上尺寸裁剪ToolStripMenuItem.Click += new System.EventHandler(this.左上尺寸裁剪ToolStripMenuItem_Click);
            // 
            // 最适尺寸裁剪ToolStripMenuItem
            // 
            this.最适尺寸裁剪ToolStripMenuItem.Name = "最适尺寸裁剪ToolStripMenuItem";
            this.最适尺寸裁剪ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.最适尺寸裁剪ToolStripMenuItem.Text = "最适尺寸裁剪";
            this.最适尺寸裁剪ToolStripMenuItem.ToolTipText = "对当前图像进行裁切，仅保留有效像素区域\r\n裁切掉图像四周多余的透明像素区域";
            this.最适尺寸裁剪ToolStripMenuItem.Click += new System.EventHandler(this.最适尺寸裁剪ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(171, 6);
            // 
            // 导出10进制颜色值ToolStripMenuItem
            // 
            this.导出10进制颜色值ToolStripMenuItem.Name = "导出10进制颜色值ToolStripMenuItem";
            this.导出10进制颜色值ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.导出10进制颜色值ToolStripMenuItem.Text = "导出10进制颜色值";
            this.导出10进制颜色值ToolStripMenuItem.ToolTipText = "导出当前图像的所有像素值，为10进制ARGB串";
            this.导出10进制颜色值ToolStripMenuItem.Click += new System.EventHandler(this.导出10进制颜色值ToolStripMenuItem_Click);
            // 
            // 导出16进制颜色值ToolStripMenuItem
            // 
            this.导出16进制颜色值ToolStripMenuItem.Name = "导出16进制颜色值ToolStripMenuItem";
            this.导出16进制颜色值ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.导出16进制颜色值ToolStripMenuItem.Text = "导出16进制颜色值";
            this.导出16进制颜色值ToolStripMenuItem.ToolTipText = "导出当前图像的所有像素值，为16进制ARGB串";
            this.导出16进制颜色值ToolStripMenuItem.Click += new System.EventHandler(this.导出16进制颜色值ToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(171, 6);
            // 
            // 尺寸缩放ToolStripMenuItem
            // 
            this.尺寸缩放ToolStripMenuItem.Name = "尺寸缩放ToolStripMenuItem";
            this.尺寸缩放ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.尺寸缩放ToolStripMenuItem.Text = "尺寸缩放";
            this.尺寸缩放ToolStripMenuItem.Click += new System.EventHandler(this.尺寸缩放ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 400);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导出遮罩图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加蒙板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 导出子图区域ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出精简数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出所有子图ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 全部导出蒙板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 左上尺寸裁剪ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最适尺寸裁剪ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 左上尺寸裁切ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最适尺寸裁切ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 导出10进制颜色值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出16进制颜色值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 合并蒙板图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 提取较小资源ToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem 导出两倍尺寸ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem 尺寸缩放ToolStripMenuItem;
    }
}

