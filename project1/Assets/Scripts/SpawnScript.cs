using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public KeyCode spawnKey = KeyCode.Space;

    // Update is called once per frame
    void Update()
    {
        // Check if the specified key is pressed
        if (Input.GetKeyDown(spawnKey))
        {
            // Spawn a new object based on the prefab
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
    }
}
