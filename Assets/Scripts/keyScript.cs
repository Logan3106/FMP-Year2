using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("KeyGone");
            gameObject.SetActive(false);
        }
    }
}
