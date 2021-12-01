using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject ContinueButton;
    public int CargarNivel;
    public GameObject BlemAngry;
    public GameObject BlemNervous;
    public GameObject BlemNormal;
    public GameObject NimraUK; 
    public GameObject NimraUKTwo;
    public GameObject NimraNormal;

    void Start()
    {
        StartCoroutine(Type());
    }
    void Update()
    {
        if (textDisplay.text == sentences[index])
            ContinueButton.SetActive(true);

        if (textDisplay.text == sentences[18])
        {
          SceneManager.LoadScene(CargarNivel);
          Time.timeScale = 2;
        }

        if (textDisplay.text == "BLEM: No!! Espera, explícame que esta pasando, como es que eres real, por que estoy en el Antiguo Egipto?!")
            BlemAngry.SetActive(true);
        else
            BlemAngry.SetActive(false);

        if (textDisplay.text == "BLEM: *Gasp* Quien eres tu?! Que es este lugar, donde demonios estoy?!?!")
            BlemNervous.SetActive(true);
        else
            BlemNervous.SetActive(false);

        if (textDisplay.text == "BLEM:  ..... ")
            BlemNormal.SetActive(true);
        else
            BlemNormal.SetActive(false);

        if (textDisplay.text == "??: Hmmm? que tenemos aquí")
            NimraUKTwo.SetActive(true);
        else
            NimraUKTwo.SetActive(false);

        if (textDisplay.text == "NIMRA: ¡¡¡COMO TE ATREVES, ESTAS ANTE LA PRESENCIA DE LA DIOSA EGIPCIA BASTET, PROTECTORA DEL BAJO  EGIPTO Y DEL DIOS RA!!! ")
            NimraUK.SetActive(true);
        else
            NimraUK.SetActive(false);

        if (textDisplay.text == "NIMRA:  ¡¡CELEBRARE SOBRE TU CADAVER!!")
            NimraNormal.SetActive(true);
        else
            NimraNormal.SetActive(false);
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
        
    public void NextSentence()
    {
        ContinueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
            textDisplay.text = "";
            ContinueButton.SetActive(false);
    }
}
