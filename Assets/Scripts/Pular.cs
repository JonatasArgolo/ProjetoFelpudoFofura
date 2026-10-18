
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PularCarnaval : MonoBehaviour
{
    public float forcaPulo = 5f;
    public float intervaloPulo = 1.2f;

    public ParticleSystem confetes;
    public int qtdConfetes = 3;
    private Rigidbody2D rb;
    private float tempoProximoPulo;
    private bool noChao;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        tempoProximoPulo = Time.time + intervaloPulo;
    }


    void Update()
    {
        if (Time.time >= tempoProximoPulo && noChao)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                forcaPulo
            );

            noChao = false;
            tempoProximoPulo = Time.time + intervaloPulo;

            // Emitir confetes apenas quando pular
            if (confetes != null && qtdConfetes > 0)
            {
                confetes.transform.position =
                    transform.position + Vector3.up * 0.8f;

                confetes.Emit(qtdConfetes);

                Debug.Log("Confetes emitidos: " + qtdConfetes);
            }
        }
    }



    void OnCollisionStay2D(Collision2D colisao)
    {
        if (colisao.gameObject.name == "chao")
        {
            foreach (ContactPoint2D contato in colisao.contacts)
            {
                if (contato.normal.y > 0.5f)
                {
                    noChao = true;
                    break;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D colisao)
    {
        if (colisao.gameObject.name == "chao")
        {
            noChao = false;
        }
    }
}
