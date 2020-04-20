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
        Destroy(FindObjectOfType<MusicManager>().gameObject);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void StartHowToPlayScene()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
