using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class CollectCoin : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    public PlayerController playerController;
    public GameObject panel;
    public int maxscore;
    public Animator PlayerAnim;
    public GameObject Player;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (score >= PlayerPrefs.GetInt("hScore"))
        {
            PlayerPrefs.SetInt("hScore", score);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("End"))
        {            
            PlayerFinished();
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
            highScoreText.text = PlayerPrefs.GetInt("hScore").ToString();
            panel.SetActive(true);
            if (score >= maxscore)
            {
                PlayerAnim.SetBool("win", true);
            }
            else
            {
                PlayerAnim.SetBool("lose", true);
            }
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void PlayerFinished()
    {
        playerController.runningSpeed = 0f;
    }
    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();
    }

}
