using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "DialoguePart", menuName = "DialoguePart", order = 0)]
public class DialoguePart : ScriptableObject
{
    public string text;
    public string character;
    public Sprite moodIcon;

    public bool hasSpeechAudio;
    public AudioClip speechAudio;
    
    public bool hasAudio;
    public AudioClip audioClip;
    
    public bool hasAnimation;
    public string animationName;
    
    
}

