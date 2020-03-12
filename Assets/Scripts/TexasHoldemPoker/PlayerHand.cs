using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour, ITexasHoldemHand
{
    List<Card> Hand;
    int HandValue;

    public PokerHands m_PokerHand { get; set; }

    public PlayerHand()
    {
        Hand = new List<Card>();
    }

    public void ResetHand()
    {
        Hand = new List<Card>();
    }

    public void AddToHand(Card card)
    {

       card.ShowCard(true);
       HandValue += PokerHelper.ConvertToVal(card.GetCardValue());
      
       Hand.Add(card);
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
