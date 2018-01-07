using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_MADS
{
    public class Menu: System.Windows.Forms.Panel
    {
        
        public void InitializeMenu(Main main)
        {
            main.Controls.Add(this);
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            BackColor = System.Drawing.Color.White;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         
            Dock = System.Windows.Forms.DockStyle.Fill;
            Location = new System.Drawing.Point(0, 0);
            
            Size = new System.Drawing.Size(1005, 721);
            TabIndex = 17;

        }

        public void AddControl(int LocX, int LocY, MenuControl control)
        {
           Controls.Add(control);
        }
        
    }
}