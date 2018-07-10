using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    public wipeControl WP;
    public int timerSetting;
    private int timer;
    public bool ending = false;
    public string levelToProceed;

    public gameData DB;


	// Use this for initialization
	void Start () {

        DB = FindObjectOfType<gameData>();
		
	}

    // Update is called once per frame
    public void Update()
    {
		/*
        if ((Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.Alpha3))&& !ending)
        {
            endLevel(SceneManager.GetActiveScene().name);

        }
		*/
        if (ending)
        {
            if (timer > 0)
            {
                timer--;

            }
            else
            {
                DB.SavePlayer();
                DB.LoadScene(levelToProceed);
            }
        }
    }

    public void endLevel(string level)
    {
        //takes a level name and loads it
        //TODO - if this is the last level in a list, go to menu
        //       else, go to next level

        ending = true;
        timer = timerSetting;
        WP.wipe();
        levelToProceed = level;


    }
}
