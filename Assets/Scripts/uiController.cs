using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiController : MonoBehaviour
{
    private int _placeNumber;

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

    [SerializeField] private Transform[] places;
    [SerializeField] private Transform player;
    [SerializeField] private Image shade;

    public void ChangeLang(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }

    private void Awake()
    {
        panels = new GameObject[] { placePanel, musicPanel, skyPanel, mainPanel, instrPanel, settingsPanel };
        _placeNumber = PlayerPrefs.GetInt("PlaceNum");
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            player.position = places[_placeNumber].position;
            player.rotation = places[_placeNumber].rotation;
        }
    }

    public void PanelsChange(GameObject curr)
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(panel == curr);
        }
    }


    public void ChangePlace(int num)
    {
        _placeNumber = num;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            StartCoroutine(Shading(num));
        }
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

    IEnumerator Shading(int num)
    {
        float a=0;
        while (a < 1f)
        {
            a += 0.03f;
            shade.color = new Color(0, 0, 0, a);
            yield return new WaitForSeconds(0.05f);
        }
        player.position = places[num].position;
        player.rotation = places[num].rotation;

        while (a > 0)
        {
            a -= 0.03f;
            shade.color = new Color(0, 0, 0, a);
            yield return new WaitForSeconds(0.05f);
        }

    }
}
