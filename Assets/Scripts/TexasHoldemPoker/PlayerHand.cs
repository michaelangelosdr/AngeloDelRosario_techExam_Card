using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour, ITexasHoldemHand
{
    List<Card> Hand;
    int HandValue;
    string PlayerName;
    public PokerHands m_PokerHand { get; set; }



    public PlayerHand(string p_PlayerName)
    {
        Hand = new List<Card>();
        PlayerName = p_PlayerName;
    }

    public void InitializePlayer()
    {   if (Hand == null)
            Hand = new List<Card>();
        else
            Hand.Clear();
    }

    public string GetPlayerName()
    {
        return PlayerName;
    }

    public void SetPlayerName(string name)
    {
        PlayerName = name;
    }

    public void ResetHand()
    {
        Hand.Clear();
    }

    public void AddToHand(Card card)
    {      
       HandValue += PokerHelper.ConvertToVal(card.GetCardValue());
      
       Hand.Add(card);
    }
    public List<Card> getHandCards()
    {
        return Hand;
    }

    public void ShowAllCards()
    {

        HandValue = 0;
        foreach (Card c in Hand)
        {
            c.ShowCard(true);
            HandValue += PokerHelper.ConvertToVal(c.GetCardValue());
        }
    }

    public int GetHandValue()
    {
        return HandValue;
    }
}
