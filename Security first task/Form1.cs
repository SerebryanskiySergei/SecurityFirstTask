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
            int value_count = _calculator.FillData(4.1);
            _calculator.GenerateSections();
            label3.Text = value_count.ToString();
            chart1.Series.Clear();
            chart1.Series.Add("Values in interval");
            for (int i = 0; i < _calculator.Sections.Count; i++)
                chart1.Series[0].Points.AddXY("[ "+_calculator.Interval * i +" , "+_calculator.Interval * (i+1) +" ]", _calculator.Sections[i]);
        }
    }
}
