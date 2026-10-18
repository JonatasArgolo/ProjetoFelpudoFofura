
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TransicaoCena : MonoBehaviour
{
    public float tempoEspera = 5f;

    void Start()
    {
        StartCoroutine(MudarCena());
    }

    IEnumerator MudarCena()
    {
        yield return new WaitForSeconds(tempoEspera);

        int cenaAtual =
            SceneManager.GetActiveScene().buildIndex;

        int proximaCena = cenaAtual + 1;

        if (proximaCena < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(proximaCena);
        }
    }
}
