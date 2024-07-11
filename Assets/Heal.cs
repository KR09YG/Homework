using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Itembase
{
    Move move;
    public override void Activate()
    {
        if ( move.currentHp < 100 )
        {
          move.currentHp += 20;
        }
    }
    private void Start()
    {
        move = GameObject.Find("Player").GetComponent<Move>();
    }
}
