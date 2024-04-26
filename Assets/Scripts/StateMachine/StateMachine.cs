using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditorInternal.VersionControl.ListControl;

public class StateMachine : MonoBehaviour
{
    public State currentState { get; private set; }
    public State lastState { get; private set; }

    public void Init(State startingState)
    {
        currentState = startingState;
        lastState = null;
        startingState.Enter();
    }

    public void ChangeState(State newState)
    {
        Debug.Log("Changing state from " + currentState + " to " + newState);
        currentState.Exit();

        lastState = currentState;
        currentState = newState;
        newState.Enter();

    }

    public State GetState()
    {
        return currentState;
    }
}
