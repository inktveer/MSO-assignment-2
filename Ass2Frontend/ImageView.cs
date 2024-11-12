using System;
using System.Runtime.CompilerServices;
using Backend;
using Cairo;
using Gtk;
using Grid = Gtk.Grid;

namespace Ass2Frontend
{
    public class ImageView : Grid {
        private Image[,] images;
        private int      tilesize = 30;
        private int      X;
        private int      Y;
        
        public ImageView(int x, int y) {
            SetSizeRequest(x * tilesize, y * tilesize);
            
        }

        public void Redraw(Trace trace, Backend.Grid grid) {
            for (int x = 0; x < X; x++) {
                for (int y = 0; y < Y; y++) {
                    Attach(getImage(grid[x,y]), x, y, tilesize, tilesize);
                }
            }
        }

        private Image getImage(Backend.Grid.Tile tile) {
            return new Image();
        }
        
    }
}