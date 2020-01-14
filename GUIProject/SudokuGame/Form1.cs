using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;


namespace SudokuGame
{
    public partial class Form1 : Form
    {
        public static ArrayList Game_table = new ArrayList();
        public static bool flag = false;
        public static int num = 0;
        private static System.Diagnostics.Process p;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Game_table.Add(text_element11);
            Game_table.Add(text_element12);
            Game_table.Add(text_element13);
            Game_table.Add(text_element14);
            Game_table.Add(text_element15);
            Game_table.Add(text_element16);
            Game_table.Add(text_element17);
            Game_table.Add(text_element18);
            Game_table.Add(text_element19);
            Game_table.Add(text_element21);
            Game_table.Add(text_element22);
            Game_table.Add(text_element23);
            Game_table.Add(text_element24);
            Game_table.Add(text_element25);
            Game_table.Add(text_element26);
            Game_table.Add(text_element27);
            Game_table.Add(text_element28);
            Game_table.Add(text_element29);
            Game_table.Add(text_element31);
            Game_table.Add(text_element32);
            Game_table.Add(text_element33);
            Game_table.Add(text_element34);
            Game_table.Add(text_element35);
            Game_table.Add(text_element36);
            Game_table.Add(text_element37);
            Game_table.Add(text_element38);
            Game_table.Add(text_element39);
            Game_table.Add(text_element41);
            Game_table.Add(text_element42);
            Game_table.Add(text_element43);
            Game_table.Add(text_element44);
            Game_table.Add(text_element45);
            Game_table.Add(text_element46);
            Game_table.Add(text_element47);
            Game_table.Add(text_element48);
            Game_table.Add(text_element49);
            Game_table.Add(text_element51);
            Game_table.Add(text_element52);
            Game_table.Add(text_element53);
            Game_table.Add(text_element54);
            Game_table.Add(text_element55);
            Game_table.Add(text_element56);
            Game_table.Add(text_element57);
            Game_table.Add(text_element58);
            Game_table.Add(text_element59);
            Game_table.Add(text_element61);
            Game_table.Add(text_element62);
            Game_table.Add(text_element63);
            Game_table.Add(text_element64);
            Game_table.Add(text_element65);
            Game_table.Add(text_element66);
            Game_table.Add(text_element67);
            Game_table.Add(text_element68);
            Game_table.Add(text_element69);
            Game_table.Add(text_element71);
            Game_table.Add(text_element72);
            Game_table.Add(text_element73);
            Game_table.Add(text_element74);
            Game_table.Add(text_element75);
            Game_table.Add(text_element76);
            Game_table.Add(text_element77);
            Game_table.Add(text_element78);
            Game_table.Add(text_element79);
            Game_table.Add(text_element81);
            Game_table.Add(text_element82);
            Game_table.Add(text_element83);
            Game_table.Add(text_element84);
            Game_table.Add(text_element85);
            Game_table.Add(text_element86);
            Game_table.Add(text_element87);
            Game_table.Add(text_element88);
            Game_table.Add(text_element89);
            Game_table.Add(text_element91);
            Game_table.Add(text_element92);
            Game_table.Add(text_element93);
            Game_table.Add(text_element94);
            Game_table.Add(text_element95);
            Game_table.Add(text_element96);
            Game_table.Add(text_element97);
            Game_table.Add(text_element98);
            Game_table.Add(text_element99);
        }


