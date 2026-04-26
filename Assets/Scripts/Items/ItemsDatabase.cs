using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsDatabase", menuName = "Scriptable Objects/ItemsDatabase")]
public class ItemsDatabase : ScriptableObject
{
    public ItemData[] items;

    //[ContextMenu("Update Items Database")]
    public void UpdateItemsDatabase()
    {
        GUID[] guids = AssetDatabase.FindAssetGUIDs("t:ItemData");
        List<ItemData> itemDataList = new List<ItemData>();

        foreach (GUID guid in guids)
        {
            ItemData itemData = AssetDatabase.LoadAssetByGUID<ItemData>(guid);
            if (itemData)
            {
                itemDataList.Add(itemData);
            }
        }
        
        
        items = itemDataList.ToArray();
        
        EditorUtility.SetDirty(this);
    }
}
