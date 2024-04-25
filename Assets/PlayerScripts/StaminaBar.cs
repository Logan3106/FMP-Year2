using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaminaBar : MonoBehaviour
{
    public GameObject player;
    public float stamina;
    public float maxStamina;
    private Movement playerMovement;
    
    public Slider staminaBar;
    public float dValue;
    void Start()
    {
        maxStamina = stamina;
        staminaBar.maxValue = maxStamina;
        playerMovement = player.GetComponent<Movement>();
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && stamina>=0)
        {
            DecreaseEnergy();
            playerMovement.speed = 12f;
        }
        else if(stamina!=maxStamina)
        {
            playerMovement.speed = 6f;
            IncreaseEnergy();
        }

        staminaBar.value = stamina;
    }

    public void DecreaseEnergy()
    {
        if(stamina <= 0)
        {
            stamina = 0;
            return;
        }

        if(stamina != 0)
        {
            stamina -= dValue * Time.deltaTime;        
        }
    }

    public void IncreaseEnergy()
    {
        if(stamina >= maxStamina)
        {
            stamina = maxStamina;
            return;
        }

        stamina += dValue * Time.deltaTime;
    }
}
