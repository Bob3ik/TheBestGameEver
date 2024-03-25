using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    [SerializeField] private RectTransform _experienceValueRectTransform;
    [SerializeField] private TextMeshProUGUI _levelValueTMP;

    [SerializeField] private List<PlayerProgressLevel> _levels;

    private int _levelValue = 1;

    private float _experienceCurrentValue = 0f;
    private float _experienceTargetValue = 100f;

    private void Start()
    {
        SetLevel(_levelValue);
        DrawUI();
    }

    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if (_experienceCurrentValue >= _experienceTargetValue)
        {
            SetLevel(_levelValue++);
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }

    private void SetLevel(int value)
    {
        _levelValue = value;

        var currentLevel = _levels[_levelValue--];
        _experienceTargetValue = currentLevel.ExperienceForTheNextLevel;
        GetComponent<FireballCaster>().Damage = currentLevel.FireballDamage;
        GetComponent<GrenadeCaster>().Damage = currentLevel.GrenadeDamage;

        var grenadeCaster = GetComponent<GrenadeCaster>();
        grenadeCaster.Damage = currentLevel.GrenadeDamage;

        if (currentLevel.GrenadeDamage < 0)
            grenadeCaster.enabled = false;
        else
            grenadeCaster.enabled = true;
    }

    private void DrawUI()
    {
        _experienceValueRectTransform.anchorMax = new Vector2(_experienceCurrentValue / _experienceTargetValue, 1f);
        _levelValueTMP.text = _levelValue.ToString();
    }
}
