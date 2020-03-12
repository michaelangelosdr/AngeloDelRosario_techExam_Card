using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="THP_Settings",menuName ="THP_settings")]
public class TexasHoldemPokerSettings : ScriptableObject
{
    [SerializeField]
    public int Number_of_players;
}
