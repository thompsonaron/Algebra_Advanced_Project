using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	public LevelData data;
	Level level;
	void Start()
	{
		level = Util.deserialize(Util.getLevelPath());
		instantiateLevel();
	}

	void instantiateLevel()
	{
		for (int i = 0; i < level.grid.Length; i++)
		{
			for (int j = 0; j < level.grid[i].Length; j++)
			{
				Instantiate(Util.getDataFromTile(data, level.grid[i][j]), new Vector3(i, 0, -j), Quaternion.identity);
				if (level.grid[i][j] != TileType.Grass)
				{
					Instantiate(Util.getDataFromTile(data, TileType.Grass), new Vector3(i, 0, -j), Quaternion.identity);
				}
			}
		}
	}

	void Update()
	{

	}
}

public enum TileType
{
	Grass,
	Enemy,
	PlayerSpawn,
	Goal,
	Rock,
	Sword
}

[Serializable]
public class TileData
{
	public bool isRanged;
	public int health;
	public int attack;
	public int actionSpeed;

	public int additionalHealth;
	public int additionalAttack;
	public int additionalActionReload;
	public int additionalActionReloadSpeed;
}

[Serializable]
public class Level
{
	public TileType[][] grid;
	public TileData[][] data;
}