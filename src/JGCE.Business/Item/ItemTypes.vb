Imports System.Runtime.CompilerServices

Public Enum ItemTypes
    Gift
End Enum
Public Module ItemTypesExtensions
    Private ReadOnly _names As IReadOnlyDictionary(Of ItemTypes, String) =
        New Dictionary(Of ItemTypes, String) From
        {
            {ItemTypes.Gift, "gift"}
        }
    <Extension>
    Public Function Name(itemType As ItemTypes) As String
        Return _names(itemType)
    End Function
End Module
