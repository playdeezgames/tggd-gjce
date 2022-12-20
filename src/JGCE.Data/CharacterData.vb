Public Class CharacterData
    Public Property LocationId As Integer
    Public Property CharacterType As Integer
    Public Property ItemIds As New HashSet(Of Integer)
    Public Property AssignedQuestTypes As New HashSet(Of Integer)
    Public Property CompletedQuestTypes As New HashSet(Of Integer)
End Class
