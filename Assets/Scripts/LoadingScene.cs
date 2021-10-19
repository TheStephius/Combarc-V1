using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public int CargarNivel;
    public float segundosEspera;
    

    // Update is called once per frame
    void Update()
    {
        segundosEspera -= Time.deltaTime;

        if (segundosEspera <= 0)
        {
            SceneManager.LoadScene(CargarNivel);
        }

    }
}
