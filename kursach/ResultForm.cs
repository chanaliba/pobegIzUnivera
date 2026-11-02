using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace kursach
{
    public partial class ResultForm : Form
    {
        public bool flag = false;
        public string name;
        public ResultForm()
        {
            InitializeComponent();
            name = textBox1.Text;
        }

        private void result_Load(object sender, EventArgs e)
        {

        }

        private void enterClick(object sender, EventArgs e)
        {
            name = textBox1.Text;
            while (name.Length > 15)
            {
                name = textBox1.Text;
            }
            flag = true;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
