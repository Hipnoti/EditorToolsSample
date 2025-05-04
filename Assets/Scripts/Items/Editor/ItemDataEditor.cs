using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemData))]
public class ItemDataEditor : Editor
{
    SerializedProperty itemSprite;
    SerializedProperty itemRarity;

    private void OnEnable()
    {
        // Cache the "itemSprite" property to expose it
        itemSprite = serializedObject.FindProperty("itemSprite");
        itemRarity = serializedObject.FindProperty("rarity");
    }

    
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GUILayout.Label("Item Data Editor", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(itemSprite);
        EditorGUILayout.PropertyField(itemRarity);
        
        // Color defaultColor = GUI.color;
        // GUI.color = GetRarityColor((ItemRarity)itemRarity.enumValueIndex);
        // EditorGUILayout.PropertyField(itemRarity);
        // GUI.color = defaultColor;

        serializedObject.ApplyModifiedProperties();
        
        GUIStyle boxStyle = new GUIStyle(GUI.skin.box)
        {
            border = new RectOffset(50, 50, 50, 50), 
            normal = { background = Texture2D.whiteTexture }
        };
        
   
        if (itemSprite.objectReferenceValue)
        {
            GUI.backgroundColor = GetRarityColor((ItemRarity)itemRarity.enumValueIndex);
            Texture2D itemSpriteTexture2D = (itemSprite.objectReferenceValue as Sprite).texture;
            GUILayout.Box(itemSpriteTexture2D, boxStyle,
                GUILayout.Width(256), GUILayout.Height(256));
            GUI.backgroundColor = Color.white;
        }
        
    }

    private Color GetRarityColor(ItemRarity rarity)
    {
        switch (rarity)
        {
            case ItemRarity.Common:
                return Color.gray; // Common items are represented as gray.
            case ItemRarity.Uncommon:
                return Color.green; // Uncommon items are green.
            case ItemRarity.Rare:
                return Color.magenta; // Rare items are blue.
            case ItemRarity.Legendary:
                return Color.yellow;
            default:
                return Color.white; // Default color fallback.
        }

    }
}