Module InPlayProcessor
    Friend Sub Run(world As IWorld)
        Do
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine("Yer totally playing the game!")
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            prompt.AddChoice(GameMenuText)
            Select Case AnsiConsole.Prompt(prompt)
                Case GameMenuText
                    If Not GameMenuProcessor.Run() Then
                        Exit Do
                    End If
            End Select
        Loop
    End Sub
End Module
