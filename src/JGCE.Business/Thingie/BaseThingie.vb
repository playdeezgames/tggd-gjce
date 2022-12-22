Public Class BaseThingie
    Implements IBaseThingie
    Protected WorldData As WorldData
    Sub New(worldData As WorldData, world As IWorld)
        Me.WorldData = worldData
        Me.World = world
    End Sub

    Public ReadOnly Property World As IWorld Implements IBaseThingie.World
End Class
