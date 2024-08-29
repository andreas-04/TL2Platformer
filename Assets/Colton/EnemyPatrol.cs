using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sprite will patrol until it reaches wall/edge, flip, then continue patrolling
// Sprite must have box collider in front of it to probe for wall/edge

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 1f;
    Rigidbody2D MyRigidBody;
    BoxCollider2D MyCollider;   // Terrain Probe
    CapsuleCollider2D MyCapsuleCollider;    // Hitbox

    // Start is called before the first frame update
    void Start()
    {
        MyRigidBody = GetComponent<Rigidbody2D>();
        MyCollider = GetComponent<BoxCollider2D>();
        MyCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            // Move right
            MyRigidBody.velocity = new Vector2(MoveSpeed, 0f);
        }
        else
        {
            // Move left
            MyRigidBody.velocity = new Vector2(-MoveSpeed, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Kill Player
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  // When collider exits another collider
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            // Turn Around
            transform.localScale = new Vector2(-(Mathf.Sign(MyRigidBody.velocity.x)), transform.localScale.y);
        }

    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
}
