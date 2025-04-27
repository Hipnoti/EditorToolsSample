using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DialoguePartScriptable))]
public class DialoguePartEditor : Editor
{
    public SerializedProperty textProperty;
    public SerializedProperty hasAudioProperty;
    public SerializedProperty audioClipProperty;
    public SerializedProperty characterName;
    
    private void OnEnable()
    {
        textProperty = serializedObject.FindProperty("text");
        hasAudioProperty = serializedObject.FindProperty("hasAudio");
        audioClipProperty = serializedObject.FindProperty("audioClip");
        characterName = serializedObject.FindProperty("characterName");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(hasAudioProperty);
        if (hasAudioProperty.boolValue)
        {
            EditorGUILayout.PropertyField(audioClipProperty);
            if(audioClipProperty.objectReferenceValue == null)
                EditorGUILayout.HelpBox("Audio Clip is null", MessageType.Warning);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
