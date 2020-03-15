using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private int MAX_NUMBER_OF_CARDS = 5;

    List<Card> BoardHand;
    private int NumberOfCards=0;

    public Board()
    {
        NumberOfCards = 0;
        BoardHand = new List<Card>();
    }

    public void SetBoardCards(Card card)
    {
       
        BoardHand.Add(card);
        NumberOfCards++;
        //BoardHand[NumberOfCards++] = card;
    }


    public Card GetBoardCard(int index)
    {
        if(BoardHand[index] == null)
        {
            Debug.Log("NO CARD IN BOARD");
            return null;
        }

        return BoardHand[index];
    }
    public List<Card> getBoardCards()
    {
        return BoardHand;
    }

    public void ResetBoard()
    {
        NumberOfCards = 0;
        BoardHand.Clear();
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

    public int GetMaxNumberOfCards()
    {
        return MAX_NUMBER_OF_CARDS;
    }
}
