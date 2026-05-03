using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteAlways]
public class RadialLayout : MonoBehaviour
{
    public float radius = 5f;
    public float startAngle = 0f;
    public bool orientToCenter = true;

    private void Update()
    {
        if(Application.isPlaying) return;
        AlignChildren();
    }
    
    public void AlignChildren()
    {
        int childCount = transform.childCount;
        if (childCount == 0) return;
    
        float angleStep = 360f / childCount;
    
        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
    
            #if UNITY_EDITOR
            Undo.RecordObject(child, "Radial Alignment");
            #endif
    
            float angle = startAngle + i * angleStep;
            float radian = angle * Mathf.Deg2Rad;
    
            Vector3 localPosition = new Vector3(
                Mathf.Cos(radian) * radius,
                0f,
                Mathf.Sin(radian) * radius
            );
    
            child.localPosition = localPosition;
    
            if (orientToCenter)
            {
                child.LookAt(transform.position);
            }
            
            #if UNITY_EDITOR
            EditorUtility.SetDirty(child);
            #endif
        }
    }
    
}
