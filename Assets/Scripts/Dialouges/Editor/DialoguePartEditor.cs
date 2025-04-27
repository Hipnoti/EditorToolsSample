using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DialoguePartScriptable))]
public class DialoguePartEditor : Editor
{
    public const string characterSpritesAssetsPath = "Assets/Sprites/Characters/";
    public SerializedProperty textProperty;
    public SerializedProperty hasAudioProperty;
    public SerializedProperty audioClipProperty;
    public SerializedProperty CharacterNameProperty;
    
    Texture2D characterTexture;
    
    private void OnEnable()
    {
        textProperty = serializedObject.FindProperty("text");
        hasAudioProperty = serializedObject.FindProperty("hasAudio");
        audioClipProperty = serializedObject.FindProperty("audioClip");
        CharacterNameProperty = serializedObject.FindProperty("characterName");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(CharacterNameProperty);

        characterTexture = GetCharacterSpriteByName(CharacterNameProperty.stringValue);
        if (characterTexture)
        {
            GUILayout.Box(characterTexture,
            GUILayout.Width(128), GUILayout.Height(128));
        }

        EditorGUILayout.PropertyField(textProperty);
        EditorGUILayout.PropertyField(hasAudioProperty);
        if (hasAudioProperty.boolValue)
        {
            EditorGUILayout.PropertyField(audioClipProperty);
            if (audioClipProperty.objectReferenceValue == null)
                EditorGUILayout.HelpBox("Audio Clip is null", MessageType.Warning);
        }


        serializedObject.ApplyModifiedProperties();
    }

    public Texture2D GetCharacterSpriteByName(string name)
    {
        Texture2D characterTexture2D = AssetDatabase.LoadAssetAtPath<Texture2D>(
            characterSpritesAssetsPath + name + ".jpg");

        return characterTexture2D;
    }
}
