using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Itembase
{
    Move _player;
    [SerializeField] float _damage;
    [SerializeField] float _speed = 2;
    int _index = 1;
    Rigidbody2D _rb;
    public int Hp = 1;
    [SerializeField] GameObject jumpitem;
    public override void Activate()
    {
        _player.currentHp -= _damage;   
    }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("Player").GetComponent<Move>();
    }
    private void Update()
    {
        _rb.velocity = Vector2.left * _speed *_index;
        if ( transform.position.x < -10 )
        {
            Destroy(this.gameObject);
        }
        
        if ( Hp <=0 )
        {
            Destroy(this.gameObject);
            Instantiate(jumpitem);
        }
    }
    // Update is called once per frame
    
    
}
