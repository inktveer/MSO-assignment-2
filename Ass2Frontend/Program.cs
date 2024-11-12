using Gtk;
using System;
using Backend;

class LearningAppWindow : Window {
 

    public LearningAppWindow(Compiler backend) : base("Toolbars") {
        Compiler Backend = backend;
        Title = "LearningApp"; 
        SetPosition(WindowPosition.Center);
        SetDefaultSize(700, 700);  
        
        // Main structure; a VBox which holds all the different subcontainers. 
        VBox structure = new VBox(false, 10);
        structure.BorderWidth = 20;
        Add(structure); 
        
        // Create the main containers. These fit the different modules of the program.
        HBox menu    = new HBox(false, 20);
        HBox content = new HBox(false, 20);
        structure.PackStart(menu,    false, false, 0); 
        structure.PackStart(content, true,  true,  0); 
        
        // Set sizes
        menu.HeightRequest    = 50;
        menu.WidthRequest     = 400;
        content.HeightRequest = 500;
        content.WidthRequest  = 400;
        
        DeleteEvent += delegate { Application.Quit(); };
        
        // Upper toolbar
        Toolbar upper = new Toolbar();
        upper.ToolbarStyle = ToolbarStyle.Icons;
        
        ToolButton load = new ToolButton(Stock.Open);
        load.Clicked += LoadContent;
        ToolButton run  = new ToolButton(Stock.Ok);
        run.Clicked += RunProgram;
        ToolButton quit = new ToolButton(Stock.Quit);
        quit.Clicked += Quit;
        
        upper.Insert(load, 0);
        upper.Insert(run, 1);
        upper.Insert(quit,2);
        

        // Add toolbars to menu
        VBox toolbarBox = new VBox(false, 2);
        toolbarBox.PackStart(upper, false, false, 0);
        menu.PackStart(toolbarBox, false, false, 0);  
        
        // Content buttons for testing purposes
        Button content1 = new Button("Content 1"); 
        Button content2 = new Button("Content 2");
        content.PackStart(content1, true, true, 0);  
        content.PackStart(content2, true, true, 0);
        
        ShowAll();
    }

    void LoadContent(object sender, EventArgs args) {
        
    }

    void RunProgram(object sender, EventArgs args) {
        
    }

    void Quit(object sender, EventArgs args)
    {
        Application.Quit();
    }


    public static void Main() {
        Compiler backend = new Compiler();
        Application.Init();
        new LearningAppWindow(backend);
        Application.Run();
    }
}