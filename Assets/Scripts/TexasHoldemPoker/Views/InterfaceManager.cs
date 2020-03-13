using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField]
    BoardInterface board_interface;

    [SerializeField]
    List<PlayerInterface> player_interfaces; 
    [SerializeField]
    Text ResultText;

    [SerializeField]
    Button PlayButton;


    #region Board view Methods

    public void SetBoardCard(Sprite sprite)
    {
        board_interface.SetBoardCard(sprite);
    }

    public void ResetBoard()
    {
        board_interface.ResetBoardCards();
    }

    #endregion

    #region Player View Methods
    public void SetPlayerName(int playerindex,string p_playername)
    {
        if(playerindex > player_interfaces.Count)
        {
            Debug.Log("No player on index "+playerindex);
            return;
        }
        player_interfaces[playerindex].SetName(p_playername);
    }

    public void SetPlayerResult(int playerindex, string p_result)
    {
        if (playerindex > player_interfaces.Count)
        {
            Debug.Log("No player on index " + playerindex);
            return;
        }
        player_interfaces[playerindex].SetHandResult(p_result);
    }

    public void SetPlayerHandSprite(int playerindex, int handIndex, Sprite sprite)
    {
        if (playerindex > player_interfaces.Count)
        {
            Debug.Log("No player on index " + playerindex);
            return;
        }
        player_interfaces[playerindex].SetHandCard(handIndex,sprite);
    }

    public void ResetPlayerHand(int playerindex)
    {
        if (playerindex > player_interfaces.Count)
        {
            Debug.Log("No player on index " + playerindex);
            return;
        }
        player_interfaces[playerindex].ResetHandCards();
    }

    #endregion


    public void SetWinnerResult(string Winner_name)
    {
        if (Winner_name == "Draw")
        {
            ResultText.text = "Draw!";
            return;
        }
        ResultText.text = Winner_name + " Wins!";
    }

    public void AddListenerToPlayButton(UnityAction action)
    {
        PlayButton.onClick.AddListener(action);
    }
}
