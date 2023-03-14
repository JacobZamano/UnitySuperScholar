using UnityEngine;
using UnityEngine.UI;

public class GoldCoin : MonoBehaviour
{
    public int goldAmount;
    public Text goldUI;

    void Start()
    {
        goldAmount = 0;
        goldUI.text = "Gold: " + goldAmount.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            goldAmount++;
            goldUI.text = "Gold: " + goldAmount.ToString();
            Destroy(gameObject);
        }
    }
}
