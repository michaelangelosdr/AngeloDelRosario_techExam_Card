using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckResult : State
{
    public CheckResult(TexasHoldemPokerManager manager): base(manager)
    {

    }

    public override IEnumerator Start()
    {
        List<Card> BoardCards = m_Manager.m_Board.getBoardCards();
        int m_index = 0;
        foreach(PlayerHand p in m_Manager.m_Players)
        {
            List<Card> CombinedHand = new List<Card>();
            List<Card> PlayerHand = p.getHandCards();
            foreach (Card c in BoardCards)
            {
                CombinedHand.Add(c);
            }
            foreach(Card c in p.getHandCards())
            {
                CombinedHand.Add(c);
            }
            


            p.m_PokerHand = PokerHelper.CheckHand(ref PlayerHand,CombinedHand);

            m_Manager.m_Interface.SetPlayerResult(m_index++,p.m_PokerHand.ToString());
           Debug.Log(p.m_PokerHand);
        }

        m_Manager.SetState(new CompResult(m_Manager));
        yield break;
        
    }


}
