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
    /// <summary>
    /// Klasa platform
    /// </summary>
    public partial class Platform :System.Windows.Forms.PictureBox
    {
        /// <summary>
        /// Metoda inicjalizacji platformy o określonych parametrach
        ///Gdy isFloor=true, program generuje platformę o określonych parametrach, która odpowiada za podłogę na poziomie 
        ///
        /// </summary>
        /// <param name="platformX">Lewa współrzędna platformy</param>
        /// <param name="platformY">Górna współrzędna platformy</param>
        /// <param name="platformWidth">Szerokość platformy</param>
        /// <param name="platformHeight">Wysokość platformy</param>
        /// <param name="isFloor">czy platforma jest podloga</param>
        /// <param name="level">poziom</param>
        public void InitializePlatform(int platformX, int platformY,int platformWidth,int platformHeight, bool isFloor, Level level)
        {

            if (isFloor)
            {
                Size = new System.Drawing.Size(1005, 37);
                Location = new System.Drawing.Point(0, 684);
                Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
                Dock = System.Windows.Forms.DockStyle.Bottom;
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            }
            else
            {
                Location = new System.Drawing.Point(platformX, platformY);
                Size = new System.Drawing.Size(platformWidth, platformHeight);
            }
            level.Controls.Add(this);
            BackgroundImage = global::Math_MADS.Properties.Resources.text1;
            BackgroundImageLayout = ImageLayout.Tile;
        }
    }

}
