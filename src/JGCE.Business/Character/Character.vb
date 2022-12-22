Public Class Character
    Inherits Thingie
    Implements ICharacter

    Public Sub New(worldData As WorldData, world As World, id As Integer)
        MyBase.New(worldData, world, id)
    End Sub

    Public ReadOnly Property IsAlive As Boolean Implements ICharacter.IsAlive
        Get
            Return True
        End Get
    End Property

    Public Property Location As ILocation Implements ICharacter.Location
        Get
            Return New Location(WorldData, World, WorldData.Characters(Id).LocationId)
        End Get
        Set(value As ILocation)
            WorldData.Characters(Id).LocationId = value.Id
        End Set
    End Property

    Public ReadOnly Property CharacterType As CharacterTypes Implements ICharacter.CharacterType
        Get
            Return CType(WorldData.Characters(Id).CharacterType, CharacterTypes)
        End Get
    End Property

    Public ReadOnly Property Items As IEnumerable(Of IItem) Implements ICharacter.Items
        Get
            Return WorldData.Characters(Id).ItemIds.Select(Function(x) New Item(WorldData, World, x))
        End Get
    End Property

    Public ReadOnly Property HasQuests As Boolean Implements ICharacter.HasQuests
        Get
            Return WorldData.Characters(Id).StartedQuestTypes.Any OrElse WorldData.Characters(Id).CompletedQuestTypes.Any
        End Get
    End Property

    Public ReadOnly Property HasItems As Boolean Implements ICharacter.HasItems
        Get
            Return WorldData.Characters(Id).ItemIds.Any
        End Get
    End Property

    Public ReadOnly Property StartedQuests As IEnumerable(Of QuestTypes) Implements ICharacter.StartedQuests
        Get
            Return WorldData.Characters(Id).StartedQuestTypes.Select(Function(x) CType(x, QuestTypes))
        End Get
    End Property

    Public ReadOnly Property CompletedQuests As IEnumerable(Of QuestTypes) Implements ICharacter.CompletedQuests
        Get
            Return WorldData.Characters(Id).CompletedQuestTypes.Select(Function(x) CType(x, QuestTypes))
        End Get
    End Property

    Public ReadOnly Property ItemsOfType(itemType As ItemTypes) As IEnumerable(Of IItem) Implements ICharacter.ItemsOfType
        Get
            Return Items.Where(Function(x) x.ItemType = itemType)
        End Get
    End Property

    Public Sub AttemptMove(direction As Directions) Implements ICharacter.AttemptMove
        Dim route = Location.Route(direction)
        If route Is Nothing Then
            AddMessage("You cannot go that way!")
        End If
        AddMessage($"You go {direction.Name}.")
        Location = route.ToLocation
    End Sub

    Public Overridable Sub AddMessage(message As String) Implements ICharacter.AddMessage
        'do nothing
    End Sub

    Public Sub Talk(targetCharacter As ICharacter) Implements ICharacter.Talk
        CharacterType.Talk(Me, targetCharacter)
    End Sub

    Public Sub Complete(questType As QuestTypes) Implements ICharacter.Complete
        WorldData.Characters(Id).StartedQuestTypes.Remove(questType)
        WorldData.Characters(Id).CompletedQuestTypes.Add(questType)
        questType.OnComplete(Me)
    End Sub

    Public Sub Start(questType As QuestTypes) Implements ICharacter.Start
        WorldData.Characters(Id).StartedQuestTypes.Add(questType)
        questType.OnStart(Me)
    End Sub

    Public Sub AttemptTake(items As IEnumerable(Of IItem)) Implements ICharacter.AttemptTake
        For Each item In items
            AttemptTakeOne(item)
        Next
    End Sub

    Public Sub AttemptDrop(items As IEnumerable(Of IItem)) Implements ICharacter.AttemptDrop
        For Each item In items
            AttemptDropOne(item)
        Next
    End Sub

    Private Sub AttemptDropOne(item As IItem)
        If HasItem(item) Then
            AddMessage($"You Drop {item.ItemType.Name}.")
            Location.AddItem(item)
            RemoveItem(item)
        End If
    End Sub

    Private Sub RemoveItem(item As IItem)
        WorldData.Characters(Id).ItemIds.Remove(item.Id)
    End Sub

    Private Function HasItem(item As IItem) As Boolean
        Return WorldData.Characters(Id).ItemIds.Contains(item.Id)
    End Function

    Private Sub AttemptTakeOne(item As IItem)
        If Location.HasItem(item) Then
            AddMessage($"You take {item.ItemType.Name}.")
            Location.RemoveItem(item)
            AddItem(item)
        End If
    End Sub

    Private Sub AddItem(item As IItem)
        WorldData.Characters(Id).ItemIds.Add(item.Id)
    End Sub

    Friend Shared Function Create(worldData As WorldData, world As World, location As ILocation, characterType As CharacterTypes) As ICharacter
        Dim characterId = If(worldData.Characters.Any, worldData.Characters.Keys.Max + 1, 0)
        worldData.Characters(characterId) = New CharacterData With
            {
                .LocationId = location.Id,
                .CharacterType = characterType
            }
        Return New Character(worldData, world, characterId)
    End Function

    Public Function CanTalk(otherCharacter As ICharacter) As Boolean Implements ICharacter.CanTalk
        Return CharacterType.CanTalk(Me, otherCharacter)
    End Function

    Public Function HasCompleted(questType As QuestTypes) As Boolean Implements ICharacter.HasCompleted
        Return WorldData.Characters(Id).CompletedQuestTypes.Contains(questType)
    End Function

    Public Function CanComplete(questType As QuestTypes) As Boolean Implements ICharacter.CanComplete
        If HasStarted(questType) Then
            Return questType.CanComplete(Me)
        End If
        Return False
    End Function

    Public Function HasStarted(questType As QuestTypes) As Boolean Implements ICharacter.HasStarted
        Return WorldData.Characters(Id).StartedQuestTypes.Contains(questType)
    End Function

    Public Function HasItemType(itemType As ItemTypes) As Boolean Implements ICharacter.HasItemType
        Return Items.Any(Function(x) x.ItemType = itemType)
    End Function
End Class
