using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    [SerializeField, Range(0, 24)] private float TimeOfDay;

    private bool bank;
    private bool buyBall;
    private bool groceries;
    private bool vistGF;
    private bool WFH;
    private bool bed;

    public GameObject Check_Obj_bank;
//public GameObject Obj_buBall;
    //public GameObject Obj_groceries;
  //  public GameObject Obj_vistGF;
   // public GameObject Obj_WFH;
  //  public GameObject Obj_bed;

    void Start()
    {
        bank = false;
        buyBall = false;
        groceries = false;
        vistGF = false;
        WFH = false;
        bed = false;

    }

    private void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            //(Replace with a reference to the game time)
            
            TimeOfDay += Time.deltaTime/45; // gets slower when you diveied 45 
            TimeOfDay %= 24; //Modulus to ensure always between 0-24
            UpdateLighting(TimeOfDay / 24f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
    }


    private void UpdateLighting(float timePercent)
    {
        //Set ambient and fog
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }

    //Try to find a directional light to use if we haven't set one
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        //Search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        //Search scene for light that fits criteria (directional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (Check_Obj_bank)
        {
            Debug.Log("You Thought it was Debug, but it was me DIO!");
            if (bank == false)
            {
                Debug.Log(bank);
                TimeOfDay ++;
                Debug.Log(TimeOfDay);
                bank = true;
                

            }
        }
    }

}