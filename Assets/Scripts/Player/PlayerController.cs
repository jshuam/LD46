using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float sprintSpeed = 10.0f;
    [SerializeField] private Camera mainCamera = null;

    private float horizontal;
    private float vertical;

    private float mouseX;
    private float mouseY;

    private Rigidbody rb;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        startPos = transform.position;

        Cursor.lockState = CursorLockMode.Locked;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();

        if (Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = startPos;
        }
    }
    
    private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    {
        Debug.Log("bruh");
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float finalMoveSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            finalMoveSpeed = sprintSpeed;
        }

        horizontal = Input.GetAxisRaw("Horizontal") * finalMoveSpeed * Time.fixedDeltaTime;
        vertical = Input.GetAxisRaw("Vertical") * finalMoveSpeed * Time.fixedDeltaTime;

        Vector3 movement = horizontal * transform.right + vertical * transform.forward;

        rb.MovePosition(rb.position + movement);
    }

    private void CameraRotation()
    {
        mouseX += Input.GetAxisRaw("Mouse X");
        mouseY += Input.GetAxisRaw("Mouse Y");

        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        transform.localRotation = Quaternion.Euler(Vector3.up * mouseX);
        mainCamera.transform.localRotation = Quaternion.Euler(Vector3.left * mouseY);
    }
}
