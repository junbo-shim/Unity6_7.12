using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    private Rigidbody2D playerRigid;
    public Animator playerAnimator;

    public float maxMoveSpeed = 4f;
    public float jumpForce = 7.5f;

    public bool isDead = false;

    void Awake()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && playerAnimator.GetBool("IsJumping") == false)
        {
            Jump();
        }
        StopHorizon();
        CheckAnimationState();
    }

    void FixedUpdate()
    {
        if (playerAnimator.GetBool("IsJumping") == false)
        {
            MoveHorizon();
        }
    }

    private void Jump() 
    {
        playerRigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        playerAnimator.SetBool("IsJumping", true);
    }

    private void MoveHorizon() 
    {
        //if (playerAnimator.GetBool("IsJumping") == true) 
        //{
        //    return;
        //}
        //else if (playerAnimator.GetBool("IsJumping") == false) 
        //{
            float horizonMove = Input.GetAxisRaw("Horizontal");

            playerRigid.AddForce(Vector2.right * horizonMove, ForceMode2D.Impulse);

            if (playerRigid.velocity.x > maxMoveSpeed)
            {
                playerRigid.velocity = new Vector2(maxMoveSpeed, playerRigid.velocity.y);
            }
            else if (playerRigid.velocity.x < maxMoveSpeed *(-1))
            {
                playerRigid.velocity = new Vector2(maxMoveSpeed *(-1), playerRigid.velocity.y);
            }
        //}
    }

    private void StopHorizon()
    {
        if (Input.GetButtonUp("Horizontal"))
        {
            playerRigid.velocity = new Vector2(0, playerRigid.velocity.y);
        }
        //if (Input.GetButtonUp("Horizontal"))
        //{
        //    playerRigid.velocity = new Vector2(playerRigid.velocity.normalized.x * 0.01f, playerRigid.velocity.y);
        //}
    }

    private void CheckAnimationState() 
    {
        if (Mathf.Abs(playerRigid.velocity.x) < 0.1f)
        {
            playerAnimator.SetBool("IsForward", false);
            playerAnimator.SetBool("IsBackward", false);
        }
        else if (playerRigid.velocity.x >= 0.1f)
        {
            playerAnimator.SetBool("IsForward", true);
            playerAnimator.SetBool("IsBackward", false);
        }
        else if (playerRigid.velocity.x <= -0.1f)
        {
            playerAnimator.SetBool("IsForward", false);
            playerAnimator.SetBool("IsBackward", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Dead")) 
        {
            playerAnimator.SetTrigger("Die");
            isDead = true;

            Time.timeScale = 0.001f;
            gameManager.DieOnce();
        }
        else if (collision.tag.Equals("Finish"))
        {
            playerAnimator.SetTrigger("Win");
        }
        if (collision.tag.Equals("Obstacle")) 
        {
            gameManager.stageScore += 100; 
        }
        else if (collision.tag.Equals("Money")) 
        {
            gameManager.stageScore += 500;
        }



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Middleground") 
        {
            playerAnimator.SetBool("IsJumping", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Middleground")
        {
            playerAnimator.SetBool("IsJumping", true);
        }
    }
}
