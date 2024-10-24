using Gtk;

namespace Ass2Frontend;

using System;
using GtkSharp;

class Program {
    static void Main(string[] args) {
        Application.Init();

        Window main = new Window("LearningApp");
        main.Resize(700, 700);
        
        VBox structure = new VBox(false, 10);
        structure.BorderWidth = 10;
        main.Add(structure);
        
        Button test1 = Button.NewWithLabel("test one");
        Button test2 = Button.NewWithLabel("test two");
        structure.Add(test1);
        structure.Add(test2);

        Ass2.Program backend = new Ass2.Program();

        
        
        main.ShowAll();
        Application.Run();
    }
}
