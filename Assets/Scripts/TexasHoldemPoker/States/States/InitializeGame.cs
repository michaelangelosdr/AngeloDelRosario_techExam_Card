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
        m_Manager.m_Board = new Board();



        m_Manager.m_Deck = new Deck();


        
        //Set UI to say GAME READY

        
        yield break;
    }

}
