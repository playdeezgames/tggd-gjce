Friend Module GameMenuProcessor
    Friend Function Run() As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Game Menu:[/]"}
        prompt.AddChoices(GoBackText, AbandonGameText)
        Select Case AnsiConsole.Prompt(prompt)
            Case AbandonGameText
                If ConfirmProcessor.Run("[red]Are you sure you want to abandon the game?[/]") Then
                    Return False
                End If
        End Select
        Return True
    End Function
End Module
