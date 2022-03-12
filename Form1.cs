using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


//по списку
//вариант 3

namespace LINII
{
    public partial class Form1 : Form
    {

        private static void PutPixel(Graphics g, Color col, int x, int y, int alpha)
        {
            g.FillRectangle(new SolidBrush(Color.FromArgb(alpha, col)), x, y, 3, 3);
        }

        public double xn;
        public double yn;
        public double xk = 0;
        public double yk = 0;

        public int sizeLine = 2;

        private string GetColor(int s1)
        {
            switch (s1)
            {
                case 1:
                {
                    return "Black";
                    //break;
                }
                case 2:
                    {
                        return "Red";
                        //break;
                    }
                case 3:
                    {
                        return "Blue";
                        //break;
                    }
                case 4:
                    {
                        return "Green";
                        //break;
                    }
                case 5:
                    {
                        return "Yellow";
                        //break;
                    }
                case 6:
                    {
                        return "Purple";
                        //break;
                    }
                default:
                    {
                        return "Purple";
                        //break; 
                    }
            }

        }


        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //это координаты пикселя, в который
                //попал курсор при нажатии
                xn = e.X;
                yn = e.Y;
            }

            else MessageBox.Show("Вы не выбрали алгоритм вывода фигуры!");
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            int n;
            double xt, yt, dx, dy;
            xk = e.X;
            yk = e.Y;

            //Приращение координат
            dx = xk - xn;
            dy = yk - yn;
            n = int.Parse(textBox6.Text);  //пунктир  

            //Занести начальную точку отрезка и нарисовать
            xt = xn;
            yt = yn;

            for (int i = 0; i < n; i++)
            {
                //Объявляем объект "g" класса Graphics и предоставляем
                //ему возможность рисования на pictureBox1
                Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

                //Рисуем закрашенный прямоугольник:
                //Объявляем объект "brush", задающий цвет кисти
                int s1 = int.Parse(textBox5.Text);
                Color c = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(GetColor(s1));
                SolidBrush brush = new SolidBrush(c);
                //Рисуем закрашенный прямоугольник
                g.FillRectangle(brush, (int)xt, (int)yt, sizeLine, sizeLine);
                xt = xt + dx / n;
                yt = yt + dy / n;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox5.Text = "1";
            textBox6.Text = "100";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            sizeLine = 5;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sizeLine = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {     
            int s1 = int.Parse(textBox5.Text);
            Color c = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(GetColor(s1));
            Pen myPen = new Pen(c, sizeLine);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            //Рисуем прямоугольник:
            g.DrawRectangle(myPen, 10, 20, 100, 200);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int s1 = int.Parse(textBox5.Text);
            Color c = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(GetColor(s1));
            Pen myPen = new Pen(c, sizeLine);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            //Рисуем прямоугольник:
            g.DrawRectangle(myPen, 10, 20, 100, 100);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int s1 = int.Parse(textBox5.Text);
            Color c = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(GetColor(s1));
            Pen myPen = new Pen(c, sizeLine);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            //первая линия, (x,y) для второй точки первой линии
            g.DrawLine(myPen, 300, 100, 100, 600);
            //вторая линия, (x,y) для второй точки второй линии
            g.DrawLine(myPen, 300, 100, 300, 600);
            //третья линия, (x,y) для второй точки третьей линии
            g.DrawLine(myPen, 100, 600, 300, 600);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int s1 = int.Parse(textBox5.Text);
            Color c = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(GetColor(s1));
            Pen myPen = new Pen(c, sizeLine);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            //левая вертикальная линия
            g.DrawLine(myPen, 100, 100, 200, 100);
            //первая диагональная линия
            g.DrawLine(myPen, 200, 100, 100, 500);
            //нижняя горизонтальная линия
            g.DrawLine(myPen, 100, 500, 270, 450);
            //правая наклонная линия
            g.DrawLine(myPen, 270, 450, 100, 100);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int s1 = int.Parse(textBox5.Text);
            Color c = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(GetColor(s1));
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen myPen = new Pen(c, sizeLine);

            BresenhamCircle(g, myPen, c, 100, 100, 50);
        }

        public static void BresenhamCircle(Graphics g, Pen myPen, Color clr, int _x, int _y, int radius)
        {
            int x = 0;
            int y = radius;
            int gap = 0;
            int delta = (2 - 2 * radius);

            while (y >= 0)
            {
                PutPixel(g, clr, _x + x, _y + y, 255);
                PutPixel(g, clr, _x + x, _y - y, 255);
                PutPixel(g, clr, _x - x, _y - y, 255);
                PutPixel(g, clr, _x - x, _y + y, 255);
                gap = 2 * (delta + y) - 1;
                if (delta < 0 && gap <= 0)
                {
                    x++;
                    delta += 2 * x + 1;
                    continue;
                }
                if (delta > 0 && gap > 0)
                {
                    y--;
                    delta -= 2 * y + 1;
                    continue;
                }
                x++;
                delta += 2 * (x - y);
                y--;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double xt = int.Parse(textBox1.Text);
            double yt = int.Parse(textBox2.Text);
            double dx = int.Parse(textBox3.Text);
            double dy = int.Parse(textBox4.Text);

            int s1 = int.Parse(textBox5.Text);
            Color c = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(GetColor(s1));
            Pen myPen = new Pen(c, sizeLine);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            //Рисуем отрезок:
            g.DrawLine(myPen, (int)xt, (int)yt, (int)dx, (int)dy);
        }
    }
}