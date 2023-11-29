using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalEnemyBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if(IsFacingDown())
        {
            //moving right or---
            myRigidBody.velocity = new Vector2(0f, moveSpeed);
        } else
        {
            //move left
            myRigidBody.velocity = new Vector2(0f, -moveSpeed);
        }
    }

    private bool IsFacingDown()
    {
        //epsilon checks for very small value
        return transform.localScale.y > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //turning
        transform.localScale = new Vector2(transform.localScale.x, -(Mathf.Sign(myRigidBody.velocity.y)));
    }

}
