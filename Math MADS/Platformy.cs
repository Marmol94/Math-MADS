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
    public partial class Platformy
    {
         PictureBox Plat=new PictureBox();
        public void Init(int x, int y, int h, int w, string nazwa, Panel panel)
        {
            
            Plat.BackColor = System.Drawing.Color.Green;
            Plat.Location = new System.Drawing.Point(x, y);
            Plat.Name = nazwa;
            Plat.Size = new System.Drawing.Size(w, h);
        
        }
    }
}
