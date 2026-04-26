using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(ItemsDatabase))]
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

        itemsDatabase.UpdateItemsDatabase();
        //
        // AssetDatabase.SaveAssets();
    }
}