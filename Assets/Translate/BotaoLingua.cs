using UnityEngine.UI;
using UnityEngine;

public class BotaoLingua : MonoBehaviour
{
    private GameManager GameManager_R; 
    private Tradutor Tradutor_R; 
    public Button PT, EN; 

    // Start is called before the first frame update
    void Start()
    {
        GameManager_R = GameManager.Instance();
        Tradutor_R = Tradutor.Instance();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager_R.linguagem == 0){
            EN.interactable = true;
            PT.interactable = false;
        }
        if (GameManager_R.linguagem  == 1){
            EN.interactable = false;
            PT.interactable = true;
        }
    }

    public void TrocaIngles(){
        Tradutor_R.Ingles();
    }

    public void TrocaPortugues(){
        Tradutor_R.Portugues();
    }
}
