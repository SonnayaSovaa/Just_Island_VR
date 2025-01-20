using UnityEngine;

public class SkyChangeMain : MonoBehaviour
{
    
    public int skyNumber=0;
    [SerializeField] private Material[] skyMaterials;
    [SerializeField] private float skyRotation = 0.4f;

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
    }
    
    void Update ()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time*skyRotation);
    }
}
