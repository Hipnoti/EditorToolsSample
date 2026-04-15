using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemsDatabase))]
public class ItemsDatabaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Find all items in assets!"))
        {
            UpdateItemsDatabase();
        }
    }

    private void UpdateItemsDatabase()
    {
        ItemsDatabase itemsDatabase = (ItemsDatabase)target;

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
        
        
        itemsDatabase.items = itemDataList.ToArray();
        
         EditorUtility.SetDirty(itemsDatabase);
        //
        // AssetDatabase.SaveAssets();
    }
}