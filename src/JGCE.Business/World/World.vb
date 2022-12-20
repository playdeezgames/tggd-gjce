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

    Public ReadOnly Property Messages As IEnumerable(Of String) Implements IWorld.Messages
        Get
            Return WorldData.Messages
        End Get
    End Property

    Public ReadOnly Property Locations As IEnumerable(Of ILocation) Implements IWorld.Locations
        Get
            Return WorldData.Locations.Keys.Select(Function(x) New Location(WorldData, Me, x))
        End Get
    End Property

    Public Shared Function Create() As IWorld
        Dim worldData As New WorldData
        Dim world = New World(worldData)
        CreateOverworld(worldData, world)
        'TODO: place home
        'TODO: place shoppes
        'TODO: place dungeons
        CreatePlayerCharacter(worldData, world)
        Return world
    End Function
    Private Const OverworldColumns = 8
    Private Const OverworldRows = 8
    Private Const ShortcutCount = 16
    Private Shared ReadOnly MazeDirections As IReadOnlyDictionary(Of Directions, MazeDirection(Of Directions)) =
        New Dictionary(Of Directions, MazeDirection(Of Directions)) From
        {
            {Directions.North, New MazeDirection(Of Directions)(Directions.South, 0, -1)},
            {Directions.East, New MazeDirection(Of Directions)(Directions.West, 1, 0)},
            {Directions.South, New MazeDirection(Of Directions)(Directions.North, 0, 1)},
            {Directions.West, New MazeDirection(Of Directions)(Directions.East, -1, 0)}
        }
    Private Shared Sub CreateOverworld(worldData As WorldData, world As World)
        Dim maze As New Maze(Of Directions)(OverworldColumns, OverworldRows, MazeDirections)
        maze.Generate()
        Dim locations(OverworldColumns - 1, OverworldRows - 1) As ILocation
        For column = 0 To OverworldColumns - 1
            For row = 0 To OverworldRows - 1
                locations(column, row) = Location.Create(worldData, world, LocationTypes.Overworld)
            Next
        Next
        For column = 0 To OverworldColumns - 1
            For row = 0 To OverworldRows - 1
                Dim location = locations(column, row)
                Dim cell = maze.GetCell(column, row)
                For Each direction In MazeDirections.Keys
                    If If(cell.GetDoor(direction)?.Open, False) Then
                        Dim nextLocation = locations(column + CInt(MazeDirections(direction).DeltaX), row + CInt(MazeDirections(direction).DeltaY))
                        Route.Create(worldData, world, location, direction, nextLocation, RouteTypes.Street)
                    End If
                Next
            Next
        Next
        Dim shortcuts = ShortcutCount
        While shortcuts > 0
            Dim column = RNG.FromRange(0, OverworldColumns - 1)
            Dim row = RNG.FromRange(0, OverworldRows - 1)
            Dim direction = RNG.FromEnumerable(MazeDirections.Keys)
            Dim nextColumn = column + CInt(MazeDirections(direction).DeltaX)
            Dim nextRow = row + CInt(MazeDirections(direction).DeltaY)
            If nextColumn >= 0 AndAlso nextRow >= 0 AndAlso nextColumn < OverworldColumns AndAlso nextRow < OverworldRows Then
                Route.Create(worldData, world, locations(column, row), direction, locations(nextColumn, nextRow), RouteTypes.Street)
                Route.Create(worldData, world, locations(nextColumn, nextRow), MazeDirections(direction).Opposite, locations(column, row), RouteTypes.Street)
                shortcuts -= 1
            End If
        End While
    End Sub

    Private Shared Sub CreatePlayerCharacter(worldData As WorldData, world As World)
        Dim location As ILocation = RNG.FromEnumerable(world.Locations.Where(Function(x) x.LocationType = LocationTypes.Overworld))
        Dim playerCharacter = Character.Create(worldData, world, location, CharacterTypes.Protagonist)
        world.PlayerCharacter = playerCharacter
    End Sub

    Public Sub ClearMessages() Implements IWorld.ClearMessages
        WorldData.Messages.Clear()
    End Sub
End Class
