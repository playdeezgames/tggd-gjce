Module GroundProcessor
    Friend Sub Run(world As IWorld)
        Dim location = world.PlayerCharacter.Location
        Do
            AnsiConsole.Clear()
            ShowMessages(world)
            Dim itemGroups = location.Items.GroupBy(Function(x) x.ItemType)
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]On the Ground:[/]"}
            prompt.AddChoice(GoBackText)
            Dim table = itemGroups.ToDictionary(Function(x) $"{x.Key.Name}(x{x.Count})", Function(x) x.Key)
            prompt.AddChoices(table.Keys)
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case GoBackText
                    Exit Do
                Case Else
                    Dim itemType = table(answer)
                    Dim itemGroup = itemGroups(itemType)
                    Dim quantity = If(itemGroup.Count > 1, AnsiConsole.Ask("[olive]How many?[/]", itemGroup.Count), 1)
                    quantity = Math.Clamp(quantity, 0, itemGroup.Count)
                    Dim items = itemGroup.Take(quantity)
                    world.PlayerCharacter.AttemptTake(items)
                    If Not location.HasItems Then
                        Exit Do
                    End If
            End Select
        Loop
    End Sub
End Module
