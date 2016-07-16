using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreatureLand : MonoBehaviour
{
    private List<Field> creatureFields = new List<Field>();


    public void EndOfDay()
    {
        for (int i = 0; i < creatureFields.Count; i++)
        {
            creatureFields[i].DayHasEnded();
        }
    }
}