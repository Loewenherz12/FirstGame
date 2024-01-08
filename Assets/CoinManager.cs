using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int geld;
    public TextMeshProUGUI money; // Verwende TextMeshProUGUI für TMP-Text

    // Start is called before the first frame update
    void Start()
    {
        geld = PlayerPrefs.GetInt("Money", 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Aktualisiere den Text des TMP-Text-Objekts
        money.text = PlayerPrefs.GetInt("Money", 0).ToString();
    }

    public void Addmoney()
    {
        geld++;
        PlayerPrefs.SetInt("Money", geld);
    }
    
}
