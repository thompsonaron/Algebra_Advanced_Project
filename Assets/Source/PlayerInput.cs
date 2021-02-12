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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentTileType == TileType.Enemy || currentTileType == TileType.Boss)
            {
                SoundManager.instance.Play("Sword");
                level.data[playerPosX][playerPosY].additionalHealth -= player.attackDamage;
                //currentTile.additionalHealth -= player.attackDamage;
                actionReloadTime = player.actionReloadSpeed;
                if (currentTile.additionalHealth <= 0)
                {
                    Debug.Log("KILLED");
                    Debug.Log(currentTileType);
                    // BEWARE - DeactivateCurrentTileObject will change boss tilel to grass and wont work so it has to be here
                    if (currentTileType == TileType.Boss)
                    {
                        Debug.Log("KILLED THE BOSS");
                        bossKilled = true;
                        CheckForWin();
                    }
                    else
                    {
                        enemyKillCounter++;
                        // TODO enemy killed something
                        DeactiveCurrentTileObject();
                        level.grid[playerPosX][playerPosY] = TileType.Grass;
                    }
                }
            }
            
            
        }

        //if (isInCombat)
        //{
        //    return;
        //}

        if (Input.GetKeyDown(KeyCode.W) && canMoveUp)
        {
            playerObject.transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, playerObject.transform.position.z + 1);
            lastMove = MoveDirection.Up;
            playerPosY--;
            actionReloadTime = player.actionReloadSpeed;
            stepsCounter++;
            SoundManager.instance.Play("StepWood");
        }
        if (Input.GetKeyDown(KeyCode.S) && canMoveDown)
        {
            playerObject.transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, playerObject.transform.position.z - 1);
            lastMove = MoveDirection.Down;
            playerPosY++;
            actionReloadTime = player.actionReloadSpeed;
            stepsCounter++;
            SoundManager.instance.Play("StepWood");
        }
        if (Input.GetKeyDown(KeyCode.A) && canMoveLeft)
        {
            playerObject.transform.position = new Vector3(playerObject.transform.position.x - 1, playerObject.transform.position.y, playerObject.transform.position.z);
            lastMove = MoveDirection.Left;
            playerPosX--;
            actionReloadTime = player.actionReloadSpeed;
            stepsCounter++;
            SoundManager.instance.Play("StepWood");
        }
        if (Input.GetKeyDown(KeyCode.D) && canMoveRight)
        {
            playerObject.transform.position = new Vector3(playerObject.transform.position.x + 1, playerObject.transform.position.y, playerObject.transform.position.z);
            lastMove = MoveDirection.Right;
            playerPosX++;
            actionReloadTime = player.actionReloadSpeed;
            stepsCounter++;
            SoundManager.instance.Play("StepWood");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTileType == TileType.Chest)
            {
                //GetRandomItem();
                GetRandomArmor();
                DeactiveCurrentTileObject();
                level.grid[playerPosX][playerPosY] = TileType.Grass;
                actionReloadTime = player.actionReloadSpeed;
                SoundManager.instance.Play("Chest");
            }
            else if (currentTileType == TileType.Sword)
            {
                //GetRandomItem();
                GetRandomWeapon();
                DeactiveCurrentTileObject();
                level.grid[playerPosX][playerPosY] = TileType.Grass;
                actionReloadTime = player.actionReloadSpeed;
                SoundManager.instance.Play("Chest");
            }
            else if (currentTileType == TileType.DroppedItem)
            {
                GettemFromDroppedTile();
                DeactiveCurrentTileObject();
                level.grid[playerPosX][playerPosY] = TileType.Grass;
                actionReloadTime = player.actionReloadSpeed;
                SoundManager.instance.Play("Chest");
            }

        }

        


        currentTile = level.data[playerPosX][playerPosY];
        currentTileType = level.grid[playerPosX][playerPosY];
        if (currentTileType == TileType.Enemy || currentTileType == TileType.Boss)
        {
            Debug.Log(currentTile.additionalHealth);
            UpdateEnemyHealth();
            UpdatePlayerHealth();
        }


    }

    private void DeactiveCurrentTileObject()
    {
        Debug.Log("Calling deactivate");
        Collider[] hitColliders = Physics.OverlapSphere(playerObject.transform.position, 0.5f);
        Debug.Log("Calling deactivate" + hitColliders.Length);
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log(hitCollider.gameObject.name);
            if (hitCollider.CompareTag("Destroyable"))
            {
                hitCollider.gameObject.SetActive(false);
            }
        }
    }

    public void CheckCurrentTile()
    {
        switch (currentTileType)
        {
            case TileType.Enemy:
               // isInCombat = true;
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
                currentTile = level.data[playerPosX][playerPosY - 1];
                currentTileType = level.grid[playerPosX][playerPosY - 1];
                break;
            case MoveDirection.Down:
                currentTile = level.data[playerPosX][playerPosY + 1];
                currentTileType = level.grid[playerPosX][playerPosY + 1];
                break;
            case MoveDirection.Left:
                currentTile = level.data[playerPosX - 1][playerPosY];
                currentTileType = level.grid[playerPosX - 1][playerPosY];
                break;
            case MoveDirection.Right:
                currentTile = level.data[playerPosX + 1][playerPosY];
                currentTileType = level.grid[playerPosX + 1][playerPosY];
                break;
            case MoveDirection.None:
                break;
            default:
                break;
        }
    }
}
