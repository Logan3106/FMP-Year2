using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditorInternal;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public Statemachine currentState;

    void Update()
    {
        RunStatemachine();
    }

    private void RunStatemachine()
    {
        Statemachine nextState = currentState?.RunCurrentState();

        if(nextState != null)
        {
            //Switch to the next state
            SwitchToNextState(nextState);
        }
    }

    private void SwitchToNextState(Statemachine nextState)
    {
        currentState = nextState;
    }
}
