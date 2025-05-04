using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectTools
{
    private const string SceneOnePath = "Assets/Scenes/Scene 1.unity";
    private const string SceneTwoPath = "Assets/Scenes/Scene 2.unity";


    [MenuItem("Tools/Load Scene 1 ^=")]
    static void LoadSceneOne()
    {
        LoadScene(SceneOnePath);
    }
    
    [MenuItem("Tools/Load Scene 2")]
    static void LoadSceneTwo()
    {
        LoadScene(SceneTwoPath);
    }

    static void LoadScene(string sceneName)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(sceneName);
        }
    }

}
