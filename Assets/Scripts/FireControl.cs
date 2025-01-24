using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class FireControl : MonoBehaviour
{
    [SerializeField] private Light fire;
    [SerializeField] private float freq;

    [SerializeField] private float min;
    [SerializeField] private float max;


    private void OnEnable()
    {
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        while (freq != 0)
        {
            fire.intensity = Random.Range(min, max);
            yield return new WaitForSeconds(freq);
        }

    }
}
