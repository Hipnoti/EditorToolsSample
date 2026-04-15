using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public Sprite itemSprite;
    public ItemRarity rarity;
}

public enum ItemRarity
{
    Common,
    Uncommon,
    Rare,
    Legendary
}