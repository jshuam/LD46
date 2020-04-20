using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EmployeeManager : MonoBehaviour
{
    [SerializeField] private GameObject spawneePreFab = null;
    [SerializeField] private Transform _employeesParent = null;
    [SerializeField] private int _spawneeSize = 0;

    // The number to spawn at a time
    [SerializeField] private int _batchSize = 0;
    [SerializeField] private bool _spawnInBatches = true;
    [SerializeField] private bool _isRespawningEnabled = false;
    [SerializeField] private List<GameObject> spawnPoints = new List<GameObject>();
    [SerializeField] private List<GameObject> destinationPoints = new List<GameObject>();
    [SerializeField] private List<string> names = new List<string>();
    [SerializeField] private List<string> roles = new List<string>();

    private FireStarterManager _fireStartermanager = null;

    List<EmployeeController> _employees;
    bool _isInitialSpawningComplete;
    bool _isInitialised;
    System.Random _rand;

    void Start()
    {
        _isInitialised = false;
        _rand = new System.Random();
        _employees = new List<EmployeeController>();
        SpawnEmployees(0);
        _isInitialised = true;

        _fireStartermanager = FindObjectOfType<FireStarterManager>();
        _fireStartermanager.CreateFireStarters();
    }

    public void Update()
    {
        if (!_isInitialised) return;
        foreach (var employee in _employees)
        {
            if (!employee.IsWalking())
            {
                var checkpoint = destinationPoints[_rand.Next(destinationPoints.Count)];
                StartCoroutine(employee.MoveTo(checkpoint.transform.position));
            }
        }

        if ((_spawnInBatches && !_isInitialSpawningComplete) || _isRespawningEnabled) SpawnEmployees(Random.Range(1, 3));
    }


    public void SpawnEmployees(int spawnWaitTime)
    {
        var end = _spawnInBatches ? Mathf.Min(_employees.Count + _batchSize, _spawneeSize) : _spawneeSize;
        var randomNames = names.OrderBy(x => _rand.Next()).ToArray();

        // yield return new WaitForSeconds(spawnWaitTime);

        for (var i = _employees.Count; i < end; i++)
        {
            var spawnPoint = spawnPoints[_rand.Next(spawnPoints.Count)];
            SpawnEmployee(randomNames[i % randomNames.Length], roles[_rand.Next(roles.Count)], spawnPoint.transform.position);
        }
        if (!_isInitialSpawningComplete && _employees.Count == _spawneeSize) _isInitialSpawningComplete = true;
    }

    public void SpawnEmployee(string name, string role, Vector3 spawnPoint)
    {
        var employeeGameObj = Instantiate(spawneePreFab, spawnPoint, Quaternion.identity, _employeesParent);
        var employeeScript = employeeGameObj.GetComponent<EmployeeController>();

        employeeScript.Initialise(name, role, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
        _employees.Add(employeeScript);
    }
}
