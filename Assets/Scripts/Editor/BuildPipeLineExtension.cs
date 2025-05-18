using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class BuildPipeLineExtension
{
    static BuildPipeLineExtension()
    {
        BuildPlayerWindow.RegisterBuildPlayerHandler(BuildPlayerWithValidation);
    }

    private static void BuildPlayerWithValidation(BuildPlayerOptions options)
    {
        bool allGood = true;
        if (!ValidateActiveCameras())
        {
            allGood = EditorUtility.DisplayDialog("Build Error", "TOO MANY CAMERAS", 
                "JUST DO IT", "Go Back!");
        }
        
        if(allGood)
           BuildPipeline.BuildPlayer(options);
    }
    
    private static bool ValidateActiveCameras()
    {
        foreach (var scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
            {
                var scenePath = scene.path;
                Scene currentScene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);
    
                Camera[] cameras = GameObject.FindObjectsOfType<Camera>();
                int activeCameras = 0;
    
                foreach (var cam in cameras)
                {
                    if (cam.isActiveAndEnabled)
                    {
                        activeCameras++;
                    }
                }
    
                if (activeCameras > 1)
                {
                    return false;
                }
            }
        }

        return true;
    }

}
