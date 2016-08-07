using UnityEngine;
using UnityEngine.UI;

public class DayTracker : MonoBehaviour
{

    int currentDay = 0;
    [SerializeField] Text dayText;

    void Start()
    {
        UpdateDay();
    }

    public void UpdateDay()
    {
        currentDay++;
        dayText.text = "Day: " + currentDay.ToString();
    }
}
