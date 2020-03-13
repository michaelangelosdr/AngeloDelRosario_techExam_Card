using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour
{
    [SerializeField]
    List<SpriteRenderer> HandCard_Sprites;

    [SerializeField]
    Text label_PlayerName;
    [SerializeField]
    Text label_PlayerHand;


    private int HandCounter = 0;

    public void SetName(string name)
    {
        label_PlayerName.text = name;
    }

    public void SetHandResult(string result)
    {
        label_PlayerHand.text = result;
    }

    public void SetHandCard(Sprite sprite)
    {
        if (HandCounter > HandCard_Sprites.Count - 1) HandCounter = 0;

        HandCard_Sprites[HandCounter++].sprite = sprite;
    }

    public void ResetHandCards()
    {
        HandCounter = 0;
        foreach(SpriteRenderer r in HandCard_Sprites)
        {
            r.sprite = null;
        }
    }
}
