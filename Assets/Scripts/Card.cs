using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class Card : MonoBehaviour
{

    int DeckIndex;

    Sprite m_cardSprite;
    Sprite m_cardBackSprite;
    string m_Cardname;
    string m_Cardface;
    string m_CardVal;

    public Card(string value, string face, Sprite sprite, Sprite BackSprite)
    {
        m_Cardface = face;
        m_CardVal = value;
        m_cardSprite = sprite;
        m_cardBackSprite = BackSprite;
        m_Cardname = m_CardVal + " Of " + m_Cardface;
        ShowCard(true);
    }

    public void SetDeckIndex(int deckindex)
    {
        DeckIndex = deckindex;
    }
    public int GetDeckIndex()
    {
        return DeckIndex;
    }
    public string GetCardName()
    {
        if (m_Cardname == null)
        {
            Debug.LogWarning("warning, name is null");
            return null;
        }
        return m_Cardname;
    }

    public string GetCardValue()
    {
        return m_CardVal;
    }

    public void ShowCard(bool isFaceUp)
    {
        if (!isFaceUp)
        {
            GetComponent<SpriteRenderer>().sprite = m_cardBackSprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = m_cardSprite;
        }
       
    }
  
}
