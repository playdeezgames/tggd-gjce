Friend Module TitleProcessor
    Friend Sub Run()
        Console.Title = "Gift of SPLORR!!"
        AnsiConsole.Clear()
        Dim figlet As New FigletText("Gift of SPLORR!!") With {.Color = Color.Yellow, .Alignment = Justify.Center}
        AnsiConsole.Write(figlet)
        AnsiConsole.MarkupLine("[red]               ,@@@@@,                 (@@@@@               
              @@(    ,@@@          ,@@@.    @@#             
               @@        @@@     @@@        @@              
                @@@                       @@@               
                   @@@@@   @@@@@@@   @@@@@[/][lime]                  
                                                            
         @@@@@@@@@@@@@@@@@  [/][red]@@@@@[/][lime]  @@@@@@@@@@@@@@@@@        
         @@@@@@@@@@@@@@@@@  [/][red]@@@@@[/][lime]  @@@@@@@@@@@@@@@@@        
                            [/][red]@@@@@[/][lime]                           
             @@@@@@@@@@@@@  [/][red]@@@@@[/][lime]  @@@@@@@@@@@@@            
             @@@@@@@@@@@@@  [/][red]@@@@@[/][lime]  @@@@@@@@@@@@@            
             @@@@@@@@@@@@@  [/][red]@@@@@[/][lime]  @@@@@@@@@@@@@            
             @@@@@@@@@@@@@  [/][red]@@@@@[/][lime]  @@@@@@@@@@@@@            
             @@@@@@@@@@@@@  [/][red]@@@@@[/][lime]  @@@@@@@@@@@@@            
             @@@@@@@@@@@@@  [/][red]@@@@@[/][lime]  @@@@@@@@@@@@@            
             @@@@@@@@@@@@@  [/][red]@@@@@[/][lime]  @@@@@@@@@@@@@            
             @@@@@@@@@@@@@  [/][red]@@@@@[/][lime]  @@@@@@@@@@@@@            
             @@@@@@@@@@@@@  [/][red]@@@@@[/][lime]  @@@@@@@@@@@@@            
             @@@@@@@@@@@@@  [/][red]@@@@@[/][lime]  @@@@@@@@@@@@@            [/]")
        AnsiConsole.MarkupLine("A Production of TheGrumpyGameDev - https://www.twitch.tv/thegrumpygamedev")
        AnsiConsole.MarkupLine("For Jame Game Christmas Edition - https://itch.io/jam/jame-gam-christmas-edition")
        Dim prompt As New SelectionPrompt(Of String) With {.Title = String.Empty}
        prompt.AddChoice("Ok")
        AnsiConsole.Prompt(prompt)
    End Sub
End Module
