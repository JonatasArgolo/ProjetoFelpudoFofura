
using UnityEngine;

public class PararNoEncontro : MonoBehaviour
{
    public ParticleSystem coracoes;
    public Transform forura;

    public float distanciaEncontro = 3f;
    public int quantidadeCoracoes = 20;

    private bool jaEncontraram = false;

    void Update()
    {
        if (jaEncontraram || forura == null)
            return;

        float distancia = Vector2.Distance(
            transform.position,
            forura.position
        );

        if (distancia <= distanciaEncontro)
        {
            jaEncontraram = true;

            Debug.Log("Felpudo e Forura se encontraram!");

            // Parar Felpudo
            MoveFelpudo felpudo =
                GetComponent<MoveFelpudo>();

            if (felpudo != null)
                felpudo.Parar();

            // Parar Forura
            MoveForura movimentoForura =
                forura.GetComponent<MoveForura>();

            if (movimentoForura != null)
                movimentoForura.Parar();

            // Zerar velocidade horizontal
            PararMovimento(GetComponent<Rigidbody2D>());
            PararMovimento(forura.GetComponent<Rigidbody2D>());

            // Emitir coracoes
            if (coracoes != null)
            {
                Vector3 posicao =
                    (transform.position + forura.position) / 2f;

                posicao.z = 0f;
                posicao.y += 1.5f;

                coracoes.transform.position = posicao;
                coracoes.Emit(quantidadeCoracoes);

                Debug.Log("Coracoes emitidos!");
            }
        }
    }

    void PararMovimento(Rigidbody2D rb)
    {
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(
                0f,
                rb.linearVelocity.y
            );
        }
    }
}
