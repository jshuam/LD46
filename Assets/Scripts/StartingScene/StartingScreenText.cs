using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingScreenText : MonoBehaviour
{
    [SerializeField]
    private TextMesh _text = null;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ExampleCoroutine()
    {
        _text.text = "Theres a negative influence starting fires";
        yield return new WaitForSeconds(2);
        _text.text = "Unless you stop them, the company will go under";
        yield return new WaitForSeconds(2);
        _text.text = "We only have so much of a run way to land this plane";
        yield return new WaitForSeconds(2);
        _text.text = "Find them report them asap other wise your stocks are gone!";
        yield return new WaitForSeconds(2);
    }
}
