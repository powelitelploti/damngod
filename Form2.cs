using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kurs;

namespace kurs
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            richTextBox1.Text = 
                "ОСНОВНЫЕ ВОЗМОЖНОСТИ:\r\n" +
                "✓ Решение СЛАУ методом Крамера для систем до 20×20\r\n" +
                "✓ Вычисление определителей методом Гаусса с выбором ведущего элемента\r\n" +
                "✓ Вычисление числа обусловленности системы\r\n✓" +
                "✓ Проверка точности решения через вычисление невязки\r\n" +
                "✓ Подробное пошаговое представление вычислений\r\n" +
                "✓ Загрузка систем из файлов специального формата\r\n" +
                "✓ Возможность сохранения решения в текстовый файл\r\n" +
                "✓ Отправка решения на печать\r\n";

            richTextBox2.Text = "ТЕОРЕТИЧЕСКАЯ БАЗА:\r\n" +
                                "• Метод Крамера: xi = Δi / Δ \r\n" +
                                "• Число обусловленности: cond(A) = || A ||·|| A⁻¹|| \r\n" +
                                "• Невязка: r = || A·x - b || \r\n" +
                                "• Точность: до 10⁻¹³ (машинная точность)";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
