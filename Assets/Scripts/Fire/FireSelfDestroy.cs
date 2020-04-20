using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSelfDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke( "DestroyLater", 2f );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyLater()
    {
        Destroy( gameObject );
    }
}
