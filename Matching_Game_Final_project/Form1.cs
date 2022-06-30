using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matching_Game_Final_project
{
    public partial class Form1 : Form
    {
        Label FirstClick = null;
        Label SeconClick = null;

        Random Rand = new Random();

        List<string> icons = new List<string>()
        {
            "!","!",",",",","N","N","K","K","z","z","b","b","w","w","v","v"
        };

        
        int seconds = 0;
        int minutes = 0;
        int hours = 0;
        

        public Form1()
        {
            InitializeComponent();
            IconTolabel();
        }

        private void IconTolabel()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconlabel = control as Label;
                if (iconlabel != null)
                {
                    int randomnumber = Rand.Next(icons.Count);
                    iconlabel.Text = icons[randomnumber];
                    iconlabel.ForeColor = iconlabel.BackColor;
                    icons.RemoveAt(randomnumber);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            FirstClick.ForeColor = FirstClick.BackColor;
            SeconClick.ForeColor = SeconClick.BackColor;
            FirstClick = null;
            SeconClick = null;
        }
        private void CheckUserClick()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconlabel = control as Label;
                if (iconlabel != null)
                {
                    if (iconlabel.ForeColor == iconlabel.BackColor)
                        return;
                }
            }
            MessageBox.Show("You Win !!!");
            //Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label clicklabel = sender as Label;

            if (clicklabel != null)
            {
                if (clicklabel.ForeColor == Color.Black)
                    return;

                if (FirstClick == null)
                {
                    FirstClick = clicklabel;
                    FirstClick.ForeColor = Color.Black;
                    return;
                }

                SeconClick = clicklabel;
                SeconClick.ForeColor = Color.Black;
                CheckUserClick();

                if (FirstClick.Text == SeconClick.Text)
                {
                    FirstClick = null;
                    SeconClick = null;
                    return;
                }
                timer1.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label17.Text = "0" + hours.ToString() + ":" + "0" + minutes.ToString() + ":" + "0" + seconds.ToString();
            seconds++;
            if (seconds == 60)
            {
                seconds = 0;
                minutes++;
            }
            if (minutes == 60)
            {
                minutes = 0;
                hours++;
            }
            if (hours == 24)
            {
                hours = 0;
            }
            timer2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            label17.Text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
            seconds++;
            if (seconds == 60)
            {
                seconds = 0;
                minutes++;
            }
            if (minutes == 60)
            {
                minutes = 0;
                hours++;
            }
            if (hours == 24)
            {
                hours = 0;
            }
            

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
