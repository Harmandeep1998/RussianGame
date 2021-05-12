using RussianGame.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RussianGame
{
    public partial class RussianGameForm : Form
    {
        Revolver revolver;
        SoundPlayer soundPlayer;
        int current, chances;

        public RussianGameForm()
        {
            InitializeComponent();
            buttonLoad.Enabled = false;
            buttonSpin.Enabled = false;
            buttonFire.Enabled = false;
            soundPlayer = new SoundPlayer();
        }

        private void RussianGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                Button button = sender as Button;
                if( button == buttonStart )
                {
                    if (button.Text.Contains("Start"))
                    {
                        button.Text="Quit Game";
                        labelMessage.Text = "Now Load the Bullet in Revolver...";
                        chances = 3;
                        labelTotal.Text = "Total Remaining Fire Chance: " + chances;
                        revolver = new Revolver();
                        buttonLoad.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Hey!!! Quitter...","Russian Game");
                        this.Close();
                    }
                }
                else if (button == buttonLoad)
                {
                    LoadBullet();
                }
                else if (button == buttonSpin)
                {
                    SpinRevolver();
                }
                else if (button == buttonFire)
                {
                    FireBullet();
                }
            }
            
        }

        public void LoadBullet()
        {
            buttonLoad.Enabled = false;
            labelMessage.Text = "Loading The Bullet at First Position in Revolver...";
            revolver.LoadBullet();
            Thread.Sleep(1000);
            buttonSpin.Enabled = true;
            labelMessage.Text = "Now Spin the Bullet...";
        }

        public void SpinRevolver()
        {
            buttonSpin.Enabled = false;
            labelMessage.Text = "After Spinning, We don't know where is the Bullet in Revolver...";
            revolver.Spin();
            Thread.Sleep(2000);
            buttonFire.Enabled = true;
            labelMessage.Text = "Now Check Your Luck Factor...";
            labelTotal.Text = "Total Remaining Fire Chance: " + chances;
            current = 0;
        }

        public void FireBullet()
        {
            if (revolver.Fire(current))
            {
                soundPlayer.Stream = Resources.bullet_fire_shot;
                soundPlayer.Play();
                picture.Image = Resources.dead;
                Thread.Sleep(2500);
                labelTotal.Text = "Hey, You are Dead to Game";
                labelMessage.Text = "";
                MessageBox.Show("Sorry!!! Better Luck Next Time...","Russian Game");
                this.Close();
                return;
            }
            else
            {
                soundPlayer.Stream = Resources.empty_gun_shot;
                soundPlayer.Play();
                Thread.Sleep(2500);
            }
            current++;
            chances--;
            if (chances == 0)
            {
                labelTotal.Text = "Hey Winner!!!";
                picture.Image = Resources.winner;
                Thread.Sleep(2500);
                MessageBox.Show("Welcome Winner See you soon...","Russian Game");
                this.Close();
            }
            else
            {
                labelTotal.Text = "Total Remaining Fire Chance: " + chances;
            }
        }
    }
}
