using UnityEngine;

public class FireStarter : MonoBehaviour
{
    private FireManager _fireManager;
    private System.Random _random;

    // Start is called before the first frame update
    void Start()
    {
        _random = new System.Random();
        _fireManager = FindObjectOfType<FireManager>();
        InvokeRepeating("RandomFire", 1.0f, 5.0f);
    }

    void RandomFire()
    {
        if (_random.Next(100) > 60)
        {
            _fireManager.CreateFire(gameObject.transform.position.x, gameObject.transform.position.z - 1.5f);
        }
    }
}
