using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroceryItemsSpawner : MonoBehaviour
{
    [Header("In-Game Spawn Settings")]
    [Tooltip("All Grocery Items prefabs")]
    public GameObject[] groceryItemsPrefabs;
    [Tooltip("World-space point where the next piece preview should appear")]

    public Transform previewSpawnPoint;

    private int nextIndex;
    private GameObject currentPreview;

    void Start()
    {
        nextIndex = Random.Range(0, groceryItemsPrefabs.Length);
    }

    public void SpawnNewGroceryItem()
    {
        Vector3 spawnPos = new Vector3(5, 19, 0);
        GameObject go = Instantiate(groceryItemsPrefabs[nextIndex], spawnPos, Quaternion.identity);

        var tet = go.GetComponent<GroceryItems>();
        //tet.fallTime = GameManager.Instance.CurrentFallTime; // to be uncommented once the gamemanager script is created, otherwise has compilation error

        nextIndex = Random.Range(0, groceryItemsPrefabs.Length);
        UpdatePreview();
    }

    private void UpdatePreview()
    {
        if (currentPreview != null)
        {
            Destroy(currentPreview);
        }

        currentPreview = Instantiate(groceryItemsPrefabs[nextIndex], previewSpawnPoint.position, Quaternion.identity);

        var tScript = currentPreview.GetComponent<GroceryItems>();
        if (tScript != null)
        {
            tScript.enabled = false;
            
        }
    }

    public void ClearPreview()
    {
        if (currentPreview != null)
        {
            Destroy(currentPreview);
        }
    }
}
