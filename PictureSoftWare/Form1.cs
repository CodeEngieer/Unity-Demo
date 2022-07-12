using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime;

namespace PopuForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region 自定义控件删除ListView加载的闪烁现象，影响浏览效果
        public class CustomListView : ListView
        {
            public CustomListView()
            {
                SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
                UpdateStyles();
            }
        }
        CustomListView clv = new CustomListView();
        #endregion
        #region 变量声明
        string filePath;                 //文件路径
        public Image ResourceImage;      //图片地址
        private int ImageWidth;          //图片宽度
        private int ImageHeight;         //图片高度
        private string ErrorMessage;     //弹出错误信息
        public Thread td;                //加载线程
        #endregion
        public bool ThumnaiCallBack()
        {
            return false;
        }
        /*作用：该方法将图片按照比例大小缩放保存到本地
         * @param：Percent：图片比例大小
         * @param：targetFilePath：目标图片路径
         */
        public bool GetReducedImage(double Percent, string targetFilePath)
        {
            try
            {
                Bitmap bt = new Bitmap(120, 120);
                Graphics g = Graphics.FromImage(bt);
                g.Clear(Color.White);

                //图片缩略图
                Image ReducedImage;
                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumnaiCallBack);
                //获取缩略图长框比例
                ImageWidth = Convert.ToInt32(ResourceImage.Width * Percent);
                ImageHeight = Convert.ToInt32(ResourceImage.Height * Percent);
                ReducedImage = ResourceImage.GetThumbnailImage(ImageWidth, ImageHeight, callb, IntPtr.Zero);
                if (ImageWidth > ImageHeight)
                {
                    g.DrawImage(ReducedImage, 0, (int)(120 - ImageHeight) / 2, ImageWidth, ImageHeight);
                }
                else
                {
                    g.DrawImage(ReducedImage, (int)(120 - ImageWidth) / 2, 0, ImageWidth, ImageHeight);
                }
                g.DrawRectangle(new Pen(Color.Red), 0, 0, 119, 119);
                bt.Save(targetFilePath, ImageFormat.Jpeg);
                bt.Dispose();
                ReducedImage.Dispose();
                return true;
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return false;
            }
        }
        //强制删除
         private void deleteFile()
         {
             try
             {
                 DirectoryInfo directoryInfo2 = new DirectoryInfo("c:\\tempPicture");
                 if (directoryInfo2.Exists)
                 {
                    Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
                    fso.DeleteFolder("c:\\tempPicture", true);
                 }
             }
             catch
             {
                 deleteFile();
             }
         }

        #region 生成的缩略图添加到列表中（完成）
        private void Add()
        {
            double percent;
            string[] a = new string[2];
            DirectoryInfo directoryInfo = new DirectoryInfo(filePath);
            FileSystemInfo[] fsi = directoryInfo.GetFileSystemInfos();
            DirectoryInfo directoryInfo1 = new DirectoryInfo("c:\\tempPicture");
            for (int i = 0; i < fsi.Length; i++)
            {
                string imgType = fsi[i].ToString().Substring(fsi[i].ToString().LastIndexOf(".") + 1, fsi[i].ToString().Length - 1 - fsi[i].ToString().LastIndexOf("."));
                if (imgType.ToLower() == "jpeg" || imgType.ToLower() == "gif" || imgType.ToLower() == "png" || imgType.ToLower() == "jpg" || imgType.ToLower() == "bmp")
                {
                    string imgName = fsi[i].ToString();
                    imgName = imgName.Remove(imgName.LastIndexOf("."));
                    string newPath;
                    if (filePath.Length == 3)
                    {
                        newPath = filePath + imgName + "." + imgType;
                    }
                    else
                    {
                        newPath = filePath + "\\" + imgName + "." + imgType;
                    }
                    ResourceImage = Image.FromFile(newPath);
                    if (ResourceImage.Width < ResourceImage.Height)
                    {
                        percent = (double)120 / ResourceImage.Height;
                    }
                    else
                    {
                        percent = (double)120 / ResourceImage.Width;
                    }
                    if (!directoryInfo1.Exists)
                    {
                        Directory.CreateDirectory("c:\\tempPicture");
                        if (GetReducedImage(percent, "c:\\tempPicture\\_" + imgName + ".JPG"))
                        {
                            imageList1.Images.Add(i.ToString(), Image.FromFile("c:\\tempPicture\\_" + imgName + ".JPG"));
                            a[0] = imgName + "." + imgType;
                            ListViewItem lvi = new ListViewItem(a);
                            lvi.ImageKey = i.ToString();
                            clv.Items.Add(lvi);
                        }
                    }
                    else
                    {
                        if (GetReducedImage(percent, "c:\\tempPicture\\_" + imgName + ".JPG"))
                        {
                            imageList1.Images.Add(i.ToString(), Image.FromFile("c:\\tempPicture\\_" + imgName + ".JPG"));
                            a[0] = imgName + "." + imgType;
                            ListViewItem lvi = new ListViewItem(a);
                            lvi.ImageKey = i.ToString();
                            clv.Items.Add(lvi);
                        }
                    }
                    ResourceImage.Dispose();
                }
                tsslText.Text = "总共有" + this.clv.Items.Count.ToString() + "张图片";

            }
            td.Abort();
        }
        #endregion

        #region 事件处理
        // 工具栏事件（完成）
        private void Open_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                clv.Items.Clear();
                filePath = folderBrowserDialog1.SelectedPath;
                td = new Thread(new ThreadStart(Add));
                td.Start();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        //自定义监听：（完成）
        private void CustomClick_Click(object sender, EventArgs e)
        {
            if (clv.SelectedItems.Count > 0)
            {
                string pictureName = clv.SelectedItems[0].Text;
                if (filePath.Length == 3)
                {
                    tsslPath.Text = "图片路径" + filePath + pictureName;
                }
                else
                {
                    tsslPath.Text = "图片路径" + filePath + "\\" + pictureName;
                }
            }
        }
        private void CustomClick_DoubleClick(object sender, EventArgs e)
        {
            if (clv.SelectedItems.Count > 0)
            {
                string pictureName = clv.SelectedItems[0].Text;
                //图片在根目录
                if (filePath.Length == 3)
                {
                    System.Diagnostics.Process.Start(filePath + pictureName);
                    tsslPath.Text = "图片路径：" + filePath + pictureName;
                }
                //盘符下路径
                else
                {
                    System.Diagnostics.Process.Start(filePath + "\\" + pictureName);
                    tsslPath.Text = "图片路径：" + filePath + "\\" + pictureName;
                }
            }
        }


        //Form窗体监听事件
        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            CheckForIllegalCrossThreadCalls = false;  //检查非法的跨线程调用
            panel1.Controls.Add(clv);
            clv.Dock = DockStyle.Fill;
            clv.LargeImageList = imageList1;
            clv.View = View.LargeIcon;
            clv.Click += new EventHandler(CustomClick_Click);
            clv.DoubleClick += new EventHandler(CustomClick_DoubleClick);

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (td != null)
            {
                td.Abort();
            }
            deleteFile();
        }
        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2022年7月7日18:13:46，鹰仓杏铃著，代码仅供参考与学习。未经允许不得转载贩卖","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
