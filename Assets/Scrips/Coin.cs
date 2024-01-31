using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameController gc;
    [SerializeField] private GameObject salut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Draggable")
        {
            Instantiate(salut, transform.position, Quaternion.identity);
            GameObject.Destroy(gameObject);
            gc.coins++;
        }
    }
}
