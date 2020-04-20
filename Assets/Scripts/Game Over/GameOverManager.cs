﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke( "GoToGameOverMenu", 10f );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoToGameOverMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene( 6, LoadSceneMode.Single );
    }
}
