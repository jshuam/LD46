using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EmployeeManager : MonoBehaviour
{
    static readonly string[] names = { "Poopy Eyes", "Two Face", "Monster Monster", "Stinky Shrek", "Cancer", "Giga Chad", "Emperor" };
    static readonly string[] roles = { "Master", "Nemesis", "Loyal Crook", "Stinky Crook", "Cancer Crook", "Padawan" };
    [SerializeField] private int _maxSpeed;
    [SerializeField] private int _maxWalkWaitTime;
    [SerializeField] private float _destinationThreshold;
    [SerializeField] private float _maxRotSpeed;

    public List<GameObject> checkpoints;
    List<EmployeeController> employees;
    public Vector3 spawnCentre;
    public Vector3 spawnSize;
    public GameObject spawneePreFab;
    public int spawneeSize;

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
            SpawnEmployee(randomNames[i % randomNames.Length], randomRoles[i % randomRoles.Length]);
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
                var checkpoint = checkpoints[random.Next(checkpoints.Count)];
                StartCoroutine(employee.MoveTo(checkpoint.transform.position));
            }
        }
    }
    public void SpawnEmployee(string name, string role)
    {
        Vector3 pos = spawnCentre + new Vector3(Random.Range(-spawnSize.x / 2, spawnSize.x / 2), Random.Range(-spawnSize.y / 2, spawnSize.y / 2), Random.Range(-spawnSize.z / 2, spawnSize.z / 2));
        var employeeGameObj = Instantiate(spawneePreFab, pos, Quaternion.identity);
        var employeeAgent = employeeGameObj.GetComponent<NavMeshAgent>();
        var employeeScript = employeeGameObj.GetComponent<EmployeeController>();
        employeeScript.Initialise(name, role, _maxSpeed, _maxWalkWaitTime, _destinationThreshold, _maxRotSpeed, employeeAgent, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
        employees.Add(employeeScript);
    }
}
