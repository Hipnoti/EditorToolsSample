using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEditor.Overlays;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[Overlay(typeof(SceneView), "Scene Selector Toolbar", group = "Advanced Subjects")]
public class SceneSelectorOverlay : Overlay
{
    public override VisualElement CreatePanelContent()
    {
        // Create the root container
        var root = new VisualElement();
        root.style.flexDirection = FlexDirection.Row;

        // Create a dropdown menu
        var dropdown = new ToolbarMenu { text = "Select Scene" };

        // Populate dropdown menu with scenes
        foreach (var scene in GetAllScenesInProjectExcludePackages())
        {
            dropdown.menu.AppendAction(scene.Name, _ =>
            {
                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    EditorSceneManager.OpenScene(scene.Path);
                }
            });
        }

        // Add the dropdown to the overlay's content
        root.Add(dropdown);

        return root;
    }

    private List<SceneInfo> GetAllScenesInProjectExcludePackages()
    {
        var scenes = new List<SceneInfo>();

        // Find all scene files in the project
        string[] guids = AssetDatabase.FindAssets("t:Scene");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);

            // Exclude scenes in packages
            if (path.StartsWith("Packages")) continue;

            string name = System.IO.Path.GetFileNameWithoutExtension(path);
            scenes.Add(new SceneInfo(name, path));
        }

        return scenes;
    }

    private class SceneInfo
    {
        public string Name;
        public string Path;

        public SceneInfo(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}