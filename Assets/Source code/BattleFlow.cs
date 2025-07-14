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
    public float surviveTime = 15f;
    public bool hasWon = false;
    void Start()
    {
        gameOverUI.SetActive(false);
        gamewinUI.SetActive(false);
        if (playerHealth != null)
        playerHealth.onDead += OnGameOver;
        Invoke(nameof(OnGameWin), surviveTime);
    }

    // Update is called once per frame
 private void OnGameOver()
    {
        if (hasWon) return;
        gameOverUI.SetActive(true);
            bgMusic.SetActive(false);
    }
    //private void Update()
    //{
    //    if (EnemyHealth.LivingEnemyCount <= 0)
    //    {
    //        OnGameWin();
    //    }
    //}
    public void OnGameWin()
    {
        if (hasWon) return;
        hasWon = true;
        gamewinUI.SetActive(true);
        bgMusic.SetActive(false);
        playerHealth.gameObject.SetActive(false);
    }
    public void OnbossDead()
    {
        Debug.Log("Boss is dead , you win");
        gamewinUI.SetActive(true);
        bgMusic.SetActive(false);
        playerHealth.gameObject.SetActive(false);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}
