using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelProgressInfo", order = 1)]
public class LevelProgressInfo : ScriptableObject
{
    public int levelToLoad = 1;
    public bool level1Completed = false;
    public bool level2Completed = false;
    public bool level3Completed = false;
}