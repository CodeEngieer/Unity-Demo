
namespace 爬虫工具
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Website = new System.Windows.Forms.TextBox();
            this.textBox_SavePath = new System.Windows.Forms.TextBox();
            this.button_OpenFile = new System.Windows.Forms.Button();
            this.listBox_ShowMessage = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(31, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "请选择保存的文件夹：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(31, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "请输入爬取图片的网址：";
            // 
            // textBox_Website
            // 
            this.textBox_Website.Location = new System.Drawing.Point(210, 132);
            this.textBox_Website.Name = "textBox_Website";
            this.textBox_Website.Size = new System.Drawing.Size(389, 25);
            this.textBox_Website.TabIndex = 4;
            this.textBox_Website.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Website_KeyPress);
            // 
            // textBox_SavePath
            // 
            this.textBox_SavePath.Location = new System.Drawing.Point(210, 88);
            this.textBox_SavePath.Name = "textBox_SavePath";
            this.textBox_SavePath.Size = new System.Drawing.Size(388, 25);
            this.textBox_SavePath.TabIndex = 5;
            // 
            // button_OpenFile
            // 
            this.button_OpenFile.Location = new System.Drawing.Point(621, 88);
            this.button_OpenFile.Name = "button_OpenFile";
            this.button_OpenFile.Size = new System.Drawing.Size(48, 25);
            this.button_OpenFile.TabIndex = 6;
            this.button_OpenFile.Text = "...";
            this.button_OpenFile.UseVisualStyleBackColor = true;
            this.button_OpenFile.Click += new System.EventHandler(this.button_OpenFile_Click);
            // 
            // listBox_ShowMessage
            // 
            this.listBox_ShowMessage.FormattingEnabled = true;
            this.listBox_ShowMessage.ItemHeight = 15;
            this.listBox_ShowMessage.Location = new System.Drawing.Point(34, 172);
            this.listBox_ShowMessage.Name = "listBox_ShowMessage";
            this.listBox_ShowMessage.Size = new System.Drawing.Size(662, 394);
            this.listBox_ShowMessage.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(621, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 8;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 578);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox_ShowMessage);
            this.Controls.Add(this.button_OpenFile);
            this.Controls.Add(this.textBox_SavePath);
            this.Controls.Add(this.textBox_Website);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "爬虫工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Website;
        private System.Windows.Forms.TextBox textBox_SavePath;
        private System.Windows.Forms.Button button_OpenFile;
        private System.Windows.Forms.ListBox listBox_ShowMessage;
        private System.Windows.Forms.Button button1;
    }
}

