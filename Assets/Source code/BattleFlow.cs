using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleFlow : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gamewinUI;
    public PlayerHealth playerHealth;
    public GameObject bgMusic;
    void Start()
    {
        gameOverUI.SetActive(false);
        gamewinUI.SetActive(false);
        playerHealth.onDead += OnGameOver;
    }

    // Update is called once per frame
 private void OnGameOver()
    {
        gameOverUI.SetActive(true);
            bgMusic.SetActive(false);
    }
    private void Update()
    {
        if (EnemyHealth.LivingEnemyCount <= 0)
        {
            OnGameWin();
        }
    }
    private void OnGameWin()
    {
        gamewinUI.SetActive(true);
        bgMusic.SetActive(false);
        playerHealth.gameObject.SetActive(false);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}
