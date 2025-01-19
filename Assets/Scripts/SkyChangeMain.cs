using UnityEngine;

public class SkyChangeMain : MonoBehaviour
{
    
    private int _skyNumber;
    [SerializeField] private Material[] skyMaterials;

    private void Awake()
    {
        _skyNumber = PlayerPrefs.GetInt("SkyNum");
        ChangeNumber(_skyNumber);
    }

    private void ChangeNumber(int num)
    {
        _skyNumber = num;
        RenderSettings.skybox = skyMaterials[num];
        DynamicGI.UpdateEnvironment();
    }
}
