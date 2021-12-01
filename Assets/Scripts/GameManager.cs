using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] AudioClip sfx_select;

    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel(int nivel)
    {
        SceneManager.LoadScene(nivel);
        Time.timeScale = 1;

    }

    public void SelectSound()
    {
        AudioSource.PlayClipAtPoint(sfx_select, Camera.main.transform.position);
    }
}
