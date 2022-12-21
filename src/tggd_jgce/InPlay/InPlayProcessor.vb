Imports System.Runtime.Serialization

Module InPlayProcessor
    Friend Sub Run(world As IWorld)
        Do
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            ShowMessages(world)
            ShowStatus(world, prompt)
            prompt.AddChoice(GameMenuText)
            Select Case AnsiConsole.Prompt(prompt)
                Case GameMenuText
                    If Not GameMenuProcessor.Run() Then
                        Exit Do
                    End If
                Case GroundText
                    GroundProcessor.Run(world)
                Case InventoryText
                    InventoryProcessor.Run(world)
                Case MoveText
                    MoveProcessor.Run(world)
                Case QuestsText
                    QuestsProcessor.Run(world)
                Case TalkText
                    TalkProcessor.Run(world)
            End Select
        Loop
    End Sub

    Private Sub ShowMessages(world As IWorld)
        For Each message In world.Messages
            AnsiConsole.MarkupLine(message)
        Next
        world.ClearMessages()
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
        Dim character = world.PlayerCharacter
        Dim location = character.Location
        ShowCharacters(prompt, location, character)
        ShowRoutes(prompt, location)
        ShowGround(prompt, location)
        If character.HasQuests Then
            prompt.AddChoice(QuestsText)
        End If
        If character.HasItems Then
            prompt.AddChoice(InventoryText)
        End If
    End Sub

    Private Sub ShowGround(prompt As SelectionPrompt(Of String), location As ILocation)
        If location.HasItems Then
            AnsiConsole.MarkupLine("There are items on the ground.")
            prompt.AddChoice(GroundText)
        End If
    End Sub

    Private Sub ShowCharacters(prompt As SelectionPrompt(Of String), location As ILocation, playerCharacter As ICharacter)
        Dim characters = location.Characters
        If characters.Any Then
            AnsiConsole.MarkupLine($"Characters: {String.Join(", ", characters.Select(Function(x) x.CharacterType.Name))}")
            If characters.Any(Function(x) playerCharacter.CanTalk(x)) Then
                prompt.AddChoice(TalkText)
            End If
        End If
    End Sub

    Private Sub ShowRoutes(prompt As SelectionPrompt(Of String), location As ILocation)
        Dim routes = location.Routes
        If routes.Any Then
            AnsiConsole.MarkupLine($"Exits: {String.Join(", ", routes.Select(Function(x) $"{x.RouteType.Name} going {x.Direction.Name}"))}")
            prompt.AddChoices(MoveText)
        End If
    End Sub
End Module
