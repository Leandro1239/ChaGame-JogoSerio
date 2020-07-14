using UnityEngine.UI;
using UnityEngine;

public class EncontraImgAudio : MonoBehaviour
{
    // REFERENCIA DA OUTRA CLASSE
    private ControlaAudio ControlaAudio_R;

    // VARIAVEIS DE IMAGEM E CONTROLE
    public Sprite ligado, desligado;
    public SpriteRenderer img;
    public int liga_Desliga;

    // INICIA INSTANCIANDO A OUTRA CLASSE E VENDO O ULTIMO ESTADO DO SOM
    private void Awake() 
    {
        ControlaAudio_R = ControlaAudio.Instance();
        ControlaAudio_R.AtualizaEstadoSom();
        liga_Desliga = ControlaAudio_R.estadoAtual;
        SpriteRenderer img = gameObject.GetComponent<SpriteRenderer>();
    }

    // A PARTIR DO ULTIMO ESTADO DO SOM, É LIGADO OU DESLIGADO A IMAGEM NO MENU
    private void Start() {
        if (liga_Desliga == 0)
            img.sprite = desligado;
        if (liga_Desliga == 1)
            img.sprite = ligado; 
    }

    // MÉTODO QUE LIGA E DESLIGA O SOM, ALTERA A IMAGEM E SALVA O ESTADO
    public void OnOffSom(){
        switch (liga_Desliga)
        {
            case 0: ControlaAudio_R.Salva(1);
                    ControlaAudio_R.Liga();
                    liga_Desliga = 1;
                    img.sprite = ligado;
                    break;

            case 1: ControlaAudio_R.Salva(0);
                    ControlaAudio_R.Desliga();
                    liga_Desliga = 0;
                    img.sprite = desligado;
                    break;
        }
    }
}
