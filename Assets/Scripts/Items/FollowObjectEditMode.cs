using System;
using UnityEngine;

[ExecuteAlways]
public class FollowObjectEditMode : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    
    private void Update()
    {
        transform.LookAt(targetTransform);
    }
}
