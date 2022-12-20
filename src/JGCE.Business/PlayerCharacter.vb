Public Class PlayerCharacter
    Inherits Character

    Public Sub New(worldData As WorldData, world As World)
        MyBase.New(worldData, world, worldData.PlayerCharacterId.Value)
    End Sub
End Class
