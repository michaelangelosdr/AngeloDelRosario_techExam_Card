using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    const int MAX_DECK_COUNT = 52;

    string[] CardNames = {"Ace","2","3","4","5","6","7","8","9","10",
                          "Jack","Queen","King"};
    string[] CardFaces = { "Clubs", "Spades", "Diamonds", "Hearts" };

    [SerializeField]
    public Sprite[] CardSprites;

    [SerializeField]
    Sprite DeckSprite;


    Card[] CardList;
    int DeckCount;

    

    public void InitializeDeck()
    {
        CardList = new Card[MAX_DECK_COUNT];

        int cardCount = 0;
        for (int i = 0; i < CardFaces.Length; i++)
        {
            for (int x = 0; x < CardNames.Length; x++)
            {


                Card c = new Card(CardNames[x], CardFaces[i], CardSprites[cardCount], DeckSprite);

                CardList[cardCount] = c;
                CardList[cardCount].SetDeckIndex(cardCount);
                cardCount++;
            }
        }
        DeckCount = cardCount;
    }

    public Card Draw()
    {
        if(DeckCount < 0)
        {
            Debug.LogWarning("Card deck empty");
            return null;
        }

        return CardList[--DeckCount]; 
    }

    public void ShuffleDeck()
    {
        for (int i = MAX_DECK_COUNT - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i);
            Card tempCard = CardList[i];
            CardList[i] = CardList[randomIndex];
            CardList[randomIndex] = tempCard;
        }
    }
    
    public void ResetDeck()
    {
        Card[] templist = new Card[MAX_DECK_COUNT];
        for(int x=0;x<CardList.Length;x++)
        {
            templist[CardList[x].GetDeckIndex()] = CardList[x]; 
        }
        CardList = templist;
        DeckCount = MAX_DECK_COUNT;
    }

    public int GetDeckCount()
    {
        return DeckCount;
    }

    public Sprite getDeckSprite()
    { return DeckSprite; }

    public Card GetCardAtIndex(int index)
    {
        return CardList[index];
    }
}
