 using UnityEditor;
 using UnityEngine;
//
 [CustomEditor(typeof(DialoguePartScriptable))]
 public class DialoguePartEditor : Editor
{
     public const string characterSpritesAssetsPath = "Assets/Sprites/Characters/";
     public SerializedProperty textProperty;
     public SerializedProperty characterNameProperty;
     public SerializedProperty hasAudioProperty;
     public SerializedProperty audioClipProperty;

     public SerializedProperty hasAnimationProperty;
     public SerializedProperty animationClipProperty;
//     
     Texture2D characterTexture;
//     
     private void OnEnable()
     {
         textProperty = serializedObject.FindProperty("text");
         hasAudioProperty = serializedObject.FindProperty("hasAudio");
         audioClipProperty = serializedObject.FindProperty("audioClip");
         characterNameProperty = serializedObject.FindProperty("characterName");
         hasAnimationProperty = serializedObject.FindProperty("hasAnimation");
         animationClipProperty = serializedObject.FindProperty("animationClip");
     }
//
     public override void OnInspectorGUI()
     { 
         serializedObject.Update();
//   
         EditorGUILayout.PropertyField(characterNameProperty);
//
           characterTexture = GetCharacterSpriteByName(characterNameProperty.stringValue);
         if (characterTexture)
         {
             GUIStyle style = new GUIStyle(GUI.skin.box)
             {
                 border = { top = 50, left = 50, right = 50, bottom = 50 },
                 normal = { background = Texture2D.whiteTexture }
             };
             GUI.backgroundColor = Color.yellow;
             GUILayout.Box(characterTexture, style,
             GUILayout.Width(128), GUILayout.Height(128));
             GUI.backgroundColor = Color.white;
         }
         else
         {
             EditorGUILayout.HelpBox("No such character found", MessageType.Error);
         }
//         
         EditorGUILayout.PropertyField(textProperty);
         EditorGUILayout.PropertyField(hasAudioProperty);
         if (hasAudioProperty.boolValue)
         {
            EditorGUILayout.PropertyField(audioClipProperty);
             if (audioClipProperty.objectReferenceValue == null)
                 EditorGUILayout.HelpBox("Audio Clip is null", MessageType.Warning );
         }
//         
         EditorGUILayout.PropertyField(hasAnimationProperty);
         if (hasAnimationProperty.boolValue)
         {
             EditorGUILayout.PropertyField(animationClipProperty);
         }
//
//
        serializedObject.ApplyModifiedProperties();
     }
//
     public Texture2D GetCharacterSpriteByName(string name)
     {
         Texture2D characterTexture2D = AssetDatabase.LoadAssetAtPath<Texture2D>(
             characterSpritesAssetsPath + name + ".jpg");
     
         return characterTexture2D;
     }
 }
