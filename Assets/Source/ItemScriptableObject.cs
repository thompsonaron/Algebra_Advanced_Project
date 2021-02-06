using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemSO", order = 1)]
[Serializable]
public class ItemScriptableObject : ScriptableObject
{
    public int ID = -1;
    public Sprite icon;
    public float actionReloadSpeed;
    public int damage;
    public int health;
    public bool ranged;
    // 1 == weapon, 2 == chest, 3 == helmet
    public int itemType;
}