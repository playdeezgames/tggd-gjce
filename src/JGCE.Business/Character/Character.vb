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

    Friend Shared Function Create(worldData As WorldData, world As World, location As ILocation, characterType As CharacterTypes) As ICharacter
        Dim characterId = If(worldData.Characters.Any, worldData.Characters.Keys.Max + 1, 0)
        worldData.Characters(characterId) = New CharacterData With
            {
                .LocationId = location.Id,
                .CharacterType = characterType
            }
        Return New Character(worldData, world, characterId)
    End Function
End Class
