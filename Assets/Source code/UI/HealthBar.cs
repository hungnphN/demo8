using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public RectTransform mask;
    public Health health;
    private float originalWidth;
    void Start()
    {
        originalWidth = mask.sizeDelta.x;
        UpdateHealthValue();
        health.onHealthChanged += UpdateHealthValue;
    }
    private void UpdateHealthValue()
    {
        if(this == null || mask == null || health == null) return;
        float scale = (float)health.healthPoint / health.defaultHealthPoint;
        mask.sizeDelta = new Vector2(scale * originalWidth, mask.sizeDelta.y);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
