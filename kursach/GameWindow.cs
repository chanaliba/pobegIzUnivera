using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic;

namespace kursach
{
    public partial class GameWindow1 : Form
    {
        private bool music = true;
        private SoundPlayer sound = new SoundPlayer("music\\music1.wav");
        private List<Item> inventory;
        private ImageList imageList;
        private bool flagWindowHandle = false;
        private bool flagEatForCat = false;
        private bool flagSwitch = false;
        private bool flagSecondDone = false;
        private bool finalBoss = false;
        private int timer;

        public int resultTime = 2147483647;


        public GameWindow1()
        {
            InitializeComponent();
            keyRoom1.Hide();
            doorOpen.Hide();
            questRoom2.Hide();
            doorToRoom3.Hide();
            toSecondRoom.Hide();
            boardButton.Hide();
            button1.Hide();
            sound.PlayLooping();

            inventory = new List<Item>();
            imageList = new ImageList();
            imageList.ImageSize = new Size(90, 80);

            mail.Hide();
            pictureBoxSwitch.Hide();
            doorOpenRoom2.Hide();

            listViewItems.LargeImageList = imageList;
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void room1DoorHandleClick(object sender, EventArgs e)
        {
            string name = "Оконная ручка";
            Image pathImage = Image.FromFile(@"image\room1-wind.png");
            AddInventory(name, pathImage);
            flagWindowHandle = true;
            windowHandle.Hide();
        }

        private void AddInventory(string name, Image pathImage)
        {
            inventory.Add(new Item(name, pathImage));
            imageList.Images.Add(pathImage);

            ListViewItem listViewItem = new ListViewItem(name)
            {
                ImageIndex = imageList.Images.Count - 1
            };

            listViewItems.Items.Add(listViewItem);
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

        private void pauseClick(object sender, EventArgs e)
        {
            timer1.Stop();
            PauseForm pauseWin = new PauseForm();
            pauseWin.ShowDialog();
            if (!pauseWin.butt)
            {
                this.Close();
            }
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer += timer1.Interval / 1000;
            label3.Text = timer.ToString();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EatClick(object sender, EventArgs e)
        {
            string name = "Кошачий корм";
            Image pathImage = Image.FromFile(@"image\eat-for-cat.png");
            if (!flagEatForCat)
            {
                AddInventory(name, pathImage);
                flagEatForCat = true;
            }
        }

        private void CatClick(object sender, EventArgs e)
        {            
            bool flag = false;
            if(listViewItems.SelectedItems.Count > 0)
            {
                var selectedIndex = listViewItems.SelectedIndices[0];
                
                if (inventory[selectedIndex].Name == "Кошачий корм")
                    flag = true;
                if (flag == true)
                {
                    string userInput = Interaction.InputBox("Посмотрите на потолок и введите увиденное слово. Затем получите ключ от двери");
                    if (userInput.ToLower() == "сова")
                    {
                        inventory.RemoveAt(selectedIndex);
                        listViewItems.Items.RemoveAt(selectedIndex);
                        flagEatForCat = false;
                        keyRoom1.Show();
                        buttonCat.Enabled = false;
                    }
                    else 
                    {
                        MessageBox.Show("К сожалению введен неправильный ответ. Попробуйте снова");
                    }
                }
            }
            else 
            {
                MessageBox.Show("Покормите кота");
            }
        }

        private void KeyRoom1Click(object sender, EventArgs e)
        {
            string name = "Ключ";
            Image pathImage = Image.FromFile(@"image\key-room1.png");
            AddInventory(name, pathImage);
            keyRoom1.Hide();
        }

        private void Room1DoorOpen(object sender, EventArgs e)
        {
            bool flag = false;
            if (listViewItems.SelectedItems.Count > 0)
            {
                var selectedIndex = listViewItems.SelectedIndices[0];

                if (inventory[selectedIndex].Name == "Ключ")
                    flag = true;
                if (flag == true)
                {
                    doorOpen.Show();
                    inventory.RemoveAt(selectedIndex);
                    listViewItems.Items.RemoveAt(selectedIndex);
                }
            }
            else
            {
                MessageBox.Show("Вам нужен ключ");
            }
        }
        private void ToRoom3Click(object sender, EventArgs e)
        {
            flagSecondDone = true;

            pictureBox3.Image = Image.FromFile(@"image\room3-background.png");

            pictureBox5.Hide();
            buttonCat.Hide();
            windowHandle.Hide();
            keyRoom1.Hide();
            doorOpen.Hide();
            doorHandle.Hide();

            mail.Hide();
            pictureBoxSwitch.Hide();
            doorOpenRoom2.Hide();
            questRoom2.Hide();
            doorToRoom3.Hide();

            toSecondRoom.Show();
            boardButton.Show();
            button1.Show();
            room1.Text = "КОМНАТА 3";


        }

        private void ToRoom2Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile(@"image\room2-background1.png");
            
            pictureBox5.Hide();
            buttonCat.Hide();
            windowHandle.Hide();
            keyRoom1.Hide();
            doorOpen.Hide();
            doorHandle.Hide();
            toSecondRoom.Hide();
            boardButton.Hide();
            button1.Hide();

            mail.Show();
            pictureBoxSwitch.Show();
            doorOpenRoom2.Show();
            if (flagSwitch == true)
                questRoom2.Show();
            else
                questRoom2.Hide();

            room1.Text = "КОМНАТА 2";
            if (!flagSecondDone)
                doorToRoom3.Hide();
            else
                doorToRoom3.Show();

        }

        private void ToRoom1Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile(@"image\room1-background.png");
            

            mail.Hide();
            pictureBoxSwitch.Hide();
            doorOpenRoom2.Hide();
            questRoom2.Hide();

            toSecondRoom.Hide();
            doorToRoom3.Hide();
            boardButton.Hide();
            button1.Hide();

            pictureBox5.Show();
            buttonCat.Show();
            doorOpen.Show();
            if(!flagWindowHandle)
                windowHandle.Show();

            room1.Text = "КОМНАТА 1";
        }

        private void switchClick(object sender, EventArgs e)
        {
            if (!flagSwitch)
            {
                flagSwitch = true;
                pictureBoxSwitch.BackgroundImage = Image.FromFile(@"image\switch-on.png");
                questRoom2.Show();
            }
            else
            {
                flagSwitch = false;
                pictureBoxSwitch.BackgroundImage = Image.FromFile(@"image\switch-off.png");
                questRoom2.Hide();
            }
        }

        private void questClick(object sender, EventArgs e)
        {
            QuestForm quest = new QuestForm();
            quest.ShowDialog();
            if (quest.flagMain == true)
            {
                doorToRoom3.Show();
            }
        }

        private void MailClick(object sender, EventArgs e)
        {
            MessageBox.Show("Анекдот! \n -- Вы продаёте рыбов?\n -- Нет. Просто показываю\n -- Красивое...\n");
        }

        private void ToSecondRoomClick3(object sender, EventArgs e)
        {
            ToRoom2Click(sender, e);
            doorToRoom3.Show();
        }

        private void BoardClick(object sender, EventArgs e)
        {
            FinalQuestForm finalquest = new FinalQuestForm();
            finalquest.ShowDialog();
            if (finalquest.flag)
            {
                MessageBox.Show("Поздравляю! Для завершения игры используйте оконную ручку!");
                finalBoss = true;
            }
        }

        private void WindowOpenClick(object sender, EventArgs e)
        {
            bool flag = false;
            if (listViewItems.SelectedItems.Count > 0)
            {
                var selectedIndex = listViewItems.SelectedIndices[0];

                if (inventory[selectedIndex].Name == "Оконная ручка")
                    flag = true;
                if (flag == true && finalBoss == true)
                {
                    inventory.RemoveAt(selectedIndex);
                    listViewItems.Items.RemoveAt(selectedIndex);
                    resultTime = timer;
                    MessageBox.Show($"Поздравляю! Вы прошли игру! Ваше время прохождения: {timer}");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Вам нужна оконная ручка");
            }
        }
    }

    public class Inventory
    {
        
    }
}
