using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxAnim : MonoBehaviour
{
    [SerializeField] private Material skyBox;

    private float initialExposureAmount;
    private float initialSunSize;
    private float initialAtmosphereThickness;
    private Color initialSkyTint;
    private float beatTime = 0.5f;
    private float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        initialSkyTint = RenderSettings.skybox.GetColor("_SkyTint");
        RenderSettings.skybox.SetColor("_SkyTint", Color.black);
        initialExposureAmount = RenderSettings.skybox.GetFloat("_Exposure");
        initialSunSize = RenderSettings.skybox.GetFloat("_SunSize");
        initialAtmosphereThickness = RenderSettings.skybox.GetFloat("_AtmosphereThickness");
        //RenderSettings.skybox.SetFloat("_Exposure", 1);

        Debug.Log(RenderSettings.skybox.GetColor("_Ground"));

        //Debug.Log(RenderSettings.skybox.GetFloat("_AtmosphereThickness")); 0 is black, 1 is normal goes up to 5
        //RenderSettings.skybox.SetFloat("_SunSize", 0);

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime <= beatTime)
        {
            RenderSettings.skybox.SetColor("_SkyTint", Color.Lerp(RenderSettings.skybox.GetColor("_SkyTint"), Color.red, 3f * Time.deltaTime));
            RenderSettings.skybox.SetFloat("_SunSize", Mathf.Lerp(RenderSettings.skybox.GetFloat("_SunSize"), 1, 3f * Time.deltaTime));
            RenderSettings.skybox.SetFloat("_AtmosphereThickness", Mathf.Lerp(RenderSettings.skybox.GetFloat("_AtmosphereThickness"), 1.5f, 3f * Time.deltaTime));
            RenderSettings.skybox.SetFloat("_Exposure", Mathf.Lerp(RenderSettings.skybox.GetFloat("_Exposure"), 1, 3f * Time.deltaTime));
        }
        else
        {
            RenderSettings.skybox.SetFloat("_Exposure", initialExposureAmount);
            RenderSettings.skybox.SetFloat("_AtmosphereThickness", initialAtmosphereThickness);
            RenderSettings.skybox.SetFloat("_SunSize", initialSunSize);
            RenderSettings.skybox.SetColor("_SkyTint", initialSkyTint);
            currentTime -= beatTime;
        }
        
    }

    private void OnDestroy()
    {
        RenderSettings.skybox.SetFloat("_Exposure", initialExposureAmount);
        RenderSettings.skybox.SetFloat("_SunSize", initialSunSize);
        RenderSettings.skybox.SetFloat("_AtmosphereThickness", initialAtmosphereThickness);
        RenderSettings.skybox.SetColor("_SkyTiny", initialSkyTint);
    }
}
