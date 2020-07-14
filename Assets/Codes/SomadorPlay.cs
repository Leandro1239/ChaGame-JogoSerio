using UnityEngine.UI;
using UnityEngine;

public class SomadorPlay : MonoBehaviour
{
    private Contador Contador_R;

    public int playTotal;                              // AÇAI

    public void Start()
    {
        //RECUPERAÇÃO DAS CLASSES
        Contador_R = Contador.Instance();

        playTotal = Contador_R.jogadas;
    }
    private void Update()
    {
        Contador_R.jogadas = playTotal;
    }

    public void SomaJogou()
    {
        playTotal += 1;
    }

    public void VerRecorde()
    {
        Contador_R.Recordes();
    }
}
