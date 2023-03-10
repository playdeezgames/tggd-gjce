Public Interface ICharacter
    Inherits IThingie
    ReadOnly Property IsAlive As Boolean
    Property Location As ILocation
    Sub AttemptMove(direction As Directions)
    Sub AddMessage(message As String)
    Function CanTalk(targetCharacter As ICharacter) As Boolean
    Sub Talk(targetCharacter As ICharacter)
    Function HasCompleted(questType As QuestTypes) As Boolean
    Function CanComplete(questType As QuestTypes) As Boolean
    Function HasStarted(questType As QuestTypes) As Boolean
    Function HasItemType(itemType As ItemTypes) As Boolean
    Sub Complete(questType As QuestTypes)
    Sub Start(questType As QuestTypes)
    Sub AttemptTake(items As IEnumerable(Of IItem))
    Sub AttemptDrop(items As IEnumerable(Of IItem))
    ReadOnly Property ItemsOfType(itemType As ItemTypes) As IEnumerable(Of IItem)
    ReadOnly Property HasQuests As Boolean
    ReadOnly Property HasItems As Boolean
    ReadOnly Property CharacterType As CharacterTypes
    ReadOnly Property Items As IEnumerable(Of IItem)
    ReadOnly Property StartedQuests As IEnumerable(Of QuestTypes)
    ReadOnly Property CompletedQuests As IEnumerable(Of QuestTypes)
End Interface
