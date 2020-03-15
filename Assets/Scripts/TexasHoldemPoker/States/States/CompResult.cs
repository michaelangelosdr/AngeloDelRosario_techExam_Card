using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompResult : State
{
    public CompResult(TexasHoldemPokerManager manager):base(manager)
    {

    }

    public override IEnumerator Start()
    {
        PlayerHand playerone = m_Manager.m_Players[0];
        PlayerHand playertwo = m_Manager.m_Players[1];
        

        if ((int)playerone.m_PokerHand > (int)playertwo.m_PokerHand)
        {
            m_Manager.m_Interface.SetWinnerResult(playerone.GetPlayerName());
        }
        else if((int)playerone.m_PokerHand == (int)playertwo.m_PokerHand)
        {
            m_Manager.m_Interface.SetWinnerResult("Draw");
        }
        else
        {
            m_Manager.m_Interface.SetWinnerResult(playertwo.GetPlayerName());
        }

        m_Manager.SetState(new Idle(m_Manager));
        return base.Start();
    }
}
