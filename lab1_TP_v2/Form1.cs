using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1_TP_v2
{
    public partial class Form1 : Form
    {
        private Liner liner;
        public Form1()
        {
            InitializeComponent();
        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(bmp);
            liner.DrawLiner(gr);
            pictureBox1.Image = bmp;
        }
        private void Create_button_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            liner = new Liner();
            liner.Init(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.FromArgb(129, 76, 76),
                Color.FromArgb(76, 126, 129), true, true);
            liner.SetPosition(rnd.Next(150, 200),
           rnd.Next(150, 200), pictureBox1.Width, pictureBox1.Height);


            Draw();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {

        }

        private void buttonDown_Click(object sender, EventArgs e)
        {

        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
			//получаем имя кнопки
			string name = (sender as Button).Name;

			switch (name)
			{

				case "buttonUp":
					if (liner != null)
					{
						liner.MoveLiner(Direction.Up);
					}
					else
					{
						MessageBox.Show("Сначала создайте зенитку!!");
						return;
					}
					break;
				case "buttonDown":
					if (liner != null)
					{
						liner.MoveLiner(Direction.Down);
					}
					else
					{
						MessageBox.Show("Сначала создайте зенитку!!");
						return;
					}
					break;
				case "buttonLeft":
					if (liner != null)
					{
						liner.MoveLiner(Direction.Left);
					}
					else
					{
						MessageBox.Show("Сначала создайте зенитку!!");
						return;
					}
					break;
				case "buttonRight":
					if (liner != null)
					{
						liner.MoveLiner(Direction.Right);
					}
					else
					{
						MessageBox.Show("Сначала создайте зенитку!!");
						return;
					}
					break;

			}

			Draw();
		}
    }
}
