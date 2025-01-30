using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyChangeMain : MonoBehaviour
{
    
    public int skyNumber=0;
    [SerializeField] private Material[] skyMaterials;
    [SerializeField] private float skyRotation = 0.4f;
    [SerializeField] private float[] intens;
    [SerializeField] private int[] temp;
    [SerializeField] private float[] brightness;
    private bool _night;

    [SerializeField] private GameObject[] nightObjects;
    [SerializeField] private Light mainLight;
    [SerializeField] private AudioControl audio;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SkyNum")) skyNumber = PlayerPrefs.GetInt("SkyNum");
        ChangeNumber(skyNumber);
    }

    public void ChangeNumber(int num)
    {
        skyNumber = num;
        RenderSettings.skybox = skyMaterials[num];
        DynamicGI.UpdateEnvironment();

        
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            RenderSettings.ambientIntensity = intens[num];
            _night = (num == 1 || num == 2 || num == 3 || num == 4 || num==9);
            foreach (GameObject n in nightObjects)
            {
                n.SetActive(_night);
            }

            mainLight.colorTemperature = temp[num];
            mainLight.intensity = brightness[num];
            audio.ChangeBySky(!_night);
        }
    }
    
    void Update ()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time*skyRotation);
    }
}
