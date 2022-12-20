Public Class BaseThingie
    Implements IBaseThingie
    Protected WorldData As WorldData
    Sub New(worldData As WorldData, world As World)
        Me.WorldData = worldData
        Me.World = world
    End Sub

    Public ReadOnly Property World As World Implements IBaseThingie.World
End Class
