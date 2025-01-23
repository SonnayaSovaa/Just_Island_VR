using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class FireControl : MonoBehaviour
{
    [SerializeField] private Light fire;
    [SerializeField] private float freq;

    private void OnEnable()
    {
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        while (freq != 0)
        {
            fire.intensity = Random.Range(10, 30);
            yield return new WaitForSeconds(freq);
        }

    }
}
