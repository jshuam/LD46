using UnityEngine;

public class Accuser : MonoBehaviour
{
    [SerializeField] private GameObject accuseText = null;
    [SerializeField] private DialogueTrigger dialogueTrigger = null;
    [SerializeField] private Camera mainCamera = null;

    private RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckForFireStarter();
        Accuse();
    }

    private void CheckForFireStarter()
    {
        if (Physics.Raycast(gameObject.transform.position, mainCamera.transform.forward * 2.5f, out _hit, 2.5f))
        {
            if (_hit.collider.gameObject.tag == "Employee")
            {
                accuseText.SetActive(true);
            }
            else
            {
                accuseText.SetActive(false);
            }
        }
        if (_hit.collider == null)
        {
            accuseText.SetActive(false);
        }
    }

    private void Accuse()
    {
        if (accuseText.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            dialogueTrigger.TriggerDialogue();

            // if (_hit.collider != null && _hit.collider.gameObject.GetComponent<FireStarter>())
            // {
            //     _hit.collider.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            // }
        }
    }
}