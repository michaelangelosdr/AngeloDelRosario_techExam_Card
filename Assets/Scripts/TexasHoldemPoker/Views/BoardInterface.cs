using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardInterface : MonoBehaviour
{
    [SerializeField]
    public List<SpriteRenderer> BoardCards;


    private int HandCounter = 0;

    public void SetBoardCard(Sprite sprite)
    {
        if (HandCounter > BoardCards.Count - 1) HandCounter = 0;

        BoardCards[HandCounter++].sprite = sprite;
    }

    public void ResetBoardCards()
    {
        HandCounter = 0;

        foreach(SpriteRenderer r in BoardCards)
        {
            r.sprite = null;
        }
    }
}
