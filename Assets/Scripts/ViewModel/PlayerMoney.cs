using UnityEngine;
using UnityEngine.Events;

public class PlayerMoney : MonoBehaviour
{
    public event UnityAction<int> moneyChanged;
    private static PlayerMoney instance;
    static public PlayerMoney Instance
    {
        get
        {
            return instance;
        }

        private set
        {
            instance = value;
        }
    }

    [SerializeField] private int startingMoney = 500;
    [SerializeField] private int currentMoney;


    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            currentMoney = startingMoney;
            //Load Creatures from JSON
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    public bool CheckIfWeCanPayForThisCreatureIfSoBuyIt(int price)
    {
        if (currentMoney >= price)
        {
            currentMoney -= price;
            if (moneyChanged != null)
                moneyChanged(currentMoney);
            return true;
        }
        return false;
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        if (moneyChanged != null)
            moneyChanged(currentMoney);
    }
}