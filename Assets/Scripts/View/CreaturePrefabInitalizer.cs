using UnityEngine;
using UnityEngine.UI;

public class CreaturePrefabInitalizer : MonoBehaviour
{
    Creature creatureBeingRepresented;
    [SerializeField] Image creatureSprite;

    public void Initialize(Creature creature)
    {
        creatureBeingRepresented = creature;
        if (creatureSprite != null)
            creatureSprite.sprite = SpriteManager.Manager.GetCreatureSprite(creature);
    }

    public void CreatureRemovedHandler(Creature creature)
    {
        if (creature.ID == creatureBeingRepresented.ID)
            Destroy(this.gameObject);
    }
}
