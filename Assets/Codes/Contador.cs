// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;

// CONTA QUANTOS AÇAIS TEM SALVO E QUANTAS VEZES FORAM JOGADAS
public class Contador : MonoBehaviour
{
    // ===== TORNA A CLASSE VISÍVEL PARA OUTRAS ===== //
    public static Contador Contador_R;

    public static Contador Instance(){
        if(!Contador_R){
            Contador_R = FindObjectOfType(typeof(Contador)) as Contador;
            if(!Contador_R)
                Debug.LogError("Não Achou o código");
        }
        return Contador_R;
    }
    // ============== INICIO DO CÓDIGO =================== \\
    private GameManager GameManager_R;


    public int jogadas, coletaBoa;
    private Text Text_Play, Text_Coleta;
    private string Play_Total;

    //FAZ COM QUE O CÓDIGO NÃO SEJA DESTRUIDO TODA VEZ QUE REINICIAR O JOGO
    void Awake()
    {
        AtualizaPlay();
        GameManager_R = GameManager.Instance();

        // =====> TIRAR DOS COMENTÁRIOS A LINHA ABAIXO PARA RESETAR TODOS OS VALORES
        // jogadas = 0; SalvaPlay(0);
    }

    private void Update()
    {
        // JOGADAS
        SalvaPlay(jogadas);
        coletaBoa = GameManager_R.coletaBoa;
    }

    // ATUALIZA OS VALORES DOS RECORDES NOS TEXTOS DE MENU
    public void Recordes()
    {
        // VALORES DE JOGADAS
        Play_Total = string.Format("{0}", jogadas);
        Text_Play = GameObject.Find("PQts_txt").GetComponent<Text>();
        Text_Play.text = Play_Total;

        // VALORES DE COLETA
        Text_Coleta = GameObject.Find("CQts_txt").GetComponent<Text>();
        Text_Coleta.text = GameManager_R.coletaBoa.ToString();               // MOSTRA EM TEXTO 
    }

    // ================================ SALVA JOGADAS ========================================= \\
    //SALVA A QUANTIDADE DE JOGADAS DENTRO DE UMA CHAVE
    public void SalvaPlay(int ClicouPlay)
    {
        PlayerPrefs.SetInt("PlaySalvo", ClicouPlay);
    }

    //VERIFICA SE TEM ALGO SALVO NA CHAVE 'PlaySalvo'
    public void AtualizaPlay()
    {
        if (PlayerPrefs.HasKey("PlaySalvo"))
            jogadas = PlayerPrefs.GetInt("PlaySalvo");    //SE TIVER, PEGA O VALOR DA CHAVE E ATRIBUI NA VARIÁVEL 'PlayTotal'
        else
        {
            jogadas = 0;                                  //SE NÃO TEM NADA SALVO COMEÇA COM ZERO
            PlayerPrefs.SetInt("PlaySalvo", jogadas);     //ATRIBUI O ZERO NO VARIÁVEL
        }
    }
}