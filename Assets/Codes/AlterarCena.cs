// BIBLIOTECAS
using UnityEngine;
using UnityEngine.SceneManagement;


// FAZ MÉTODOS DE TROCAR DE CENÁRIO
public class AlterarCena : MonoBehaviour //Troca de cenário de acordo com o número somado
{            
    public static AlterarCena instance;
    private Contador Contador_R;
    private ControlaAudio ControlaAudio_R;

    private void Start() {
        Contador_R = Contador.Instance();
        ControlaAudio_R = ControlaAudio.Instance();
    }

    // ========================== VOLTAR ================================== \\
    public void Voltar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
    }

    public void Voltar2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Time.timeScale = 1;
    }

    public void Voltar3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        Time.timeScale = 1;
    }

    public void Voltar4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        Time.timeScale = 1;
    }

    public void Voltar5()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
        Time.timeScale = 1;
    }

    public void Voltar6()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6);
        Time.timeScale = 1;
    }

    // ========================== AVANÇAR ================================== \\
    public void Avançar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void Avançar2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        Time.timeScale = 1;
    }

    public void Avançar3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        Time.timeScale = 1;
    }

    public void Avançar4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        Time.timeScale = 1;
    }

    public void Avançar5()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
        Time.timeScale = 1;
    }


    //FECHA O JOGO
    public void Sair ()             
    {
        Application.Quit();
    }

    //RECARREGA A CENA
    public void Repetir()           
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SomClick()
    {
        ControlaAudio_R.ClickSom();
    }
}
