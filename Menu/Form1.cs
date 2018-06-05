using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
    public partial class Form1 : Form
    {
        enum LR { Left, Right };
        LR side;
        Size SizeGameObject;
        bool isStart;
        int speed;
        public Form1()
        {
            InitializeComponent();
            speed = 2;
            side = LR.Right;
            isStart = false;
            SizeGameObject = new Size(GameObject.Size.Width, GameObject.Size.Height);
        }

        private void Unchecked()
        {
            Speed1.Checked = Speed2.Checked = Speed3.Checked = Speed4.Checked = false;
        }

        private void Start()
        {
            isStart = true;
            timer1.Start();
        }

        private bool Compression()
        {
            if (side == LR.Left && GameObject.Size.Width > 20)
            {
                GameObject.Size = new Size(GameObject.Size.Width - Math.Abs(speed), GameObject.Size.Height + Math.Abs(speed));
                return false;
            }
            else if (side == LR.Right && GameObject.Size.Width > 20)
            {
                GameObject.Size = new Size(GameObject.Size.Width - Math.Abs(speed), GameObject.Size.Height + Math.Abs(speed));
                return false;
            }
            else
            {
                GameObject.Size = new Size(GameObject.Size.Width + Math.Abs(speed), GameObject.Size.Height - Math.Abs(speed));
                return true;
            }
        }
        private void Move()
        {
            if (GameObject.Location.X <= 0 && Compression())
            {
                speed = Math.Abs(speed);
                side = LR.Right;
            }
            else if (GameObject.Location.X >= this.ClientSize.Width - GameObject.Size.Width || speed > 0 && side == LR.Left )
            {         
                speed = -speed;
                side = LR.Left;
            }
            GameObject.Location = new Point(GameObject.Location.X + speed, GameObject.Location.Y);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void Speed1_Click(object sender, EventArgs e)
        {
            Unchecked();
            Speed1.Checked = true;
            speed = 2;
        }

        private void Speed2_Click(object sender, EventArgs e)
        {
            Unchecked();
            Speed2.Checked = true;
            speed = 4;
        }

        private void Speed3_Click(object sender, EventArgs e)
        {
            Unchecked();
            Speed3.Checked = true;
            speed = 6;
        }

        private void Speed4_Click(object sender, EventArgs e)
        {
            Unchecked();
                Speed4.Checked = true;
            speed = 8;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Move();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
