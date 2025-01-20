using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{
    [SerializeField] private TMP_Text[] texts;
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private TMP_Text currMusic;

    private Dictionary<string, AudioClip> _musicDict;
    [SerializeField] private Slider slider;

    void Awake()
    {
        _musicDict = new Dictionary<string, AudioClip>();
        for (int i = 0; i < texts.Length; i++)
        {
            _musicDict.Add(texts[i].text, clips[i]);
            texts[i].text = clips[i].name;
        }

        if (PlayerPrefs.HasKey("Music"))
        {
            currMusic.text = PlayerPrefs.GetString("Music");
            ChangeMusic(currMusic);
            slider.value = PlayerPrefs.GetFloat("Volume");
        }
    }

    public void ChangeMusic(TMP_Text clipName)
    {
        audioSource.clip = _musicDict[clipName.text];
        currMusic.text = clipName.text;
        audioSource.Play();
    }
}
