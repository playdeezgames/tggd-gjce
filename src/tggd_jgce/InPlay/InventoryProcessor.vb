Module InventoryProcessor
    Friend Sub Run(world As IWorld)
        Dim character = world.PlayerCharacter
        Do
            Dim itemGroups = character.Items.GroupBy(Function(x) x.ItemType)
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]In Yer Inventory:[/]"}
            prompt.AddChoice(GoBackText)
            Dim table = itemGroups.ToDictionary(Function(x) $"{x.Key.Name}(x{x.Count})", Function(x) x.Key)
            prompt.AddChoices(table.Keys)
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case GoBackText
                    Exit Do
                Case Else
            End Select
        Loop
    End Sub
End Module
