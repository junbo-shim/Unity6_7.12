using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigid;
    private Animator playerAnimator;


    public float forwardForce = 300f;
    public float backwardForce = 300f;
    public float jumpForce = 400f;


    private int jumpCount = 0;
    private bool isGround = true;
    private bool isNothing = true;
    private bool isForward = false;
    private bool isBackward = false;
    private bool isJump = false;
    private bool isDead = false;



    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        Debug.Assert(playerRigid != null);
        Debug.Assert(playerAnimator != null);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) { return; }

        playerAnimator.SetBool("OnGround", isGround);
        playerAnimator.SetBool("PressedNothing", isNothing);
        playerAnimator.SetBool("PressedRight", isForward);
        playerAnimator.SetBool("PressedLeft", isBackward);
        playerAnimator.SetBool("PressedJump", isJump);
    }

    private void GoForward() 
    {
    
    }
    private void GoBackward() 
    {
    
    }
    private void DoJump() 
    {
    
    }
    private void Die() 
    {
        playerAnimator.SetTrigger("Die");
        playerRigid.velocity = Vector2.zero;
        isDead = true;
    }

}
