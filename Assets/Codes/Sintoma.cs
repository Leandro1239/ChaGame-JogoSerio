// BIBLIOTECAS
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// TRATA OS DANOS QUE O PERSONAGEM TOMA
public class Sintoma : MonoBehaviour 
{
    private ControlaAudio ControlaAudio_R;
    private GameManager GameManager_R;
    private ControlaPaineis ControlaPaineis_R;
    private Contador Contador_R;

    // CONTROLE DE VIDA
    private int ValorAtual = 3, Dano = 1, Energia = 1;    //VALOR TOTAL DA VIDA, VALOR QUANDO LEVA DANO, VALOR QUANDO RECUPERA VIDA
    public GameObject estado1, estado2, estado3, estado4;

    public void Start() {
        //RECUPERAÇÃO DAS CLASSES
        ControlaAudio_R = ControlaAudio.Instance();
        GameManager_R = GameManager.Instance();
        ControlaPaineis_R = ControlaPaineis.Instance();
        Contador_R = Contador.Instance();
        AtualizaValores();
    }
    // ============================ COLISÕES ================================= \\
    //COLISÃO COM INIMIGO
    public void OnCollisionEnter2D(Collision2D Dano)                        //TOMOU DANO
    {
        if (Dano.gameObject.CompareTag("Inimigo"))              
        {
            // DESTROI O OBJETO E PERDE VIDA
            Destroy(Dano.gameObject);                       //DESTROI O INIMIGO QUANDO TOCA
            VidaPerde();                                    //CHAMA O METODO 'VidaPerde'

            // EMITE SOM E CONTA TOQUES NO BARBEIRO
            ControlaAudio_R.PlaySom(1);              // Gerenciador de Áudio
            //Contador_R.BarbeiroTocou();
        }
    }

    //COLISÃO COM REMÉDIO
    public void OnTriggerEnter2D(Collider2D Vida)                         //GANHA VIDA AO PASSAR NA BARRACA
    {
        if (Vida.gameObject.CompareTag("Vida"))
        {
            VidaGanha();                                    //CHAMA O METODO 'VidaGanha'
            Destroy(Vida.gameObject);                       //DESTROI A CURA
        }
    }

    // ========================= GERENCIA DE VIDA ========================== \\
    //MÉTODO QUE FAZ PERDER VIDA
    public void VidaPerde()
    {
        if (ValorAtual >= 0)
        {
            ValorAtual -= Dano;
            EstadoSaude();                                  //CHAMA O MÉTODO 'EstadoSaúde' PARA VALIDAR 
        }
        AtualizaValores();
    }

    //MÉTODO QUE FAZ GANHARR VIDA
    public void VidaGanha()
    {
        if (ValorAtual < 3)
        {
            ValorAtual += Energia;
            EstadoSaude();                                  //CHAMA O MÉTODO 'EstadoSaúde' PARA VALIDAR 
        }
        AtualizaValores();
    }

    public void AtualizaValores()
    {
        GameManager_R.vida = ValorAtual;
        //GameManager_R.dano = apanhou;
    }

    // ========================== ESCREVE NA TELA =========================== \\
    //MÉTODO QUE VERIFICA O ESTADO DE SAÚDE PARA ESCREVER NA TELA
    public void EstadoSaude()                               //DIFINE TODOS OS ESTADOS E O QUE ACONTECE NELES
    {
        if (ValorAtual == 3)
        {
            GameManager_R.vida = 3; 
            estado1.gameObject.SetActive(true);
            estado2.gameObject.SetActive(false);
            estado3.gameObject.SetActive(false);
            estado4.gameObject.SetActive(false);
        }

        if (ValorAtual == 2)
        {
            GameManager_R.vida = 2;
            estado1.gameObject.SetActive(false);
            estado2.gameObject.SetActive(true);
            estado3.gameObject.SetActive(false);
            estado4.gameObject.SetActive(false);
        }

        if (ValorAtual == 1)
        {
            GameManager_R.vida = 1;
            estado1.gameObject.SetActive(false);
            estado2.gameObject.SetActive(false);
            estado3.gameObject.SetActive(true);
            estado4.gameObject.SetActive(false);
        }

        if (ValorAtual == 0)
        {
            GameManager_R.vida = 0;
            ControlaPaineis_R.GameOverUI();
            estado1.gameObject.SetActive(false);
            estado2.gameObject.SetActive(false);
            estado3.gameObject.SetActive(false);
            estado4.gameObject.SetActive(true);
        }
    }
}
