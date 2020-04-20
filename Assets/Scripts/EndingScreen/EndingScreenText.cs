using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScreenText : MonoBehaviour
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
        _text.text = "Congratulations";
        yield return new WaitForSeconds(4);
        _text.text = "You have successfully removed the cancer";
        yield return new WaitForSeconds(4);
        _text.text = "I'm sure this won't have any long running effects";
    }
}
