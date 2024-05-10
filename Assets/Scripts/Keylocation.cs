using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Keylocation : MonoBehaviour
{ 

    public GameObject[] keySpawnsPositions;
    public GameObject Key;
    public int randomInt;

    private void Awake()
    {
        randomInt = Random.Range(0, keySpawnsPositions.Length);

        Instantiate(Key, keySpawnsPositions[randomInt].transform.position, Quaternion.identity);
    }
}
