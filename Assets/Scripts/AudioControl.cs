using System;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField] private AudioClip[] forest;
    [SerializeField] private AudioClip[] waves;
    [SerializeField] private AudioClip grass;
    [SerializeField] private AudioClip wind;

    [SerializeField] private AudioSource source;

    private char _currLoc;
    private bool _day;
    private int _num;

    private void Awake()
    {
        _num = PlayerPrefs.GetInt("SkyNum");
        _day = (_num == 5 || _num == 6 || _num == 8);
    }

    public void ChangeByLoc(char loc)
    {
        switch (_currLoc)
        {
            case 'f': //forest
                if (_currLoc == 'f') break;
                else
                {
                    if (_day)
                    {
                        source.clip = forest[1];
                        source.Play();
                        break;
                    }
                    else
                    {
                        source.clip = forest[0];
                        source.Play();
                        break;
                    }
                }
            case 'm': //mountain
                source.clip = wind;
                source.Play();
                break;
            case 'w': //waves
                if (_currLoc == 'w') break;
                else
                {
                    if (_day)
                    {
                        source.clip = waves[1];
                        source.Play();
                        break;
                    }
                    else
                    {
                        source.clip = waves[0];
                        source.Play();
                        break;
                    }
                }
            case 'g':
                source.clip = grass;
                source.Play();
                break;
        }

        _currLoc = loc;
    }

    public void ChangeBySky(bool day)
    {
        switch (_currLoc)
        {
            case 'f': //forest
                if (day == _day) break;
                else
                {
                    if (day)
                    {
                        source.clip = forest[1];
                        source.Play();
                        break;
                    }
                    else
                    {
                        source.clip = forest[0];
                        source.Play();
                        break;
                    }
                }
            case 'w': //waves
                if (day == _day) break;
                else
                {
                    if (day)
                    {
                        source.clip = waves[1];
                        source.Play();
                        break;
                    }
                    else
                    {
                        source.clip = waves[0];
                        source.Play();
                        break;
                    }
                }
        }

        _day = day;
    }



}
