// BIBLIOTECAS
using UnityEngine;

// TRATA A MOVIMENTAÇÃO DO PERSONAGEM
public class Movimentacao : MonoBehaviour
{
    private ControlaAudio ControlaAudio_R;
    private ControlaPaineis ControlaPaineis_R;
    private GameManager GameManager_R;

    //PLAYER
    public GameObject player;                                     //JOGADOR
    public Rigidbody2D playerPula;
    public Animator anime;
    public float tempoAtual, tempoFinal;

    // CONTROLE DE PULO E VELOCIDADE
    private int direcao = 0, controle;        //FORÇA DE PULO, VELOCIDADE DA CORRIDA, ORIENTAÇÃO NO EIXO X (direçao)
    private bool olhandodireita = true;                             //VERIFICA ORIENTAÇÃO   

    // GAME OBJECT QUE CHECA O CHÃO
    private bool noChao = false;
    private float raioChao = 0.5f;
    private Transform checaChao;
    public LayerMask oChao;
    public GameObject cuidado1, cuidado2;

    public void Start() {
        //RECUPERAÇÃO DAS CLASSES
        ControlaAudio_R = ControlaAudio.Instance();
        GameManager_R = GameManager.Instance();
        ControlaPaineis_R = ControlaPaineis.Instance();

        playerPula = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(10, 11);                   //IGNORA COLISÃO ENTRE OBJETOS COM MESMA LAYER
    }

    //MÉTODO QUE REPETE SEMPRE
    void Update()
    {
        // EstadoDeSaude();
        tempoAtual = Time.deltaTime;

        // MOVIMENTO
        player.transform.Translate(new Vector3((direcao * 7) * Time.deltaTime, 0, 0));
        
        // ATUALIZA VALORES PARA O GAME MANAGER
        GameManager_R.direcao = direcao;

        // ANIMAÇÃO
        anime = player.GetComponent<Animator>();

        // CONTROLE DAS ANIMAÇÕES
        if (direcao == 0 && noChao == true)
        {
            anime.SetBool("para", true);
            anime.SetBool("pula", false);
            anime.SetBool("corre", false);
        }

        if (direcao != 0 && noChao == true)
        {
            anime.SetBool("para", false);
            anime.SetBool("pula", false);
            anime.SetBool("corre", true);
        }

        //CONTROLANDO PELO TECLADO PARA TESTES
        if (Input.GetKeyDown(KeyCode.Space))
            Pula();

        // VERIFICA DISTÂNCIA DO CHÃO
        checaChao = player.transform.Find("ChecaChão");
        noChao = Physics2D.OverlapCircle(checaChao.position, raioChao, oChao);           // DEFINE O TAMANHO DO RAIO DO 'CHECACHAO'
    }

    public void OnTriggerEnter2D(Collider2D TriggerPessoa)
    {
        if (TriggerPessoa.gameObject.CompareTag("Pessoa"))
        {
            if (controle == 0)
            {
                ControlaPaineis_R.Pessoa();
                controle = 1;
            }
        }
    }

    // ====================== CONTROLE ======================= \\
    // GIRA O PERSONAGEM
    void Flip()
    {
        olhandodireita = !olhandodireita;                       //INVERTE A ORIENTAÇÃO
        Vector3 theScale = player.transform.localScale;                //PEGA O VALOR DA ESCALA
        theScale.x *= -1;                                       //INVERTE A ESCALA
        player.transform.localScale = theScale;                        //VALIDA
    }

    //VIRA PARA A DIREITA
    public void Direita()                                       
    {
        direcao = 1;                                            //ATRIBUI VALOR POSITIVO PARA ANDAR NO EIXO X
        ControlaAudio_R.Corre();
        if (direcao > 0 && olhandodireita == false)
            Flip();                                             //VERIFICA SE ESTÁ ANDANDO NA DIREÇÃO DO EIXO POSITIVO
    }

    //VIRA PARA A ESQUERDA
    public void Esquerda()                                      
    {
        direcao = -1;                                           //ATRIBUI VALOR NEGATIVO PARA ANDAR NO EIXO X
        ControlaAudio_R.Corre();
        if (direcao < 0 && olhandodireita == true)
            Flip();                                             //VERIFICA SE ESTÁ ANDANDO NA DIREÇÃO DO EIXO NEGATIVO
    }

    //PARA DE ANDAR
    public void Para()                                          
    {
        ControlaAudio_R.NaoCorre();
        direcao = 0;                                            //PARADO NO EIXO X
    }

    //SAI DO CHÃO
    public void Pula()
    {
        if (noChao == true)
        {
            noChao = false;
            anime.SetBool("para", false);
            anime.SetBool("pula", true);
            anime.SetBool("corre", false);
            playerPula.AddForce(new Vector2(0, 1200));
            ControlaAudio_R.PlaySom(2);                // Gerenciador de Áudio
        }
    }
}