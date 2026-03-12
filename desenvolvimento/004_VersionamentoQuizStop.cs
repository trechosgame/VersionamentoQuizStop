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

public class responder : MonoBehaviour
{
    public int idTema;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        txtInfoTema.text = " Você acertou X de X questões !!! ";
        infoTema.SetActive(false);
        estrela1.SetActive(false);
        estrela2.SetActive(false);
        estrela3.SetActive(false);
        btnPlay.interactable = false;

    }

    public void selecioneTema(int i)
    {
        idTema = i;
        txtNomeTema.text = nomeTema[idTema];

           //int notaFinal = 0;  IREMOS EDITAR AQUI DEPOIS
           int acertos = 0;   // IREMOS EDITAR AQUI DEPOIS

        txtInfoTema.text = " Você acertou "+acertos.ToString()+" de " +numeroQuestoes.ToString() +"questões !!!";
        infoTema.SetActive(true);
        btnPlay.interactable = true;
    }

    public void jogar()
    {
        SceneManager.LoadScene("T"+idTema.ToString());

    }
}

