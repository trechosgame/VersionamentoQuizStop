# 11_VersionamentoQuizStop
- Neste versionamento do jogo Palavras,  os efeitos sonoros foram adicionados na t1,
- O que estava acontecendo (e por que o som ainda toca no Play):
- 1. AudioManager centralizado (perfeito!)
- 2. Colocou o PlayClick() no OnClick dos botões** (perfeito!)
- 3. MAS… o som ainda toca quando dá Play porque ainda tem AudioSource com “Play On Awake” nos botões (ou em algum lugar da cena).

#### Passo 1: Remova TODOS os AudioSource que estão nos botões
- Selecione **btnRespostaA**, **B**, **C** e **D**
- Se tiver **AudioSource** → clique na engrenagem → **Remove Component**
- Repita nos 4

#### Passo 2: Configure o AudioManager como ÚNICA fonte de som
1. Selecione o GameObject **AudioManager** na Hierarchy
2. No Inspector dele:
   - **Music Source** → arraste um AudioSource vazio (pra música de fundo)
   - **Sfx Source** → arraste OUTRO AudioSource vazio (pra efeitos)
   - **Click** → arraste seu som de clique
   - **Desmarque “Play On Awake”** dos dois AudioSources

#### Passo 3: Confirme o código do AudioManager (copia e cola isso inteiro)

```csharp
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    public AudioClip background;
    public AudioClip click;
    public AudioClip correct;
    public AudioClip wrong;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (background != null && musicSource != null)
        {
            musicSource.clip = background;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlayClick()   => PlaySFX(click);
    public void PlayCorrect() => PlaySFX(correct);
    public void PlayWrong()   => PlaySFX(wrong);

    private void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
            sfxSource.PlayOneShot(clip);
    }
}
```

#### Passo 4: Confirme o OnClick dos botões
- On Click ()
-   ├─ GC → ResponderResposta()
  - └─ AudioManager → PlayClick()
  ```

# Resultado:
- Nenhum AudioSource nos botões
- Som só toca quando clica**
- AudioManager centralizado e funcionando em qualquer cena

   
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


# Meus Games:
- https://trechosgame.github.io/Jogo_Da_Forca/app.html
- https://trechosgame.github.io/Jogo-Quem-Sou-Eu/app.html
- https://trechosgame.github.io/Quiz-Responsivo/quiz.html

# Redes Sociais:
- https://www.instagram.com/trechosgame/
- https://www.behance.net/trechosgame
- https://www.colab55.com/@trechosdecodigo
- https://www.youtube.com/channel/UCfEsOEx_t6hiIms8HzttxOw/featured
- https://github.com/trechosgame  

# Color Palette:
 - https://mycolor.space

# Editor de Códigos Online:
- https://www.programiz.com/

# Editor de Imagens Online:
 - https://www.resizepixel.com/pt/edit

# Imagens:
- https://www.freepik.com/
- https://www.storyset.com/
- https://www.undraw.com/
- https://www.pixabay.com/
- https://www.unsplash.com/
- https://www.flaticon.com/
- https://www.pngegg.com/

