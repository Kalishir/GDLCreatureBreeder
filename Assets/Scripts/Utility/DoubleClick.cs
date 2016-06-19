using UnityEngine;
using System.Collections;

/// <summary>
/// just checks for double clicks and moves creature into breeding hold if its possible
/// </summary>
public class DoubleClick : MonoBehaviour
{
    private bool oneClick = false;
    private float timerForDoubleClick;

    private float delay = 0.3f;

    public void Clicked()
    {
        if(!UIManager.Instance.BreedingWindowIsOpen)
            return;

        
        if (!oneClick)
        {
            oneClick = true;

            timerForDoubleClick = Time.time;
        }
        else
        {
            if ((Time.time - timerForDoubleClick) < delay)
            {
                //Double Clicked
                oneClick = false;
                UIManager.Instance.CanIMoveCreatureToBreeding(gameObject);
                
            }
            else
            {
                //Its been a while since we last clicked. so make this the first click
                oneClick = true;

                timerForDoubleClick = Time.time;
            }
        }
    }
}
