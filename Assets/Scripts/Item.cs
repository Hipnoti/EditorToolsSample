using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;

    private void OnValidate()
    {
        if(!meshRenderer)
         meshRenderer = GetComponentInChildren<MeshRenderer>();
    }
}
