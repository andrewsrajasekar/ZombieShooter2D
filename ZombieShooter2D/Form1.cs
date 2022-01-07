using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombieShooter2D
{
    public partial class Form1 : Form
    {

        bool moveUp, moveDown, moveLeft, moveRight, gameOver;
        string facing = "up";
        int currentHealth = 100;
        int speed = 10;
        int ammo = 10;
        int zombieSpeed = 3;
        int score = 0;
        Random randNum = new Random();

        List<PictureBox> zombiesList = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            if(currentHealth > 1)
            {
                healthBar.Value = currentHealth;
            }
            else
            {
                gameOver = true;
                playerCharacter.Image = Properties.Resources.dead;
                gameTimer.Stop();
            }

            ammoText.Text = "Ammo : " + ammo;
            scoreText.Text = "Kills : " + score;

            if(moveLeft && playerCharacter.Left > 0)
            {
                playerCharacter.Left -= speed;
            }

            if (moveRight && playerCharacter.Left + playerCharacter.Width < this.ClientSize.Width)
            {
                playerCharacter.Left += speed;
            }

            if (moveUp && playerCharacter.Top > 48)
            {
                playerCharacter.Top -= speed;
            }

            if (moveDown && playerCharacter.Top + playerCharacter.Height < this.ClientSize.Height)
            {
                playerCharacter.Top += speed;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (playerCharacter.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 5;
                    }
                }

                if (x is PictureBox && (string)x.Tag == "zombie")
                {
                    if(playerCharacter.Bounds.IntersectsWith(x.Bounds))
                    {
                        currentHealth -= 1;
                    }

                    if(x.Left > playerCharacter.Left)
                    {
                        x.Left -= zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zleft;
                    }

                    if (x.Left < playerCharacter.Left)
                    {
                        x.Left += zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zright;
                    }

                    if (x.Top > playerCharacter.Top)
                    {
                        x.Top -= zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zdown;
                    }

                    if (x.Top < playerCharacter.Top)
                    {
                        x.Top += zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zup;
                    }
                }

                foreach(Control j in this.Controls)
                {
                    if(j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "zombie")
                    {
                        if(x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score++;

                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            zombiesList.Remove(((PictureBox)x));
                            SpawnZombies();
                        }

                    }
                }

            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(gameOver)
            {
                return;
            }

            if(e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                moveLeft = true;
                facing = "left";
                playerCharacter.Image = Properties.Resources.left;
            }

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                moveRight = true;
                facing = "right";
                playerCharacter.Image = Properties.Resources.right;
            }

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                moveDown = true;
                facing = "down";
                playerCharacter.Image = Properties.Resources.down;
            }

            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                moveUp = true;
                facing = "up";
                playerCharacter.Image = Properties.Resources.up;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                moveDown = false;
            }

            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                moveUp = false;
            }

            if(e.KeyCode == Keys.Space && ammo > 0 && !gameOver)
            {
                ammo--;
                ShootBullet(facing);

                if(ammo < 1)
                {
                    DropAmmo();
                }
            }

            if(e.KeyCode == Keys.Enter && gameOver)
            {
                RestartGame();
            }
        }

        private void ShootBullet(String direction)
        {
            Bullet bullet = new Bullet();
            bullet.direction = direction;
            bullet.bulletLeft = playerCharacter.Left + (playerCharacter.Width / 2);
            bullet.bulletTop = playerCharacter.Top + (playerCharacter.Height / 2);
            bullet.MakeBullet(this);
        }

        private void SpawnZombies()
        {
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown;
            zombie.Left = randNum.Next(0,900);
            zombie.Top = randNum.Next(0, 800);
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;

            zombiesList.Add(zombie);
            this.Controls.Add(zombie);
            playerCharacter.BringToFront();
        }

        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Tag = "ammo";
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.Left = randNum.Next(10,this.ClientSize.Width - ammo.Width);
            ammo.Top = randNum.Next(60, this.ClientSize.Height - ammo.Height);
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;

            this.Controls.Add(ammo);
            playerCharacter.BringToFront();
        }

        private void RestartGame()
        {
            playerCharacter.Image = Properties.Resources.up;

            foreach(PictureBox i in zombiesList)
            {
                this.Controls.Remove(i);
            }

            zombiesList.Clear();

            for (int i = 0;i < 3;i++)
            {
                SpawnZombies();
            }

            moveUp = moveDown = moveLeft = moveRight = gameOver = false;
            currentHealth = 100;
            ammo = 10;
            score = 0;

            gameTimer.Start();
        }
    }
}
