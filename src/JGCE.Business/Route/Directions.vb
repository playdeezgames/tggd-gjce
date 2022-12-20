Imports System.Runtime.CompilerServices

Public Enum Directions
    North
    East
    South
    West
    Up
    Down
    Inward
    Outward
End Enum
Public Module DirectionsExtensions
    Private ReadOnly _names As IReadOnlyDictionary(Of Directions, String) =
        New Dictionary(Of Directions, String) From
        {
            {Directions.North, "north"},
            {Directions.East, "east"},
            {Directions.South, "south"},
            {Directions.West, "west"},
            {Directions.Up, "up"},
            {Directions.Down, "down"},
            {Directions.Inward, "in"},
            {Directions.Outward, "out"}
        }
    <Extension>
    Public Function Name(direction As Directions) As String
        Return _names(direction)
    End Function
End Module