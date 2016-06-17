using UnityEngine;
using System.Collections;

public class PlayerMoney : MonoBehaviour
{
    private static PlayerMoney instance;
    static public PlayerMoney Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField] private int startingMoney = 500;
    private int currentMoney;
    

    void Awake()
    {
        instance = this;
        //TODO should be changed when we introduce saving/loading
        currentMoney = startingMoney;
    }

    public bool CheckIfWeCanPayForThisCreatureIfSoBuyIt(int price)
    {
        if (currentMoney >= price)
        {
            currentMoney -= price;
            return true;
        }
        return false;
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
    }
}