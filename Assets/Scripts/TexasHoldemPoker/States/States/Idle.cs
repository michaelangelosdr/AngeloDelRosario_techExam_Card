using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public Idle(TexasHoldemPokerManager manager):base(manager)
    {

    }

    public override IEnumerator Start()
    {
        Debug.Log("IDLE STATE");
        return base.Start();
    }
    public override IEnumerator PlayGame()
    {

        m_Manager.SetState(new Deal(m_Manager));

        yield break;
    }
}
