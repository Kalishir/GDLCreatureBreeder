using UnityEngine;
using UnityEngine.Events;

public class PlayerMoney : MonoBehaviour
{
    public event UnityAction<int> MoneyChanged;

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
    public int Money
    {
        get
        {
            return currentMoney;
        }
        set
        {
            currentMoney = value;
            if (MoneyChanged != null)
                MoneyChanged(currentMoney);
        }
    }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    public void Start()
    {
        Money = startingMoney;
    }


    //TODO: Rename and refactor this.
    public bool CheckIfWeCanPayForThisCreatureIfSoBuyIt(int price)
    {
        if (currentMoney >= price)
        {
            currentMoney -= price;
            if (MoneyChanged != null)
                MoneyChanged(currentMoney);
            return true;
        }
        return false;
    }
}