using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGame : State
{
   public InitializeGame(TexasHoldemPokerManager manager):base(manager)
    {

    }
    public override IEnumerator Start()
    {      
        m_Manager.m_Deck = new Deck();
       for(int x=0; x<m_Manager.settings.Number_of_players;x++)
        {
            string name = "Player" + x+1;
            m_Manager.m_Players[x].InitializeHand(name);
        }
        m_Manager.m_Board = new Board();
        
        yield break;
    }

}
