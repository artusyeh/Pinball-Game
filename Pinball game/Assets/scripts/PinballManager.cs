using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PinballManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject ballObj;

    int score = 0;
    Vector3 ballStartPos;

    void Start()
    {
        ballStartPos = ballObj.transform.position;

        //Always start fresh when scene loads
        score = 0;
        UpdateScoreText();
    }

    public void AddScore()
    {
        score += 100;
        UpdateScoreText();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
            //Reset score when player dies
            score = 0;
            PlayerPrefs.SetInt("Score", 0);

            //Reload scene
            SceneManager.LoadScene("MainGame");
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
