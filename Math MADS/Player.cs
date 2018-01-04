using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_MADS
{
    public partial class Player: System.Windows.Forms.PictureBox
    {
        public void InitializePlayer()
        {
            Left = 0;
            Top = -10;
            Image = global::Math_MADS.Properties.Resources.przod;
            Size = new System.Drawing.Size(28, 63);
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Location = new System.Drawing.Point(0, 478 );
            

        }
    }
}
