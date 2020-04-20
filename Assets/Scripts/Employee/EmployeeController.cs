using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EmployeeController : MonoBehaviour
{
    public NavMeshAgent agent;
    public TextMesh employeeDetails = null;

    [SerializeField] private int _maxSpeed = 5;
    [SerializeField] private int _maxWalkWaitTime = 10;
    [SerializeField] private float _maxRotSpeed = 180;
    [SerializeField] private float _destinationReachedThreshold = 10;
    [SerializeField] private float _detailsDistanceThreshold = 200;

    private Vector3 _destination;
    private float _speed;
    private float _walkWaitTime;
    private bool _isWalking;
    private bool _isStopped;
    private FireManager _fireManager;

    private GameObject _fire;

    // Start is called before the first frame update
    void Start()
    {
        _isWalking = false;

        _fireManager = FindObjectOfType<FireManager>();
    }


    void Update()
    {
        DisplayEmployeeDetails();
        UpdateWalkingStatus();

        if (_fire != null)
            _fire.transform.position = transform.position;
    }

    public void Initialise(string name, string role, Color color)
    {
        employeeDetails.text = $"{name} <{role}>";
        employeeDetails.color = color;
        _speed = Random.Range(1, _maxSpeed);
        _walkWaitTime = Random.Range(1, _maxWalkWaitTime);
        agent.speed = _speed;
        agent.angularSpeed = Random.Range(100f, Mathf.Max(_maxRotSpeed, 100f));

        SetColor(color);
    }

    public bool IsWalking()
    {
        return _isWalking;
    }

    public void StopMate(Vector3 directionToFace)
    {
        agent.SetDestination(transform.position);
        var targetRotation = Quaternion.LookRotation(directionToFace - transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3.0f);
    }

    public void GoOnMate()
    {
        agent.SetDestination(_destination);
    }

    void UpdateWalkingStatus()
    {
        if (_isWalking && CheckDestinationReached())
        {
            _isWalking = false;
        }
    }

    void DisplayEmployeeDetails()
    {
        // Only display text if camera is within a certain range
        if (Vector3.SqrMagnitude(employeeDetails.transform.position - Camera.main.transform.position) < _detailsDistanceThreshold)
        {
            employeeDetails.gameObject.SetActive(true);

            // Rotate text to face camera
            employeeDetails.transform.LookAt(Camera.main.transform.position);
            employeeDetails.transform.Rotate(0, 180, 0);
        }
        else
        {
            employeeDetails.gameObject.SetActive(false);
        }
    }

    public IEnumerator MoveTo(Vector3 target)
    {
        _isWalking = true;
        _destination = target;

        var walkWait = Random.Range(1, _maxWalkWaitTime);
        yield return new WaitForSeconds(walkWait);

        if (agent != null) agent.SetDestination(_destination);
    }

    public void UrFired()
    {
        _fire = _fireManager.CreateFireWithObject(transform.position);
    }

    void SetColor(Color color)
    {
        var material = GetComponent<Renderer>().material;
        material.color = color;
    }

    bool CheckDestinationReached()
    {
        if (_isWalking)
        {
            var offset = _destination - transform.position;
            var distanceToTarget = Vector3.SqrMagnitude(offset);
            return distanceToTarget < _destinationReachedThreshold;
        }

        return true;
    }

    void OnDestroy()
    {
        Destroy(_fire);
    }

}
