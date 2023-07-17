using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    private SpriteRenderer moneySprite;
    private CircleCollider2D moneyCollider;

    // Start is called before the first frame update
    void Start()
    {
        moneySprite = GetComponent<SpriteRenderer>();
        moneyCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Debug.Log("������ġ");
            Debug.Log("����ȹ��");
            moneySprite.enabled = false;
            moneyCollider.enabled = false;
        }
    }
}
