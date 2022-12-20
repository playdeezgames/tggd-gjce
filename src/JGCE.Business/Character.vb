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
    Friend Shared Function Create(worldData As WorldData, world As World) As ICharacter
        Dim characterId = If(worldData.Characters.Any, worldData.Characters.Max(Function(x) x.Key), 0)
        worldData.Characters(characterId) = New CharacterData
        Return New Character(worldData, world, characterId)
    End Function
End Class
