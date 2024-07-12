using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    [SerializeField] float _movespeed =1;
    public float _jumppower = 3;
    [SerializeField] float _jumpcount = 1;
    [SerializeField] GameObject cir;
    [SerializeField] GameObject cir2;
    Slider Slider;
    float timer = 0;    
    SpriteRenderer sp;
    Animator anim;
    Rigidbody2D rb;
    private float _inputX;
    bool right;
    bool left;
    List<Itembase> _itemList = new List<Itembase>();
    public float _hp =100;
    public float currentHp;
    // Start is called before the first frame update
    void Start()
    {
        Slider = GameObject.Find("Slider").GetComponent<Slider>();
        Slider.value = 1;
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        currentHp = _hp;
        DontDestroyOnLoad(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Slider.value = currentHp / _hp;
        if (Input.GetButtonDown("Fire1"))
        {
            if (_itemList.Count > 0)
            {
                // リストの先頭にあるアイテムを使って、破棄する
                Itembase item = _itemList[0];
                _itemList.RemoveAt(0);
                item.Activate();
                Destroy(item.gameObject);
            }
        }
        _inputX = Input.GetAxisRaw("Horizontal");
        if (_inputX == 1)
        {
            sp.flipX = false;
        }
     
        if (_inputX == -1)
        {
            sp.flipX = true;
        }
       
        if ( Input.GetKeyDown(KeyCode.Space)&&_jumpcount > 0 )
        {
            rb.velocity = new Vector2(0,_jumppower);
            _jumpcount = 0;
            anim.Play("HeroKnight_Fall");
            
        }
        else if ( _jumpcount == 0 && !Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("HeroKnight_Jump");
        }


        if (_inputX != 0 && _jumpcount == 1)
        {
            anim.Play("HeroKnight_Run");
        }
        else if (_inputX == 0 && _jumpcount == 1)
        {
            anim.Play("HeroKnight_Idle");
        }

        if (currentHp <= 0)
        {
            anim.Play("Deathanim");
        }
        
        if (Input.GetKeyDown(KeyCode.S) && _inputX ==0)
        {
            anim.Play("HeroKnight_Attack1");
            cir.SetActive(true);
            cir2.SetActive(true);
            timer = 0;
        }
        if ( timer > 0.5)
        {
            cir.SetActive(false);
            cir2.SetActive(false);
        }
        
    }
    private void FixedUpdate()
    {
        if (!Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = new Vector2(_inputX * _movespeed, rb.velocity.y);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            _jumpcount = 1;
        }
        
        
    }
    public void GetItem(Itembase item)
    {
        _itemList.Add(item);
    }
}
