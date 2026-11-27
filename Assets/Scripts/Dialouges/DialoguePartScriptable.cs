using UnityEngine;

[CreateAssetMenu(fileName = "DialoguePartScriptable", menuName = "Scriptable Objects/DialoguePartScriptable")]
public class DialoguePartScriptable : ScriptableObject
{
    public string text;
    
    public bool hasAudio;
    public AudioClip audioClip;
    
    [Tooltip("The name of the character speaking this dialogue part.")]
    public string characterName;
    public Texture2D sprite;
    
    public bool hasAnimation;
    public AnimationClip animationClip;
    
    
}
