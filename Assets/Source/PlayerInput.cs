using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Game
{
    public void PlayerInput()
    {
        if (actionReloadTime > 0f)
        {
            return;
        }

            if (Input.GetKeyDown(KeyCode.W) && canMoveUp)
        {
            playerObject.transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, playerObject.transform.position.z + 1);
            lastMove = MoveDirection.Up;
            playerPosY--;
            actionReloadTime = player.actionReloadSpeed;
        }
        if (Input.GetKeyDown(KeyCode.S) && canMoveDown)
        {
            playerObject.transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, playerObject.transform.position.z - 1);
            lastMove = MoveDirection.Down;
            playerPosY++;
            actionReloadTime = player.actionReloadSpeed;
        }
        if (Input.GetKeyDown(KeyCode.A) && canMoveLeft)
        {
            playerObject.transform.position = new Vector3(playerObject.transform.position.x - 1, playerObject.transform.position.y, playerObject.transform.position.z);
            lastMove = MoveDirection.Left;
            playerPosX--;
            actionReloadTime = player.actionReloadSpeed;
        }
        if (Input.GetKeyDown(KeyCode.D) && canMoveRight)
        {
            playerObject.transform.position = new Vector3(playerObject.transform.position.x + 1, playerObject.transform.position.y, playerObject.transform.position.z);
            lastMove = MoveDirection.Right;
            playerPosX++;
            actionReloadTime = player.actionReloadSpeed;
        }

        currentTile = level.data[playerPosX][playerPosY];
        currentTileType = level.grid[playerPosX][playerPosY];

        Debug.Log(currentTileType);

    }

    public void CheckCurrentTile()
    {
        switch (currentTileType)
        {
            case TileType.Enemy:
                isInCombat = true;
                break;
            case TileType.Goal:
                // TODO player wins
                break;
            case TileType.Sword:
                // TODO pickup
                break;
            case TileType.Chest:
                // TODO pickup
                break;
            default:
                break;
        }
    }

    public void CurrentTileUpdate()
    {
        switch (lastMove)
        {
            case MoveDirection.Up:
                currentTile = level.data[playerPosX][playerPosY-1];
                currentTileType = level.grid[playerPosX][playerPosY-1];
                break;
            case MoveDirection.Down:
                currentTile = level.data[playerPosX][playerPosY+1];
                currentTileType = level.grid[playerPosX][playerPosY+1];
                break;
            case MoveDirection.Left:
                currentTile = level.data[playerPosX-1][playerPosY];
                currentTileType = level.grid[playerPosX-1][playerPosY];
                break;
            case MoveDirection.Right:
                currentTile = level.data[playerPosX+1][playerPosY];
                currentTileType = level.grid[playerPosX+1][playerPosY];
                break;
            case MoveDirection.None:
                break;
            default:
                break;
        }
    }
}
