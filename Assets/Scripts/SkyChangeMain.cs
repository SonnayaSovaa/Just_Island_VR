using System.Runtime.Serialization;
using TMPro;
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
    [SerializeField] private Material dayOcean;
    [SerializeField] private Material nightOcean;
    [SerializeField] private Material dawnOcean;
    [SerializeField] private Material riseOcean;
    [SerializeField] private Renderer ocean;
    [SerializeField] private TMP_Text[] texts;
    
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

        foreach (TMP_Text te in texts)
        {
            if (num == 1 || num == 2 || num == 3 || num == 4 || num == 9 || _night || num==7) te.color=Color.white;
            else te.color=Color.black;
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            RenderSettings.ambientIntensity = intens[num];
            _night = (num == 1 || num == 2 || num == 3 || num == 4 || num == 9);
            foreach (GameObject n in nightObjects)
            {
                n.SetActive(_night);
            }

            mainLight.colorTemperature = temp[num];
            mainLight.intensity = brightness[num];
            audio.ChangeBySky(!_night);

            
            switch (num)
            {
                case 8:
                    ocean.material = riseOcean;
                    break;
                case 0:
                    ocean.material = dayOcean;
                    break;
                case 5:
                    ocean.material = dayOcean;
                    break;
                case 6:
                    ocean.material = dayOcean;
                    break;
                case 2:
                    ocean.material = dawnOcean;
                    break;
                case 7:
                    ocean.material = dawnOcean;
                    break;
                default:
                    ocean.material = nightOcean;
                    break;
            }
        }
    }

    void Update ()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time*skyRotation);
    }
}
