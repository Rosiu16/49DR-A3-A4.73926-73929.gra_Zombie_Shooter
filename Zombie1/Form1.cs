using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zombie1
{
    public partial class Form1 : Form
    {

        bool goLeft, goRight, goUp, goDown, gameOver;
        string facing = "up";
        int playerhealth = 100;
        int speed = 10;
        int ammo = 10;
        int ZombieSpeed = 3;
        Random RandNum = new Random();


        List<PictureBox> zombieslist = new List<PictureBox>();



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            "Siema Wojtek test test test2"
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

        }
        private void ShootBullet(string direction)
        {

        }
        private void MakeZombies()
        {

        }
        private void RestartGame()
        {

        }
    }
}
