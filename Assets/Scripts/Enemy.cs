using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator myAnimator;
    Rigidbody2D myBody;
    BoxCollider2D myCollider;

    void Start()
    {
        myAnimator = GetComponent<Animator>();

        //myAnimator.SetBool("Walking", true);

        myBody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        EnemyDetection();
        Kick();

    }

    public bool EnemyDetection()
    {
        //se hace la linea
        RaycastHit2D detector = Physics2D.Raycast(transform.position, Vector2.left, 30f, LayerMask.GetMask("Player"));
        Debug.DrawRay(transform.position, Vector2.left * 30f, Color.green);
        //!= diferente
        return detector.collider != null;

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 10f);

    }

    public void Kick()
    {
        if (EnemyDetection())
        {
            myAnimator.SetTrigger("Kick");
        }
    }
}