using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static string t1;
        public static string t2;
        public static string t3;
        public static string save_file;
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt";
            openFileDialog2.Filter = "Text files(*.txt)|*.txt";
            openFileDialog3.Filter = "Text files(*.txt)|*.txt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Show();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            { return; }
            string filename = openFileDialog1.FileName;// получение выбранного файла
            t1 = File.ReadAllText(filename, Encoding.GetEncoding(1251));// чтение файла в строку
            textBox2.Text = t1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Show();
            if (openFileDialog2.ShowDialog() == DialogResult.Cancel)
            { return; }
            string filename = openFileDialog2.FileName;
            t2 = File.ReadAllText(filename, Encoding.GetEncoding(1251));
            textBox3.Text = t2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Show();
            if (openFileDialog3.ShowDialog() == DialogResult.Cancel)
            { return; }
            save_file = openFileDialog3.FileName;
            string t3 = File.ReadAllText(save_file, Encoding.GetEncoding(1251));
            textBox1.Text = t3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string t = File.ReadAllText(save_file, Encoding.GetEncoding(1251));
            t3 = t + Environment.NewLine + "*********************************************" + Environment.NewLine + t1 + Environment.NewLine + "*********************************************" + Environment.NewLine + t2;
            StreamWriter sw = new StreamWriter(save_file);
            sw.Write(t3);
            sw.Close();
            MessageBox.Show("Файлы объединены");
            textBox1.Text = t3;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
        }
    }
}
