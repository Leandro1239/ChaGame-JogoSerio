using UnityEngine;

public class CriaCidadao : MonoBehaviour
{
    public GameObject pessoa;
    public int vez = 1;
    void Start()
    {
        InvokeRepeating("CriadorCidadao", 4, 30);
    }

    void CriadorCidadao()
    {
        GameObject _pessoa = (GameObject)Instantiate(pessoa);
        switch (vez)
        {
            case 1:
                _pessoa.transform.position = new Vector3(31.8f, -4.4f, 100);
                vez = 2;
                break;
            case 2:
                _pessoa.transform.position = new Vector3(75.9f, -4.5f, 100);
                vez = 1;
                break;
        }
    }
}