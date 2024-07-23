using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    [SerializeField] ThrowBall ThrowBall;
    [SerializeField] DrawLine DrawLine;

  
    [SerializeField] private ParticleSystem crucibleEnter;
    [SerializeField] private ParticleSystem BestScorePass;
    [SerializeField] private AudioSource[] Sounds;

    
    [SerializeField] private GameObject[] Panels;
    [SerializeField] private TextMeshProUGUI[] ScoreTexts;

    int BallCount;

    void Start()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            ScoreTexts[0].text = PlayerPrefs.GetInt("BestScore").ToString();
            ScoreTexts[1].text = PlayerPrefs.GetInt("BestScore").ToString();
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", 0);
            ScoreTexts[0].text = "0";
            ScoreTexts[1].text = "0";
        }
    }
    public void Continue(Vector2 Pos)
    {
        crucibleEnter.transform.position = Pos;
        crucibleEnter.gameObject.SetActive(true);
        crucibleEnter.Play();

        BallCount++;
        Sounds[0].Play();
        ThrowBall.Continue();
        DrawLine.Continue();
    }

    public void GameOver()
    {
        Sounds[1].Play();
        Panels[1].SetActive(true);
        Panels[2].SetActive(false);

        ScoreTexts[1].text = PlayerPrefs.GetInt("BestScore").ToString();
        ScoreTexts[2].text = BallCount.ToString();

        if (BallCount > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", BallCount);
            BestScorePass.gameObject.SetActive(true);
            BestScorePass.Play();
        }

        ThrowBall.StopThrowBall();
        DrawLine.StopDrawLine();
    }

    public void StartGame()
    {
        Panels[0].SetActive(false);
        ThrowBall.StartGame();
        DrawLine.StartDrawLine();
        Panels[2].SetActive(true);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
