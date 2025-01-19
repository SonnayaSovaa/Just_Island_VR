using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiController : MonoBehaviour
{
    private int _skyNumber = 0;
    [SerializeField] private Material[] skyMaterials;

    [SerializeField] AudioSource audioSource;
    [SerializeField] private TMP_Text currMusic;

    public void ChangeNumber(int num)
    {
        _skyNumber = num;
        RenderSettings.skybox = skyMaterials[num];
        DynamicGI.UpdateEnvironment();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ToMain()
    {
        PlayerPrefs.SetInt("SkyNum", _skyNumber);
        PlayerPrefs.SetString("Music", currMusic.text);
        SceneManager.LoadScene(1);
    }

}
