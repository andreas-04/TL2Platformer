using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    //gameObject for the panel
    public GameObject hud;
    public bool hudOpen;
    
    //called once at beginning
    void Start()
    {
        hud.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("are you running");
        //checks if user hit tab. will pause if not yet, or resume if paused
        if(Input.GetKeyDown(KeyCode.Tab)){
            Debug.Log("Escape pressed");
            if(hudOpen){
                closeHud();
            } else{
                openHud();
            }
        }
    }

    //pauses the game, pulls up hud
    public void openHud(){
        hud.SetActive(true);
        Time.timeScale = 0f;
        hudOpen = true;
    }

    //resumes it, closes hud
    public void closeHud(){
        hud.SetActive(false);
        Time.timeScale = 1f;
        hudOpen = false;
    }
}

