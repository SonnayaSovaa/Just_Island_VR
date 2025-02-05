using System;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] private AudioControl audio;
    [SerializeField] private char location;

    private void OnTriggerEnter(Collider other)
    {
        audio.ChangeByLoc(location);
    }
}
