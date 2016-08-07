using UnityEngine;
using UnityEngine.UI;


public class CashUpdater : MonoBehaviour
{
    Text text;

    void Start()
    {
        text = transform.Find("Text").GetComponent<Text>();
        PlayerMoney.Instance.MoneyChanged += UpdateCash;
    }

    void OnEnable()
    {
        if(PlayerMoney.Instance != null)
            PlayerMoney.Instance.MoneyChanged += UpdateCash;
    }

    void OnDisable()
    {
        PlayerMoney.Instance.MoneyChanged -= UpdateCash;
    }

    void UpdateCash(int newTotal)
    {
        if (text != null)
            text.text = "$ " + newTotal;
    }
}
