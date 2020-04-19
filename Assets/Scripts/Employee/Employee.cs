using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee : MonoBehaviour
{

    public int maxWalkTime = 5;
    public int maxWalkWaitTime = 3;
    public int maxRotateWaitTime = 3;
    public int maxRotateTime = 3;

    private Material _material;
    private float _speed;
    private float _rotSpeed = 100f;
    private bool _isWandering = false;
    private bool _isRotatingLeft = false;
    private bool _isRotatingRight = false;
    private bool _isWalking = false;


    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<Renderer>().material;
        _speed = (float) Random.Range(1,5);
        ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isWandering)
        {
            StartCoroutine(Wander());
        }
        if (_isRotatingRight)
        {
            transform.Rotate(transform.up * Time.deltaTime * _rotSpeed);
        }
        else if (_isRotatingLeft)
        {
            transform.Rotate(transform.up * Time.deltaTime * -_rotSpeed);
        }
        if (_isWalking)
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
    }

    void ChangeColor(){
        _material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    void KillMe(){
        // Will kill the object
    }

    IEnumerator Wander()
    {
        _isWandering = true;

        // Amount of times the capsule rotates
        var rotTime = Random.Range(1, maxRotateTime);

        var rotateWait = Random.Range(1, maxRotateWaitTime);
        var rotateLorR = Random.Range(1, 2);

        // How long till employee will walk
        var walkWait = Random.Range(1, maxRotateWaitTime);
        var walkTime = Random.Range(1, maxWalkTime);

        yield return new WaitForSeconds(walkWait);

        _isWalking = true;
        yield return new WaitForSeconds(walkTime);
        _isWalking = false;

        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            _isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            _isRotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            _isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            _isRotatingLeft = false;
        }
        _isWandering = false;
    }
}
