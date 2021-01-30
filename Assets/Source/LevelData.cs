using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Project/LevelData")]
public class LevelData : ScriptableObject
{
	public GameObject grass;
	public GameObject enemy;
	public GameObject playerSpawn;
	public GameObject goal;
	public GameObject rock;
	public GameObject sword;

	public GameObject water;
	public GameObject chest;

}