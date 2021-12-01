using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField] AudioClip sfx_vida;
    [SerializeField] float speed;


    public int CargarNivel;
    public int maxHealth = 100;
    public int cHealth;
    public BarraDeVida HB;
    float dir = 1;

    Animator myAnimator;
    Rigidbody2D myBody;
    BoxCollider2D myCollider;

    void Start()
    {
        myAnimator = GetComponent<Animator>();

        myAnimator.SetBool("IsRunning", true);

        myBody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<BoxCollider2D>();

        cHealth = maxHealth;
        HB.SetMaxHealth(maxHealth);

    }

    void Update()
    { 
       Caminar();
       Punch();

        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
            TakeDamage(5);
    }
    bool SeeWall()
    {
        return myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        RaycastHit2D raycast_pared = Physics2D.Raycast(myCollider.bounds.center, new Vector2(dir, 0), myCollider.bounds.extents.x + 0.1f, LayerMask.GetMask("Ground"));
        Debug.DrawRay(myCollider.bounds.center, new Vector2(dir, 0) * (myCollider.bounds.extents.x + 0.1f), Color.green);

        return (raycast_pared.collider != null);
    }

    void Caminar()
    {
        float movH = Input.GetAxis("Horizontal");

        if (movH != 0)
        {
            if (movH < 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
                transform.localScale = new Vector2(1, 1);

            if (SeeWall() && movH == dir)
            {
                myAnimator.SetBool("IsRunning", false);
                myBody.velocity = new Vector2(0, myBody.velocity.y);
            }
            else
            {
                dir = transform.localScale.x;

                myAnimator.SetBool("IsRunning", true);
                myBody.velocity = new Vector2(movH * speed, myBody.velocity.y);
            }
        }
        else
        {
            myBody.velocity = new Vector2(0, myBody.velocity.y);
            myAnimator.SetBool("IsRunning", false);
        }
    }

    void TakeDamage(int damage)
    {
        cHealth -= damage;
        HB.SetHealth(cHealth);

        if (cHealth <= 0)
            SceneManager.LoadScene(CargarNivel);

        if (cHealth == 30)
            AudioSource.PlayClipAtPoint(sfx_vida, Camera.main.transform.position);
    }

    void Punch()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            myAnimator.SetTrigger("Punch");
        }
    }
}