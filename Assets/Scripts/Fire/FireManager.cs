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
        CreateFire( -3, -6, flamePrefabs[random.Next(flamePrefabs.Count)] );
        CreateFire( 3, -6, flamePrefabs[random.Next(flamePrefabs.Count)] );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Start is called before the first frame update
    void CreateFire( int x, int z, GameObject flamePrefab )
    {
        Instantiate( flamePrefab, new Vector3( x, 2, z ), Quaternion.identity * Quaternion.Euler (-90f, 0f, 0f) );
    }
}
