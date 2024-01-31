using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GameObject star;
    [SerializeField] private GameObject winPanel;

    private void Start()
    {
        star.SetActive(false);
        winPanel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            star.SetActive(true);
            winPanel.SetActive(true);
        }
    }
}
