Module InPlayProcessor
    Friend Sub Run(world As IWorld)
        Do
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            ShowStatus(world, prompt)
            prompt.AddChoice(GameMenuText)
            Select Case AnsiConsole.Prompt(prompt)
                Case GameMenuText
                    If Not GameMenuProcessor.Run() Then
                        Exit Do
                    End If
            End Select
        Loop
    End Sub

    Private Sub ShowStatus(world As IWorld, prompt As SelectionPrompt(Of String))
        If world.PlayerCharacter.IsAlive Then
            ShowAliveStatus(world, prompt)
        Else
            ShowDeadStatus(world, prompt)
        End If
    End Sub

    Private Sub ShowDeadStatus(world As IWorld, prompt As SelectionPrompt(Of String))
        AnsiConsole.MarkupLine("[red]Yer totally dead![/]")
    End Sub

    Private Sub ShowAliveStatus(world As IWorld, prompt As SelectionPrompt(Of String))
        AnsiConsole.MarkupLine("Yer totally alive!")
        Dim location = world.PlayerCharacter.Location
        AnsiConsole.MarkupLine($"Exits: {String.Join(", ", location.Routes.Select(Function(x) x.Direction.Name))}")
    End Sub
End Module
