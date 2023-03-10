Friend Module MainMenuProcessor
    Friend Sub Run()
        Do
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Main Menu:[/]"}
            prompt.AddChoices(StartGameText, QuitText)
            Select Case AnsiConsole.Prompt(prompt)
                Case QuitText
                    If ConfirmProcessor.Run("[red]Are you sure you want to quit?[/]") Then
                        Exit Do
                    End If
                Case StartGameText
                    InPlayProcessor.Run(World.Create())
            End Select
        Loop
    End Sub
End Module
