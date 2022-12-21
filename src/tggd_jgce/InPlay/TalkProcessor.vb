Friend Module TalkProcessor
    Friend Sub Run(world As IWorld)
        Dim playerCharacter = world.PlayerCharacter
        Dim targets = playerCharacter.Location.Characters.Where(Function(x) playerCharacter.CanTalk(x))
        Select Case targets.Count
            Case 0
                Return
            Case 1
                TalkOneProcessor.Run(world, targets.Single)
            Case Else
                Dim table = targets.ToDictionary(Function(x) x.CharacterType.Name, Function(x) x)
                Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Talk To Whom?[/]"}
                prompt.AddChoice(GoBackText)
                prompt.AddChoices(table.Keys)
                Dim answer = AnsiConsole.Prompt(prompt)
                Select Case answer
                    Case GoBackText
                        'do nothing
                    Case Else
                        TalkOneProcessor.Run(world, table(answer))
                End Select
        End Select
    End Sub
End Module
