using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverControl : MonoBehaviour {


    public moveScore MS;

    public moveCharacter MC;
    public Animator RPA;
    public AudioSource RPAS;
    public AudioClip RPlose;
    public Animator PA;
    public AudioSource PAS;
    public AudioClip Pwin;
    public Enemy PPF;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    private void OnTriggerEnter(Collider other)
    {

        PA.SetBool("victory", true);
        RPA.SetBool("lose", true);

        RPAS.clip = RPlose;
        PAS.clip = Pwin;
        RPAS.Play();
        PAS.Play();

        PPF.enabled = false;
        MS.toView = true;
        MC.enabled = false;

    }
}
