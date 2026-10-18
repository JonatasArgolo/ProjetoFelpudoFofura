
using UnityEngine;

public class MoveFelpudo : MonoBehaviour
{
    public Transform forura;
    public float velocidade = 1.5f;

    private bool podeMover = true;

    void Update()
    {
        if (!podeMover || forura == null)
            return;

        Vector3 destino = new Vector3(
            forura.position.x,
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
