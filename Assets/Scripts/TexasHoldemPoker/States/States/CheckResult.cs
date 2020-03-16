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
        //ClearConsole();
        //List<Card> cardtest = new List<Card>();

        //cardtest.Add(new Card("2", "Hearts"));
        //cardtest.Add(new Card("3", "Diamonds"));
        //cardtest.Add(new Card("4", "Hearts"));
        //cardtest.Add(new Card("5", "Diamonds"));
        //cardtest.Add(new Card("6", "Hearts"));
        //cardtest.Add(new Card("7", "Diamonds"));
        //cardtest.Add(new Card("Ace", "Hearts"));

        foreach (PlayerHand p in m_Manager.m_Players)
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
            //p.m_PokerHand = PokerHelper.CheckHand(ref PlayerHand, cardtest);


            p.setHandCards(PlayerHand);
            Debug.Log("Player_CardHand:" + p.getHandCards().Count + " poker hand" + p.m_PokerHand);
            m_Manager.m_Interface.SetPlayerResult(m_index++,p.m_PokerHand.ToString());
         
        }

        m_Manager.SetState(new CompResult(m_Manager));
        yield break;
        
    }

    static void ClearConsole()
    {
        var logEntries = System.Type.GetType("UnityEditor.LogEntries, UnityEditor.dll");

        var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);

        clearMethod.Invoke(null, null);
    }
}
