using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Itembase
{
    Gamemanager manager;
    // Start is called before the first frame update
    private void Start()
    {
        manager = GameObject.Find("Gamemanager").GetComponent<Gamemanager>();
    }
    public override void Activate()
    {
        manager.score += 1;
    }
}
