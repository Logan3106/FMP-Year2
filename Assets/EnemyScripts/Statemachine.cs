using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Statemachine : MonoBehaviour
{

    public abstract Statemachine RunCurrentState();
}
