using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FireManager : MonoBehaviour
{
    public List<GameObject> flamePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        var random = new System.Random();
        CreateFire( -110f, 0f, flamePrefabs[2] );
        CreateFire( -110.4f, 0.4f, flamePrefabs[2] );
        CreateFire( -110.2f, 0f, flamePrefabs[2] );
        CreateFire( -112.5f, 0f, flamePrefabs[2] );
        CreateFire( -115f, 0f, flamePrefabs[2] );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Start is called before the first frame update
    void CreateFire( float x, float z, GameObject flamePrefab )
    {
        Instantiate( flamePrefab, new Vector3( x, 1, z ), Quaternion.identity * Quaternion.Euler (-90f, 0f, 0f) );
    }
}
