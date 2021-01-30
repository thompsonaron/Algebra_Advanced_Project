using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemSO", order = 1)]
public class ItemScriptableObject : ScriptableObject
{
    public Sprite icon;
    public float actionReloadSpeed;
    public int damage;
    public int health;
    public bool ranged;
    // 1 == weapon, 2 == chest, 3 == helmet
    public int itemType;
}