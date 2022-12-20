Public Class PlayerCharacter
    Inherits Character

    Public Sub New(worldData As WorldData, world As World)
        MyBase.New(worldData, world, worldData.PlayerCharacterId.Value)
    End Sub
    Public Overrides Sub AddMessage(message As String)
        MyBase.AddMessage(message)
        WorldData.Messages.Add(message)
    End Sub
End Class
