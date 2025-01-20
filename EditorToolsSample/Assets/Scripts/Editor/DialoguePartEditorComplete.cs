// using UnityEditor;
//
// [CustomEditor(typeof(DialoguePart))]
// public class DialoguePartEditorComplete : Editor
// {
//     private SerializedProperty dialogueTextProperty;
//     private SerializedProperty hasAudioProperty;
//     private SerializedProperty audioClipProperty;
//     private SerializedProperty characterProperty;
//
//     private void OnEnable()
//     {
//         dialogueTextProperty = serializedObject.FindProperty("text");
//         characterProperty = serializedObject.FindProperty("character"); 
//         hasAudioProperty = serializedObject.FindProperty("hasAudio");
//         audioClipProperty = serializedObject.FindProperty("audioClip");
//     }
//
//     public override void OnInspectorGUI()
//     {
//         serializedObject.Update();
//         EditorGUILayout.PropertyField(dialogueTextProperty);
//         EditorGUILayout.Space();
//         EditorGUILayout.PropertyField(hasAudioProperty);
//
//         if (hasAudioProperty.boolValue)
//         {
//             EditorGUILayout.PropertyField(audioClipProperty);
//             if(audioClipProperty.objectReferenceValue == null)
//                 EditorGUILayout.HelpBox("Please select an audio clip", MessageType.Warning);
//         }
//
//         serializedObject.ApplyModifiedProperties();
//         
//         
//     }
// }
