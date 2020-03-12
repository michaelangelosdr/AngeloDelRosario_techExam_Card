using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerHelper : MonoBehaviour
{
    public static int ConvertToVal(string val)
    {
        int Value = 0;
        if (val == "Ace") Value = 0;
        else if (val == "Jack" || val == "Queen" || val == "King") Value = 10;
        else
        {
            Value = int.Parse(val);
        }

        return Value;
    }

}
