using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI coinText; 
    public TMPro.TextMeshProUGUI healthText;
    public Slider healthSlider;


    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Collected Coins: 0 " ;
    }

    // Update is called once per frame
    void Update()
    {

    }

public void Restart(){

    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

}

public void UpdateCoinText(int Coins)
{
    coinText.text = "Collected Coins:" + Coins.ToString();

}
public void UpdateHealthText(int CurrentHealth, int MaxHealth)
{
    healthText.text = CurrentHealth + "/" + MaxHealth.ToString();

    float newCurrentHealth = (float) CurrentHealth / MaxHealth;
    healthSlider.value = newCurrentHealth;
}


}
