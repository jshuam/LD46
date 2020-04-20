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
    [SerializeField] private float _maxRotSpeed;
    [SerializeField] private float _destinationReachedThreshold;

    private Vector3 _destination;
    private float _speed;
    private float _walkWaitTime;
    private bool _isWalking;
    private bool _isStopped;

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

    public void Initialise(string name, string role, Color color)
    {
        fullName = name;
        this.role = role;
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

    public IEnumerator MoveTo(Vector3 target)
    {
        _isWalking = true;
        _destination = target;

        var walkWait = Random.Range(1, _maxWalkWaitTime);
        yield return new WaitForSeconds(walkWait);

        if (agent != null) agent.SetDestination(_destination);
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
