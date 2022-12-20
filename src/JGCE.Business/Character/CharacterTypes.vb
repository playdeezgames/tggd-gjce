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
    Private ReadOnly _canTalk As IReadOnlyDictionary(Of CharacterTypes, Func(Of ICharacter, ICharacter, Boolean)) =
        New Dictionary(Of CharacterTypes, Func(Of ICharacter, ICharacter, Boolean)) From
        {
            {CharacterTypes.Protagonist, AddressOf CanProtagonistTalk}
        }
    Private Function CanProtagonistTalk(fromCharacter As ICharacter, toCharacter As ICharacter) As Boolean
        Return toCharacter.CharacterType = CharacterTypes.LoveInterest
    End Function
    <Extension>
    Public Function CanTalk(characterType As CharacterTypes, fromCharacter As ICharacter, toCharacter As ICharacter) As Boolean
        If _canTalk.ContainsKey(characterType) Then
            Return _canTalk(characterType)(fromCharacter, toCharacter)
        End If
        Return False
    End Function
End Module