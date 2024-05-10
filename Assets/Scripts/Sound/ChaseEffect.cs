using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEffect : MonoBehaviour
{
    public AudioSource source;
    EnemyScript es;
    void Start()
    {
        GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (es.isPlayerInFov)
        {
            source.Play();
        }
        else
        {
            source.Pause();
        }
    }
}
