using System;
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
    
    public static Level deserialize(string path)
    {
        FileStream fs = new FileStream(path, FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();
        var level = (Level)formatter.Deserialize(fs);
        fs.Close();

        return level;
    }

    public static string getLevelPath()
    {
        return Application.dataPath + "/Maps/level1.bin";
    }

    public static GameObject getDataFromTile(LevelData data, TileType tile)
    {
        if(tile == TileType.Grass) return data.grass;
        if(tile == TileType.Enemy) return data.enemy;
        if(tile == TileType.PlayerSpawn) return data.playerSpawn;
        if(tile == TileType.Goal) return data.goal;
        if(tile == TileType.Rock) return data.rock;
        if(tile == TileType.Sword) return data.sword;

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

		return Color.white;
	}
}