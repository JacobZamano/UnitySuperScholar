using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public TMP_Text coinText;
    public int currentCoins = 0;

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Dollars: " + currentCoins.ToString();
    }

    void Awake()
    {
        instance = this;
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = "Dollars: " + currentCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
