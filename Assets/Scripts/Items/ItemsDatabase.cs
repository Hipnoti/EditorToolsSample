using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsDatabase", menuName = "Scriptable Objects/ItemsDatabase")]
public class ItemsDatabase : ScriptableObject
{
    public ItemData[] items;

    [ContextMenu("Update Items Database")]
    public void UpdateItemsDatabase()
    {
        string[] guids = AssetDatabase.FindAssets("t:ItemData");
        List<ItemData> itemDataList = new List<ItemData>();

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            ItemData itemData = AssetDatabase.LoadAssetAtPath<ItemData>(path);
            if (itemData)
            {
                itemDataList.Add(itemData);
            }
        }
        
        
        items = itemDataList.ToArray();
        
        EditorUtility.SetDirty(this);
    }
}
