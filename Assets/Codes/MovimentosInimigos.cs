using UnityEngine;

//FAZ A MOVIMENTAÇÃO DO INIMIGO
public class MovimentosInimigos : MonoBehaviour
{
    //VARIÁVEIS
    private float velMove = 3f;
    private Rigidbody2D rb;
    private bool moveE = true;
    public Transform limite;
    
    //INICIA
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(12, 12);                   //IGNORA COLISÃO ENTRE OBJETOS COM MESMA LAYER
    }

    // VERIFICA A MOVIMENTAÇÃO
    void Update()
    {
        if (moveE)
            rb.velocity = new Vector2(-velMove, rb.velocity.y);
        else
            rb.velocity = new Vector2(velMove, rb.velocity.y);
        VerificaChao();
    }

    // VERIFICA SE TEM CHÃO, SE NÃO TIVER ELE VIRA
    void VerificaChao()
    {
        if (!Physics2D.Raycast(limite.position, Vector2.down, 2f))
            Flip();
    }

    // VERIFICA SE TEM BARREIRA
    public void OnTriggerEnter2D(Collider2D Volta)
    {
        if (Volta.gameObject.CompareTag("VoltaBarbeiro"))
        {
            Flip();
        }
    }

    //MÉTODO QUE FAZ VIRAR
    void Flip()
    {
        moveE = !moveE;
        Vector3 temp = transform.localScale;

        if (moveE)
            temp.x = Mathf.Abs(temp.x);
        else
            temp.x = - Mathf.Abs(temp.x);
        transform.localScale = temp;
    }
}
