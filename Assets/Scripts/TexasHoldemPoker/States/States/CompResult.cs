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
        List<Card> testone = playerone.getHandCards();
        List<Card> testtwo = playertwo.getHandCards();
        //Debug.Log(testone.Count);
        //PokerHelper.LogCardNames(testone);

        //Debug.Log("============");
        //Debug.Log(testtwo.Count);
       // PokerHelper.LogCardNames(testtwo);
        if ((int)playerone.m_PokerHand > (int)playertwo.m_PokerHand)
        {
            m_Manager.m_Interface.SetWinnerResult(playerone.GetPlayerName());
        }
        else if((int)playerone.m_PokerHand == (int)playertwo.m_PokerHand)
        {
            PokerHelper.logTestFive(testone);
            PokerHelper.logTestFive(testtwo);

            m_Manager.m_Interface.SetWinnerResult(PokerHelper.CheckDrawWinner(playerone,playertwo));
        }
        else
        {
            m_Manager.m_Interface.SetWinnerResult(playertwo.GetPlayerName());
        }

        m_Manager.SetState(new Idle(m_Manager));
       // m_Manager.PlayGame();
        return base.Start();
    }
}
