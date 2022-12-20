Imports System.Runtime.CompilerServices

Public Enum RouteTypes
    Street
End Enum
Public Module RouteTypesExtensions
    Private ReadOnly _names As IReadOnlyDictionary(Of RouteTypes, String) =
        New Dictionary(Of RouteTypes, String) From
        {
            {RouteTypes.Street, "street"}
        }
    <Extension>
    Public Function Name(routeType As RouteTypes) As String
        Return _names(routeType)
    End Function
End Module
