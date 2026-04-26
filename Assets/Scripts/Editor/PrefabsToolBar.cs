#if UNITY_2021_2_OR_NEWER
using UnityEditor;
using UnityEditor.Toolbars;
using UnityEditor.Overlays;
using UnityEngine;
using System.Collections.Generic;

[EditorToolbarElement(id: PrefabToolbarOverlayWithCustomIcons.ToolbarElementID)]
public class PrefabToolbarOverlayWithCustomIcons : EditorToolbarDropdown
{
    public const string ToolbarElementID = "PrefabToolbarOverlayWithCustomIcons/PrefabsDropdown";

    private static List<GameObject> prefabs = new List<GameObject>();
    private static Dictionary<string, Texture2D> prefabIcons = new Dictionary<string, Texture2D>();

    public PrefabToolbarOverlayWithCustomIcons()
    {
        text = "Prefabs";
        clicked += ShowDropdown;
    }

    private void ShowDropdown()
    {
        GenericMenu menu = new GenericMenu();

        if (prefabs.Count == 0)
        {
            menu.AddDisabledItem(new GUIContent("No prefabs found."));
        }
        else
        {
            foreach (var prefab in prefabs)
            {
                if (prefab != null)
                {
                    GUIContent menuItemContent = new GUIContent(prefab.name, GetCustomPrefabIcon(prefab));

                    menu.AddItem(
                        menuItemContent,
                        false,
                        () => InstantiatePrefab(prefab)
                    );
                }
            }
        }

        menu.ShowAsContext();
    }

    private void InstantiatePrefab(GameObject prefab)
    {
        if (prefab != null)
        {
            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            Undo.RegisterCreatedObjectUndo(instance, "Instantiate Prefab");
            instance.transform.position = Vector3.zero;

            Selection.activeObject = instance;
        }
    }
 
    private Texture2D GetCustomPrefabIcon(GameObject prefab)
    {
        if (prefabIcons.TryGetValue(prefab.name, out Texture2D icon))
        {
            return icon;
        }

        GUIContent content = EditorGUIUtility.ObjectContent(prefab, prefab.GetType());
        return content.image as Texture2D;
    }

    [InitializeOnLoadMethod]
    private static void LoadPrefabsAndIcons()
    {
        prefabs.Clear();
        prefabIcons.Clear();

        string[] prefabGuids = AssetDatabase.FindAssets("t:Prefab", new[] { "Assets/Prefabs" });
        foreach (string guid in prefabGuids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
            if (prefab != null) prefabs.Add(prefab);
        }

        string[] iconGuids = AssetDatabase.FindAssets("t:Texture2D", new[] { "Assets/Sprites/Items" });
        foreach (string guid in iconGuids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            Texture2D icon = AssetDatabase.LoadAssetAtPath<Texture2D>(assetPath);
            if (icon != null)
            {
                string iconName = System.IO.Path.GetFileNameWithoutExtension(assetPath);
                prefabIcons[iconName] = icon;
            }
        }

        prefabs.Sort((a, b) => string.Compare(a.name, b.name, System.StringComparison.Ordinal));
    }
}

[Overlay(typeof(SceneView), "Prefab Toolbar Overlay with Custom Icons")]
public class PrefabToolbarWithCustomIcons : ToolbarOverlay
{
    public PrefabToolbarWithCustomIcons() : base(PrefabToolbarOverlayWithCustomIcons.ToolbarElementID) {}
}
#endif