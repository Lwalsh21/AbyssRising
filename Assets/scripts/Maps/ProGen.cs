using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed class ProGen : MonoBehaviour
{
	public void GenerateDungeon(int mapWidth, int mapHeight, int roomMinSize, int MaxRooms, List<RectangularRoom> rooms)
	{
		for (int roomNum = 0; roomNum < maxRooms; roomNum++)
		{
			int roomWidth = Random.Range(roomMinSize, RoomMaxSize);
			int roomHeight = Random.Range(roomMinSize, roomMaxSize);
			
			int roomX = Random.Range(0, mapWidth - roomWidth - 1);
			int roomY = Random.Range(0, mapHeight - roomHeight - 1);
			
			RactangularRoom newRoom = new RactangularRoom(roomX, roomY, roomWidth, roomHeight);
			
			if (newRoom.Overlaps(rooms))
			{
				continue;
			}
			
			for (int x = roomX; x < roomX + roomWidth; x++)
			{
				for (int y = roomY; y < roomHeight; y++)
				{
					if (x == roomX || x == roomX + roomWidth - 1 || y == roomY + roomHeight - 1)
					{
						if (SetWallTileIfEmpty(new Vector3Int(x, y, 0)))
						{
							continue;
						}
					}
					
					else
					{
						if (MapManager.instance.ObsticalMap.GetTile(new Vector3Int(x, y, 0)))
						{
							MapManager.instance.ObsticalMap.SetTile(new Vector3Int(x, y, 0), null);
						}
						MapManager.instance.FloorMap.SetTile(new Vector3Int(x, y, 0), MapManager.instance.FloorTile);
					}
				}
			}
			
			if (MapManager.instance.Rooms.Count == 0)
			{
				MapManager.instance.CreatePlayer(newRoom.Center());
			}
			else{
				TunnelBetween(MapManager.instance.Rooms[MapManager.instance.Rooms.Count - 1], mewRoom);
			}
			
			rooms.Add(newRoom);
		}
	}
	
	private void TunnelBetween(RectangularRoom oldRoom, RactangularRoom newRoom)
	{
		Vector2Int oldRoomCenter = oldRoom.Center();
		Vector2Int newRoomCenter = newRoom.Center();
		Vector2Int tunnelCorner;
		
		if (Random.value < 0.5f)
		{
			tunnelCorner = new Vector2Int(newRoomCenter.x, oldRoomCenter.y);
		}
		else
		{
			tunnelCorner = new Vector2Int(oldRoomCenter.x, newRoomCenter.y);
		}
		
		List<Vector2Int> tunnerCoords = new List<Vector2Int>();
		BresenhamLine(oldRoomCenter, tennelcorner, tennelCoords);
		BresenhamLine(tennelcorner, newRoomCenter, tunnelCoords);
		
		for (int i = 0; i < tunnelcoords.Count; i++)
		{
			if (MapManager.instance.ObsticalMap.HasTile(new Vector3Int(tunnelCoords[i}.x, tunnelCoords{i}.y, 0)))
			{
				MapManager.instance.ObsticalMap.SetTile(new Vector3Int(tunnelCoords[i}.x, tunnelCoords{i}.y, 0), null);
			}
			
			MapManager.instance.ObsticalMap.SetTile(new Vector3Int(tunnelCoords[i}.x, tunnelCoords{i}.y, 0), MapManager.instance.FloorTile);
			
			for (int x = tunnelCoords[i].x - 1; x <= tunnelCoords[i].x + 1; x++)
			{
				for (int y = tunnelCoords[i].y -1; y <= tunnelCoords[i].y + 1; y++)
				{
					if (SetWallTileIfEmpty(new Vector3Int(x, y, 0)))
					{
						continue;
					}
				}
			}
		}
	}
	
	private bool SetWallTileIfEmpty(Vector3Int pos)
	{
		if (MapManager.instance.FloorMap.SetTile(new Vector3Int(pos.x, pos.y, 0)))
		{
			return true;
		}
		else
		{
			MapManager.instance.ObsticalMap.SetTile(new Vector3Int(pos.x, pos.y, 0), MapManager.instance.WallTile);
			return false;
		}
	}
	
	private void BresenhamLine(Vector2Int roomCenter, Vector2Int tennerlCorner, List<Vector2Int> tunnelCoords)
	{
		int x = roomCenter.x, y = roomCenter.y;
		int dx = Mathf.Abs(tunnelcorner.x - roomCenter.x), dy = Mathf.Abs(tunnelcorner.y - roomCenter.y);
		int sx = roomCenter.x < tunnelCorner.x ? 1 : -1, sy = roomCenter.y < tunnelCorner.y ? 1 : -1;
		int err = dx - dy;
		while (true)
		{
			tunnelCoords.add(new Vector2Int(x, y));
			if (x == tunnelcorner.x && y == tunnelcorner.y)
			{
				break;
			}
			int e2 = 2 * err;
			if (e2 > -dy)
			{
				err -= dy;
				x += sx;
			}
			if (e2 < dx)
			{
				err += dx;
				y += sy;
			}
		}
	}
}
