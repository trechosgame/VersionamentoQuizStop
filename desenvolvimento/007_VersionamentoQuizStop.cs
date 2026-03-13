using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class comandosBasicos : MonoBehaviour
{
    public void carregaCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    public void resetarPontuacoes()
    {
        PlayerPrefs.DeleteAll();
    }
    
    
}



using UnityEngine;
using System.Collections;
public class moveOffset : MonoBehaviour
{
    private Material materialAtual;
    public float velocidade;
    private float offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        materialAtual = GetComponent<Renderer>().material; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offset += 0.01f;

        materialAtual.SetTextureOffset("_MainTex", new Vector2(offset * velocidade, 0)); 
    }
}



using UnityEngine;
using UnityEditor.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;


public class notaFinal : MonoBehaviour
{
    private int idTema;
    public Text txtNota;
    public Text txtInfoTema;

    public GameObject estrela1;
    public GameObject estrela2;
    public GameObject estrela3;

    private int notaF;
    private int acertos;
    void Start()
    {
        idTema = PlayerPrefs.GetInt("idTema");
        
        estrela1.SetActive(false);
        estrela2.SetActive(false);
        estrela3.SetActive(false);

        
        notaF = PlayerPrefs.GetInt("notaFinalTemp" + idTema.ToString());
        acertos = PlayerPrefs.GetInt("acertosTemp" + idTema.ToString());

        txtNota.text = notaF.ToString();
        txtInfoTema.text = " Você acertou " + acertos.ToString() + " de 20 perguntas";

        if (notaF == 10)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(true);
        }
        else if (notaF >= 7)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(false);
        }
        else if (notaF >= 5)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(false);
            estrela3.SetActive(false);
        }
    }

    public void jogarNovamente()
    {
        SceneManager.LoadScene("T"+idTema.ToString());
    }
    
}



using UnityEngine;
using UnityEditor.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

public class responder : MonoBehaviour
{
    private int idTema;
    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text respostaD;
    public Text infoRespostas;

    public string[] perguntas;  // armazena todas as perguntas
    public string[] alternativaA;  // armazena todas as alternativas A

    public string[] alternativaB;  // armazena todas as alternativas B

    public string[] alternativaC;   // armazena todas as alternativas C

    public string[] alternativaD;  // armazena todas as alternativas D


    public string[] corretas;  // armazena as alternativas corretas

    private int idPergunta;
    private float acertos;
    private float questoes;
    private float media;
    private int notaFinal;

    
    void Start()
    {
        idTema = PlayerPrefs.GetInt("idTema");
        idPergunta = 0;
        questoes = perguntas.Length;
        pergunta.text = perguntas[idPergunta];
        respostaA.text = alternativaA[idPergunta];
        respostaB.text = alternativaB[idPergunta];
        respostaC.text = alternativaC[idPergunta];
        respostaD.text = alternativaD[idPergunta];

        infoRespostas.text = "    Respondendo "+(idPergunta + 1).ToString()+ " de "+questoes.ToString() + " perguntas.";
    }

    public void resposta(string alternativa)
    {
        if (alternativa == "A")
        {
            if (alternativaA[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }

        else if (alternativa == "B")
        {
           if (alternativaB[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }

        else if (alternativa == "C")
        {
           if (alternativaC[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }

        else if (alternativa == "D")
        {
           if (alternativaD[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }
        proximaPergunta();
       
    }

    void proximaPergunta()
    {
        idPergunta += 1;

        if (idPergunta <= (questoes - 1))
        {
            pergunta.text = perguntas[idPergunta];
            respostaA.text = alternativaA[idPergunta];
            respostaB.text = alternativaB[idPergunta];
            respostaC.text = alternativaC[idPergunta];
            respostaD.text = alternativaD[idPergunta];

            infoRespostas.text = "    Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas.";
        }
        else
        {
            // O QUE FAZER SE TERMINAR AS PERGUNTAS
            media = 10 * (acertos / questoes); // CALCULA A MEDIA COM BASE NO PERCENTUAL DE ACERTO
            notaFinal = Mathf.RoundToInt(media); // ARREDONDA A NOTA PARA O PRÓXIMO INTEIRO, SEGUNDO A REGRA DA MATEMÁTICA.

            if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idTema.ToString()))
            {
                PlayerPrefs.SetInt("notaFinal"+idTema.ToString(), notaFinal);
                PlayerPrefs.SetInt("acertos"+idTema.ToString(), (int) acertos);
            }
            PlayerPrefs.SetInt("notaFinalTemp"+idTema.ToString(), notaFinal);
            PlayerPrefs.SetInt("acertosTemp"+idTema.ToString(), (int) acertos);

            SceneManager.LoadScene("notaFinal");
        }

       
    }







    // Update is called once per frame
    void Update()
    {
        
    }
}




using UnityEngine;
using UnityEditor.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class temaInfo : MonoBehaviour
{
    public int idTema;

    public GameObject estrela1;
    public GameObject estrela2;
    public GameObject estrela3;

    private int notaFinal;

    void Start()
    {
        estrela1.SetActive(false);
        estrela2.SetActive(false);
        estrela3.SetActive(false);
        
        int notaFinal = PlayerPrefs.GetInt("notaFinal" + idTema.ToString());
        
        if (notaFinal == 10)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(true);
        }
        else if (notaFinal >= 7)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(false);
        }
        else if (notaFinal >= 5)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(false);
            estrela3.SetActive(false);
        }
    
    }

   
    void Update()
    {
        
    }
}



using UnityEngine;
using UnityEditor.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class temaJogo : MonoBehaviour
{
    public Button btnPlay;
    public Text txtNomeTema;

    public GameObject infoTema;
    public Text txtInfoTema;
    public GameObject estrela1;
    public GameObject estrela2;
    public GameObject estrela3;

    public string[] nomeTema;
    public int numeroQuestoes;

    private int idTema;
    void Start()
    {
        idTema = 0;
        txtNomeTema.text = nomeTema[idTema];
        txtInfoTema.text = "  Você acertou  X  de  X  questões.";
        infoTema.SetActive(false);
        estrela1.SetActive(false);
        estrela2.SetActive(false);
        estrela3.SetActive(false);
        btnPlay.interactable = false;

    }

    public void selecioneTema(int i)
    {
        idTema = i;
        PlayerPrefs.SetInt("idTema", idTema);
        txtNomeTema.text = nomeTema[idTema];

           int notaFinal = PlayerPrefs.GetInt("notaFinal"+idTema.ToString());
           int acertos = PlayerPrefs.GetInt("acertos"+idTema.ToString());

           estrela1.SetActive(false);
           estrela2.SetActive(false);
           estrela3.SetActive(false);
           
        if (notaFinal == 10)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(true);
        }
        else if (notaFinal >= 7)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(false);
        }
        else if (notaFinal >= 5)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(false);
            estrela3.SetActive(false);
        }



        txtInfoTema.text = " Você acertou "+acertos.ToString()+" de " + numeroQuestoes.ToString() +" questões !";
        infoTema.SetActive(true);
        btnPlay.interactable = true;
    }

    public void jogar()
    {
        SceneManager.LoadScene("T"+idTema.ToString());

    }
}




