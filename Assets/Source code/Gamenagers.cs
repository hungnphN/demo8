using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamenagers : MonoBehaviour
{
    public float surviveTime = 60f;
    public GameObject gamewinUI;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Wingame), surviveTime);
    }

    // Update is called once per frame
    void Wingame()
    {
        gamewinUI.SetActive(true);
        Time.timeScale = 0;
    }
}
