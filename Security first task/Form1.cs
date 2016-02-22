using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Security_first_task
{
    public partial class Form1 : Form
    {
        private Calculator _calculator;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _calculator  = new Calculator();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _calculator = new Calculator();

            int value_count = _calculator.FillData(Convert.ToDouble(textBox1.Text));
            if (textBox2.TextLength > 0)
                _calculator.GenerateSections(Convert.ToInt32(textBox2.Text));
            else
                _calculator.GenerateSections();
            if (value_count == Calculator.DEFAULT_VALUES_COUNT)
                label4.Text = "Count of diff values : more than " + Calculator.DEFAULT_VALUES_COUNT;
            else
                label4.Text = "Count of diff values : " + value_count.ToString();
            meanLbl.Text = "Mean value = "+_calculator.MeanValue.ToString();
            dispLbl.Text = "Dispersion = "+_calculator.Dispersion.ToString();
            xiLbl.Text = "Xi ^2 = "+_calculator.GenerateXi().ToString();
            pilbl.Text = "Experimentsl PI = "+_calculator.TestWithKnownTask().ToString();
            chart1.Series.Clear();
            chart1.Series.Add("Values in interval");
            for (int i = 0; i < _calculator.Sections.Count; i++)
                chart1.Series[0].Points.AddXY(_calculator.Interval * i, _calculator.Sections[i]);
        }
    }
}
