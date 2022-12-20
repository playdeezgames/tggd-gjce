Imports System.Runtime.CompilerServices

Public Enum CharacterTypes
    Protagonist
    LoveInterest
End Enum
Public Module CharacterTypesExtensions
    Private ReadOnly _names As IReadOnlyDictionary(Of CharacterTypes, String) =
        New Dictionary(Of CharacterTypes, String) From
        {
            {CharacterTypes.Protagonist, "you"},
            {CharacterTypes.LoveInterest, "yer love interest"}
        }
    <Extension>
    Public Function Name(characterType As CharacterTypes) As String
        Return _names(characterType)
    End Function
End Module