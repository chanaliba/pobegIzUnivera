using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach
{
    public partial class Rating : Form
    {
        private string path = @"results.txt";

        public Rating()
        {
            InitializeComponent();
            try
            {
                var lines = File.ReadLines(path).Take(10);
                int i = 1;
                foreach (var line in lines)
                {
                    var items = line.Split(':');
                    listView1.Items.Add($"{i}.  {items[0].Trim()}:   {items[1]}\n");
                    i++;
                }
                listView1.Items.Add("...............................................");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }

        }

        private void Raitng_Load(object sender, EventArgs e)
        {
            
        }
    }
}
