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
        int score;
        List<PictureBox> zombieslist = new List<PictureBox>();



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            if(playerhealth > 1)
            {
                healthBar.Value = playerhealth;
            }
            else
            {
                gameOver = true;
                player.Image = Properties.Resources.dead;
                GameTimer.Stop();

            }

            txtAmmo.Text = "Ammo: " + ammo;
            txtScore.Text = "Kills: " + score;

            if(goLeft == true && player.Left > 0)
            {
                player.Left -= speed;
            }
            if(goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += speed;
            }
            if(goUp == true && player.Top > 41)
            {
                player.Top -= speed;
            }
            if(goDown == true && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += speed;
            }

            foreach (Control x in this.Controls) 
            {
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 5;
                    }
                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                facing = "left";
                player.Image = Properties.Resources.left;
                
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                facing = "right";
                player.Image = Properties.Resources.right;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                facing = "up";
                player.Image = Properties.Resources.up;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                facing = "down";
                player.Image = Properties.Resources.down;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;

            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Space  && ammo >0)
            {
                ammo--;
                ShootBullet(facing);

                if (ammo <1)
                {
                    DropAmmo();

                }
            }

        }
        private void ShootBullet(string direction)
        {
            Bullet shootBullet = new Bullet();
            shootBullet.direction = direction;
            shootBullet.bulletLeft = player.Left + (player.Width / 2);
            shootBullet.bulletTop = player.Top + (player.Height / 2);
            shootBullet.MakeBullet(this);
        }
        private void MakeZombies()
        {
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown;
            zombie.Left = RandNum.Next(0, 900);
            zombie.Top = RandNum.Next(0, 800);
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            zombieslist.Add(zombie);
            this.Controls.Add(zombie);
            player.BringToFront();

        }

        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = RandNum.Next(10, this.ClientSize.Width - ammo.Width);
            ammo.Top = RandNum.Next(60, this.ClientSize.Height - ammo.Height);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);

            ammo.BringToFront();
            player.BringToFront();
        }


        private void RestartGame()
        {

        }
    }
}
