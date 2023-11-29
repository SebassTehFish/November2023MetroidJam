using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalEnemyBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if(IsFacingRight())
        {
            //moving right or---
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        } else
        {
            //move left
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        //epsilon checks for very small value
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //turning
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), transform.localScale.y);
    }

}
