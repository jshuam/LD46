using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FireManager : MonoBehaviour
{
    [SerializeField] private GameObject flamePrefab = null;

    [SerializeField] private GameObject noCollisionFlamePrefab = null;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Start is called before the first frame update
    public void CreateFire(float x, float z, bool collide = true)
    {
        if( collide )
        {
            Instantiate( flamePrefab, new Vector3(x, 2, z), Quaternion.identity * Quaternion.Euler(-90f, 0f, 0f) );
        }
        else
        {
            Instantiate( noCollisionFlamePrefab, new Vector3(x, 2, z), Quaternion.identity * Quaternion.Euler(-90f, 0f, 0f) );
        }
    }
}
