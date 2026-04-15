using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DebugBuildProcess : IPostprocessBuildWithReport
{
    public int callbackOrder => 0;
    
    public void OnPostprocessBuild(BuildReport report)
    {
        ulong totalSize = report.summary.totalSize;
        float sizeInMB = totalSize / (1024f * 1024f);
        Debug.Log($"Unity reported build size: {sizeInMB} MB");
        
        string buildPath = report.summary.outputPath;
        string buildDirectory = Path.GetDirectoryName(buildPath);
        
        if (Directory.Exists(buildDirectory))
        {
            float directorySizeMB = GetDirectorySize(buildDirectory) / (1024f * 1024f);
            Debug.Log($"Actual build folder size: {directorySizeMB} MB");
    
            if (directorySizeMB > 10)
            {
              //  Debug.LogError($"Build folder size is over {directorySizeMB} MB! please check why.");
                EditorUtility.DisplayDialog("Whow...", 
                $"build size is over {directorySizeMB} MB! please check why.",
                "oh well...");
            }
        }
    }
    
    private long GetDirectorySize(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        long size = 0;
        
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            size += file.Length;
        }
        
        DirectoryInfo[] dirs = dir.GetDirectories();
        foreach (DirectoryInfo subdir in dirs)
        {
            size += GetDirectorySize(subdir.FullName);
        }
        
        return size;
    }

    public void OnPreprocessBuild(BuildReport report)
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
                    Debug.LogError($"Scene '{currentScene.name}' has {activeCameras} active cameras." +
                                   " FIX IT YOU...!");
                }
            }
        }
    }
    
    // EditorUtility.DisplayDialog("Whow...", 
    // $"build size is over {directorySizeMB} MB! please check why.",
    // "oh well...");
}