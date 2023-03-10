Imports System.Runtime.CompilerServices

Public Enum RouteTypes
    Street
    Door
    DungeonCorridor
    Stairs
End Enum
Public Module RouteTypesExtensions
    Private ReadOnly _names As IReadOnlyDictionary(Of RouteTypes, String) =
        New Dictionary(Of RouteTypes, String) From
        {
            {RouteTypes.Street, "street"},
            {RouteTypes.Door, "door"},
            {RouteTypes.DungeonCorridor, "corridor"},
            {RouteTypes.Stairs, "stairs"}
        }
    <Extension>
    Public Function Name(routeType As RouteTypes) As String
        Return _names(routeType)
    End Function
End Module
