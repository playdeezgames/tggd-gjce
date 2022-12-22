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
End Module
