Module InPlayProcessor
    Friend Sub Run(world As IWorld)
        Do
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            If world.PlayerCharacter.IsAlive Then
                AnsiConsole.MarkupLine("Yer totally alive!")
            Else
                AnsiConsole.MarkupLine("[red]Yer totally dead![/]")
            End If
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
