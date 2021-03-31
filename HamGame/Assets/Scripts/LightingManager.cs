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

    private bool allTasksDone;
    private bool bed;

    private bool Activebank;
    private bool ActivebuyBall;
    private bool Activegroceries;
    private bool ActivevistGF;
   
    private bool Activebed;

    private bool Curfew;

    private bool GameOver;

    public GameObject Check_Obj_bank;
    public GameObject Check_Obj_buyBall;
    public GameObject Check_Obj_groceries;
    public GameObject Check_Obj_vistGF;
    public GameObject Check_Obj_bed;
    public GameObject Check_Obj_Cop;





    void Start()
    {
       GameOver = false;
       bank = false;
        buyBall = false;
        groceries = false;
        vistGF = false;
    
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
        activeCurfur();
        endingRank();

    }


    void OnTriggerEnter(Collider other)
    {

        // Checks if the user goes to the bank
        if (other.gameObject == Check_Obj_bank)
        {
            if (bank == false && Activebank == true)
            {
                TimeOfDay ++;
                Debug.Log("You have gone to the bank");
                bank = true;    
            }
        }

        //Not working
        // Checks if the user goes to HamMart to buy the ball
        if (other.gameObject == Check_Obj_buyBall)
        {

            if (buyBall == false) 
            {
                if (bank == true && ActivebuyBall == true)
                {
                    TimeOfDay++;
                    Debug.Log("You bought the ball!");
                    buyBall = true;
                }
            }
        }

        // Checks if the user goes to the bank
        if (other.gameObject == Check_Obj_groceries)
        {
            if (groceries == false)
            {
                if (bank == true && Activegroceries == true)
                {
                   
                    TimeOfDay++;
                    Debug.Log("You got groceries!");
                    groceries = true;
                }
            }
        }

        // Checks if the user goes to the bank
        if (other.gameObject == Check_Obj_vistGF)
        {
            if (vistGF == false) 
            {
                if (ActivevistGF == true)
                {

                    TimeOfDay++;
                    Debug.Log("You visted your GF");
                    vistGF = true;
                }
            }
            
        }

        // Checks if the user Works from home
        if (other.gameObject == Check_Obj_Cop)
        {

            Debug.Log("Ending Rank: D-");
            Debug.Log("Cop!");
            GameOver = true;
        }

        if (other.gameObject == Check_Obj_bed)
        {
            if (bed == false && Activebed == true)
            {
                Debug.Log("Day 1 is over");
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
        else
        {
            Debug.Log("The HamMart is clsoed");
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

        // Lets the code now that all day 1 tasks are compete
        if (bank == true && buyBall == true && vistGF == true && groceries == true)
        {
            allTasksDone = true;
            Debug.Log("All taskes are done");
        }

        //Time where the Bed  is active
        if (TimeOfDay <= 15 && allTasksDone == true && bed == false)
        {
            Activebed = true;
            Debug.Log("The bed is active");
        }
    }

    void activeCurfur()
    {
        if (TimeOfDay >= 19)
        {
            Debug.Log("Curfew started");
            Curfew = true;
        }
        else 
        {
            Debug.Log("Curfew Not started yet");
            Curfew = false; 
        }
    }


    void endingRank()
    {
        //Rank E: Falling to go to bed in time on the first day.
        if (TimeOfDay >= 23 && bed == false)
        {
            Debug.Log("Ending Rank: E");
            GameOver = true;
        }
 
        //Rank F: Failing to complete any of the tasks on the first day.
        if (TimeOfDay >= 15 && bank == false || TimeOfDay >= 15 && groceries == false || TimeOfDay >= 15 && vistGF == false)
        {
            Debug.Log("Ending Rank: F");
            GameOver = true;
        }
    }






}