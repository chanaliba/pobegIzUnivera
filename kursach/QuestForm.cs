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
    public partial class QuestForm : Form
    {
        private List<Image> images;

        private bool flagOne = true;
        private bool flagTwo = false;
        private bool flagThree = false;

        private int indexOne;
        private int indexTwo;
        private int indexThree;

        public bool flagMain = false;


        public QuestForm()
        {
            InitializeComponent();
            images = new List<Image>();
            images.Add(Image.FromFile(@"image\arrowUp.png"));
            images.Add(Image.FromFile(@"image\arrowRight.png"));
            images.Add(Image.FromFile(@"image\arrowDown.png"));
            images.Add(Image.FromFile(@"image\arrowLeft.png"));


        }

        private void QuestForm_Load(object sender, EventArgs e)
        {

        }

        private void FirstClick(object sender, EventArgs e)
        {
            if (indexOne == 3)
                indexOne = -1;

            indexOne++;
            pictureBox1.BackgroundImage = images[indexOne];
            if (indexOne == 0)
                flagOne = true;
            else
                flagOne = false;
        }

        private void SecondClick(object sender, EventArgs e)
        {
            if (indexTwo == 3)
                indexTwo = -1;

            indexTwo++;
            pictureBox2.BackgroundImage = images[indexTwo];
            if (indexTwo == 1)
                flagTwo = true;
            else
                flagTwo = false;
        }

        private void ThirdClick(object sender, EventArgs e)
        {
            if (indexThree == 3)
                indexThree = -1;

            indexThree++;
            pictureBox3.BackgroundImage = images[indexThree];
            if (indexThree == 3)
                flagThree = true;
            else
                flagThree = false;
        }

        private void ClickMain(object sender, EventArgs e)
        {
            if (flagOne && flagTwo && flagThree)
            {
                flagMain = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный ответ. Попробуй ещё раз!");
            }
        }
    }
}
