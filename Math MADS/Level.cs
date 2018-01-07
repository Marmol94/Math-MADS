using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_MADS
{
    public class Level:System.Windows.Forms.Panel
    {
        public void InitializeLevel(Main main)
        {
            
            main.Controls.Add(this);
            BackColor = System.Drawing.Color.Transparent;
            BackgroundImage = global::Math_MADS.Properties.Resources.Galaxy;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            Dock = System.Windows.Forms.DockStyle.Fill;
            ForeColor = System.Drawing.Color.Transparent;
            Location = new System.Drawing.Point(0, 0);
            Margin = new System.Windows.Forms.Padding(0);
            Size = new System.Drawing.Size(1005, 721);
        }

        public bool WasFinishedBefore(bool finish)
        {
            return finish;
        }
    }
}
