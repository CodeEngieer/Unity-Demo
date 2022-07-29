using System;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace 爬虫工具
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_OpenFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveUrl = new FolderBrowserDialog();
            saveUrl.RootFolder = Environment.SpecialFolder.Desktop;
            saveUrl.Description = "";
            var result = saveUrl.ShowDialog();
            if (result == DialogResult.OK)
            {
                string savePath = saveUrl.SelectedPath;
                textBox_SavePath.Text = savePath;
            }
        }
        /*
         * 方法名称：HttpGetHandle（获取网络请求）
         * 方法功能：爬取指定网站
         * @param：string：url：指定网址
         * @param：string：path：保存地址
         * @param：int：name：图片递归名字
         */
        public void HttpGetHandle(string url, string path, int name)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            HttpWebRequest webRequest = WebRequest.CreateHttp(url);
            webRequest.Method = "GET";
            webRequest.UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:75.0) Gecko/20100101 Firefox/75.0";
            var webResponse = webRequest.GetResponse();
            StreamReader streamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
            string str = streamReader.ReadToEnd();
            streamReader.Close();
            if (string.IsNullOrEmpty(str))
            {
                listBox_ShowMessage.Items.Add("=====================错误====================");

            }
            //正则表达式配对网站图片
            Regex regex = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<Group>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>");
            MatchCollection match = regex.Matches(str);
            WebClient client = new WebClient();
            int temp = 0;
            try
            {
                foreach (Match match1 in match)
                {
                    string src = match1.Groups[1].Value;
                    if (src.Contains("http") && !src.Contains(".svg"))
                    {
                        temp++;
                        client.DownloadFile(src, path + name + ".jpg");
                        name++;
                        listBox_ShowMessage.Items.Add("\n正在爬取=================" + "|" + temp);
                    }
                }
            }
            catch (Exception ex)
            {
                listBox_ShowMessage.Items.Add("===============" + ex.ToString());
            }
            stopwatch.Stop();
            listBox_ShowMessage.Items.Add("===================爬取成功====================");
            listBox_ShowMessage.Items.Add("\n_______总共爬取了" + temp + "张图片!_______________");
            listBox_ShowMessage.Items.Add("\n一共耗时" + stopwatch.ElapsedMilliseconds / 1000 + "秒");
        }
        private void CreateFile()
        {
            if (Directory.Exists(@"D:\Picture\"))
            {
                listBox_ShowMessage.Items.Add("开始爬取指定网站图片！");
            }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(@"D:\Picture\");
                directoryInfo.Create();
            }
        }
        private void textBox_Website_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (textBox_Website != null)
                {
                    CreateFile();
                    string savePath = textBox_SavePath.Text;
                    string completePath = savePath + "//";
                    string url = textBox_Website.Text;
                    HttpGetHandle(url, completePath, 1);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string savePath = textBox_SavePath.Text;
            string completePath = savePath + "//";
            string url = textBox_Website.Text;
            HttpGetHandle(url, completePath, 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox_Website.Text = "https://codeengieer.github.io/BufferPrivateBlog.github.io/page/2/";
        }
    }
}
