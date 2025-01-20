using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "DialogueSegment", menuName = "DialogueSegment", order = 0)]
    public class DialogueSegmentData : ScriptableObject
    {
        public List<DialoguePart> dialogueParts;
        
    }
}