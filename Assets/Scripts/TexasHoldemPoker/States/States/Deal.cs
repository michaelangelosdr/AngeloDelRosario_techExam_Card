using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deal : State
{
   public Deal(TexasHoldemPokerManager manager):base(manager)
    {

    }

    public override IEnumerator Start()
    {
        Deck m_deck = m_Manager.m_Deck;
        Board m_board = m_Manager.m_Board;
        List<PlayerHand> m_players = m_Manager.m_Players;
        //Debug.Log("DEAL STATE");
        #region Deck Shuffle 
        m_deck.ResetDeck();
        m_deck.ShuffleDeck();
        m_Manager.m_Interface.SetWinnerResult(" ");
        for (int x = 0; x < m_board.GetMaxNumberOfCards(); x++)
        {
            m_Manager.m_Interface.SetBoardCard(m_deck.getDeckSprite());
        }
        for (int x = 0; x < m_Manager.m_Players.Count; x++)
        {
            for (int i = 0; i < 2; i++)
            {
                m_Manager.m_Interface.SetPlayerHandSprite(x,i, m_deck.getDeckSprite());
                
            }
            m_Manager.m_Interface.SetPlayerResult(x, "...");
        }
        #endregion

       
        #region add cards to players


        for (int x = 0; x < m_Manager.m_Players.Count; x++)
        {
            for (int i = 0; i < 2; i++)
            {
                Card c = m_deck.Draw();
                m_players[x].AddToHand(c);
                m_Manager.m_Interface.SetPlayerHandSprite(x,i, c.getCardSprite());
                yield return new WaitForSeconds(0.1f);

            }
        }


        #endregion


        #region add cards to board


        for (int x=0; x<m_board.GetMaxNumberOfCards();x++)
        {
            Card c = m_deck.Draw();
            m_board.SetBoardCards(c);
            m_Manager.m_Interface.SetBoardCard(c.getCardSprite());
           yield return new WaitForSeconds(0.1f);
        }
        #endregion

        m_Manager.SetState(new CheckResult(m_Manager));
        yield break;
    }

    public override IEnumerator PlayGame()
    {/*
        Deck m_deck = m_Manager.m_Deck;
        Board m_board = m_Manager.m_Board;
        List<PlayerHand> m_players = m_Manager.m_Players;
     
      
        for (int x = 0; x < m_board.GetMaxNumberOfCards(); x++)
        {
            m_Manager.m_Interface.SetBoardCard(m_deck.getDeckSprite());
        }
        for (int x = 0; x < m_Manager.m_Players.Count; x++)
        {
            for (int i = 0; i < 2; i++)
            {
                m_Manager.m_Interface.SetPlayerHandSprite(x,i, m_deck.getDeckSprite());
            }
        }

        
        m_Manager.SetState(new Deal(m_Manager));*/
        yield break;
    }
}
