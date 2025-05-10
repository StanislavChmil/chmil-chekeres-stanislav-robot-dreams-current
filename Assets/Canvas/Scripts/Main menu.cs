using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    private const string GAME_SCENE = "De_Dust_2";

    public void StartGame()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }
    
    public void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}