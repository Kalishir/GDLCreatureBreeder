using UnityEngine;
using UnityEngine.UI;


public class CashUpdater : MonoBehaviour
{
    Text text;

    void Start()
    {
        text = transform.Find("Text").GetComponent<Text>();
        PlayerMoney.Instance.moneyChanged += UpdateCash;
    }

    void OnEnable()
    {
        if(PlayerMoney.Instance != null)
            PlayerMoney.Instance.moneyChanged += UpdateCash;
    }

    void OnDisable()
    {
        PlayerMoney.Instance.moneyChanged -= UpdateCash;
    }

    void UpdateCash(int newTotal)
    {
        if (text != null)
            text.text = "$ " + newTotal;
    }
}
