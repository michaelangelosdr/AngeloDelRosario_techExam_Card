using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private int MAX_NUMBER_OF_CARDS = 5;

    Card[] BoardHand;
    private int NumberOfCards;

    public Board()
    {
        NumberOfCards = 0;
        BoardHand = new Card[MAX_NUMBER_OF_CARDS];
    }

    public void AddCardsToBoard(Card card)
    {
        BoardHand[NumberOfCards++] = card;
    }

    public int GetCardVal_OnIndex(int index)
    {
        if(index <NumberOfCards)
        {
            return PokerHelper.ConvertToVal(BoardHand[index].GetCardValue());
        }

        Debug.Log("hand Empty");
        return 0;
    }
}
