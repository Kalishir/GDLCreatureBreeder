using UnityEngine;
using System.Collections;

public class Tend : MonoBehaviour
{
    public void TendCreature(Creature creature)
    {
        //TODO: Remove Magic Number
        creature.Health += Random.Range(0, creature.MaxHealth/4);
        creature.Horniness += Random.Range(0, creature.Libido);
    }
}
