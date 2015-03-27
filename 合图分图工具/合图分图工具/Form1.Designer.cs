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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.导出遮罩图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加蒙板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.导出子图区域ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出精简数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出所有子图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox = new System.Windows.Forms.ListBox();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.AllowDrop = true;
            this.panel.Controls.Add(this.pictureBox);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(400, 400);
            this.panel.TabIndex = 85;
            this.panel.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel_DragDrop);
            this.panel.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_DragEnter);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox.Image = global::PngSplit.Properties.Resources.PngSplit_help2;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(400, 400);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 82;
            this.pictureBox.TabStop = false;
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
            this.添加蒙板ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 142);
            // 
            // 导出遮罩图像ToolStripMenuItem
            // 
            this.导出遮罩图像ToolStripMenuItem.Name = "导出遮罩图像ToolStripMenuItem";
            this.导出遮罩图像ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.导出遮罩图像ToolStripMenuItem.Text = "导出蒙板";
            this.导出遮罩图像ToolStripMenuItem.Click += new System.EventHandler(this.导出蒙板图像ToolStripMenuItem_Click);
            // 
            // 导出图像ToolStripMenuItem
            // 
            this.导出图像ToolStripMenuItem.Name = "导出图像ToolStripMenuItem";
            this.导出图像ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.导出图像ToolStripMenuItem.Text = "导出图像";
            this.导出图像ToolStripMenuItem.Click += new System.EventHandler(this.导出图像ToolStripMenuItem_Click);
            // 
            // 添加蒙板ToolStripMenuItem
            // 
            this.添加蒙板ToolStripMenuItem.CheckOnClick = true;
            this.添加蒙板ToolStripMenuItem.Name = "添加蒙板ToolStripMenuItem";
            this.添加蒙板ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加蒙板ToolStripMenuItem.Text = "添加蒙板";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // 导出子图区域ToolStripMenuItem
            // 
            this.导出子图区域ToolStripMenuItem.Name = "导出子图区域ToolStripMenuItem";
            this.导出子图区域ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.导出子图区域ToolStripMenuItem.Text = "导出子图区域";
            this.导出子图区域ToolStripMenuItem.Click += new System.EventHandler(this.导出子图区域ToolStripMenuItem_Click);
            // 
            // 导出精简数据ToolStripMenuItem
            // 
            this.导出精简数据ToolStripMenuItem.Name = "导出精简数据ToolStripMenuItem";
            this.导出精简数据ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.导出精简数据ToolStripMenuItem.Text = "导出精简数据";
            this.导出精简数据ToolStripMenuItem.Click += new System.EventHandler(this.导出精简数据ToolStripMenuItem_Click);
            // 
            // 导出所有子图ToolStripMenuItem
            // 
            this.导出所有子图ToolStripMenuItem.Name = "导出所有子图ToolStripMenuItem";
            this.导出所有子图ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.导出所有子图ToolStripMenuItem.Text = "导出所有子图";
            this.导出所有子图ToolStripMenuItem.Click += new System.EventHandler(this.导出所有子图ToolStripMenuItem_Click);
            // 
            // listBox
            // 
            this.listBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 12;
            this.listBox.Location = new System.Drawing.Point(400, 0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(120, 400);
            this.listBox.TabIndex = 86;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 400);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导出遮罩图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加蒙板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 导出子图区域ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出精简数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出所有子图ToolStripMenuItem;
    }
}

