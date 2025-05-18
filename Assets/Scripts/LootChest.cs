using System;
using UnityEngine;
using UnityEngine.Serialization;

public class LootChest : MonoBehaviour
{
    public ItemRarity itemsSpawnRarity;
    [SerializeField] private Collider chestCollider;

    private void OnValidate()
    {
        if(!chestCollider)
            chestCollider = GetComponent<Collider>();
    }

    private void Reset()
    {
        transform.localScale = Vector3.one * 2;
        //Add here other reset stuff!
    }
}
