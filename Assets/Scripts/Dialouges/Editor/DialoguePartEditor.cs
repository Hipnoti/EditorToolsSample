using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DialoguePartScriptable))]
public class DialoguePartEditor : Editor
{
    public const string CharacterSpritesAssetsPath = "Assets/Sprites/Characters/";
    public SerializedProperty textProperty;
    public SerializedProperty hasAudioProperty;
    public SerializedProperty audioClipProperty;
    public SerializedProperty characterNameProperty;
    public SerializedProperty hasAnimationProperty;
    public SerializedProperty animationClipProperty;
    
    Texture2D characterTexture;
    
    private void OnEnable()
    {
        textProperty = serializedObject.FindProperty("text");
        hasAudioProperty = serializedObject.FindProperty("hasAudio");
        audioClipProperty = serializedObject.FindProperty("audioClip");
        characterNameProperty = serializedObject.FindProperty("characterName");
        hasAnimationProperty = serializedObject.FindProperty("hasAnimation");
        animationClipProperty = serializedObject.FindProperty("animationClip");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(characterNameProperty);

        characterTexture = GetCharacterSpriteByName(characterNameProperty.stringValue);
        if (characterTexture)
        {
            GUILayout.Box(characterTexture,
            GUILayout.Width(128), GUILayout.Height(128));
        }
        else
        {
            EditorGUILayout.HelpBox("No such character found", MessageType.Error);
        }

        EditorGUILayout.PropertyField(textProperty);
        EditorGUILayout.PropertyField(hasAudioProperty);
        if (hasAudioProperty.boolValue)
        { 
            EditorGUILayout.PropertyField(audioClipProperty);
            if (audioClipProperty.objectReferenceValue == null)
                EditorGUILayout.HelpBox("Audio Clip is null", MessageType.Warning);
        }
        
        EditorGUILayout.PropertyField(hasAnimationProperty);
        if (hasAnimationProperty.boolValue)
        {
            EditorGUILayout.PropertyField(animationClipProperty);
        }


        serializedObject.ApplyModifiedProperties();
    }

    public Texture2D GetCharacterSpriteByName(string name)
    {
        Texture2D characterTexture2D = AssetDatabase.LoadAssetAtPath<Texture2D>(
            CharacterSpritesAssetsPath + name + ".jpg");
        
        return characterTexture2D;
    }
}
