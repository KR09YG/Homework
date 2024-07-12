using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public float score = 0;
    [SerializeField] Text text;
    [SerializeField] GameObject game;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text =score.ToString() + "–‡";
        if ( score > 12 )
        {
            game.SetActive( true );
        }
    }
}
