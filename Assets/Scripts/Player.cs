using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField] float speed;

    Animator myAnimator;
    public int maxHealth = 100;
    public int cHealth;
    public BarraDeVida HB;
    public int CargarNivel;

    void Start()
    {
        cHealth = maxHealth;
        HB.SetMaxHealth(maxHealth);

        myAnimator = GetComponent<Animator>();
        myAnimator.SetBool("IsRunning", true);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }
        void TakeDamage(int damage)
        {
            cHealth -= damage;
            HB.SetHealth(cHealth);
        }

        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(movH * speed, movV * speed) * Time.deltaTime;
        transform.Translate(movimiento);

        if (cHealth <= 0)
        {
            SceneManager.LoadScene(CargarNivel);
        }

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
