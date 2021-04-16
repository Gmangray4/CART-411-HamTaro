using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    [SerializeField, Range(0, 24)] public float TimeOfDay;

    public bool bank;
    public bool buyBall;
    public bool groceries;
    public bool vistGF;

    public bool allTasksDone;
    public bool bed;

    public bool Activebank;
    public bool ActivebuyBall;
    public bool Activegroceries;
    public bool ActivevistGF;



    public bool Activebed;

    private bool Curfew;

    public bool NPCGameOver;

    public bool InteractionCop;
    public bool InteractionNPC;

    bool skip;
    bool interact;
    bool interact2;

    public GameObject Player;

    public GameObject Obj_bank;
    public GameObject Obj_buyBall;
    public GameObject Obj_groceries;
    public GameObject Obj_vistGF;
    public GameObject Obj_bed;

    public GameObject GroceryClerk;
    public GameObject GF;
    public GameObject HamMarkClerk;
    public GameObject Banker;
    public GameObject CurfewTime;

    public GameObject GOMisTaks;
    public GameObject GOPast23;

    public GameObject Ball;
    public GameObject BallTP;


    public GameObject AICop;
    //public GameObject PlaneCOPNPC1;

    public GameObject UITimeOfDay;
    Text TimeOfDayDisplay;
    public float TimeSpeed;

    void Start()
    {
       InteractionCop = false;
       InteractionNPC = false;
        bank = false;
        buyBall = false;
        groceries = false;
        vistGF = false;
        allTasksDone = false;
        bed = false;
        NPCGameOver = false;
        skip = false;
        interact = false;
        interact2 = false;


       TimeOfDayDisplay = UITimeOfDay.GetComponent<Text>();

        AICop.SetActive(false);
        
    }

    void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            //(Replace with a reference to the game time)
            
            TimeOfDay += Time.deltaTime/TimeSpeed; // gets slower when you diveied 45 
            TimeOfDay %= 24; //Modulus to ensure always between 0-24
            UpdateLighting(TimeOfDay / 24f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
        
        
    }


    public void UpdateLighting(float timePercent)
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
    public void OnValidate()
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

    public void FixedUpdate()
    {
        activeEvents();
        activeCurfur();
        endingRank();
        CheckInteractions();
        IntaractionReady();

       TimeOfDayDisplay.text = "Hour " + TimeOfDay.ToString();

    }


    void CheckInteractions()
    {

        // Checks if the user goes to the bank
        if (Obj_bank.GetComponent<InteractTask>().InteractionComplete == true)
        {
            if (bank == false)
            {
                TimeOfDay++;
                Debug.Log("You have gone to the bank");
             
                bank = true;
            }

        }



        // Checks if the user goes to HamMart to buy the ball
        if (Obj_buyBall.GetComponent<InteractTask>().InteractionComplete == true)
        {
            if (buyBall == false)
            {
                TimeOfDay++;
                Ball.transform.position = BallTP.transform.position;
           
                Debug.Log("You bought the ball!");
                buyBall = true;
            }

        }



        // Checks if the user goes to the bank
        if (Obj_groceries.GetComponent<InteractTask>().InteractionComplete == true)
        {

            if (groceries == false)
            {

                TimeOfDay++;
                Debug.Log("You got groceries!");
                groceries = true;
            }
        }


        // Checks if the user goes to the bank
        if (Obj_vistGF.GetComponent<InteractTask>().InteractionComplete == true)
        {
            if (vistGF == false)
            {


                TimeOfDay++;
               
                Debug.Log("You visted your GF");
                vistGF = true;

            }

        }

        if (Obj_bed.GetComponent<InteractTask>().InteractionComplete == true)
        {

            if (bed == false && Activebed == true)
            {
                NPCGameOver = true;
                Debug.Log("Day 1 is over");
                SceneManager.LoadScene(sceneName: "Scenes/DemoWin");
            }
        }

        //Rank D-:Breaking the law by being caught by one of the Police officers.
        if (InteractionCop == true && NPCGameOver == false)
        {
            NPCGameOver = true;
            Debug.Log("Ending Rank: C-");
            Debug.Log("Cop!");
            SceneManager.LoadScene(sceneName: "Scenes/GameOverC-");
            NPCGameOver = true;
        }
        // Rank D:When you get too close to an NPC without your hamster ball after the rule is enforced on day two.

        if (InteractionNPC == true && NPCGameOver == false)
        {
            
            Debug.Log("Ending Rank: D");
            Debug.Log("NPC!");
            SceneManager.LoadScene(sceneName: "Scenes/GameOverD");
            NPCGameOver = true;
        }

        //////////////////////////////Game Overs/////////////////////////////

    }



    void activeEvents()
    {
        //Time where the bank is active
        if(TimeOfDay >= 8 && TimeOfDay <= 15 && bank == false)
        {
            Activebank = true;
            
            Debug.Log("The Bank is Open");
        }

        //Time where the HamMart is active
        if (TimeOfDay >= 9 && TimeOfDay <= 15 && buyBall == false)
        {
            ActivebuyBall = true;
          
            Debug.Log("The HamMart is Open");
        }
        else
        {
            Debug.Log("The HamMart is clsoed");

        }

        //Time where the Visting your GF is active
        if (TimeOfDay >= 17 && TimeOfDay <= 20 && vistGF == false)
        {
            ActivevistGF = true;
           
            Debug.Log("The GF is home");
        }

        //Time where the Groceries is active
        if (TimeOfDay >= 9 && TimeOfDay <= 15 && groceries == false)
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
        if (allTasksDone == true && bed == false)
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
        if (Curfew == true)
        {
            CurfewTime.SetActive(true);
            AICop.SetActive(true);
            
        }
        else
        {
            CurfewTime.SetActive(false);
            AICop.SetActive(false);
            
        }
    }

    void IntaractionReady()
    {
        if(Activebank == true && bank == false) {
            Obj_bank.SetActive(true);
            Banker.SetActive(true);
        }
        else
        {
            Obj_bank.SetActive(false);
            Banker.SetActive(false);

        }

        if (ActivebuyBall == true && buyBall == false && bank == true)
        {
            Obj_buyBall.SetActive(true);
            HamMarkClerk.SetActive(true);
        }
        else
        {
            Obj_buyBall.SetActive(false);
            HamMarkClerk.SetActive(false);

        }
        if (Activegroceries == true && groceries == false && bank == true)
        {
            Obj_groceries.SetActive(true);
            GroceryClerk.SetActive(true);

        }
        else
        {
            Obj_groceries.SetActive(false);
            GroceryClerk.SetActive(false);
        }

        if (ActivevistGF == true && vistGF == false)
        {
            Obj_vistGF.SetActive(true);
            GF.SetActive(true);
        }
        else
        {
            Obj_vistGF.SetActive(false);
            GF.SetActive(false);
        }
        if (Activebed == true)
        {
            Obj_bed.SetActive(true);
        }
        else
        {
            Obj_bed.SetActive(false);
        }
    }


    void endingRank()
    {
        //Rank E: Falling to go to bed in time on the first day.
        if (TimeOfDay >= 23 && bed == false && NPCGameOver == false)
        {
            Debug.Log("Ending Rank: E");
            GOPast23.SetActive(true);
            Player.GetComponent<ThirdPersonController>().enabled = false;
            Player.GetComponent<ThirdPersonCamera>().enabled = false;
            StartCoroutine(timer1());
            NPCGameOver = true;
            interact = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && TimeOfDay >= 23 && bed == false && interact == true)
        {
            SceneManager.LoadScene(sceneName: "Scenes/GameOverE");
        }

        //Rank F: Failing to complete any of the tasks on the first day.
        if (TimeOfDay >= 15 && bank == false && NPCGameOver == false || TimeOfDay >= 15 && groceries == false && NPCGameOver == false || TimeOfDay >= 20 && vistGF == false && NPCGameOver == false || TimeOfDay >= 15 && buyBall == false && NPCGameOver == false)
        {
            Debug.Log("Ending Rank: F");
            GOMisTaks.SetActive(true);
            Player.GetComponent<ThirdPersonController>().enabled = false;
            Player.GetComponent<ThirdPersonCamera>().enabled = false;
            StartCoroutine(timer2());
            NPCGameOver = true;
            interact2 = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && TimeOfDay >= 15 && bank == false && interact2 == true || Input.GetKeyDown(KeyCode.Space) && TimeOfDay >= 15 && groceries == false && interact2 == true || Input.GetKeyDown(KeyCode.Space) && TimeOfDay >= 20 && vistGF == false && interact2 == true || Input.GetKeyDown(KeyCode.Space) && TimeOfDay >= 15 && buyBall == false && interact2 == true)
            {
            SceneManager.LoadScene(sceneName: "Scenes/GameOverF");
        }
        }


    IEnumerator timer1()
    {
        Debug.Log("Your enter Coroutine at" + Time.time);
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(sceneName: "Scenes/GameOverE");
    }

    IEnumerator timer2()
    {
        Debug.Log("Your enter Coroutine at" + Time.time);
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(sceneName: "Scenes/GameOverF");
    }




}