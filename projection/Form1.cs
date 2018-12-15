using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projection
{
    public partial class Form1 : Form
    {
        //建立图层
        public Bitmap AxisMap;  //画坐标轴
        public Bitmap cuboid_map;   //画矩形

        //原点和X,Y坐标轴
        PointF center = new PointF(350,250);
        PointF x = new PointF(500, 250);
        PointF y = new PointF(350, 100);

        //原始的点数据,通过这四个点来生成三维矩形，
        //z轴长度为100
        PointF p1 = new PointF(25, 25);
        PointF p2 = new PointF(25, 50);
        PointF p3 = new PointF(50, 50);
        PointF p4 = new PointF(50, 25);

        //备份原始的点数据，以便还原
        PointF pp1 = new PointF(25, 25);
        PointF pp2 = new PointF(25, 50);
        PointF pp3 = new PointF(50, 50);
        PointF pp4 = new PointF(50, 25);

        //投影后的点，不能直接画在屏幕上，需要坐标转换
        PointF p11 = new PointF();
        PointF p12 = new PointF();
        PointF p21 = new PointF();
        PointF p22 = new PointF();
        PointF p31 = new PointF();
        PointF p32 = new PointF();
        PointF p41 = new PointF();
        PointF p42 = new PointF();

        //旋转角度
        double alpha;

        //获取视点或者方向
        int x_text, y_text, z_text;

        //绘制坐标轴，Z轴是根据投影生成的
        public void draw_axis()
        {
            //确定图层的大小
            AxisMap = new Bitmap(pictureBox.Width, pictureBox.Height);

            PointF z = new PointF();
            if (center_radioButton.Checked)
            {
                z = center_change(0, 0, 100, x_text, y_text, z_text);
            }
            else
            {
                z = parallel(0, 0, 100, x_text, y_text, z_text);
            }

            //坐标变换
            z.X = z.X + 350;
            z.Y = -z.Y + 250;
           
            //建立图层和画笔,用来绘制栅格
            pictureBox.Image= AxisMap;
            Graphics g = Graphics.FromImage(AxisMap);
            Pen mypen = new Pen(Color.FromArgb(255, 0, 0, 0));
            Brush mybrush = new SolidBrush(Color.FromArgb(255, 0, 0, 0));

            //箭头
            mypen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            g.DrawLine(mypen, center, x);
            g.DrawString("X", this.Font, mybrush, x);
            g.DrawLine(mypen, center, y);
            g.DrawString("Y", this.Font, mybrush, y);
            g.DrawLine(mypen, center, z);
            g.DrawString("Z", this.Font, mybrush, z);
        }

        //通过全局变量坐标转换后绘制长方体
        public void draw_cuboid()
        {
            //确定图层的大小
            cuboid_map = new Bitmap(pictureBox.Width, pictureBox.Height);

            //建立图层和画笔,用来绘制栅格
            pictureBox.BackgroundImage = cuboid_map;
            Graphics g = Graphics.FromImage(cuboid_map);
            Pen mypen = new Pen(Color.FromArgb(255, 0, 0, 0));

            //坐标变换
            PointF pp11 = new PointF(p11.X + 350,-p11.Y + 250);
            PointF pp12 = new PointF(p12.X + 350, -p12.Y + 250);
            PointF pp21 = new PointF(p21.X + 350, -p21.Y + 250);
            PointF pp22 = new PointF(p22.X + 350, -p22.Y + 250);
            PointF pp31 = new PointF(p31.X + 350, -p31.Y + 250);
            PointF pp32 = new PointF(p32.X + 350, -p32.Y + 250);
            PointF pp41 = new PointF(p41.X + 350, -p41.Y + 250);
            PointF pp42 = new PointF(p42.X + 350, -p42.Y + 250);

            //连线
             g.DrawLine(mypen, pp11, pp21);
             g.DrawLine(mypen, pp21, pp31);
             g.DrawLine(mypen, pp31, pp41);
             g.DrawLine(mypen, pp41, pp11);
             g.DrawLine(mypen, pp12, pp22);
             g.DrawLine(mypen, pp22, pp32);
             g.DrawLine(mypen, pp32, pp42);
             g.DrawLine(mypen, pp42, pp12);
             g.DrawLine(mypen, pp11, pp12);
             g.DrawLine(mypen, pp21, pp22);
             g.DrawLine(mypen, pp31, pp32);
             g.DrawLine(mypen, pp41, pp42);
        }

        //传入一个点的抽象三维坐标（相对于图中构建的坐标系）以及中心投影的参数，返回投影后的点（不能直接用于显示）
        public PointF center_change(float x,float  y,float  z,int  x_center,int  y_center,int  z_center)
        {
            PointF one = new PointF();
            one.X = (float)(x_center + (x - x_center) * z_center / (z_center - z));
            one.Y = (float)(y_center + (y - y_center) * z_center / (z_center - z));
            return one;
        }

        //传入一个点的抽象三维坐标（相对于图中构建的坐标系）以及平行投影的参数，返回投影后的点（不能直接用于显示）
        public PointF parallel(double  x, double y, double  z, int  x_d, int y_d, int z_d)
        {
            PointF one=new PointF();
            one.X = (float)(x - z * x_d / z_d);
            one.Y = (float)(y - z * y_d / z_d);
            return one;
        }

        public Form1()
        {
            InitializeComponent();

            //初始化状态
            center_radioButton.Checked = true;
            parallel_radioButton.Checked = false;
            x_textBox.Text = "200";
            y_textBox.Text = "200";
            z_textBox.Text = "200";
            alpha_textBox.Text="2";
            //为投影中心赋值
            x_text = int.Parse(x_textBox.Text);
            y_text = int.Parse(y_textBox.Text);
            z_text= int.Parse(z_textBox.Text);
            stop_button.Enabled = false;
            axis_checkBox.Checked = true;
            timer.Enabled = false;


            alpha = System.Convert.ToDouble(alpha_textBox.Text);

            //开始的时候先展示出中心投影的形状
            p11 = center_change(p1.X, p1.Y, 0, x_text, y_text, z_text);
            p12 = center_change(p1.X, p1.Y, 100, x_text, y_text, z_text);
            p21 = center_change(p2.X, p2.Y, 0, x_text, y_text, z_text);
            p22 = center_change(p2.X, p2.Y, 100, x_text, y_text, z_text);
            p31 = center_change(p3.X, p3.Y, 0, x_text, y_text, z_text);
            p32 = center_change(p3.X, p3.Y, 100, x_text, y_text, z_text);
            p41 = center_change(p4.X, p4.Y, 0, x_text, y_text, z_text);
            p42 = center_change(p4.X, p4.Y, 100, x_text, y_text, z_text);
           
            draw_axis();       //绘制坐标轴
            draw_cuboid();     //绘制矩形
        }

        //计时器，自动旋转时启用
        private void timer_tick(object sender, EventArgs e)
        {

            timer.Interval = 10;//每十毫秒旋转一次
            rotation();
        }

        //对原始四个点进行旋转之后生成其它点，清空长方体图层，绘图
        public void rotation()
        {
            //获取投影参数
            x_text = int.Parse(x_textBox.Text);
            y_text = int.Parse(y_textBox.Text);
            z_text = int.Parse(z_textBox.Text);

            //获取旋转参数
            alpha = System.Convert.ToDouble(alpha_textBox.Text);

            //只需要对原始的四个点进行旋转即可
            p1 = rotation_z(p1, alpha);
            p2 = rotation_z(p2, alpha);
            p3 = rotation_z(p3, alpha);
            p4 = rotation_z(p4, alpha);

            //判断投影类型，生成其它点
            if(center_radioButton.Checked)
            {
                p11 = center_change(p1.X, p1.Y, 0, x_text, y_text, z_text);
                p12 = center_change(p1.X, p1.Y, 100, x_text, y_text, z_text);
                p21 = center_change(p2.X, p2.Y, 0, x_text, y_text, z_text);
                p22 = center_change(p2.X, p2.Y, 100, x_text, y_text, z_text);
                p31 = center_change(p3.X, p3.Y, 0, x_text, y_text, z_text);
                p32 = center_change(p3.X, p3.Y, 100, x_text, y_text, z_text);
                p41 = center_change(p4.X, p4.Y, 0, x_text, y_text, z_text);
                p42 = center_change(p4.X, p4.Y, 100, x_text, y_text, z_text);
            }
            else
            {
                p11 = parallel(p1.X, p1.Y, 0, x_text, y_text, z_text);
                p12 = parallel(p1.X, p1.Y, 100, x_text, y_text, z_text);
                p21 = parallel(p2.X, p2.Y, 0, x_text, y_text, z_text);
                p22 = parallel(p2.X, p2.Y, 100, x_text, y_text, z_text);
                p31 = parallel(p3.X, p3.Y, 0, x_text, y_text, z_text);
                p32 = parallel(p3.X, p3.Y, 100, x_text, y_text, z_text);
                p41 = parallel(p4.X, p4.Y, 0, x_text, y_text, z_text);
                p42 = parallel(p4.X, p4.Y, 100, x_text, y_text, z_text);
            }
            if (axis_checkBox.Checked)
            {
                draw_axis();
            }
           
            //绘制长方体
            draw_cuboid();
        }

        //只旋转一个点,z轴
        public PointF rotation_z(PointF p, double alpha)
        {
            PointF tem = new PointF();
            tem = p;
            p.X = (float)(tem.X * Math.Cos(alpha / 360) - tem.Y * Math.Sin(alpha / 360));
            p.Y = (float)(tem.X * Math.Sin(alpha / 360) + tem.Y * Math.Cos(alpha / 360));
            return p;
        }

        //停止计时器
        private void stop_button_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        //初始化，清空画布后回到FORM的原始状态
        private void original_button_Click(object sender, EventArgs e)
        {

            //恢复原始值
            p1 = pp1;
            p2 = pp2;
            p3 = pp3;
            p4 = pp4;

            //初始化状态
            center_radioButton.Checked = true;
            parallel_radioButton.Checked = false;
            x_textBox.Text = "200";
            y_textBox.Text = "200";
            z_textBox.Text = "200";
            alpha_textBox.Text = "2";

            //为投影中心赋值
            x_text = int.Parse(x_textBox.Text);
            y_text = int.Parse(y_textBox.Text);
            z_text = int.Parse(z_textBox.Text);
            stop_button.Enabled = false;
            axis_checkBox.Checked = true;

            alpha = System.Convert.ToDouble(alpha_textBox.Text);

            //开始的时候先展示出中心投影的形状
            p11 = center_change(p1.X, p1.Y, 0, x_text, y_text, z_text);
            p12 = center_change(p1.X, p1.Y, 100, x_text, y_text, z_text);
            p21 = center_change(p2.X, p2.Y, 0, x_text, y_text, z_text);
            p22 = center_change(p2.X, p2.Y, 100, x_text, y_text, z_text);
            p31 = center_change(p3.X, p3.Y, 0, x_text, y_text, z_text);
            p32 = center_change(p3.X, p3.Y, 100, x_text, y_text, z_text);
            p41 = center_change(p4.X, p4.Y, 0, x_text, y_text, z_text);
            p42 = center_change(p4.X, p4.Y, 100, x_text, y_text, z_text);

          
            draw_axis();       //绘制坐标轴
            draw_cuboid();     //绘制矩形
            timer.Enabled = false;

        }

        //绘制投影图形
        private void projection_button_Click(object sender, EventArgs e)
        {
            //获取投影参数
            x_text = int.Parse(x_textBox.Text);
            y_text = int.Parse(y_textBox.Text);
            z_text = int.Parse(z_textBox.Text);

            //绘制坐标轴
            draw_axis();

            //判断投影类型，生成其它点
            if (center_radioButton.Checked)
            {
                //透视投影
                p11 = center_change(p1.X, p1.Y, 0, x_text, y_text, z_text);
                p12 = center_change(p1.X, p1.Y, 100, x_text, y_text, z_text);
                p21 = center_change(p2.X, p2.Y, 0, x_text, y_text, z_text);
                p22 = center_change(p2.X, p2.Y, 100, x_text, y_text, z_text);
                p31 = center_change(p3.X, p3.Y, 0, x_text, y_text, z_text);
                p32 = center_change(p3.X, p3.Y, 100, x_text, y_text, z_text);
                p41 = center_change(p4.X, p4.Y, 0, x_text, y_text, z_text);
                p42 = center_change(p4.X, p4.Y, 100, x_text, y_text, z_text);
            }
            else
            {
                //平行投影
                p11 = parallel(p1.X, p1.Y, 0, x_text, y_text, z_text);
                p12 = parallel(p1.X, p1.Y, 100, x_text, y_text, z_text);
                p21 = parallel(p2.X, p2.Y, 0, x_text, y_text, z_text);
                p22 = parallel(p2.X, p2.Y, 100, x_text, y_text, z_text);
                p31 = parallel(p3.X, p3.Y, 0, x_text, y_text, z_text);
                p32 = parallel(p3.X, p3.Y, 100, x_text, y_text, z_text);
                p41 = parallel(p4.X, p4.Y, 0, x_text, y_text, z_text);
                p42 = parallel(p4.X, p4.Y, 100, x_text, y_text, z_text);
            }
            //绘制长方体
            draw_cuboid();
        }

        private void axis_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (axis_checkBox.Checked)  //显示坐标轴
            {
                //绘制坐标轴
                draw_axis();
            }
            else                       //不显示坐标轴
            {
                //确定图层的大小
                AxisMap = new Bitmap(pictureBox.Width, pictureBox.Height);
                pictureBox.Image = AxisMap;
            }
        }

        //关闭窗口
        private void quit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //开始旋转
        private void auto_button_Click(object sender, EventArgs e)
        {
            //开始旋转
            timer.Enabled = true;
            stop_button.Enabled = true;
        }

    }
}
