using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static int FindValueIndex<T>(IEnumerable<T> sequence, T value)
        {
            int index = 1;
            foreach (T element in sequence)
            {
                if (EqualityComparer<T>.Default.Equals(element, value))
                {
                    return index;
                }
                index++;
            }
            return 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBox1.Text) & !String.IsNullOrEmpty(textBox2.Text))
                {
                    string[] values = textBox1.Text.Split(new string[] { ", " }, StringSplitOptions.None); // метод Split для разделения строки на массив строк. пробел стал частью слова.
                    string desired = textBox2.Text;
                    int position = FindValueIndex(values, desired);
                    textBox3.Text = Convert.ToString(position);
                }
                else if (Int32.TryParse(textBox1.Text, out int i))
                {
                    string[] valueStrings = textBox1.Text.Split(new string[] { ", " }, StringSplitOptions.None);
                    int[] values = Array.ConvertAll(valueStrings, Int32.Parse);
                    int desired = Convert.ToInt32(textBox2.Text);
                    int position = FindValueIndex(values, desired);
                    textBox3.Text = Convert.ToString(position);
                }
                else
                {
                    string[] valueStrings = textBox1.Text.Split(new string[] { ", " }, StringSplitOptions.None);
                    double[] values = Array.ConvertAll(valueStrings, Double.Parse); // преобразование массива из одного типа в другой
                    double desired = Convert.ToDouble(textBox2.Text);
                    double position = FindValueIndex(values, desired);
                    textBox3.Text = Convert.ToString(position);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Проверьте правильность введенных данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Clear();
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
