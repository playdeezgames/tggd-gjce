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
        Return _canTalk(characterType)(fromCharacter, toCharacter)
    End Function
    Private ReadOnly _talk As IReadOnlyDictionary(Of CharacterTypes, Action(Of ICharacter, ICharacter)) =
        New Dictionary(Of CharacterTypes, Action(Of ICharacter, ICharacter)) From
        {
            {CharacterTypes.Protagonist, AddressOf ProtagonistTalk}
        }
    Private Sub ProtagonistTalk(fromCharacter As ICharacter, toCharacter As ICharacter)
        Select Case toCharacter.CharacterType
            Case CharacterTypes.LoveInterest
                ProtagonistTalkLoveInterest(fromCharacter, toCharacter)
            Case Else
                Throw New NotImplementedException
        End Select
    End Sub
    Private Sub ProtagonistTalkLoveInterest(fromCharacter As ICharacter, toCharacter As ICharacter)
        If fromCharacter.HasCompleted(QuestTypes.MainQuest) Then
            fromCharacter.AddMessage("Thank you for the lovely gift!")
        ElseIf fromCharacter.CanComplete(QuestTypes.MainQuest) Then
            fromCharacter.Complete(QuestTypes.MainQuest)
        ElseIf fromCharacter.HasStarted(QuestTypes.MainQuest) Then
            fromCharacter.AddMessage("I can't wait to see what you got me!")
        Else
            fromCharacter.Start(QuestTypes.MainQuest)
        End If
    End Sub
    <Extension>
    Public Sub Talk(characterType As CharacterTypes, fromCharacter As ICharacter, toCharacter As ICharacter)
        If characterType.CanTalk(fromCharacter, toCharacter) Then
            _talk(characterType)(fromCharacter, toCharacter)
        End If
    End Sub
End Module