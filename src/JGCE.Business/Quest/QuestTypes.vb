Imports System.Runtime.CompilerServices
Public Enum QuestTypes
    MainQuest
End Enum
Public Module QuestTypesExtensions
    Private ReadOnly _canComplete As IReadOnlyDictionary(Of QuestTypes, Func(Of ICharacter, Boolean)) =
        New Dictionary(Of QuestTypes, Func(Of ICharacter, Boolean)) From
        {
            {QuestTypes.MainQuest, AddressOf MainQuestCanComplete}
        }
    Private Function MainQuestCanComplete(character As ICharacter) As Boolean
        Return character.HasItemType(ItemTypes.Gift)
    End Function
    <Extension>
    Friend Function CanComplete(questType As QuestTypes, character As ICharacter) As Boolean
        Return _canComplete(questType)(character)
    End Function
    Private ReadOnly _onStart As IReadOnlyDictionary(Of QuestTypes, Action(Of ICharacter)) =
        New Dictionary(Of QuestTypes, Action(Of ICharacter)) From
        {
            {QuestTypes.MainQuest, AddressOf MainQuestOnStart}
        }
    Private Sub MainQuestOnStart(character As ICharacter)
        character.AddMessage("""Today is Gift Day, as you know!""")
        character.AddMessage("""I hope you remembered!""")
        character.AddMessage("(You did not remember.)")
        character.AddMessage("(Yer gonna need to find a gift!)")
    End Sub
    <Extension>
    Friend Sub OnStart(questType As QuestTypes, character As ICharacter)
        _onStart(questType)(character)
    End Sub
    Private ReadOnly _onComplete As IReadOnlyDictionary(Of QuestTypes, Action(Of ICharacter)) =
        New Dictionary(Of QuestTypes, Action(Of ICharacter)) From
        {
            {QuestTypes.MainQuest, AddressOf MainQuestOnComplete}
        }

    Private Sub MainQuestOnComplete(character As ICharacter)
        character.AddMessage("""Thanks! It was exactly what I hoped for!""")
        character.AddMessage("""Sorry I didn't get you anything in return! I forgot.""")
    End Sub

    <Extension>
    Friend Sub OnComplete(questType As QuestTypes, character As ICharacter)
        _onComplete(questType)(character)
    End Sub
    Private ReadOnly _names As IReadOnlyDictionary(Of QuestTypes, String) =
        New Dictionary(Of QuestTypes, String) From
        {
            {QuestTypes.MainQuest, "Acquire a gift for yer love interest."}
        }
    <Extension>
    Public Function Name(questType As QuestTypes) As String
        Return _names(questType)
    End Function
End Module
