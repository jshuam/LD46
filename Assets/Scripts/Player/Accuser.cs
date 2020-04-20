using UnityEngine;

public class Accuser : MonoBehaviour
{
    [SerializeField] private GameObject accuseText = null;
    [SerializeField] private DialogueTrigger dialogueTrigger = null;
    [SerializeField] private Camera mainCamera = null;

    private FireStarterManager _fireStarterManager = null;
    private RaycastHit _hit;
    private EmployeeController stoppedEmployee = null;

    // Start is called before the first frame update
    void Start()
    {
        _fireStarterManager = FindObjectOfType<FireStarterManager>();
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
            if (_hit.collider.CompareTag("Employee"))
            {
                var employee = _hit.collider.gameObject.GetComponent<EmployeeController>();
                employee.StopMate(transform.position);
                accuseText.SetActive(true);
                stoppedEmployee = employee;
            }
            else
            {
                accuseText.SetActive(false);
            }
        }
        if (_hit.collider == null)
        {
            accuseText.SetActive(false);
            if (stoppedEmployee != null)
            {
                stoppedEmployee.GoOnMate();
                stoppedEmployee = null;
            }
        }
    }

    private void Accuse()
    {
        if (accuseText.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            dialogueTrigger.TriggerDialogue();

            if (_hit.collider != null)
            {
                if (_hit.collider.gameObject.GetComponent<FireStarter>() == null)
                {
                    _fireStarterManager.SpreadNegativity();
                }

                Destroy(_hit.collider.gameObject, 2.0f);
            }
        }
    }
}