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



