using UnityEngine.UI;
using UnityEngine;

public class ControlaPontosWin5 : MonoBehaviour
{
    private GameManager GameManager_R;

    public int life, pontos;
    public Text coleta;
    public GameObject estrela1, estrela2, estrela3;
    public GameObject estadoWin1, estadoWin2, estadoWin3;
    public GameObject pontosA, pontosB, pontosC;
    void Start()
    {
        GameManager_R = GameManager.Instance();
    }

    void Update()
    {
        life = GameManager_R.vida;
        pontos = GameManager_R.coletaFase;

        if (GameManager_R.passou5 == 1)
        {
            coleta.text = pontos.ToString();

            if (pontos == 10 && life == 3)
            {
                estrela1.gameObject.SetActive(true);
                estrela2.gameObject.SetActive(true);
                estrela3.gameObject.SetActive(true);
                pontosA.gameObject.SetActive(true);
                pontosB.gameObject.SetActive(false);
                pontosC.gameObject.SetActive(false);
            }

            if (pontos < 10 && pontos >= 5 && life <= 3)
            {
                estrela1.gameObject.SetActive(true);
                estrela2.gameObject.SetActive(true);
                estrela3.gameObject.SetActive(false);
                pontosA.gameObject.SetActive(false);
                pontosB.gameObject.SetActive(true);
                pontosC.gameObject.SetActive(false);
            }

            if (pontos >= 1 && life <= 3)
            {
                estrela1.gameObject.SetActive(true);
                estrela2.gameObject.SetActive(false);
                estrela3.gameObject.SetActive(false);
                pontosA.gameObject.SetActive(false);
                pontosB.gameObject.SetActive(false);
                pontosC.gameObject.SetActive(true);
            }

            if (life == 3)
            {
                estadoWin1.gameObject.SetActive(true);
                estadoWin2.gameObject.SetActive(false);
                estadoWin3.gameObject.SetActive(false);
            }

            if (life == 2)
            {
                estadoWin1.gameObject.SetActive(false);
                estadoWin2.gameObject.SetActive(true);
                estadoWin3.gameObject.SetActive(false);
            }

            if (life == 1)
            {
                estadoWin1.gameObject.SetActive(false);
                estadoWin2.gameObject.SetActive(false);
                estadoWin3.gameObject.SetActive(true);
            }
        }
    }
}
