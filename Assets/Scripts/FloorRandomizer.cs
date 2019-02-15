using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRandomizer : MonoBehaviour
{
    [SerializeField] Material[] materials;

    void Start()
    {
        GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];
    }
}
