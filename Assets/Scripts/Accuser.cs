using UnityEngine;

public class Accuser : MonoBehaviour
{
    [SerializeField] private GameObject accuseText = null;
    [SerializeField] private Camera mainCamera = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, mainCamera.transform.forward * 2.5f, out hit, 2.5f))
        {
            if (hit.collider.gameObject.tag == "Employee")
            {
                accuseText.SetActive(true);
            }
            else
            {
                accuseText.SetActive(false);
            }
        }
        if (hit.collider == null)
        {
            accuseText.SetActive(false);
        }
    }
}