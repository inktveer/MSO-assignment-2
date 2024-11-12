using System;
using System.Runtime.CompilerServices;
using Backend;
using Cairo;
using Gtk;
using Grid = Gtk.Grid;

namespace Ass2Frontend
{
    public class ImageView : Grid {
        private int       x;
        private int       y;
        private Image[][] images;
        
        public ImageView(int xSize, int ySize) {
            x = xSize;
            y = ySize;
            
        }

        public void Redraw() {
            
        }
        
    }
}