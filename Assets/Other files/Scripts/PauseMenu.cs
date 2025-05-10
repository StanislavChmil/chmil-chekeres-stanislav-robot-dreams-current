using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    public static PauseMenuUI Instance;

    [SerializeField] private CanvasGroup pauseCanvasGroup;
    private PlayerInputActions inputActions;
    private bool isPaused = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        inputActions = new PlayerInputActions();
        inputActions.Player.BackToMenu.performed += ctx => TogglePause();

        SetPauseCanvas(false);
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void TogglePause()
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        SetPauseCanvas(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
    }

    public void ResumeGame()
    {
        SetPauseCanvas(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Canvases");
    }

    private void SetPauseCanvas(bool show)
    {
        if (pauseCanvasGroup != null)
        {
            pauseCanvasGroup.alpha = show ? 1f : 0f;
            pauseCanvasGroup.interactable = show;
            pauseCanvasGroup.blocksRaycasts = show;
        }
    }
}