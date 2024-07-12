using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;


public class Boss : MonoBehaviour
{
    SpriteRenderer sp;
    [SerializeField] float speed =1;
    Rigidbody2D rb;
    int index = 0;
    float timer = 0;
    Animator animator;
    public float Hp = 2;
    [SerializeField] Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer > 4)
        {
         index = Random.Range(-1, 1);
         timer = 0;
        }
        if (index > 0) 
        {
            sp.flipX = true;
            animator.Play("Walk");
            
        }
        else if (index < 0)
        {
            sp.flipX = false;
            animator.Play("Walk");
        }

        if( Hp <= 0)
        {
            Destroy(this.gameObject);
            text.text = "ƒQ[ƒ€ƒNƒŠƒA";
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.right * index * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Hp -= 1;
        }
        if (collision.gameObject.tag == "atc")
        {
            Hp -= 1;
        }
    }
}
