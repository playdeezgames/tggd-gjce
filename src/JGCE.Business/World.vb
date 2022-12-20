Public Class World
    Implements IWorld
    Private WorldData As WorldData
    Sub New(worldData As WorldData)
        Me.WorldData = worldData
    End Sub

    Public Property PlayerCharacter As ICharacter Implements IWorld.PlayerCharacter
        Get
            Return New PlayerCharacter(WorldData, Me)
        End Get
        Set(value As ICharacter)
            If value Is Nothing Then
                WorldData.PlayerCharacterId = Nothing
            Else
                WorldData.PlayerCharacterId = value.Id
            End If
        End Set
    End Property

    Public Shared Function Create() As IWorld
        Dim worldData As New WorldData
        Dim world = New World(worldData)
        'TODO: make stuff in the world
        Dim playerCharacter = Character.Create(WorldData, world)
        world.PlayerCharacter = playerCharacter
        Return world
    End Function
End Class
