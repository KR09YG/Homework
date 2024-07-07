using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Itembase : MonoBehaviour
{
    [Tooltip("効果音")]
    [SerializeField] AudioClip sound = default;
    [Tooltip("使うタイミング")]
    [SerializeField] Act _whenAct = Act.Get;


    // Start is called before the first frame update
    public abstract void Activate();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if( sound )
            {
                AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);

            }
            if ( _whenAct == Act.Get)
            {
                Activate();
                Destroy(this.gameObject);
            }
            else if (_whenAct == Act.Use)
            {
                this.transform.position = Camera.main.transform.position;

                GetComponent<Collider2D>().enabled = false;

                collision.gameObject.GetComponent<Move>().GetItem(this);
            }
        }
    }
    enum Act
    {
        Get,

        Use,
    }
}
