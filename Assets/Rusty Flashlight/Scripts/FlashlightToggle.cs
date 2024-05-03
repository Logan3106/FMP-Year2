using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FlashlightToggle : MonoBehaviour
{
    public GameObject lightGO; //light gameObject to work with
    private bool isOn = false; //is flashlight on or off?
    [SerializeField] AudioSource soundSource;
    

    // Use this for initialization
    void Start()
    {
        
        //set default off
        lightGO.SetActive(isOn);
    }

    // Update is called once per frame
    void Update()
    {
        //toggle flashlight on key down
        if (Input.GetKeyDown(KeyCode.X))
        {
            //toggle light
            isOn = !isOn;
            //turn light on
            if (isOn)
            {
                soundSource.Play();
                lightGO.SetActive(true);
            }
            //turn light off
            else
            {
                soundSource.Play();
                lightGO.SetActive(false);

            }
        }
    }
}
