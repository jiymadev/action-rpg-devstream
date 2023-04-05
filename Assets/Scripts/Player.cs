using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterAttributes))]
public class Player : MonoBehaviour
{
    CharacterAttributes _attributes;

    [SerializeField]
    int _healthMax, _healthCurrent;

    [SerializeField]
    int _manaMax, _manaCurrent;
    float _manaRegen;

    [SerializeField]
    int _staminaMax, _staminaCurrent;
    float _staminaRegen;

    float _staminaTimer, _manaTimer, _healthTimer;

    public int Health 
    {
        get 
        {
            return _healthCurrent;
        }
        private set 
        {
            if(value > _healthMax) value = _healthMax;
            if(value < 0) value = 0;

            _healthCurrent = value;
        }
    }

    public int Mana 
    {
        get 
        {
            return _manaCurrent;
        }
        private set 
        {
            if(value > _manaMax) value = _manaMax;
            if(value < 0) value = 0;
            _manaCurrent = value;
        }
    }

    public int Stamina 
    {
        get 
        {
            return _staminaCurrent;
        }
        private set 
        {
            if(value > _staminaMax) value = _staminaMax;
            if(value < 0) value = 0;
            _staminaCurrent = value;
        }
    }

    public void Start() 
    {
        GetComponents();
        CalculateMaxes();
        ResetStats();
        CalculateRegens();
    }

    public void Update() 
    {
        RegenStats();
    }

    public void AdjustHealth(int amount) 
    {
        if(amount == 0) return;
        if(amount > 0) ReactHeal(amount);
        if(amount < 0) ReactDamage(amount);
        Health += amount;
    }

    private void ReactHeal(int amount) 
    {

    }

    private void ReactDamage(int amount)
    {

    }

    private void GetComponents() 
    {
        _attributes = GetComponent<CharacterAttributes>();
    }

    private void ResetStats()
    {
        _healthCurrent = _healthMax;
        _manaCurrent = _manaMax;
        _staminaCurrent = _staminaMax;
    }

    private void CalculateMaxes() 
    {
        _healthMax = 100 + _attributes.Con * 5;
        _manaMax = 100 + _attributes.Int * 5;
        _staminaMax = 100 + _attributes.Str * 5;
    }

    private void CalculateRegens()
    {
        _manaRegen = 1 + _attributes.Wis / 20f;
        _staminaRegen = 1 + _attributes.Dex / 20f;
    }

    private void RegenStats() 
    {
        if(_healthCurrent < _healthMax) RegenHealth();
        if(_manaCurrent < _manaMax) RegenMana();
        if(_staminaCurrent < _staminaMax) RegenStamina();
    }

    // Timer should tick once per second on 0 Dex
    // More than once per second on positive Dex
    // Less than once per second on negative Dex
    private void RegenStamina() 
    {
        _staminaTimer -= Time.deltaTime * _staminaRegen;

        // To account for float imprecision.
        if(_staminaTimer < Mathf.Epsilon)
        {
            Debug.Log("Stamina Tick");
            _staminaTimer = 1f;
            Stamina += 1;
        }
    }

    // Timer should tick once per second on 0 Wis
    // More than once per second on positive Wis
    // Less than once per second on negative Wis
    private void RegenMana() 
    {
        _manaTimer -= Time.deltaTime * _manaRegen;

        // To account for float imprecision.
        if(_manaTimer < Mathf.Epsilon)
        {
            Debug.Log("Mana Tick");
            _manaTimer = 1f;
            Mana += 1;
        }
    }

    // TODO: Increase health based on percentage
    private void RegenHealth()
    {
        _healthTimer -= Time.deltaTime;

        // To account for float imprecision.
        if(_healthTimer < Mathf.Epsilon)
        {
            Debug.Log("Health Tick");
            _healthTimer = 1f;
            Health += 1;
        }
    }

}
