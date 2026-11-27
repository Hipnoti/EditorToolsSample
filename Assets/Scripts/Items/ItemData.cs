using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public Sprite itemSprite;
    public ItemRarity rarity;
}

public enum ItemRarity
{
    [InspectorName("Boring")]
    Common,
    [InspectorName("Not Boring")]
    Uncommon,
    [InspectorName("Whow")]
    Rare,
    [InspectorName("Wait for it...!")]
    Legendary
}