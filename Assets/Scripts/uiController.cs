using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiController : MonoBehaviour
{
    private int _placeNumber = 0;
    
    [SerializeField] private TMP_Text currMusic;
    [SerializeField] private GameObject placePanel;
    [SerializeField] private GameObject musicPanel;
    [SerializeField] private GameObject skyPanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject instrPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Slider slider;

    private GameObject[] panels;
    [SerializeField] private SkyChangeMain skCh;

    public void ChangeLang(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
    
    private void Awake()
    {
        panels = new GameObject[] { placePanel, musicPanel, skyPanel, mainPanel, instrPanel, settingsPanel};
    }

    public void PanelsChange(GameObject curr)
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(panel==curr);
        }
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
        PlayerPrefs.SetInt("SkyNum", skCh.skyNumber);
        PlayerPrefs.SetString("Music", currMusic.text);
        PlayerPrefs.SetInt("PlaceNum", _placeNumber);
        PlayerPrefs.SetFloat("Volume", slider.value);
        SceneManager.LoadScene(1);
    }

    public void ToMenu()
    {
        PlayerPrefs.SetInt("SkyNum", skCh.skyNumber);
        PlayerPrefs.SetString("Music", currMusic.text);
        PlayerPrefs.SetInt("PlaceNum", _placeNumber);
        PlayerPrefs.SetFloat("Volume", slider.value);
        SceneManager.LoadScene(0);
    }
    
}
