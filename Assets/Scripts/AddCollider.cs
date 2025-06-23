using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCollider : MonoBehaviour
{
    void Start()
    {
        // Add a MeshCollider component to the GameObject this script is attached to
        MeshCollider collider = gameObject.AddComponent<MeshCollider>();

        // Automatically set the collider to match the mesh bounds of the object
        collider.convex = true; // Set to true if the mesh is convex, false otherwise
    }
}