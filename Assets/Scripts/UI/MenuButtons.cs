using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void PlayGameButton()
    {
        //Debug.Log("Play");
        SceneManager.LoadScene("main_scene", LoadSceneMode.Single);
    }

    public void OpenHelpWindowButton()
    {
        Debug.Log("Open Help");
    }

    public void QuitGameButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OpenAboutWindowButton()
    {
        Debug.Log("Open About");
    }

}
