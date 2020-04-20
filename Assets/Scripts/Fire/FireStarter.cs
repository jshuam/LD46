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

    void Update()
    {
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * 2.5f, Color.blue);
    }

    void RandomFire()
    {
        if (_random.Next(100) > 60)
        {
            RaycastHit hit;
            Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, 2.5f);

            if (hit.collider == null)
            {
                _fireManager.CreateFire(gameObject.transform.position);
            }
        }
    }
}
