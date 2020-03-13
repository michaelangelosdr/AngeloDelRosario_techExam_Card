using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public Idle(TexasHoldemPokerManager manager):base(manager)
    {

    }

    public override IEnumerator Start()
    {
        return base.Start();
    }
    public override IEnumerator PlayGame()
    {

        yield break;
    }
}
