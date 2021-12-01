using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialogo_Dos : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject ContinueButton;
    public GameObject BlemExpression;
    public int CargarNivel;
    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
            ContinueButton.SetActive(true);

        if (textDisplay.text == sentences[4])
        {
            SceneManager.LoadScene(CargarNivel);
            Time.timeScale = 2;
        }

        if (textDisplay.text == "BLEM:  Ahg...estoy... estoy perdiendo...la...conciencia")
            BlemExpression.SetActive(true);
        else
            BlemExpression.SetActive(false);
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
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
