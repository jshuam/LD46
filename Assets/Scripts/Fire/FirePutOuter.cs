using UnityEngine;

public class FirePutOuter : MonoBehaviour
{
    [SerializeField] private GameObject putOutFireText = null;
    private RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {

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
            Destroy(_hit.transform.gameObject);
        }
    }
}
