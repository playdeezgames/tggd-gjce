Public Class LocationData
    Public Property Routes As New Dictionary(Of Integer, RouteData)
    Public Property LocationType As Integer
    Public Property ItemIds As New HashSet(Of Integer)
    Public Property DungeonType As Integer
End Class
