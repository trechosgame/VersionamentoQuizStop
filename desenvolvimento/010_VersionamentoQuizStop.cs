# 10_VersionamentoQuizStop
- Neste versionamento do jogo Palavras,  o componente AudioMixer.cs foi criado, onde será organizado os efeitos
- sonoros, cliques forem necessário neste quiz.
- <img src="AudioMixer.png" width="500px">

 
# CÓDIGO FONTE DOS EFEITOS SONOROS:
 - https://www.youtube.com/watch?v=N8whM1GjH4w&list=PLf6aEENFZ4Fv0ifncKE3T05qrI450U_aD&index=18
   
# CÓDIGO FONTE DO GAME:
- 1 https://www.youtube.com/watch?v=AAGuuSVBk8M&list=PLJLLSehgFnspMBk7VaLI18Digsj2xuMhT&index=1

#
- 2 https://www.youtube.com/watch?v=M0viZrgunNI&list=PLJLLSehgFnspMBk7VaLI18Digsj2xuMhT&index=2

#
- 3 https://www.youtube.com/watch?v=NwtiYSVplHA&list=PLJLLSehgFnspMBk7VaLI18Digsj2xuMhT&index=3

#
- 4 https://www.youtube.com/watch?v=5XCDkd61-i8&list=PLJLLSehgFnspMBk7VaLI18Digsj2xuMhT&index=4

#
- 5 https://www.youtube.com/watch?v=aDTtgv3RgCQ&list=PLJLLSehgFnspMBk7VaLI18Digsj2xuMhT&index=5

#
- 6 https://www.youtube.com/watch?v=r4MFdbkIM0M&list=PLJLLSehgFnspMBk7VaLI18Digsj2xuMhT&index=10


using System;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Source ------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    
    

    [Header("--------- Audio Clip ------")]
    public AudioClip background;
    public AudioClip click;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    // Efeitos sonoros
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    } 
    public static AudioManager instace;
    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    internal void PlayClick()
    {
        throw new NotImplementedException();
    }
}





------------
-------------


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



----------
----------
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




----------
----------


  

