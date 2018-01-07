using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_MADS
{
    public class MenuControl:System.Windows.Forms.PictureBox
    {
        public void InitializeChooser(Menu menu)
        {

            Image = Properties.Resources.przod;
            Location = new System.Drawing.Point(180,110);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Size = new System.Drawing.Size(45, 50);
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            Visible = true;
            menu.Controls.Add(this);
            BackColor = Color.Transparent;
        }
        public void InitializeOption( int LocX,int LocY, Menu menu, System.Drawing.Image image)
        {

            Image = image;
            Location = new System.Drawing.Point(LocX, LocY);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Size = new System.Drawing.Size(180, 90);
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            Visible = true;
            menu.Controls.Add(this);
            BackColor = Color.Transparent;
        }


        public void ChangeControlPositionUp()
        {
            Location = new System.Drawing.Point(this.Left, this.Top - 100);

        }
        public void ChangeControlPositionDown()
        {
            Location = new System.Drawing.Point(this.Left, this.Top + 100);

        }
        public void ChangeControlPositionLeft()
        {
            Location = new System.Drawing.Point(this.Left-100, this.Top);

        }
        public void ChangeControlPositionRight()
        {
            Location = new System.Drawing.Point(this.Left+100, this.Top);

        }
    }
}
