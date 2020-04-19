using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireObject : MonoBehaviour
{
    public int x, z;

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    private GameObject instantiatedObject;

    public FireObject( int x, int z, GameObject flamePrefab )
    {
        CreateFire( x, z, flamePrefab );
    }

    // Start is called before the first frame update
    void CreateFire( int x, int z, GameObject flamePrefab )
    {
        instantiatedObject = (GameObject)Instantiate( flamePrefab, new Vector3( x, 1, z ), Quaternion.identity );
    }

    // generate a message when the game shuts down or switches to another Scene
    // or switched to ExampleClass2
    void OnDestroy()
    {
        Destroy( instantiatedObject );
    }
}
