using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 开机动画
{
    public partial class OpenAnimation : Form
    {
        public OpenAnimation()
        {
            InitializeComponent();
        }
        Bitmap bit;                          //绘制图像
        private void OpenAnimation_Load(object sender, EventArgs e)
        {
            bit = new Bitmap("Girl.png");
            bit.MakeTransparent(Color.Blue);
            this.FormBorderStyle = FormBorderStyle.None;
            this.timer1.Start();
            this.timer1.Interval = 5000;   //窗体存在时间5s
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage((Image)bit, new Point(0, 0));//在窗体上绘制图片
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
            // LoginPanel login = new LoginPanel();
            //login.Show();
            this.timer1.Stop();
        }
    }
}
