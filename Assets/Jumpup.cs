using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpup : Itembase
{
    Move move;
    public float powerup = 2;
    public override void Activate()
    {
        move._jumppower *= powerup;
    }

    // Start is called before the first frame update
    void Start()
    {
        move = GameObject.Find("Player").GetComponent<Move>();
    }


}
