﻿using System;
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

	[HideInInspector] public float enemyKillCounter;
	[HideInInspector] public float stepsCounter;
	// 1 == kill all enemies, 2 == kill the boss, 3 == reach goal in 10 steps
	[HideInInspector] public int goalType;
	[HideInInspector] public bool bossKilled;


	public LevelData data;
	Level level;
	void Start()
	{
		level = Util.deserialize(Util.getLevelPath(1));
		enemyKillCounter = 0;
		stepsCounter = 0;
		bossKilled = false;
		instantiateLevel();
		goalType = level.goalType;
		initUI();
		initInventory();
		initRaycast();
		initPlayerStats();
	}

	void initPlayerStats()
    {
		player.baseHealth = 15;
		player.baseAttack = 5;
		player.health = player.baseHealth;
		player.attackDamage = player.baseAttack;

		player.actionReloadSpeed = 2f;
		actionReloadTime = player.actionReloadSpeed;
		player.damageTaken = 0;
		player.damageHealed = 0;
		UpdatePlayerHealth();
		UpdatePlayerAttack();
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
					level.data[x][y].additionalAttack = 3;
                }

				if (level.grid[x][y] == TileType.Boss)
				{
					level.data[x][y].additionalHealth = 30;
					level.data[x][y].additionalAttack = 5;
				}
			}
		}
		Debug.Log("GOAL TYPE: " + level.goalType);
		//Debug.Log("GRID" + level.grid.Length);
	}


    void Update()
	{
		CheckSurroundingTiles();
		PlayerInput();
		//Debug.Log("Player pos: " + playerPosX + " " + playerPosY);
		UpdateRaycast();
		Combat();
		CheckForWin();
		CheckForLoss();
        UIUpdate();
        actionReloadTime -= Time.deltaTime;
		Debug.Log(currentTileType);
	}


	// TODO Disable input etc.
	public void CheckForWin()
    {
        switch (level.goalType)
        {
			case 1:
                if (enemyKillCounter >= 3)
                {
					Debug.Log("KILLED ENEMIES WIN!");
					ActivateWinUi();
                }
				break;
			case 2:
                if (bossKilled)
                {
					Debug.Log("KILLLED THE BOSS");
					ActivateWinUi();
                }
				break;
			case 3:
                if (currentTileType == TileType.Goal)
                {
					Debug.Log("REACHED THE GOAL");
					ActivateWinUi();
                }
				break;
            default:
                break;
        }
    }


	// TODO Disable input etc.
	public void CheckForLoss()
	{
		if (player.health < 0)
		{
			Debug.Log("Regular death");
			ActivateLossUI();
		}

		// goal type 3 is steps goal
		if (level.goalType == 3)
        {
            if (stepsCounter > 10)
            {
				Debug.Log("Ran out of steps");
				ActivateLossUI();
            }
        }
    }

	private float currentEnemyAttackSpeed;
	private float currentEnemyAttackTime;

	public void Combat()
    {
        if ((currentTileType == TileType.Enemy || currentTileType == TileType.Boss) && !isInCombat)
        {
			isInCombat = true;
			currentEnemyAttackSpeed = currentTile.actionSpeed;
			// TODO temporary - remove
			currentEnemyAttackSpeed = 2f;
			currentEnemyAttackTime = currentEnemyAttackSpeed;
        }
        else if (currentTileType != TileType.Enemy && currentTileType != TileType.Boss)
        {
			Debug.Log("COMBAT RESET");
			isInCombat = false;
		}

        if (isInCombat)
        {
			//Debug.Log("COMBAT " + currentEnemyAttackTime);
			currentEnemyAttackTime -= Time.deltaTime;
            if (currentEnemyAttackTime <= 0f)
            {
				player.health -= currentTile.additionalAttack;
				player.damageTaken += currentTile.additionalAttack;
				Debug.Log("PLAYER HEALTH " + player.health);
				currentEnemyAttackTime = currentEnemyAttackSpeed;
            }
        }
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
			canMoveLeft = IsTileMovableTo(level.grid[playerPosX - 1][playerPosY]);
        }
		if(playerPosX + 1 < level.grid.Length)
		{
			canMoveRight = IsTileMovableTo(level.grid[playerPosX + 1][playerPosY]);
        }
		if (playerPosY -1 >= 0)
		{
			canMoveUp = IsTileMovableTo(level.grid[playerPosX][playerPosY - 1]);
        }
		if (playerPosY + 1 < level.grid[playerPosX].Length)
		{
			canMoveDown = IsTileMovableTo(level.grid[playerPosX][playerPosY + 1]);
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
    Boss,
	None,
    DroppedItem
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

	public int scriptableItemID;

}

[Serializable]
public class Level
{
	public TileType[][] grid;
	public TileData[][] data;
	// 1== kill enemies, 2 == kill boss, 3 == reach goal in 10 steps
	public int goalType;
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
	public int damageTaken;
	public int damageHealed;
	public int baseHealth;
    internal int baseAttack;
}







//[Serializable]
//public class Enemy
//{
//	public int health;
//	public Attack attack;
//}

