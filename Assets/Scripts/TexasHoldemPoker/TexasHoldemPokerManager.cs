using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexasHoldemPokerManager : StateMachine
{
    [SerializeField]
    public TexasHoldemPokerSettings settings;
    [SerializeField]
    public Deck m_Deck;
    public List<PlayerHand> m_Players;
    public Board m_Board;
    public InterfaceManager m_Interface;
  


    private void Start()
    {
        SetState(new InitializeGame(this));
    }

    public void PlayGame()
    {
        StartCoroutine(State.PlayGame());
    }
    
}
