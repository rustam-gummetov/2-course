using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        static public Queue<int[]> numbers = new Queue<int[]>();  //создание очереди, элементы которой - массивы (индексы точек)
        static public int m = 3, n = 3; //размеры поля
        static public int[,] field;
        static public int[,] way;   //массив индексов пути
        static public int[] current; //текущие координаты
        static public int C;         //количество ходов
        Label labelM = new Label();
        Label labelN = new Label();
        Label route = new Label();
        Label result = new Label();
        Label motion = new Label();  //для надписи ход
        Label counter = new Label(); //номер хода
        Graphics g;
        Pen line = new Pen(Color.Black, 1);
        SolidBrush rec = new SolidBrush(Color.Lime);
        SolidBrush white = new SolidBrush(Color.Gainsboro);
        static public int Second = 0; //для таймера

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelM.Location = new Point(110, 150);
            labelM.Size = new Size(35, 35);
            Controls.Add(labelM);
            labelM.Font = new Font(labelM.Font.Name, 14, labelM.Font.Style);
            labelM.Text = "" + m;
            labelN.Location = new Point(110, 304);
            labelN.Size = new Size(35, 35);
            Controls.Add(labelN);
            labelN.Font = new Font(labelN.Font.Name, 14, labelN.Font.Style);
            labelN.Text = "" + n;
            button6.Visible = false;
            button7.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m > 3)
            {
                m--;
                labelM.Text = "" + m;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (m < 10)
            {
                m++;
                labelM.Text = "" + m;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (n > 3)
            {
                n--;
                labelN.Text = "" + n;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (n < 10)
            {
                n++;
                labelN.Text = "" + n;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            field = new int[m, n];               //создаем поле
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    field[i, j] = 0;                    //заполняем поле нулями
                }
            }
            field[0, 0] = -1;                           //стартовая точка = -1       
            int[] mas = new int[] { 0, 0 };             //массив в индексами стартовой точки
            numbers.Enqueue(mas);                       //добавление стартовой точки в очередь
            while (field[m - 1, n - 1] == 0)
            {
                int[] point = numbers.Dequeue();       //извлекли из очереди точку
                if (point[0] == 0 && point[1] == 0)
                    testP(point[0], point[1], 1);
                else
                    testP(point[0], point[1], field[point[0], point[1]] + 1);
            }
            int count = field[m - 1, n - 1];  //кол-во ходов сделано
            C = count;           
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (field[i, j] == 0)
                        field[i, j] = -1;
                }
            }
            field[0, 0] = 0;
            way = new int[2, count + 1];
            way[0, count] = m - 1;
            way[1, count] = n - 1;
            current = new int[2];
            current[0] = m - 1;
            current[1] = n - 1;
            while (count != 0)
            {
                find_only_way(current[0], current[1], count - 1);
                count--;
            }
            button6.Visible = true;
        }

        static public void testP(int i, int j, int count) //проверка стен,
        {                                                  //доступных ходов и заполнение поля
            if ((i - 2) >= 0)  //на 2 вверх
            {
                if ((j - 1) >= 0)   //на 1 влево
                {
                    if (field[i - 2, j - 1] == 0)
                    {
                        field[i - 2, j - 1] = count;
                        int[] mas = new int[] { i - 2, j - 1 };
                        numbers.Enqueue(mas);
                    }
                }
                if ((j + 1) < n)   //на 1 вправо
                {
                    if (field[i - 2, j + 1] == 0)
                    {
                        field[i - 2, j + 1] = count;
                        int[] mas = new int[] { i - 2, j + 1 };
                        numbers.Enqueue(mas);
                    }
                }
            }
            if ((i + 2) < m)    //на 2 вниз
            {
                if ((j - 1) >= 0)    //на 1 влево
                {
                    if (field[i + 2, j - 1] == 0)
                    {
                        field[i + 2, j - 1] = count;
                        int[] mas = new int[] { i + 2, j - 1 };
                        numbers.Enqueue(mas);
                    }
                }
                if ((j + 1) < n)   //на 1 вправо
                {
                    if (field[i + 2, j + 1] == 0)
                    {
                        field[i + 2, j + 1] = count;
                        int[] mas = new int[] { i + 2, j + 1 };
                        numbers.Enqueue(mas);
                    }
                }
            }
            if ((j - 2) >= 0)  //на 2 влево
            {
                if ((i - 1) >= 0)     //на 1 вверх
                {
                    if (field[i - 1, j - 2] == 0)
                    {
                        field[i - 1, j - 2] = count;
                        int[] mas = new int[] { i - 1, j - 2 };
                        numbers.Enqueue(mas);
                    }
                }
                if ((i + 1) < m)   //на 1 вниз
                {
                    if (field[i + 1, j - 2] == 0)
                    {
                        field[i + 1, j - 2] = count;
                        int[] mas = new int[] { i + 1, j - 2 };
                        numbers.Enqueue(mas);
                    }
                }
            }
            if ((j + 2) < n)    //на 2 вправо
            {
                if ((i - 1) >= 0)    //на 1 вверх
                {
                    if (field[i - 1, j + 2] == 0)
                    {
                        field[i - 1, j + 2] = count;
                        int[] mas = new int[] { i - 1, j + 2 };
                        numbers.Enqueue(mas);
                    }
                }
                if ((i + 1) < m)    //на 1 вниз
                {
                    if (field[i + 1, j + 2] == 0)
                    {
                        field[i + 1, j + 2] = count;
                        int[] mas = new int[] { i + 1, j + 2 };
                        numbers.Enqueue(mas);
                    }
                }
            }
        }

        static public void find_only_way(int i, int j, int search)          //ищем обратный путь
        {
            bool f = false;
            while (f == false)
            {
                if ((i - 2) >= 0)  //на 2 вверх
                {
                    if ((j - 1) >= 0)   //на 1 влево
                    {
                        if (field[i - 2, j - 1] == search)
                        {
                            current[0] = i - 2;
                            current[1] = j - 1;
                            way[0, search] = i - 2;
                            way[1, search] = j - 1;
                            f = true;
                            break;
                        }
                    }
                    if ((j + 1) < n)   //на 1 вправо
                    {
                        if (field[i - 2, j + 1] == search)
                        {
                            current[0] = i - 2;
                            current[1] = j + 1;
                            way[0, search] = i - 2;
                            way[1, search] = j + 1;
                            f = true;
                            break;
                        }
                    }
                }
                if ((i + 2) < m)    //на 2 вниз
                {
                    if ((j - 1) >= 0)    //на 1 влево
                    {
                        if (field[i + 2, j - 1] == search)
                        {
                            current[0] = i + 2;
                            current[1] = j - 1;
                            way[0, search] = i + 2;
                            way[1, search] = j - 1;
                            f = true;
                            break;
                        }
                    }
                    if ((j + 1) < n)   //на 1 вправо
                    {
                        if (field[i + 2, j + 1] == search)
                        {
                            current[0] = i + 2;
                            current[1] = j + 1;
                            way[0, search] = i + 2;
                            way[1, search] = j + 1;
                            f = true;
                            break;
                        }
                    }
                }
                if ((j - 2) >= 0)  //на 2 влево
                {
                    if ((i - 1) >= 0)     //на 1 вверх
                    {
                        if (field[i - 1, j - 2] == search)
                        {
                            current[0] = i - 1;
                            current[1] = j - 2;
                            way[0, search] = i - 1;
                            way[1, search] = j - 2;
                            f = true;
                            break;
                        }
                    }
                    if ((i + 1) < m)   //на 1 вниз
                    {
                        if (field[i + 1, j - 2] == search)
                        {
                            current[0] = i + 1;
                            current[1] = j - 2;
                            way[0, search] = i + 1;
                            way[1, search] = j - 2;
                            f = true;
                            break;
                        }
                    }
                }
                if ((j + 2) < n)    //на 2 вправо
                {
                    if ((i - 1) >= 0)    //на 1 вверх
                    {
                        if (field[i - 1, j + 2] == search)
                        {
                            current[0] = i - 1;
                            current[1] = j + 2;
                            way[0, search] = i - 1;
                            way[1, search] = j + 2;
                            f = true;
                            break;
                        }
                    }
                    if ((i + 1) < m)    //на 1 вниз
                    {
                        if (field[i + 1, j + 2] == search)
                        {
                            current[0] = i + 1;
                            current[1] = j + 2;
                            way[0, search] = i + 1;
                            way[1, search] = j + 2;
                            f = true;
                            break;
                        }
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {           
            g = pictureBox1.CreateGraphics();
            for (int x = 0; x < n * 30; x += 30)
            {
                for (int y = 0; y < m * 30; y += 30)
                {
                    g.DrawRectangle(line, x, y, 30, 30);
                }
            }
            motion.Location = new Point(700, 100);
            motion.Size = new Size(50, 30);
            Controls.Add(motion);
            motion.Font = new Font(motion.Font.Name, 14, motion.Font.Style);
            motion.Text = "Ход";
            counter.Location = new Point(700, 130);
            counter.Size = new Size(30, 30);
            Controls.Add(counter);
            counter.Font = new Font(counter.Font.Name, 14, counter.Font.Style);
            timer1.Enabled = true;    //запускаем таймер
            route.Location = new Point(350, 70);
            route.Size = new Size(70, 30);
            Controls.Add(route);
            route.Font = new Font(route.Font.Name, 14, route.Font.Style);
            route.Text = "Путь:";
            result.Location = new Point(350, 430);
            result.Size = new Size(400, 60);
            Controls.Add(result);
            result.Font = new Font(result.Font.Name, 14, result.Font.Style);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Second > C)
            {
                result.Text = "Минимальное количество шагов: " + C;
                button7.Visible = true;
                timer1.Stop();
            }
            else
            {               
                g.FillRectangle(rec, 1 + way[1, Second] * 30, 1 + way[0, Second] * 30, 29, 29);
                counter.Text = "" + Second;
                Second++;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Visible = false;
            button7.Visible = false;
            g.FillRectangle(white, 0, 0, 301, 301);
            Second = 0;
            m = 3;
            n = 3;
            C = 0;
            pictureBox1.Enabled = false;
            labelM.Text = "" + m;
            labelN.Text = "" + n;
            result.Text = "";
            counter.Text = "";
            motion.Text = "";
            route.Text = "";
            Array.Clear(field, 0, field.Length);
            Array.Clear(way, 0, way.Length);
            Array.Clear(current, 0, current.Length);
            while (numbers.Count != 0)
            {
                numbers.Dequeue();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
