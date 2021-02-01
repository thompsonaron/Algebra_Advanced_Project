using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Game : MonoBehaviour
{
	public GameObject playerObject;
	[HideInInspector] public int playerPosX;
	[HideInInspector] public int playerPosY;
	[HideInInspector] public Player player;
	private float actionReloadTime;
	private bool canDoAction = false;


	public LevelData data;
	Level level;
	void Start()
	{
		level = Util.deserialize(Util.getLevelPath());
		initUI();
		instantiateLevel();
		initPlayerStats();
		initInventory();
		initRaycast();
	}

	void initPlayerStats()
    {
		player.actionReloadSpeed = 2f;
		actionReloadTime = player.actionReloadSpeed;
		player.attackDamage = 5;
    }

	void instantiateLevel()
	{
		for (int x = 0; x < level.grid.Length; x++)
		{
			for (int y = 0; y < level.grid[x].Length; y++)
			{
				Instantiate(Util.getDataFromTile(data, level.grid[x][y]), new Vector3(x, 0, -y), Quaternion.identity);
				if (level.grid[x][y] != TileType.Grass)
				{
					Instantiate(Util.getDataFromTile(data, TileType.Grass), new Vector3(x, 0, -y), Quaternion.identity);
				}
                if (level.grid[x][y] == TileType.PlayerSpawn)
                {
					// spawning player
					playerObject = Instantiate(playerObject, new Vector3(x, 0, -y), Quaternion.identity);
					playerPosX = x;
					playerPosY = y;
					
				}
                if (level.grid[x][y] == TileType.Enemy)
                {
					level.data[x][y].additionalHealth = 11;
                }
			}
		}

		Debug.Log("GRID" + level.grid.Length);
	}


    void Update()
	{
		CheckSurroundingTiles();
		PlayerInput();
		Debug.Log("Player pos: " + playerPosX + " " + playerPosY);
		UIUpdate();
		actionReloadTime -= Time.deltaTime;
		initUI();
		UpdateRaycast();
	}

	public bool canMoveUp;
	public bool canMoveDown;
	public bool canMoveLeft;
	public bool canMoveRight;
	public bool isInCombat;

	TileType leftTileType;
	TileType rightTileType;
	TileType upperTileType;
	TileType lowerTileType;
	TileType currentTileType;
	TileData leftTile;
	TileData rightTile;
	TileData upperTile;
	TileData lowerTile;
	TileData currentTile;

	MoveDirection lastMove = MoveDirection.None;

	[HideInInspector] public GameObject[] chestsAndSwords = new GameObject[20];

	void LoadChestsAndSwords()
    {
		
    }

	void CheckSurroundingTiles()
    {
        canMoveLeft = false;
        canMoveRight = false;
        canMoveUp = false;
        canMoveDown = false;

        // left
        if (playerPosX -1 >= 0)
        {
			Debug.Log(canMoveLeft = IsTileMovableTo(level.grid[playerPosX - 1][playerPosY]));
        }
		if(playerPosX + 1 < level.grid.Length)
		{
			Debug.Log(canMoveRight = IsTileMovableTo(level.grid[playerPosX + 1][playerPosY]));
        }
		if (playerPosY -1 >= 0)
		{
			Debug.Log(canMoveUp = IsTileMovableTo(level.grid[playerPosX][playerPosY - 1]));
        }
		if (playerPosY + 1 < level.grid[playerPosX].Length)
		{
			Debug.Log(canMoveDown = IsTileMovableTo(level.grid[playerPosX][playerPosY + 1]));
        }

        //Debug.Log("L:" + canMoveLeft);
        //Debug.Log("R:" + canMoveRight);
        //Debug.Log("U:" + canMoveUp);
        //Debug.Log("D:" + canMoveDown);

        //      Debug.Log("L:" + level.grid[playerPosX - 1][playerPosY]);
        //Debug.Log("R:" + level.grid[playerPosX + 1][playerPosY]);
        //Debug.Log("U:" + level.grid[playerPosX][playerPosY - 1]);
        //Debug.Log("D:" + level.grid[playerPosX][playerPosY + 1]);

        //      Debug.Log("L:" + (playerPosX - 1));
        //      Debug.Log("R:" + (playerPosX + 1));
        //      Debug.Log("U:" + (playerPosY - 1));
        //      Debug.Log("D:" + (playerPosY + 1));
    }

	public bool IsTileMovableTo(TileType tileType)
    {

        if (tileType == TileType.Rock || tileType == TileType.Water )
        {
			return false;
        }
		return true;
    }
}

public enum MoveDirection
{
	Up,
	Down,
	Left,
	Right,
	None
}

public enum TileType
{
	Grass,
	Enemy,
	PlayerSpawn,
	Goal,
	Rock,
	Sword,
	Water,
	Chest,
	None
}

[Serializable]
public class TileData
{
	public bool isRanged;
	public bool isLootable;
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

[Serializable]
public class Player
{
	public int health;
	//public int armor;
	public List<Item> inventory;
	public float actionReloadSpeed;
	public int actionReload;
	public int attackDamage;
}







//[Serializable]
//public class Enemy
//{
//	public int health;
//	public Attack attack;
//}

