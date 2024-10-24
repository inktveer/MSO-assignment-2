using Gtk;

namespace Ass2Frontend;

using System;
using GtkSharp;

class Program {
    static void Main(string[] args) {
        Application.Init();

        Window main = new Window("LearningApp");
        main.Resize(700, 700);
        
        VBox structure = new VBox(false, 0);
        main.Add(structure);
        
        Button test1 = Button.NewWithLabel("test one");
        Button test2 = Button.NewWithLabel("test two");
        test1.BorderWidth = 10;
        test2.BorderWidth = 10;
        structure.Add(test1);
        structure.Add(test2);


        main.ShowAll();
        Application.Run();
    }
}

// using System;
// using Gtk;
// namespace Gtk_Test;
//
// class GtkHelloWorld {
//     public static void Main() {
//         Application.Init();
//         
//         Window helloworld = new Window("My first GTK application");
//         helloworld.Resize(400,400);
//         
//         // Label first = Label.New("Hello, World! This is also a test to see if this window will look pretty or not, so let's see!");
//         // helloworld.Add(first);
//         
//         HBox box     = new HBox(false, 10);
//         helloworld.Add(box);
//
//         Button test1 = Button.NewWithLabel("test one");
//         Button test2 = Button.NewWithLabel("test two");
//         box.Add(test1);
//         box.Add(test2);
//         
//         
//         helloworld.ShowAll();
//         Application.Run();
//     }
// }