using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStarterManager : MonoBehaviour
{
    [SerializeField] private int _currentFireStarters = 0;
    [SerializeField] private GameObject _employeesParent = null;

    private GameObject[] _employees;
    private System.Random _random = new System.Random();
    private int _fireStarterLimit = 1;

    // Start is called before the first frame update
    void Start()
    {
        CreateFireStarters();
    }

    // Update is called once per frame
    public void SpreadNegativity()
    {
        _currentFireStarters--;
        _fireStarterLimit++;
        CreateFireStarters();
    }

    private void CreateFireStarters()
    {
        if (_employeesParent.GetComponentsInChildren<FireStarter>().Length == _employeesParent.transform.childCount)
            return;

        for (int i = _currentFireStarters; i < _fireStarterLimit; i++)
        {
            int randIdx = _random.Next(_employeesParent.transform.childCount);
            _employeesParent.transform.GetChild(randIdx).gameObject.AddComponent<FireStarter>();
            _currentFireStarters++;
        }
    }
}
