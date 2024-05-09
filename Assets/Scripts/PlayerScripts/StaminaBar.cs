using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : CharacterStats
{
    public GameObject player;
    public float stamina;
    public float maxStamina;
    private Movement playerMovement;
    public Animator anim;
    
    public Slider staminaBar;
    public float dValue;
    void Start()
    {
        maxStamina = stamina;
        staminaBar.maxValue = maxStamina;
        playerMovement = player.GetComponent<Movement>();
        anim = player.GetComponent<Animator>();
    }

    
    void Update()
    {
        Animations();

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

    public void Animations()
    {
        if (playerMovement.speed >= 12)
        {
            anim.Play("Running");
        }
        else if (playerMovement.speed <= 6)
        {
            anim.Play("walking");
        }
    }
}
