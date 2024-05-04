using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider sliderHP;
    public Slider sliderMP;

    public void SetMaxHealth(int health)
    {
        sliderHP.maxValue = health;
        sliderHP.value = health;
    }

    public void SetMaxMana(int mana)
    {
        sliderMP.maxValue = mana;
        sliderMP.value = mana;
    }

    public void SetHealth(int health)
    {
        sliderHP.value = health;
    }

    public void SetMana(int mana)
    {
        sliderMP.value = mana;
    }
}
