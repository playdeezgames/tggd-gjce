Friend Module MoveProcessor
    Friend Sub Run(world As IWorld)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Which way?[/]"}
        prompt.AddChoice(GoBackText)
        Dim table = world.PlayerCharacter.Location.Routes.ToDictionary(Function(x) x.Direction.Name, Function(x) x.Direction)
        prompt.AddChoices(table.Keys)
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case GoBackText
                'do nothing
            Case Else
                world.PlayerCharacter.AttemptMove(table(answer))
        End Select
    End Sub
End Module
