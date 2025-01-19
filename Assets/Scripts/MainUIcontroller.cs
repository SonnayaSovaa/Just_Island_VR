using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIcontroller : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private bool _paused = false;
    
    private void Awake()
    {
        
    }


    void Pause()
    {
        _paused = !_paused;
        pausePanel.SetActive(_paused);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
