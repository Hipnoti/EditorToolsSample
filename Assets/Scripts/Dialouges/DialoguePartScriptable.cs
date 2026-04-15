using UnityEngine;

[CreateAssetMenu(fileName = "DialoguePartScriptable", menuName = "Scriptable Objects/DialoguePartScriptable")]
public class DialoguePartScriptable : ScriptableObject
{
    public string text;
    
    public bool hasAudio;
    public AudioClip audioClip;
    
    public string characterName;
    public Texture2D sprite;
}
