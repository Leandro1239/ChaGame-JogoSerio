// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;

// COLETA O AÇAI EM CADA FASE
public class SomadorAcaiBom : MonoBehaviour
{
    private ControlaAudio ControlaAudio_R;
    private ControlaPaineis ControlaPaineis_R;
    private GameManager GameManager_R;
    public int coletaFase;

    // TEXTOS NA TELA
    public Text txtColetaFase;

    public void Start() 
    {
        //RECUPERAÇÃO DAS CLASSES
        ControlaAudio_R = ControlaAudio.Instance();
        GameManager_R = GameManager.Instance();
        ControlaPaineis_R = ControlaPaineis.Instance();

        GameManager_R.coletaFase = 0;
    }

    private void Update()
    {
        txtColetaFase.text = GameManager_R.coletaFase.ToString();               // MOSTRA EM TEXTO 
    }

    // VERIFICA COLISÃO E COLETA E CONTA AÇAI
    public void OnTriggerEnter2D(Collider2D Coletar)              
    {
        if (Coletar.gameObject.CompareTag("AcaiBom"))
        {
            if (GameManager_R.coletaBoa == 0)
                ControlaPaineis_R.ColetouAcaiBomUI();
            GameManager_R.coletaBoa += 1;
            GameManager_R.coletaFase += 1;
            ControlaAudio_R.PlaySom(0);                          // ATIVA O GERENCIADOR DE ÁUDIO
            Destroy(Coletar.gameObject);                         // DESTROI O "Coletor", QUE É A TAG DO ACAI
        }
    }
}
