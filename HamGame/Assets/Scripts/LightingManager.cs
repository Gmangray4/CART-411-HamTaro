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
    private bool allTasksDone;
    private bool bed;

    private bool Activebank;
    private bool ActivebuyBall;
    private bool Activegroceries;
    private bool ActivevistGF;
    private bool ActiveWFH;
    private bool Activebed;


    public GameObject Check_Obj_bank;
    public GameObject Obj_buBall;
    public GameObject Obj_groceries;
    public GameObject Obj_vistGF;
    public GameObject Obj_WFH;
    public GameObject Obj_bed;



    void Start()
    {
        bank = false;
        buyBall = false;
        groceries = false;
        vistGF = false;
        WFH = false;
        allTasksDone = false;
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

    private void FixedUpdate()
    {
        activeEvents();
    }


    void OnTriggerEnter(Collider other)
    {
        if (Check_Obj_bank)
        {
     
            if (bank == false)
            {
                Debug.Log(bank);
                TimeOfDay ++;
                Debug.Log(TimeOfDay);
                bank = true;
      
            }
        }
    }

    void activeEvents()
    {
        //Time where the bank is active
        if(TimeOfDay >= 6 && TimeOfDay <= 15 && bank == false)
        {
            Activebank = true;
            Debug.Log("The Bank is Open");
        }

        //Time where the HamMart is active
        if (TimeOfDay >= 10 && TimeOfDay <= 15 && buyBall == false)
        {
            ActivebuyBall = true;
            Debug.Log("The HamMart is Open");
        }

        //Time where the Visting your GF is active
        if (TimeOfDay >= 10 && TimeOfDay <= 15 && vistGF == false)
        {
            ActivevistGF = true;
            Debug.Log("The GF is home");
        }

        //Time where the Groceries is active
        if (TimeOfDay >= 10 && TimeOfDay <= 15 && groceries == false)
        {
            Activegroceries= true;
            Debug.Log("The Grocerie store is Open");
        }

        //Time where the work from hom  is active
        if (TimeOfDay >= 9 && TimeOfDay <= 19 && WFH == false)
        {
            ActiveWFH = true;
            Debug.Log("You can work from Home now");
        }

        // Lets the code now that all day 1 tasks are compete
        if (bank == true && buyBall == true && vistGF == true && groceries == true && WFH == true)
        {
            allTasksDone = true;
            Debug.Log("All taskes are done");
        }

        //Time where the Bed  is active
        if (TimeOfDay <= 22 && allTasksDone == true && bed == false)
        {
            Activebed = true;
            Debug.Log("The bed is active");
        }
    }

}