using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Xml.Linq;

namespace kursach
{

    public partial class MainForm : Form
    {
        private List<Item> items;
        private bool music = true;
        private SoundPlayer sound = new SoundPlayer(@"music\music1.wav");
        private string path = @"results.txt";

        public MainForm()
        {
            InitializeComponent();
            sound.PlayLooping();
            items = new List<Item>();
        }

        private void LoadGame(object sender, EventArgs e)
        {
            Result result = new Result();

            ResultForm nameWin = new ResultForm();
            nameWin.ShowDialog();

            if (nameWin.flag == true)
            {
                GameWindow1 gameWin = new GameWindow1();
                gameWin.ShowDialog();

                result.Name = nameWin.name;
                result.Time = gameWin.resultTime;
                if(result.Time < 2147483647)
                    WriteFile(path, result);
            }
        }

        private void WriteFile(string path, Result result)
        {
            List<(string Name, int Time)> items = new List<(string, int)>();

            if (File.Exists(path))
            {
                foreach (var line in File.ReadLines(path))
                {
                    var parts = line.Split(':');
                    if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int existingTime))
                    {
                        items.Add((parts[0].Trim(), existingTime));
                    }
                }
            }
            items.Add((result.Name, result.Time));
            var sortedItems = items.OrderBy(item => item.Time).ToList();
            File.WriteAllLines(path, sortedItems.Select(item => $"{item.Name}: {item.Time}"));
        }

        private void LoadHelp(object sender, EventArgs e)
        {
            HelpWindow helpWin = new HelpWindow();

            helpWin.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutClick(object sender, EventArgs e)
        {
            Autor autor = new Autor();
            autor.ShowDialog();
        }


        private void exitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void soundClick(object sender, EventArgs e)
        {
            if (music)
            {
                sound.Stop();
                pictureBox1.BackgroundImage = new Bitmap(@"image\music-icon-off.png");
            }
            else 
            {
                sound.Play();
                pictureBox1.BackgroundImage = new Bitmap(@"image\music-icon.png");
            }
            music = !music;
        }

        private void RatingClick(object sender, EventArgs e)
        {
            Rating rating = new Rating();
            rating.ShowDialog();
        }
    }

    public class Result
    {
        public string Name;
        public int Time;

        public override string ToString()
        {
            return Name + ": " + Time.ToString();
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Item(string name, Image image)
        {
            Name = name;
            Quantity = 0;
        }
    }
}
