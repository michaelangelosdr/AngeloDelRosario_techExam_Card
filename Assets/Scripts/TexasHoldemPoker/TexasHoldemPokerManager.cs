using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexasHoldemPokerManager : StateMachine
{
    [SerializeField]
    public TexasHoldemPokerSettings settings;

    public Deck m_Deck;

    public List<PlayerHand> m_Players;
    public Board m_Board;

    #region Game Engine Specifics

    [SerializeField]
    public List<Transform> PlayerSpots;
    #endregion

    private void Start()
    {
        SetState(new InitializeGame(this));
    }

}
