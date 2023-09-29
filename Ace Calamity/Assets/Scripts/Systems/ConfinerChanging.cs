using Cinemachine;
using UnityEngine;
using System.Collections.Generic;

public class ConfinerChanging : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera playerFollowCamera;
    private CinemachineConfiner2D boundingConfiner;

    // Create a dictionary to map region tags to their colliders
    private Dictionary<string, PolygonCollider2D> regionColliders = new Dictionary<string, PolygonCollider2D>();

    private void Start()
    {
        boundingConfiner = playerFollowCamera.GetComponent<CinemachineConfiner2D>();

        // Populate the dictionary with regions by finding objects with PolygonCollider2D components and tags
        PolygonCollider2D[] collidersInScene = FindObjectsOfType<PolygonCollider2D>();
        foreach (PolygonCollider2D collider in collidersInScene)
        {
            if (!string.IsNullOrEmpty(collider.gameObject.tag))
            {
                regionColliders[collider.gameObject.tag] = collider;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string regionTag = other.gameObject.tag;

        // Check if the region tag exists in the dictionary
        if (regionColliders.ContainsKey(regionTag))
        {
            Debug.Log("Entered " + regionTag);
            boundingConfiner.m_BoundingShape2D = regionColliders[regionTag];
        }
    }
}
