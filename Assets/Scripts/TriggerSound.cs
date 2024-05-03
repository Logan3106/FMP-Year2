using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{

    [SerializeField] private CooldDownTime cooldown;
    [SerializeField] public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(cooldown.isCoolingDown)
        if(other.gameObject.tag == "Player")
        {
            print("SoundsPlays");
            audio.Play();
            cooldown.StartCooldown();
        }
    }
}
