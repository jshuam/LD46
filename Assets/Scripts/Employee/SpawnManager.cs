using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Vector3 spawnCentre;
    public Vector3 spawnSize;
    public GameObject spawneePreFab;
    public int spawneeSize;

    void Start()
    {
        for (var i = 0; i < spawneeSize; i++)
        {
            SpawnObject();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnObject()
    {
        Vector3 pos = spawnCentre + new Vector3(Random.Range(-spawnSize.x / 2, spawnSize.x / 2), Random.Range(-spawnSize.y / 2, spawnSize.y / 2), Random.Range(-spawnSize.z / 2, spawnSize.z / 2));
        Instantiate(spawneePreFab, pos, Quaternion.identity);
    }
}
