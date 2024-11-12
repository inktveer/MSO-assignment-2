using Gtk;
using Pango;
using WrapMode = Gtk.WrapMode;

namespace Ass2Frontend;

public class Textview : TextView {
    public Textview() {
        WrapMode      = WrapMode.Word;
        Justification = Justification.Left;
        AcceptsTab    = false;
        ModifyFont(FontDescription.FromString("Roboto Mono 16"));
    }
    
    
}