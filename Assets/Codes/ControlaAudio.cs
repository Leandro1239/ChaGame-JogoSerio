// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaAudio : MonoBehaviour
{
    // ===== TORNA A CLASSE VISÍVEL PARA OUTRAS ===== //
    public static ControlaAudio ControlaAudio_R;

    public static ControlaAudio Instance(){
        if(!ControlaAudio_R){
            ControlaAudio_R = FindObjectOfType(typeof(ControlaAudio)) as ControlaAudio;
            if(!ControlaAudio_R){
                Debug.LogError("Não Achou o código");
            }
        }
        return ControlaAudio_R;
    }
    // ===== INICIO DO CÓDIGO ===== \\
    
    public int estadoAtual;
    
    // MÚSICAS
    public AudioClip[] clipsMusica;
    public AudioSource musicaBG;  

    // SONS
    public AudioClip[] clipsSons;
    public AudioSource sons;

    // CLICKS
    public AudioClip[] clipsClickSons;
    public AudioSource click;

    // OUTROS SONS
    public AudioClip[] clipsOutrosSons;
    public AudioSource outrosSons;

    // SALVA O ESTADO DA MUSICA
    public void Salva(int estado)
    {
        PlayerPrefs.SetInt("EstadoSom", estado);
    }

    //VERIFICA SE TEM ALGO SALVO NA CHAVE 'EstadoSom'
    public void AtualizaEstadoSom()
    {
        if (PlayerPrefs.HasKey("EstadoSom"))                
        {
            estadoAtual = PlayerPrefs.GetInt("EstadoSom");
            if (estadoAtual == 1)                  
                Liga();
            if (estadoAtual == 0)  
                Desliga();                               
        }

        else 
        {
            estadoAtual = 1;
            Liga();
        }
    }

    // ========================== METODOS DOS AUDIO ========================= \\
    // MUSICAS
    public void PlayMusica(int indexx)
    {
        musicaBG.clip = clipsMusica[indexx];
        musicaBG.Play();
    }

    // SONS
    public void PlaySom(int index){
        sons.clip = clipsSons[index];
        sons.Play ();
    }

    // CLICK
    public void PlayClick(int index)
    {
        click.clip = clipsClickSons[index];
        click.Play();
    }

    // OUTROS SONS
    public void PlayOutrosSons(int indexx)
    {
        outrosSons.clip = clipsOutrosSons[indexx];
        outrosSons.Play();
    }

    // LIGA O SOM
    public void Liga(){
        musicaBG.volume = 0.3f;
        sons.volume = 0.7f;
        outrosSons.volume = 0.8f;
        click.volume = 0.5f;
    }

    // DESLIGA O SOM
    public void Desliga(){
        musicaBG.volume = 0f;
        sons.volume = 0f;
        outrosSons.volume = 0f;
        click.volume = 0f;
    }

    public void Corre()
    {
        PlayOutrosSons(0);
    }

    public void NaoCorre()
    {
        PlayOutrosSons(1);
    }

    public void ClickSom()
    {
        PlayClick(0);
    }
}
