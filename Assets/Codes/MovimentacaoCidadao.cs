using UnityEngine;

public class MovimentacaoCidadao : MonoBehaviour
{
    public GameObject cidadao;
    private int dir = -2, tocou;
    private bool olhandoPraDireita = true;                             //VERIFICA ORIENTAÇÃO   

    // GAME OBJECT QUE CHECA O CHÃO
    private bool noChao = false;
    private float raioChao = 0.5f;
    private Transform VeChao;
    public LayerMask oChao;
    public GameObject conversa;

    //INICIA
    void Start()
    {
        Physics2D.IgnoreLayerCollision(11, 11);                   //IGNORA COLISÃO ENTRE OBJETOS COM MESMA LAYER
    }

    // VERIFICA A MOVIMENTAÇÃO
    void Update()
    {
        if (noChao)
            cidadao.transform.Translate(new Vector3((dir) * Time.deltaTime, 0, 0));

        // VERIFICA DISTÂNCIA DO CHÃO
        VeChao = cidadao.transform.Find("VeChao");
        noChao = Physics2D.OverlapCircle(VeChao.position, raioChao, oChao);
    }

    public void OnTriggerEnter2D(Collider2D Coletar)
    {
        if (tocou == 0)
        {
            if (Coletar.gameObject.CompareTag("Player"))
            {
                conversa.SetActive(true);
                Time.timeScale = 0;
                dir = 2;                                                              //ADICIONA VELOCIDADE PARA A ESQUERDA
                olhandoPraDireita = !olhandoPraDireita;                                 //INVERTE A ORIENTAÇÃO
                Vector3 theScale = cidadao.transform.localScale;                        //PEGA O VALOR DA ESCALA
                theScale.x *= -1;                                                       //INVERTE A ESCALA
                cidadao.transform.localScale = theScale;                                //VALIDA 
                tocou = 1;
            }
        }       
    }
}
