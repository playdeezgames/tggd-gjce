Imports System.Runtime.CompilerServices

Public Enum LocationTypes
    Overworld
    House
    Dungeon
End Enum
Public Module LocationTypesExtensions
    Private _onEnter As IReadOnlyDictionary(Of LocationTypes, Action(Of WorldData, IWorld, ILocation, ICharacter)) =
        New Dictionary(Of LocationTypes, Action(Of WorldData, IWorld, ILocation, ICharacter)) From
        {
            {LocationTypes.Dungeon, AddressOf OnEnterDungeon}
        }

    Private Sub OnEnterDungeon(worldData As WorldData, world As IWorld, location As ILocation, character As ICharacter)
        If Not character.CharacterType = CharacterTypes.Protagonist Then
            Return
        End If
        Dim dungeonType = location.DungeonType
        dungeonType.AttemptSpawn(worldData, world, location)
    End Sub

    <Extension>
    Friend Sub OnEnter(locationType As LocationTypes, worldData As WorldData, world As IWorld, location As ILocation, character As ICharacter)
        If _onEnter.ContainsKey(locationType) Then
            _onEnter(locationType)(worldData, world, location, character)
        End If
    End Sub
End Module
