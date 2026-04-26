using UnityEditor;
using UnityEditor.Overlays;
using UnityEditor.Toolbars;
using UnityEngine;

[Overlay(typeof(SceneView), "Custom Toolbar Overlay")]
public class CustomToolbarOverlay : ToolbarOverlay
{
    public CustomToolbarOverlay() : base("custom-toolbar/button1", "custom-toolbar/button2")
    {
    }
}

[EditorToolbarElement("custom-toolbar/button1", typeof(SceneView))]
public class CustomButton1 : EditorToolbarButton
{
    public CustomButton1()
    {
        text = "Button 1";
        tooltip = "This is Button 1!";
        clicked += () =>
        {
            Debug.Log("Button 1 clicked!");
        };
    }
}

[EditorToolbarElement("custom-toolbar/button2", typeof(SceneView))]
public class CustomButton2 : EditorToolbarButton
{
    public CustomButton2()
    {
        text = "Button 2"; 
        tooltip = "This is Button 2!";
        clicked += () =>
        {
            Debug.Log("Button 2 clicked!");
        };
    }
}