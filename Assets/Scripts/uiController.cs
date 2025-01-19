using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiController : MonoBehaviour
{
    private int _skyNumber = 0;
    private int _placeNumber = 0;
    
    [SerializeField] private Material[] skyMaterials;

    [SerializeField] private TMP_Text currMusic;
    [SerializeField] private GameObject placePanel;
    [SerializeField] private GameObject musicPanel;
    [SerializeField] private GameObject skyPanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject instrPanel;

    private GameObject[] panels;

    private void Awake()
    {
        panels = new GameObject[] { placePanel, musicPanel, skyPanel, mainPanel, instrPanel};
    }

    public void SettingsChange(GameObject curr)
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(panel==curr);
        }
    }
    
    

    public void ChangeNumber(int num)
    {
        _skyNumber = num;
        RenderSettings.skybox = skyMaterials[num];
        DynamicGI.UpdateEnvironment();
    }

    public void ChangePlace(int num)
    {
        _placeNumber = num;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ToMain()
    {
        PlayerPrefs.SetInt("SkyNum", _skyNumber);
        PlayerPrefs.SetString("Music", currMusic.text);
        PlayerPrefs.SetInt("PlaceNum", _placeNumber);
        SceneManager.LoadScene(1);
    }

}
