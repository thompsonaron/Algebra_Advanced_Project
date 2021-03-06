﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static void serialize(Level level, string path)
    {
        FileStream fs = new FileStream(path, FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(fs, level);
        fs.Close();
    }

    public static void serialize(SaveData save, string path)
    {
        FileStream fs = new FileStream(path, FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(fs, save);
        fs.Close();
    }

    public static Level deserialize(string path)
    {
        FileStream fs = new FileStream(path, FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();
        var level = (Level)formatter.Deserialize(fs);
        fs.Close();

        return level;
    }

    public static SaveData deserializeSave(string path)
    {
        FileStream fs = new FileStream(path, FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();
        var level = (SaveData)formatter.Deserialize(fs);
        fs.Close();

        return level;
    }

    public static string getLevelPath(int lvlNumber)
    {
        return Application.dataPath + "/Maps/level"+ lvlNumber+ ".bin";
    }

    public static string getSavePath(int lvlNumber)
    {
        return Application.dataPath + "/Maps/save"+ lvlNumber +".bin";
    }

    public static GameObject getDataFromTile(LevelData data, TileType tile)
    {
        if(tile == TileType.Grass) return data.grass;
        if(tile == TileType.Enemy) return data.enemy;
        if(tile == TileType.PlayerSpawn) return data.playerSpawn;
        if(tile == TileType.Goal) return data.goal;
        if(tile == TileType.Rock) return data.rock;
        if(tile == TileType.Sword) return data.sword;
        if(tile == TileType.Water) return data.water;
        if(tile == TileType.Chest) return data.chest;
        if(tile == TileType.Boss) return data.boss;


        return null;
    }
    
	public static Color getColor(TileType tile)
	{
		if (tile == TileType.Grass) return Color.green;
		if (tile == TileType.Enemy) return Color.red;
		if (tile == TileType.PlayerSpawn) return Color.blue;
		if (tile == TileType.Goal) return Color.cyan;
		if (tile == TileType.Rock) return Color.gray;
		if (tile == TileType.Sword) return Color.yellow;
		if (tile == TileType.Water) return Color.magenta;
		if (tile == TileType.Sword) return Color.white;
		if (tile == TileType.Boss) return new Color(0.3f, 0.4f, 0.6f);

		return Color.white;
	}
}