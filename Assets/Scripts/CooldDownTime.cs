using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CooldDownTime
{
        [SerializeField] private float cooldownTime;
        private float nextSound;

        public bool isCoolingDown => Time.time > nextSound;
        public void StartCooldown() => nextSound = Time.time + cooldownTime;
    
}
