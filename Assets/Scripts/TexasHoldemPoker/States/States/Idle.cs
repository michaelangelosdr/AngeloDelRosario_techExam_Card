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
      

        foreach(PlayerHand p in m_Manager.m_Players)
        {
            p.ResetHand();
        }
        m_Manager.m_Board.ResetBoard();

        return base.Start();
    }
    public override IEnumerator PlayGame()
    {

        m_Manager.SetState(new Deal(m_Manager));

        yield break;
    }
}
