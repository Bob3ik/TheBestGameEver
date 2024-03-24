using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private RectTransform _valueRectTransform;
    [SerializeField] private Animator _animator;

    [SerializeField] private GameObject _gameplayUI;
    [SerializeField] private GameObject _gameOverScreen;

    [SerializeField] public float Value;
    [SerializeField] private float _maxValue;

    private void Start()
    {
        _maxValue = Value;
        DrawHealthBar();
    }

    public void DeadDamage(float damage)
    {
        Value -= damage;
        if (Value <= 0)
        {
            _gameplayUI.SetActive(false);
            _gameOverScreen.SetActive(true);

            GetComponent<PlayerController>().enabled = false;
            GetComponent<FireballCaster>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;

            _animator.SetTrigger("death");
        }

        DrawHealthBar();
    }

    public void AddHealth(float amount)
    {
        Value += amount;
        Value = Mathf.Clamp(Value, 0, _maxValue);

        DrawHealthBar();
    }

    private void DrawHealthBar()
    {
        _valueRectTransform.anchorMax = new Vector2(Value / _maxValue, 1f);
    }
}
