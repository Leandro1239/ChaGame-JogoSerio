using UnityEngine;

public class Nivel1 : MonoBehaviour
{
    private ControlaPaineis ControlaPaineis_R;
    private GameManager GameManager_R;
    //public static Nivel1 instance;                     //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES            
    public int acaiDesseNivel;

    //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 
    void Start()
    {
        //instance = this;
        ControlaPaineis_R = ControlaPaineis.Instance();
        GameManager_R = GameManager.Instance();
    }

    //FICA SEMPRE VERIFICANDO MUDANÇA NA VARIAVEL 'AcaiFase' e atribuindo a 'AcaiDesseNivel'
    public void Update()
    {
        acaiDesseNivel = GameManager_R.coletaFase;
    }

    //VERIFICA COLISÃO COM O PLAYER 
    public void OnCollisionEnter2D(Collision2D Pass)
    {
        if (Pass.gameObject.CompareTag("Player"))
        {
            ControlaPaineis_R.PassLevelUI();
            GameManager_R.passou1 = 1; 
        }
    }
}