        private void button_start_Click(object sender, EventArgs e)
        {
            p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "sudoku.exe";
            p.Start();
            Thread.Sleep(1000);
            MessageBox.Show("操作成功，请点击开始游戏按钮");
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            StreamReader buf = new StreamReader("checkboard.txt");
            for (int k = 0; k < 10 * num; k++)
            {
                string linemore = buf.ReadLine();
            }
            for (int i = 0; i < 9; i++)
            {
                string line = buf.ReadLine();
                for (int j = 0; j < 9; j++)
                {
                    TextBox text_element = Game_table[i * 9 + j] as TextBox;
                    if (line[2 * j] == '0')
                    {
                        text_element.Text = "";
                        text_element.ReadOnly = false;
                        text_element.ForeColor = Color.White;
                        text_element.BackColor = Color.DeepSkyBlue;
                    }
                    else
                    {
                        text_element.Text = line[2 * j].ToString();
                        text_element.ReadOnly = true;
                        text_element.ForeColor = Color.Black;
                        text_element.BackColor = Color.SpringGreen;
                    }

                }
            }
            num++;
            flag = true;
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {
                MessageBox.Show("请开始游戏", "警告");
                return;
            }
            int[,] map = new int[9, 9];//保存数独中的数字
            //检查是否每个方格均已填写
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    TextBox text_element = Game_table[i * 9 + j] as TextBox;
                    if (text_element.Text == "")
                    {
                        MessageBox.Show("尚未完成，请继续填写", "警告");
                        return;
                    }
                    else
                        map[i, j] = (text_element.Text.ToCharArray())[0] - '0';
                }
            }

            //每个方格均非空，检查是否正确
            int[] judge = new int[10];
            for (int i = 0; i < 9; i++)//遍历1-9行
            {
                for (int j = 1; j <= 9; j++)
                    judge[i] = 0;
                for (int j = 0; j < 9; j++)//遍历该行的每个小方格
                {
                    int x = map[i, j];
                    judge[x] = 1;
                }
                for (int k = 1; k <= 9; k++)
                {
                    if (judge[k] != 1)
                    {
                        MessageBox.Show("回答错误", "错误");
                        return;
                    }
                }
            }
            for (int i = 0; i < 9; i++)//遍历1-9列
            {
                for (int j = 1; j <= 9; j++)
                    judge[i] = 0;
                for (int j = 0; j < 9; j++)//遍历该列的每个小方格
                {
                    int x = map[j, i];
                    judge[x] = 1;
                }
                for (int k = 1; k <= 9; k++)
                {
                    if (judge[k] != 1)
                    {
                        MessageBox.Show("回答错误", "错误");
                        return;
                    }
                }
            }
            //遍历每个3*3方块
            for (int i = 0; i < 9; i += 3)
                for (int j = 0; j < 9; j += 3)
                {
                    for (int k = 1; k <= 9; k++)
                        judge[k] = 0;

                    //遍历该方块的每个小方格
                    for (int a = 0; a < 3; a++)
                        for (int b = 0; b < 3; b++)
                        {
                            int x = map[i + a, j + b];
                            judge[x] = 1;
                        }
                    for (int k = 1; k <= 9; k++)
                    {
                        if (judge[k] != 1)
                        {
                            MessageBox.Show("回答错误", "错误");
                            return;
                        }
                    }
                }

            MessageBox.Show("回答正确", "恭喜");//是合法数独，求解成功
            Form f = new Form();
            f.Text = "牛b格拉斯";
            f.BackgroundImage = System.Drawing.Image.FromFile("腻害.gif");
            f.ShowDialog();
        }


        private void button_hint_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {
                MessageBox.Show("请开始游戏", "警告");
                return;
            }
            num--;
            int pos = -1;
            for (int i = 0; i < 81; i++)
            {
                TextBox text_element_1 = Game_table[i] as TextBox;
                if (text_element_1.Text == "")
                {
                    pos = i;
                    break;
                }
            }
            if (pos == -1)
            {
                MessageBox.Show("所有方格均已填写", "警告");
                return;
            }

            StreamReader buf = new StreamReader("answer.txt");
            for (int k = 0; k < 10 * num; k++)
            {
                string linemore = buf.ReadLine();
            }
            for (int i = 0; i < pos / 9; i++)
            {
                string linemore = buf.ReadLine();
            }
            string line = buf.ReadLine();
            int j = pos % 9;
            TextBox text_element = Game_table[pos] as TextBox;
            text_element.Text = line[2 * j].ToString();
            text_element.ReadOnly = true;
            text_element.ForeColor = Color.Blue;
            num++;
        }


        private void button_answer_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {
                MessageBox.Show("请开始游戏", "警告");
                return;
            }
            StreamReader buf = new StreamReader("answer.txt");
            for (int k = 0; k < 10 * (num-1); k++)
            {
                string linemore = buf.ReadLine();
            }
            for (int i = 0; i < 9; i++)
            {
                string line = buf.ReadLine();
                for (int j = 0; j < 9; j++)
                {
                    TextBox text_element = Game_table[i * 9 + j] as TextBox;
                    text_element.Text = line[2 * j].ToString();
                    text_element.ReadOnly = true;
                    text_element.ForeColor = Color.Black;
                }
            }
        }

        #region 键盘控制光标上下左右移动

        private void text_element11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element91.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element21.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element19.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element12.Focus();
        }
        private void text_element12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element92.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element22.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element11.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element13.Focus();
        }
        private void text_element13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element93.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element23.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element12.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element14.Focus();
        }
        private void text_element14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element94.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element24.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element13.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element15.Focus();
        }
        private void text_element15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element95.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element25.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element14.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element16.Focus();
        }
        private void text_element16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element96.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element26.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element15.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element17.Focus();
        }
        private void text_element17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element97.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element27.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element16.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element18.Focus();
        }
        private void text_element18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element98.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element28.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element17.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element19.Focus();
        }
        private void text_element19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element99.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element29.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element18.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element11.Focus();
        }
        private void text_element21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element11.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element31.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element29.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element22.Focus();
        }
        private void text_element22_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element12.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element32.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element21.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element23.Focus();
        }
        private void text_element23_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element13.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element33.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element22.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element24.Focus();
        }
        private void text_element24_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element14.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element34.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element23.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element25.Focus();
        }
        private void text_element25_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element15.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element35.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element24.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element26.Focus();
        }
        private void text_element26_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element16.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element36.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element25.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element27.Focus();
        }
        private void text_element27_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element17.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element37.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element26.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element28.Focus();
        }
        private void text_element28_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element18.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element38.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element27.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element29.Focus();
        }
        private void text_element29_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element19.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element39.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element28.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element21.Focus();
        }
        private void text_element31_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element21.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element41.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element39.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element32.Focus();
        }
        private void text_element32_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element22.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element42.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element31.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element33.Focus();
        }
        private void text_element33_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element23.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element43.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element32.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element34.Focus();
        }
        private void text_element34_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element24.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element44.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element33.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element35.Focus();
        }
        private void text_element35_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element25.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element45.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element34.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element36.Focus();
        }
        private void text_element36_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element26.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element46.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element35.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element37.Focus();
        }
        private void text_element37_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element27.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element47.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element36.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element38.Focus();
        }
        private void text_element38_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element28.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element48.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element37.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element39.Focus();
        }
        private void text_element39_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element29.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element49.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element38.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element31.Focus();
        }
        private void text_element41_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element31.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element51.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element49.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element42.Focus();
        }
        private void text_element42_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element32.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element52.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element41.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element43.Focus();
        }
        private void text_element43_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element33.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element53.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element42.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element44.Focus();
        }
        private void text_element44_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element34.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element54.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element43.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element45.Focus();
        }
        private void text_element45_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element35.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element55.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element44.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element46.Focus();
        }
        private void text_element46_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element36.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element56.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element45.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element47.Focus();
        }
        private void text_element47_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element37.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element57.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element46.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element48.Focus();
        }
        private void text_element48_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element38.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element58.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element47.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element49.Focus();
        }
        private void text_element49_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element39.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element59.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element48.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element41.Focus();
        }
        private void text_element51_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element41.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element61.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element59.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element52.Focus();
        }
        private void text_element52_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element42.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element62.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element51.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element53.Focus();
        }
        private void text_element53_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element43.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element63.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element52.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element54.Focus();
        }
        private void text_element54_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element44.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element64.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element53.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element55.Focus();
        }
        private void text_element55_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element45.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element65.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element54.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element56.Focus();
        }
        private void text_element56_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element46.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element66.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element55.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element57.Focus();
        }
        private void text_element57_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element47.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element67.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element56.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element58.Focus();
        }
        private void text_element58_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element48.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element68.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element57.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element59.Focus();
        }
        private void text_element59_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element49.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element69.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element58.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element51.Focus();
        }
        private void text_element61_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element51.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element71.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element69.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element62.Focus();
        }
        private void text_element62_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element52.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element72.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element61.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element63.Focus();
        }
        private void text_element63_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element53.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element73.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element62.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element64.Focus();
        }
        private void text_element64_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element54.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element74.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element63.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element65.Focus();
        }
        private void text_element65_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element55.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element75.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element64.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element66.Focus();
        }
        private void text_element66_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element56.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element76.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element65.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element67.Focus();
        }
        private void text_element67_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element57.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element77.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element66.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element68.Focus();
        }
        private void text_element68_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element58.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element78.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element67.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element69.Focus();
        }
        private void text_element69_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element59.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element79.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element68.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element61.Focus();
        }
        private void text_element71_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element61.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element81.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element79.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element72.Focus();
        }
        private void text_element72_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element62.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element82.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element71.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element73.Focus();
        }
        private void text_element73_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element63.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element83.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element72.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element74.Focus();
        }
        private void text_element74_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element64.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element84.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element73.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element75.Focus();
        }
        private void text_element75_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element65.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element85.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element74.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element76.Focus();
        }
        private void text_element76_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element66.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element86.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element75.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element77.Focus();
        }
        private void text_element77_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element67.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element87.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element76.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element78.Focus();
        }
        private void text_element78_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element68.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element88.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element77.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element79.Focus();
        }
        private void text_element79_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element69.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element89.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element78.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element71.Focus();
        }
        private void text_element81_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element71.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element91.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element89.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element82.Focus();
        }
        private void text_element82_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element72.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element92.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element81.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element83.Focus();
        }
        private void text_element83_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element73.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element93.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element82.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element84.Focus();
        }
        private void text_element84_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element74.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element94.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element83.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element85.Focus();
        }
        private void text_element85_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element75.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element95.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element84.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element86.Focus();
        }
        private void text_element86_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element76.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element96.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element85.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element87.Focus();
        }
        private void text_element87_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element77.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element97.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element86.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element88.Focus();
        }
        private void text_element88_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element78.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element98.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element87.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element89.Focus();
        }
        private void text_element89_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element79.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element99.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element88.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element81.Focus();
        }
        private void text_element91_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element81.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element11.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element99.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element92.Focus();
        }
        private void text_element92_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element82.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element12.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element91.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element93.Focus();
        }
        private void text_element93_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element83.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element13.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element92.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element94.Focus();
        }
        private void text_element94_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element84.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element14.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element93.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element95.Focus();
        }
        private void text_element95_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element85.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element15.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element94.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element96.Focus();
        }
        private void text_element96_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element86.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element16.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element95.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element97.Focus();
        }
        private void text_element97_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element87.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element17.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element96.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element98.Focus();
        }
        private void text_element98_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element88.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element18.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element97.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element99.Focus();
        }
        private void text_element99_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                text_element89.Focus();
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                text_element19.Focus();
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                text_element98.Focus();
            else if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
                text_element91.Focus();
        }

        #endregion


        #region 如果输入的不是合格键，则取消该输入
        private void CheckKey(object sender, KeyPressEventArgs e)
        {
            if (flag == false)
                return;
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8
                && e.KeyChar != (char)38 && e.KeyChar != (char)40 && e.KeyChar != (char)37 && e.KeyChar != (char)39
                && e.KeyChar != (char)87 && e.KeyChar != (char)83 && e.KeyChar != (char)65 && e.KeyChar != (char)68)
            {
                e.Handled = true;
            }
        }
        #endregion


    }
}
