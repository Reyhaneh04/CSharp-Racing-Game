using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacingGAme_Tutorial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        int speed;
        int score=0;
        PictureBox [] road = new PictureBox[8];
        

        private void Form1_Load(object sender, EventArgs e)
        {
            speed = 3;
            road[0] = pictureBox1;
            road[1] = pictureBox2;
            road[2] = pictureBox3;
            road[3] = pictureBox4;
            road[4] = pictureBox5;
            road[5] = pictureBox6;
            road[6] = pictureBox7;
            road[7] = pictureBox8;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int x = 0; x < road.Length; x++)
            {
                road[x].Top += speed;
                if (road[x].Top >= this.Height)
                {
                    road[x].Top =-road[x].Height;
                }
            }
            if(score>10 && score < 20)
            {
                speed = 5;
            }
            else if (score > 20 && score < 30)
            {
                speed = 6;
            }
            else if (score > 30)
            {
                score = 7;
            }
            Speed_text.Text = "Speed" + speed;
            if (Car.Bounds.IntersectsWith(EnemyCar1.Bounds))
            {
                gameover();
            }
            else if (Car.Bounds.IntersectsWith(EnemyCar2.Bounds))
            {
                gameover();
            }
            else if (Car.Bounds.IntersectsWith(EnemyCar3.Bounds))
            {
                gameover();
            }
        }
        private void gameover()
        {
            Replay_btn.Visible = true;
            End_text.Visible = true;
            RoadMover.Stop();
            Enemy1_mover.Stop();
            Enemy2_mover.Stop();
            Enemy3_mover.Stop();    
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                Left_mover.Start();
            }
            if (e.KeyCode == Keys.Right)
            {
                Right_mover.Start();
            }
        }

   

        private void Right_mover_Tick(object sender, EventArgs e)
        {
            if(Car.Location.X <200)
            {
                Car.Left += 5;

            }
        }

        private void Left_mover_Tick(object sender, EventArgs e)
        {
            if (Car.Location.X >0)
            {
                Car.Left -= 5;
            }
               
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Right_mover.Stop();
            Left_mover.Stop() ;
        }
        private void Enemy1_mover_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            EnemyCar1.Top += speed/2;
            if (EnemyCar1.Top >= this.Height)
            {
                score += 1;
                Score_text.Text = "Score" + score;
                EnemyCar1.Top = -((int)(Math.Ceiling(random.NextDouble() * 150)) + EnemyCar1.Height);
                EnemyCar1.Left = (int)(Math.Ceiling(random.NextDouble() * 50)) + 0;
            }
        }

        private void Enemy2_mover_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            EnemyCar2.Top += speed;
            if (EnemyCar2.Top >= this.Height)
            {
                score += 1;
                Score_text.Text = "Score" + score;
                    EnemyCar2.Top = -((int)(Math.Ceiling(random.NextDouble() * 150)) + EnemyCar2.Height);
                    EnemyCar2.Left = (int)(Math.Ceiling(random.NextDouble() * 50)) + 80;
                
            }
        }

        private void Enemy3_mover_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            EnemyCar3.Top += speed*3/2;
            if (EnemyCar3.Top >= this.Height)
            {
                score += 1;
                Score_text.Text = "Score" + score;
                EnemyCar3.Top = -((int)(Math.Ceiling(random.NextDouble() * 150)) + EnemyCar3.Height);
                    EnemyCar3.Left = (int)(Math.Ceiling(random.NextDouble() * 50)) + 150;
                
            }
        }

        private void Replay_btn_Click(object sender, EventArgs e)
        {
            score = 0;
            this.Controls.Clear();
            InitializeComponent();
            Form1_Load(e, e);
        }
    }
}
