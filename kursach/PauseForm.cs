using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach
{
    public partial class PauseForm : Form
    {
        public bool butt; 
        public PauseForm()
        {
            InitializeComponent();
        }

        private void continueClick(object sender, EventArgs e)
        {
            butt = true;
            this.Close();
        }

        private void exitClick(object sender, EventArgs e)
        {
            butt = false;
            this.Close();
        }
    }
}
