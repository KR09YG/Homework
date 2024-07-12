using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour
{
    [SerializeField] AudioClip AudioClip;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Swing()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.S) )
        {
            animator.Play("HeroKnight_Attack1");
        }
    }
}
