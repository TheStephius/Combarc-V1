using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;

    Animator myAnimator;
       
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();

        myAnimator.SetBool("IsRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(movH * speed, movV * speed) * Time.deltaTime;
        transform.Translate(movimiento);

        if (movH != 0)
        {
            myAnimator.SetBool("IsRunning", true);

            if (movH < 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
                transform.localScale = new Vector2(1, 1);
        }
        else
        {
            myAnimator.SetBool("IsRunning", false);
        }
    }
}
