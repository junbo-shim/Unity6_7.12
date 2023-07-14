using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    private SpriteRenderer moneySprite;

    // Start is called before the first frame update
    void Start()
    {
        moneySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player")) 
        {
            
            

            moneySprite.enabled = false;
        }
    }
}
