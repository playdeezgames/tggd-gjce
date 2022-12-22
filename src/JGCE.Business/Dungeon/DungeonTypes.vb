Imports System.Runtime.CompilerServices

Public Enum DungeonTypes
    None
    Paper
    Cardboard
    Ribbon
    Tape
    Macguffin
End Enum
Public Module DungeonTypesExtensions
    Private ReadOnly _names As IReadOnlyDictionary(Of DungeonTypes, String) =
        New Dictionary(Of DungeonTypes, String) From
        {
            {DungeonTypes.None, "n/a"},
            {DungeonTypes.Paper, "paper"},
            {DungeonTypes.Cardboard, "cardboard"},
            {DungeonTypes.Ribbon, "ribbon"},
            {DungeonTypes.Tape, "tape"},
            {DungeonTypes.Macguffin, "macguffin"}
        }
    <Extension>
    Function Name(dungeonType As DungeonTypes) As String
        Return _names(dungeonType)
    End Function
    Private ReadOnly _spawnCheck As IReadOnlyDictionary(Of DungeonTypes, IReadOnlyDictionary(Of Boolean, Integer)) =
        New Dictionary(Of DungeonTypes, IReadOnlyDictionary(Of Boolean, Integer)) From
        {
            {DungeonTypes.Ribbon, New Dictionary(Of Boolean, Integer) From {{False, 1}, {True, 1}}},
            {DungeonTypes.Paper, New Dictionary(Of Boolean, Integer) From {{False, 1}, {True, 1}}},
            {DungeonTypes.Cardboard, New Dictionary(Of Boolean, Integer) From {{False, 1}, {True, 1}}},
            {DungeonTypes.Tape, New Dictionary(Of Boolean, Integer) From {{False, 1}, {True, 1}}},
            {DungeonTypes.Macguffin, New Dictionary(Of Boolean, Integer) From {{False, 1}, {True, 1}}}
        }
    Private ReadOnly _spawnGenerator As IReadOnlyDictionary(Of DungeonTypes, IReadOnlyDictionary(Of CharacterTypes, Integer)) =
        New Dictionary(Of DungeonTypes, IReadOnlyDictionary(Of CharacterTypes, Integer)) From
        {
            {DungeonTypes.Paper, New Dictionary(Of CharacterTypes, Integer) From {{CharacterTypes.WrappingPaperRat, 1}}},
            {DungeonTypes.Ribbon, New Dictionary(Of CharacterTypes, Integer) From {{CharacterTypes.RibbonSnake, 1}}},
            {DungeonTypes.Cardboard, New Dictionary(Of CharacterTypes, Integer) From {{CharacterTypes.CardboardGoblin, 1}}},
            {DungeonTypes.Tape, New Dictionary(Of CharacterTypes, Integer) From {{CharacterTypes.TapeSpider, 1}}},
            {DungeonTypes.Macguffin, New Dictionary(Of CharacterTypes, Integer) From {{CharacterTypes.GiftBats, 1}}}
        }
    <Extension>
    Sub AttemptSpawn(dungeonType As DungeonTypes, worldData As WorldData, world As IWorld, location As ILocation)
        If Not _spawnCheck.ContainsKey(dungeonType) Then
            Return
        End If
        If Not RNG.FromGenerator(_spawnCheck(dungeonType)) Then
            Return
        End If
        Dim characterType = RNG.FromGenerator(_spawnGenerator(dungeonType))
        Character.Create(worldData, world, location, characterType)
    End Sub
End Module
