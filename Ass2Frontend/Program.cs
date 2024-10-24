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
        structure.BorderWidth = 30;
        main.Add(structure);

        HBox menu    = new HBox(false, 20);
        HBox content = new HBox(false, 20);
        structure.Add(menu);
        structure.Add(content);
        menu.HeightRequest    = 50;
        menu.WidthRequest     = 400;
        content.HeightRequest = 500;
        content.WidthRequest  = 400;

        Button menu1    = new Button();
        Button menu2    = new Button();
        Button menu3    = new Button();
        Button content1 = new Button();
        Button content2 = new Button();
        Button content3 = new Button();
        menu.Add(menu1);
        menu.Add(menu2);
        menu.Add(menu3);
        content.Add(content1);
        content.Add(content2);

        
        Ass2.Program backend = new Ass2.Program();
        

        
        
        main.ShowAll();
        Application.Run();
    }
}
