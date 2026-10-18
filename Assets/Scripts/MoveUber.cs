
using UnityEngine;
using System.Collections;

public class MovimentoUber : MonoBehaviour
{
    public float velocidade = 3f;
    public float posicaoParadaX = 0f;

    public GameObject felpudo;
    public GameObject forura;

    public float tempoParaEntrar = 2f;
    public float tempoParaSair = 1f;
    public float posicaoFinalX = -12f;

    public GameObject telaFinal;

    private bool chegou = false;
    private bool indoEmbora = false;
    private bool terminou = false;

    void Update()
    {
        if (!chegou)
        {
            Vector3 posicao = transform.position;

            posicao.x = Mathf.MoveTowards(
                posicao.x,
                posicaoParadaX,
                velocidade * Time.deltaTime
            );

            transform.position = posicao;

            if (Mathf.Abs(transform.position.x - posicaoParadaX) < 0.01f)
            {
                chegou = true;
                StartCoroutine(EntrarNoUber());
            }
        }
        else if (indoEmbora && !terminou)
        {
            Vector3 posicao = transform.position;

            posicao.x = Mathf.MoveTowards(
                posicao.x,
                posicaoFinalX,
                velocidade * Time.deltaTime
            );

            transform.position = posicao;

            if (Mathf.Abs(transform.position.x - posicaoFinalX) < 0.01f)
            {
                terminou = true;
                indoEmbora = false;

                if (telaFinal != null)
                    telaFinal.SetActive(true);

                Debug.Log("Fim da historia!");
            }
        }
    }

    IEnumerator EntrarNoUber()
    {
        Debug.Log("O Uber chegou!");

        yield return new WaitForSeconds(tempoParaEntrar);

        if (felpudo != null)
            felpudo.SetActive(false);

        if (forura != null)
            forura.SetActive(false);

        Debug.Log("Felpudo e Forura entraram no Uber!");

        yield return new WaitForSeconds(tempoParaSair);

        indoEmbora = true;
    }
}
