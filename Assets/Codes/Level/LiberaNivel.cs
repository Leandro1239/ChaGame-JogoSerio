using UnityEngine;
using UnityEngine.UI;

public class LiberaNivel : MonoBehaviour
{
    private GameManager GameManager_R;
    // VARIAVEIS PARA COLOCAR OS BUTOES E PARA SIMBOLIZAR A PASSAGEM DE NIVEL
    public Button Level2, Level3, Level4, Level5;
    public int Passou1, Passou2, Passou3, Passou4, Passou5;

    // RECONHECE A VARIÁVEL DE CADA CÓDIGO
    public void Start()
    {
        GameManager_R = GameManager.Instance();
        AtualizaSave();
    }

    private void Awake()
    {
        // TIRAR DOS COMENTÁRIOS PARA RESETAR OS SAFES
       // Salva1(0); Salva2(0); Salva3(0); Salva4(0);
       // Passou1 = 0; Passou2 = 0; Passou3 = 0; Passou4 = 0; Passou5 = 0;
    }
    // VERIFICA SE JÁ PASSOU DE FASE

    private void Update()
    {
        AtualizaSave();
        // VERIFICA EM CADA CÓDIGO SE PASSOU OU NÃO
        Passou1 = GameManager_R.passou1; 
        Passou2 = GameManager_R.passou2; 
        Passou3 = GameManager_R.passou3; 
        Passou4 = GameManager_R.passou4; 
        Passou5 = GameManager_R.passou5;

        // =========== CONDIÇÃO PARA LIBERAR OS NIVEIS ============ \\
        if (Passou1 == 1)
        {
            Level2.interactable = true;
            Salva1(Passou1);
        }

        if (Passou2 == 1)
        {
            Level3.interactable = true;
            Salva2(Passou2);
        }

        if (Passou3 == 1)
        {
            Level4.interactable = true;
            Salva3(Passou3);
        }

        if (Passou4 == 1)
        {
            Level5.interactable = true;
            Salva4(Passou4);
        }
    }

    // ================= SALVA OS VALORES EM CHAVES ================== \\
    public void Salva1(int valor)
    {
        PlayerPrefs.SetInt("Passa1", Passou1);
    }
    public void Salva2(int valor2)
    {
        PlayerPrefs.SetInt("Passa2", Passou2);
    }
    public void Salva3(int valor3)
    {
        PlayerPrefs.SetInt("Passa3", Passou3);
    }
    public void Salva4(int valor4)
    {
        PlayerPrefs.SetInt("Passa4", Passou4);
    }
    
    // ATUALIZA OS VALORES DAS CHAVES
    public void AtualizaSave()
    {
        if (PlayerPrefs.HasKey("Passa1")) { 
            Passou1 = PlayerPrefs.GetInt("Passa1");
            if (Passou1 == 1)
                PlayerPrefs.SetInt("Passa1", Passou1);
            else
            {
                Passou1 = 0;
                PlayerPrefs.SetInt("Passa1", Passou1);
                Level2.interactable = false;
            }    
        }

        if (PlayerPrefs.HasKey("Passa2")) {
            Passou2 = PlayerPrefs.GetInt("Passa2");
            if (Passou2 == 1)
                PlayerPrefs.SetInt("Passa2", Passou2);
            else
            {
                Passou2 = 0;
                PlayerPrefs.SetInt("Passa2", Passou2);
                Level3.interactable = false;
            }
        }

        if (PlayerPrefs.HasKey("Passa3"))
        {
            Passou3 = PlayerPrefs.GetInt("Passa3");
            if (Passou3 == 1)
                PlayerPrefs.SetInt("Passa3", Passou3);
            else
            {
                Passou3 = 0;
                PlayerPrefs.SetInt("Passa3", Passou3);
                Level4.interactable = false;
            }
        }

        if (PlayerPrefs.HasKey("Passa4"))
        {
            Passou4 = PlayerPrefs.GetInt("Passa4");
            if (Passou4 == 1)
                PlayerPrefs.SetInt("Passa4", Passou4);
            else
            {
                Passou4 = 0;
                PlayerPrefs.SetInt("Passa4", Passou4);
                Level5.interactable = false;
            }
        }
    }
}
