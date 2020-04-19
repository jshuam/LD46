using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EmployeeController : MonoBehaviour
{
    public string fullName;
    public string role;
    public NavMeshAgent agent;

    [SerializeField] private int _maxSpeed;
    [SerializeField] private int _maxWalkWaitTime;
    [SerializeField] private float _destinationReachedThreshold;
    [SerializeField] private float _rotSpeed;

    private EmployeeManager manager;
    private Vector3 _destination;
    private float _speed;
    private float _walkWaitTime;
    private bool _isWalking;

    // Start is called before the first frame update
    void Start()
    {
        _isWalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isWalking && CheckDestinationReached())
        {
            _isWalking = false;
        }
    }
    public void Initialise(string name, string role, int maxSpeed, int maxWalkWaitTime, float destinationThreshold, float maxRotSpeed, NavMeshAgent agent, Color color)
    {
        fullName = name;
        this.role = role;
        this.agent = agent;

        _maxSpeed = maxSpeed;
        _maxWalkWaitTime = maxWalkWaitTime;
        _rotSpeed = Random.Range(Mathf.Max(100f, maxRotSpeed), Mathf.Max(100f, maxRotSpeed));
        _speed = Random.Range(1, _maxSpeed);
        _destinationReachedThreshold = destinationThreshold;
        _walkWaitTime = Random.Range(1, _maxWalkWaitTime);
        this.agent.speed = _speed;
        this.agent.angularSpeed = _rotSpeed;
        SetColor(color);
    }

    public bool IsWalking()
    {
        return _isWalking;
    }

    public void StopWalking()
    {
        _isWalking = false;
    }

    public void ResumWalking()
    {

    }

    public IEnumerator MoveTo(Vector3 target)
    {
        _isWalking = true;
        _destination = target;

        var walkWait = Random.Range(1, _maxWalkWaitTime);
        yield return new WaitForSeconds(walkWait);

        agent.SetDestination(_destination);
    }

    public void SetManager(EmployeeManager manager)
    {
        this.manager = manager;
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

}
