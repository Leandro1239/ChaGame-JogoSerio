using UnityEngine;
using DFTGames.Localization;

public class Tradutor : MonoBehaviour
{
    // ===== TORNA A CLASSE VISÍVEL PARA OUTRAS ===== //
    public static Tradutor Tradutor_R;

    public static Tradutor Instance(){
        if(!Tradutor_R){
            Tradutor_R = FindObjectOfType(typeof(Tradutor)) as Tradutor;
            if(!Tradutor_R)
                Debug.LogError("Não Achou o código");
        }
        return Tradutor_R;
    }
    // ===== INICIO DO CÓDIGO ===== \\

    private GameManager GameManager_R; 
    public int lingua;

    #region Public Methods

    private void Start() {
        GameManager_R = GameManager.Instance();
    }
    // VERIFICA QUAL A ULTIMA TRADUÇÃO UTILIZADA
    private void Update() 
    {
        AtualizaLinguagem();
        GameManager_R.linguagem = lingua;
    }
    
    // SALVA O ESTADO DA MUSICA
    public void Salva(int idioma)
    {
        PlayerPrefs.SetInt("GuardaIdioma", idioma);
    }

    //VERIFICA SE TEM ALGO SALVO NA CHAVE 'EstadoSom'
    public void AtualizaLinguagem()
    {
        if (PlayerPrefs.HasKey("GuardaIdioma"))                
        {
            lingua = PlayerPrefs.GetInt("GuardaIdioma");
            AtualizaIdioma();                            
        }

        else {
            lingua = 0;
            AtualizaIdioma();
            Salva(lingua);
        }       
    }

    // FAZ A TROCA DA LINGUAGEM DEPENDENDO DA ESCOLHA E DESATIVA O BOTAO DA LINGUA ESCOLHIDA
    private void AtualizaIdioma() {
        if (lingua == 0)
            SetPortuguese();
        if (lingua == 1)
            SetEnglish();
    }
    
    // SELECIONA UMA LINGUA, TROCA DE ESTADO E SALVA
    public void Ingles()
    {
        lingua = 1;
        GameManager_R.linguagem = 1;
        AtualizaIdioma();
        Salva(lingua);
    }

    // SELECIONA UMA LINGUA, TROCA DE ESTADO E SALVA
    public void Portugues()
    {
        lingua = 0;
        GameManager_R.linguagem = 0;
        AtualizaIdioma();
        Salva(lingua);
    }

    // SETA A LINGUAGEM
    public void SetEnglish()
    {
        Localize.SetCurrentLanguage(SystemLanguage.English);
        LocalizeImage.SetCurrentLanguage();
    }

    // SETA A LINGUAGEM
    public void SetPortuguese()
    {
        Localize.SetCurrentLanguage(SystemLanguage.Portuguese);
        LocalizeImage.SetCurrentLanguage();
    }
    #endregion Public Methods
}
