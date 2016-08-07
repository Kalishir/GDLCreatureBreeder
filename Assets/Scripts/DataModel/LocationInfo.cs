using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class LocationInfo: ScriptableObject
{
    /// <summary>
    /// Creature Capacity for the Location
    /// 0 Repesents unlimited.
    /// </summary>
    [Range(0, 100)] [SerializeField] private int creatureCapacity;

    public int CreatureCapacity
    {
        get
        {
            return creatureCapacity;
        }
        private set
        {
            creatureCapacity = value;
        }
    }

    [Range(0f, 1f)] [SerializeField] private float baseBreedingChance;

    [SerializeField] private int healthGainedAtEndOfDay;

    public int HealthGainedAtEndOfDay
    {
        get
        {
            return healthGainedAtEndOfDay;
        }
        private set
        {
            healthGainedAtEndOfDay = value;
        }
    }

    [SerializeField] private int horinessGainedAtEndOfDay;

    public int HorninessGainedAtEndOfDay
    {
        get
        {
            return horinessGainedAtEndOfDay;
        }
        private set
        {
            HorninessGainedAtEndOfDay = value;
        }
    }

    /// <summary>
    /// Gold gained per creature in the location at the end of the day
    /// Is a percentage based on the creatures value.
    /// </summary>
    [Range(0, 1f)] [SerializeField] private float goldGainedAtEndOfDay;

    public float GoldGainedAtEndOfDay
    {
        get
        {
            return goldGainedAtEndOfDay;
        }
        private set
        {
            goldGainedAtEndOfDay = value;
        }
    }

    [Space]
    [Header("Upgrade Information")]
    [SerializeField] bool canUpgrade;
    public bool CanUpgrade
    {
        get
        {
            return canUpgrade;
        }
        private set
        {
            canUpgrade = value;
        }
    }

    [SerializeField] LocationInfo upgradesTo;

    public LocationInfo UpgradesTo
    {
        get
        {
            return upgradesTo;
        }
        private set
        {
            upgradesTo = value;
        }
    }

    [SerializeField] int costToUpgrade;
    public int CostToUpgrade
    {
        get
        {
            return costToUpgrade;
        }
        private set
        {
            costToUpgrade = value;
        }
    }
}
