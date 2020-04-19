using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EmployeeManager : MonoBehaviour
{
    static readonly string[] names = { "Poopy Eyes", "Two Face", "Monster Monster", "Stinky Shrek", "Cancer", "Giga Chad", "Emperor" };
    static readonly string[] roles = { "Master", "Nemesis", "Loyal Crook", "Stinky Crook", "Cancer Crook", "Padawan" };
    [SerializeField] private int _maxSpeed = 10;
    [SerializeField] private int _maxWalkWaitTime = 10;
    [SerializeField] private float _destinationThreshold = 10.0f;
    [SerializeField] private float _maxRotSpeed = 100.0f;
    [SerializeField] private Transform _employeesParent = null;
    [SerializeField] private int spawneeSize;
    [SerializeField] private List<GameObject> spawnPoints;
    [SerializeField] private List<GameObject> destinationPoints;
    [SerializeField] private GameObject spawneePreFab;

    List<EmployeeController> employees;
    bool _isInitialised;
    System.Random random;

    void Start()
    {
        _isInitialised = false;
        random = new System.Random();
        var randomNames = names.OrderBy(x => random.Next()).ToArray();
        var randomRoles = roles.OrderBy(x => random.Next()).ToArray();

        employees = new List<EmployeeController>();
        for (var i = 0; i < spawneeSize; i++)
        {
            var spawnPoint = spawnPoints[random.Next(spawnPoints.Count)];
            SpawnEmployee(randomNames[i % randomNames.Length], randomRoles[i % randomRoles.Length], spawnPoint.transform.position);
        }
        _isInitialised = true;
    }

    public void Update()
    {
        if (!_isInitialised) return;
        foreach (var employee in employees)
        {
            if (!employee.IsWalking())
            {
                var checkpoint = destinationPoints[random.Next(destinationPoints.Count)];
                StartCoroutine(employee.MoveTo(checkpoint.transform.position));
            }
        }
    }

    public void SpawnEmployee(string name, string role, Vector3 spawnPoint)
    {
        var employeeGameObj = Instantiate(spawneePreFab, spawnPoint, Quaternion.identity, _employeesParent);
        var employeeAgent = employeeGameObj.GetComponent<NavMeshAgent>();
        var employeeScript = employeeGameObj.GetComponent<EmployeeController>();

        employeeScript.Initialise(name, role, _maxSpeed, _maxWalkWaitTime, _destinationThreshold, _maxRotSpeed, employeeAgent, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
        employees.Add(employeeScript);
    }
}
