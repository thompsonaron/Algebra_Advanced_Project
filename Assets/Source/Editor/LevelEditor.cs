﻿using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelEditor : EditorWindow
{
	int selectedX = -1;
	int selectedY = -1;
	Level level;
	[MenuItem("Project/Level Editor")]
	static void show()
	{
		LevelEditor window = (LevelEditor)EditorWindow.GetWindow(typeof(LevelEditor));
		window.init();
		window.Show();
	}

	public void init()
	{
		if (File.Exists(Util.getLevelPath()))
		{
			level = Util.deserialize(Util.getLevelPath());
		}
		else
		{
			level = new Level();
			level.grid = new TileType[5][];
			level.data = new TileData[5][];
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
						var value = (int)(level.grid[i][j] + 1) % 6;
						level.grid[i][j] = (TileType)value;
					}
				}
			}
		}
		GUI.color = Color.white;

		var saveY = level.grid[0].Length * 50;
		if (GUI.Button(new Rect(0, saveY, 100, 50), "Save"))
		{
			Util.serialize(level, Util.getLevelPath());
			AssetDatabase.Refresh();
		}

        if(selectedX != -1 && selectedY != -1)
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
}