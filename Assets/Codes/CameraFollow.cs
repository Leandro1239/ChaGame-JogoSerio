using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    // Cria o jogador e a posição a ser seguida
    private GameObject player; 
    private Transform posicao;
    public int posY = 8, posZ = 0;

    // ACHA O JOGADOR E O CHEGACHAO PARA PODER SEGUIR
    public void Update() {
        player = GameObject.Find("Jogador");
        posicao = player.transform.Find("ChecaChão");
        transform.position = new Vector3(posicao.position.x, posY, posZ);     // SEGUE SOMENTE NO EIXO X            
    }
}
