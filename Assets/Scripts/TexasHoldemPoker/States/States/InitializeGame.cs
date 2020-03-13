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
        Debug.Log("INITIALIZING");

        m_Manager.m_Deck.InitializeDeck();
       for(int x=0; x<m_Manager.settings.Number_of_players;x++)
        {
            m_Manager.m_Players[x].InitializePlayer();
            string name = "Player" + (x+1);
            m_Manager.m_Players[x].SetPlayerName(name);
            m_Manager.m_Interface.SetPlayerName(x, name);
        }
        m_Manager.m_Board = new Board();

        m_Manager.m_Interface.AddListenerToPlayButton(m_Manager.PlayGame);

        m_Manager.SetState(new Idle(m_Manager));
        yield break;
    }

}
