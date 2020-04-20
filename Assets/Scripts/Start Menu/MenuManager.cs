using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartMainMenuScene()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void StartGameScene()
    {
        var musicManager = FindObjectOfType<MusicManager>()?.gameObject;
        if( musicManager != null )
        { 
            Destroy( musicManager );
        }
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void StartHowToPlayScene()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}
