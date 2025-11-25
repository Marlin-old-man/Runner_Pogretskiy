using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject pausePanel;

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

    public void SetPaused(bool value)
    {
        pausePanel.SetActive(value);
        Time.timeScale = value ? 0f : 1f;
    }
    public void GoToMenu(int index)
    {
        SceneManager.LoadScene(index);
    }
}
