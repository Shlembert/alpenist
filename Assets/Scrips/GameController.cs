using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Target tg;
    [SerializeField] private GameObject windowRestart;
    [SerializeField] private Slider slHeight;
    [SerializeField] private Slider slDistance;
    [SerializeField] private Text coinsTxt;
    [SerializeField] private GameObject danger;
    public int coins;

    private void Start()
    {
        windowRestart.SetActive(false);
        danger.SetActive(false);
        Time.timeScale = 1;
        coins = 0;
    }

    private void Update()
    {
        slHeight.value = tg.transform.position.y;
        slDistance.value = tg.dist;
        coinsTxt.text = coins.ToString();

        if (tg.gap) windowRestart.SetActive(true);

        if (tg.dist > 3.5f) danger.SetActive(true);
        else danger.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
    }
}
