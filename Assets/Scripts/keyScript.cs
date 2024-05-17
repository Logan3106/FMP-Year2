using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
{
    public Transform laserOrigin;

    LineRenderer laserLine;

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        laserFire();
    }

    public void laserFire()
    {
        laserLine.SetPosition(0, laserOrigin.position);
    }
}
