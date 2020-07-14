using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ===== TORNA A CLASSE VISÍVEL PARA OUTRAS ===== //
    public static GameManager GameManager_R;

    public static GameManager Instance(){
        if(!GameManager_R){
            GameManager_R = FindObjectOfType(typeof(GameManager)) as GameManager;
            if(!GameManager_R)
                Debug.LogError("Não Achou o código");
        }
        return GameManager_R;
    }
    // ===== INICIO DO CÓDIGO ===== \\

    // VARIAVEIS DAS CLASSES REFERENCIADAS
    private ControlaAudio ControlaAudio_R;
    public int linguagem, direcao, coletaFase, coletaBoa, vida, passou1 = 0, passou2 = 0, passou3 = 0, passou4 = 0, passou5 = 0;

    void Awake()
    {
        AtualizaColeta();

        //RECUPERAÇÃO DAS CLASSES
        ControlaAudio_R = ControlaAudio.Instance();

        // INICIA A MUSICA
        ControlaAudio_R.PlayMusica(0);

        if (GameManager_R == null)                                   //FAZ COM QUE O CÓDIGO NÃO SEJA DESTRUIDO TODA VEZ QUE REINICIAR O JOGO
        {
            GameManager_R = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    private void Update()
    { 
        SalvaColeta(coletaBoa);
    }

    // ================================ SALVA COLETA ========================================= \\
    //GUARDA O VALOR DA VARIÁVEL NA CHAVE 'AcaiSalvo'
    public void SalvaColeta(int Coletado)
    {
        PlayerPrefs.SetInt("AcaiSalvo", Coletado);
    }

    //VERIFICA SE TEM ALGO SALVO NA CHAVE 'AcaiSalvo'
    public void AtualizaColeta()
    {
        if (PlayerPrefs.HasKey("TotalEntregue"))
            coletaBoa = PlayerPrefs.GetInt("TotalEntregue");    //SE TIVER, PEGA O VALOR DA CHAVE E ATRIBUI NA VARIÁVEL 'AcaiTotal'
        else
        {
            coletaBoa = 0;                                  //SE NÃO TEM NADA SALVO COMEÇA COM ZERO
            PlayerPrefs.SetInt("TotalEntregue", coletaBoa);     //ATRIBUI O ZERO NO VARIÁVEL
        }
    }

}


