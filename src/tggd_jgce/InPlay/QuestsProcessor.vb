Module QuestsProcessor
    Friend Sub Run(world As IWorld)
        Dim character = world.PlayerCharacter
        Dim startedQuests = character.StartedQuests
        If startedQuests.any Then
            AnsiConsole.MarkupLine("[yellow]Started Quests:[/]")
            For Each quest In startedQuests
                AnsiConsole.MarkupLine($"* {quest.Name}")
            Next
        End If
        Dim completedQuests = character.CompletedQuests
        If completedQuests.any Then
            AnsiConsole.MarkupLine("[lime]Completed Quests:[/]")
            For Each quest In completedQuests
                AnsiConsole.MarkupLine($"* {quest.Name}")
            Next
        End If
        OkPrompt()
    End Sub
End Module
