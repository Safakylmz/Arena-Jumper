using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject coinPrefab;

    
    public int numberofPlatforms = 150;
    public float levelWidth = 3f;
    public float minY = 0.2f;
    public float maxY = 1.5f;
    bool testO = true;
    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        float randomNr = Random.Range(1, 1);

        for (int i = 0; i < numberofPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
