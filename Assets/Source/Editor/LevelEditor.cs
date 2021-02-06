using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelEditor : EditorWindow
{
	int selectedX = -1;
	int selectedY = -1;

	int currentLevel = 1;

	Level level;
	[MenuItem("Project/Level Editor")]
	static void show()
	{
		LevelEditor window = (LevelEditor)EditorWindow.GetWindow(typeof(LevelEditor));
		window.init();
		window.Show();
	}

	public void init(int levelNum = 1)
	{
		LoadLevel(levelNum);
	}

	public void LoadLevel(int lvlNumber)
    {
		if (File.Exists(Util.getLevelPath(lvlNumber)))
		{
			level = Util.deserialize(Util.getLevelPath(lvlNumber));
		}
		else
		{
			level = new Level();
			level.grid = new TileType[5][];
			level.data = new TileData[5][];
			level.goalType = 1;
			for (int i = 0; i < level.grid.Length; i++)
			{
				level.grid[i] = new TileType[5];
				level.data[i] = new TileData[5];
				for (int j = 0; j < level.data[i].Length; j++)
				{
					level.data[i][j] = new TileData();
				}
			}
		}
	}

	void OnGUI()
    {
        LoadLevellFields();
        GUI.color = Color.white;
        // SAVE
        var saveY = level.grid[0].Length * 50;
        if (GUI.Button(new Rect(0, saveY, 100, 50), "Save"))
        {
            Util.serialize(level, Util.getLevelPath(currentLevel));
            AssetDatabase.Refresh();
        }

        // LOAD
        if (GUI.Button(new Rect(0, saveY + 50, 100, 50), "Load lvl 1"))
        {
            currentLevel = 1;
            LoadLevel(1);
            LoadLevellFields();
            AssetDatabase.Refresh();
        }
        if (GUI.Button(new Rect(100, saveY + 50, 100, 50), "Load lvl 2"))
        {
            currentLevel = 2;
            LoadLevel(2);
            LoadLevellFields();
            AssetDatabase.Refresh();
        }
        if (GUI.Button(new Rect(200, saveY + 50, 100, 50), "Load lvl 3"))
        {
            currentLevel = 3;
            LoadLevel(3);
            LoadLevellFields();
            AssetDatabase.Refresh();
        }
        GUI.Label(new Rect(300, saveY + 50, 100, 50), "Loaded lvl " + currentLevel);


        GUI.BeginGroup(new Rect(0, level.grid[0].Length * 50 + 150, Screen.width, Screen.height));
        GUILayout.BeginVertical();
        GUILayout.Label("");
        GUILayout.Label("Goal: ", GUILayout.Width(70));
        level.goalType = (int)GUILayout.HorizontalSlider(level.goalType, 1, 3, GUILayout.Width(50));
        //GUILayout.Label("", GUILayout.Width(70));
        switch (level.goalType)
        {
            case 1:
                GUILayout.Label("Kill all enemies", GUILayout.Height(40));
                break;
            case 2:
                GUILayout.Label("Kill the boss", GUILayout.Height(40));
                break;
            case 3:
                GUILayout.Label("Reach goal in 10 steps", GUILayout.Height(40));
                break;
            default:
                break;
        }
        GUILayout.EndVertical();
        GUI.EndGroup();

        if (selectedX != -1 && selectedY != -1)
        {
            var tile = level.data[selectedX][selectedY];

            GUI.BeginGroup(new Rect(0, level.grid[0].Length * 50 + 50, Screen.width, Screen.height));
            GUILayout.BeginHorizontal();
            GUILayout.Label("isRanged: ", GUILayout.Width(70));
            tile.isRanged = GUILayout.Toggle(tile.isRanged, "");
            GUILayout.EndHorizontal();

            GUI.EndGroup();
        }
    }

    private void LoadLevellFields()
    {
        if (level == null || level.grid == null)
        {
            init();
        }

        for (int i = 0; i < level.grid.Length; i++)
        {
            for (int j = 0; j < level.grid[i].Length; j++)
            {
                GUI.color = Util.getColor(level.grid[i][j]);
                if (GUI.Button(new Rect(i * 100, j * 50, 100, 50), level.grid[i][j].ToString()))
                {
                    if (Event.current.button == 1)
                    {
                        selectedX = i;
                        selectedY = j;
                    }
                    else
                    {
                        var value = (int)(level.grid[i][j] + 1) % 9;
                        level.grid[i][j] = (TileType)value;
                    }
                }
            }
        }
    }
}