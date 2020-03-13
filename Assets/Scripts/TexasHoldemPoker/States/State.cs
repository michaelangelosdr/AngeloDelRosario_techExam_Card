using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{

    //Make a base manager class in the future for extention of state machine
    protected TexasHoldemPokerManager m_Manager;

    public State(TexasHoldemPokerManager manager)
    {
        m_Manager = manager;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }   

    public virtual IEnumerator PlayGame()
    {
        yield break;
    }
}
