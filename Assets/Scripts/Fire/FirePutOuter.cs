using UnityEngine;

public class FirePutOuter : MonoBehaviour
{
    [SerializeField] private GameObject putOutFireText = null;
    private FireManager _fireManager = null;
    private RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {
        _fireManager = FindObjectOfType<FireManager>();
    }

    void Update()
    {
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * 2.5f, Color.red);
        FireDetect();
        PutOutFire();
    }

    void FireDetect()
    {
        Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out _hit, 2.5f);

        if (_hit.collider != null && _hit.transform.tag == "Flame")
        {
            putOutFireText.SetActive(true);
        }
        else
        {
            putOutFireText.SetActive(false);
        }
    }

    private void PutOutFire()
    {
        if (putOutFireText.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            GameObject fire = _hit.transform.gameObject; 
            Destroy(fire);
            _fireManager.PutOutFire(fire);
        }
    }
}
