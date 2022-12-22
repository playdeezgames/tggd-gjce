Friend Module InventoryItemProcessor
    Friend Sub Run(world As IWorld, itemType As ItemTypes)
        Dim character = world.PlayerCharacter
        Do
            AnsiConsole.Clear()
            ShowMessages(world)
            Dim items = character.ItemsOfType(itemType)
            AnsiConsole.MarkupLine($"You currently have {items.Count} {itemType.Name}.")
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            prompt.AddChoice(GoBackText)
            prompt.AddChoice(DropText)
            Select Case AnsiConsole.Prompt(prompt)
                Case DropText
                    Dim quantity = If(items.Count > 1, AnsiConsole.Ask("[olive]How many?[/]", items.Count), 1)
                    quantity = Math.Clamp(quantity, 0, items.Count)
                    Dim itemsToDrop = items.Take(quantity)
                    world.PlayerCharacter.AttemptDrop(itemsToDrop)
                    If Not world.PlayerCharacter.HasItemType(itemType) Then
                        Exit Do
                    End If
                Case GoBackText
                    Exit Do
            End Select
        Loop
    End Sub
End Module
