using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FireManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> flamePrefabs = null;
    private System.Random _random;

    // Start is called before the first frame update
    void Start()
    {
        // CreateFire(-3, -6, flamePrefabs[random.Next(flamePrefabs.Count)]);
        // CreateFire(3, -6, flamePrefabs[random.Next(flamePrefabs.Count)]);
        _random = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Start is called before the first frame update
    public void CreateFire(float x, float z)
    {
        Instantiate(flamePrefabs[_random.Next(flamePrefabs.Count)], new Vector3(x, 2, z), Quaternion.identity * Quaternion.Euler(-90f, 0f, 0f));
    }
}
