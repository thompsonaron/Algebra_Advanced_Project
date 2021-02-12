using System.Collections.Generic;
using System.IO;
using System;


public static class Serializator
{
    // OK
    public static byte[] serialize(TileData tiledata)
    {
        var s = new MemoryStream();
        var bW = new BinaryWriter(s);
        bW.Write(tiledata.isRanged);
        bW.Write(tiledata.isLootable);
        bW.Write(tiledata.health);
        bW.Write(tiledata.attack);
        bW.Write(tiledata.actionSpeed);
        bW.Write(tiledata.additionalHealth);
        bW.Write(tiledata.additionalAttack);
        bW.Write(tiledata.additionalActionReload);
        bW.Write(tiledata.additionalActionReloadSpeed);
        bW.Write(tiledata.scriptableItemID);
        return s.ToArray();
    }

    // TODO
    public static Level DeserializeLevel(byte[] b)
    {
        var s = new MemoryStream(b);
        var bR = new BinaryReader(s);
        var obj = new Level();
        obj.grid = new TileType[10][];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                obj.grid[i][j] = DeserializeTileType(ref b, ref s, ref bR);
            }
            
        }
        obj.data = new TileData[10][];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                obj.data[i][j] = DeserializeTileData(ref b, ref s, ref bR);
            }
        }
        obj.goalType = bR.ReadInt32();
        return obj;
    }
    // TODO
    private static Level DeserializeLevel(ref byte[] b, ref MemoryStream s, ref BinaryReader bR)
    {
        var obj = new Level();
        obj.grid = new TileType[10][];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                obj.grid[i][j] = DeserializeTileType(ref b, ref s, ref bR);
            }

        }
        obj.data = new TileData[10][];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                obj.data[i][j] = DeserializeTileData(ref b, ref s, ref bR);
            }
        }
        obj.goalType = bR.ReadInt32();
        return obj;
    }

    private static TileType DeserializeTileType(ref byte[] b, ref MemoryStream s, ref BinaryReader bR)
    {
        var obj = new TileType();
        obj = (TileType)bR.ReadInt32();
        return obj;
    }

    // TODO
    public static byte[] serialize(Level level)
    {
        //int counter1 = 0;
        //int counter2 = 0;
        var s = new MemoryStream();
        var bW = new BinaryWriter(s);
        //bW.Write(level.grid.Length);
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                bW.Write((int)level.grid[i][j]);
            }
        }
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                serialize(level.data[i][j]);
            }
        }
        
        //bW.Write(level.data.Length);
        //foreach (var item in level.grid)
        //{
        //    bW.Write(item);
        //}
        //foreach (var item in level.data)
        //{
        //    bW.Write(item);
        //}
        bW.Write(level.goalType);
        return s.ToArray();
    }

    //OK
    public static byte[] serialize(Player player)
    {
        var s = new MemoryStream();
        var bW = new BinaryWriter(s);
        bW.Write(player.health);
        bW.Write(player.actionReloadSpeed);
        bW.Write(player.actionReload);
        bW.Write(player.attackDamage);
        bW.Write(player.damageTaken);
        bW.Write(player.damageHealed);
        bW.Write(player.baseHealth);
        return s.ToArray();
    }

    // OK
    public static byte[] serialize(SaveData savedata)
    {
        var s = new MemoryStream();
        var bW = new BinaryWriter(s);
        bW.Write(savedata.inventory.Length);
        foreach (var item in savedata.inventory)
        {
            bW.Write(item);
        }
        bW.Write(savedata.helmID);
        bW.Write(savedata.chestID);
        bW.Write(savedata.weaponID);
        bW.Write(serialize(savedata.levelData));
        bW.Write(savedata.playerPosX);
        bW.Write(savedata.playerPosY);
        bW.Write(serialize(savedata.player));
        bW.Write(savedata.stepsCounter);
        bW.Write(savedata.killCounter);
        return s.ToArray();
    }

    // OK
    public static TileData DeserializeTileData(byte[] b)
    {
        var s = new MemoryStream(b);
        var bR = new BinaryReader(s);
        var obj = new TileData();
        obj.isRanged = bR.ReadBoolean();
        obj.isLootable = bR.ReadBoolean();
        obj.health = bR.ReadInt32();
        obj.attack = bR.ReadInt32();
        obj.actionSpeed = bR.ReadInt32();
        obj.additionalHealth = bR.ReadInt32();
        obj.additionalAttack = bR.ReadInt32();
        obj.additionalActionReload = bR.ReadInt32();
        obj.additionalActionReloadSpeed = bR.ReadInt32();
        obj.scriptableItemID = bR.ReadInt32();
        return obj;
    }



    // OK
    public static Player DeserializePlayer(byte[] b)
    {
        var s = new MemoryStream(b);
        var bR = new BinaryReader(s);
        var obj = new Player();
        obj.health = bR.ReadInt32();
        obj.actionReloadSpeed = bR.ReadSingle();
        obj.actionReload = bR.ReadInt32();
        obj.attackDamage = bR.ReadInt32();
        obj.damageTaken = bR.ReadInt32();
        obj.damageHealed = bR.ReadInt32();
        obj.baseHealth = bR.ReadInt32();
        return obj;
    }

    // OK
    public static SaveData DeserializeSaveData(byte[] b)
    {
        var s = new MemoryStream(b);
        var bR = new BinaryReader(s);
        var obj = new SaveData();
        int inventoryArraySize = bR.ReadInt32();
        obj.inventory = new Int32[inventoryArraySize];
        for (int i = 0; i < inventoryArraySize; i++)
        {
            obj.inventory[i] = bR.ReadInt32();
        }
        obj.helmID = bR.ReadInt32();
        obj.chestID = bR.ReadInt32();
        obj.weaponID = bR.ReadInt32();
        obj.levelData = DeserializeLevel(ref b, ref s, ref bR);
        obj.playerPosX = bR.ReadInt32();
        obj.playerPosY = bR.ReadInt32();
        obj.player = DeserializePlayer(ref b, ref s, ref bR);
        obj.stepsCounter = bR.ReadInt32();
        obj.killCounter = bR.ReadInt32();
        return obj;
    }

    // OK
    private static TileData DeserializeTileData(ref byte[] b, ref MemoryStream s, ref BinaryReader bR)
    {
        var obj = new TileData();
        obj.isRanged = bR.ReadBoolean();
        obj.isLootable = bR.ReadBoolean();
        obj.health = bR.ReadInt32();
        obj.attack = bR.ReadInt32();
        obj.actionSpeed = bR.ReadInt32();
        obj.additionalHealth = bR.ReadInt32();
        obj.additionalAttack = bR.ReadInt32();
        obj.additionalActionReload = bR.ReadInt32();
        obj.additionalActionReloadSpeed = bR.ReadInt32();
        obj.scriptableItemID = bR.ReadInt32();
        return obj;
    }

   

    // OK
    private static Player DeserializePlayer(ref byte[] b, ref MemoryStream s, ref BinaryReader bR)
    {
        var obj = new Player();
        obj.health = bR.ReadInt32();
        obj.actionReloadSpeed = bR.ReadSingle();
        obj.actionReload = bR.ReadInt32();
        obj.attackDamage = bR.ReadInt32();
        obj.damageTaken = bR.ReadInt32();
        obj.damageHealed = bR.ReadInt32();
        obj.baseHealth = bR.ReadInt32();
        return obj;
    }

    // OK
    private static SaveData DeserializeSaveData(ref byte[] b, ref MemoryStream s, ref BinaryReader bR)
    {
        var obj = new SaveData();
        int inventoryArraySize = bR.ReadInt32();
        obj.inventory = new Int32[inventoryArraySize];
        for (int i = 0; i < inventoryArraySize; i++)
        {
            obj.inventory[i] = bR.ReadInt32();
        }
        obj.helmID = bR.ReadInt32();
        obj.chestID = bR.ReadInt32();
        obj.weaponID = bR.ReadInt32();
        obj.levelData = DeserializeLevel(ref b, ref s, ref bR);
        obj.playerPosX = bR.ReadInt32();
        obj.playerPosY = bR.ReadInt32();
        obj.player = DeserializePlayer(ref b, ref s, ref bR);
        obj.stepsCounter = bR.ReadInt32();
        obj.killCounter = bR.ReadInt32();
        return obj;
    }


    public static byte[] serialize(string stringdata)
    {
        var s = new MemoryStream();
        var bW = new BinaryWriter(s);
        bW.Write(stringdata);
        return s.ToArray();
    }
    public static string DeserializeString(byte[] b)
    {
        var s = new MemoryStream(b);
        var bR = new BinaryReader(s);
        return bR.ReadString();
    }
}
