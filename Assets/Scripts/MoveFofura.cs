
using UnityEngine;

public class MoveForura : MonoBehaviour
{
    public Transform felpudo;
    public float velocidade = 1.5f;

    private bool podeMover = true;

    void Update()
    {
        if (!podeMover || felpudo == null)
            return;

        Vector3 destino = new Vector3(
            felpudo.position.x,
            transform.position.y,
            transform.position.z
        );

        transform.position = Vector3.MoveTowards(
            transform.position,
            destino,
            velocidade * Time.deltaTime
        );
    }

    public void Parar()
    {
        podeMover = false;
    }
}
