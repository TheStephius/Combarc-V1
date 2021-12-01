using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida1 : MonoBehaviour
{
    [SerializeField] AudioClip sfx_vida;

    public int CargarNivel;
    public int maxHealth = 100;
    public int cHealth;
    public BarraDeVida HB;

    void Start()
    {
        cHealth = maxHealth;
        HB.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TakeDamage(3);
    }
    void TakeDamage(int damage)
    {
        cHealth -= damage;
        HB.SetHealth(cHealth);

        if (cHealth <= 0)
            SceneManager.LoadScene(CargarNivel);

        if (cHealth <= 20)
            AudioSource.PlayClipAtPoint(sfx_vida, Camera.main.transform.position);
    }
}
