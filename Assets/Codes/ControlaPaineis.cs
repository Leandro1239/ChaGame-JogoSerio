using UnityEngine;

public class ControlaPaineis : MonoBehaviour
{
    // ===== TORNA A CLASSE VISÍVEL PARA OUTRAS ===== //
    public static ControlaPaineis ControlaPaineis_R;

    public static ControlaPaineis Instance(){
        if(!ControlaPaineis_R){
            ControlaPaineis_R = FindObjectOfType(typeof(ControlaPaineis)) as ControlaPaineis;
            if(!ControlaPaineis_R)
                Debug.LogError("Não Achou o código");
        }
        return ControlaPaineis_R;
    }
    // ===== INICIO DO CÓDIGO ===== \\

    public GameObject PainelLose, PainelWin, PainelPause, PainelTutorial, PainelColetaBoa, PainelPessoa;

    public void Start() 
    {
       // TutorialUI();
    }

    // ATIVA PAINEL DE LOSE E PAUSA O TEMPO ================= \\
    public void GameOverUI()
    {
        PainelLose.SetActive(true);
        //Time.timeScale = 0;
    }

    //ATIVA PAINEL DE PRÓXIMO NÍVEL E PAUSA O TEMPO ================= \\
    public void PassLevelUI()
    {
        PainelWin.SetActive(true);
        // Time.timeScale = 0;
    }
    // ================== ATIVA PAINEL DE PAUSE E PAUSA ================= \\
    public void PauseUI()
    {
        PainelPause.SetActive(true);
        Time.timeScale = 0;
    }

    // ================== DESATIVA PAINEL DE PAUSE E CONTINUA ================= \\
    public void ContinueUI()
    {
        Time.timeScale = 1;
    }

    // ================== ATIVA PAINEL DE TUTORIAL E PAUSA ================= \\
    public void TutorialUI()
    {
        PainelTutorial.SetActive(true);
        Time.timeScale = 0;
    }

    // ================== ATIVA PAINEL DE COLETA E PAUSA ================= \\
    public void ColetouAcaiBomUI(){
        PainelColetaBoa.SetActive(true);
        Time.timeScale = 0;
    }

    public void Pessoa()
    {
        PainelPessoa.SetActive(true);
        //Time.timeScale = 0;
    }
}
