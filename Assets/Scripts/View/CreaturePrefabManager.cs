using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[DisallowMultipleComponent]
public class CreaturePrefabManager : MonoBehaviour
{
    [SerializeField] private Image creatureBackground;
    [SerializeField] private Image creatureImage;
    [SerializeField] private string uniqueID;

    public Image CreatureImage
    {
        get { return creatureImage; }
    }
    public Image CreatureBackground
    {
        get { return creatureBackground; }
    }

    public string UniqueID
    {
        get { return uniqueID; }
        private set { uniqueID = value; }
    }

    private Text creatureName;
    private Text creatureValue;
    private Image creatureSprite;
    private Creature creature;

    void Awake()
    {
        creatureName = gameObject.transform.Find("CreatureInfo/Name").gameObject.GetComponent<Text>();
        creatureValue = gameObject.transform.Find("CreatureInfo/Price/Price").gameObject.GetComponent<Text>();
        creatureSprite = gameObject.transform.Find("CreatureIcon/Image").gameObject.GetComponent<Image>();
    }

    void Start()
    { 
        PointerUIHelper uiHelper;
        uiHelper = GetComponent<PointerUIHelper>();
        UIManager theManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        uiHelper.onPointerClick.AddListener(() => theManager.UpdateSelectedItem(this));

        var doubleClickHandler = GetComponent<DoubleClick>();
        uiHelper.onPointerClick.AddListener(() => doubleClickHandler.Clicked());
    }

    void OnEnable()
    {
        //Add Event Subscriptions
        if (creature != null)
        {
            creature.ValueChanged += UpdateValue;
        }
    }

    void OnDisable()
    {
        //Add Event Un-Subscriptions
        if (creature != null)
        {
            creature.ValueChanged -= UpdateValue;
        }
    }

    
    public void Initialize(Creature creature)
    {
        gameObject.name = creature.CreatureName;
        creatureName.text = creature.CreatureName;
        creatureValue.text = creature.CurrentValue.ToString();
        UniqueID = creature.ID;
        creatureSprite.sprite = SpriteManager.Manager.GetCreatureSprite(creature);
        this.creature = creature;
        this.creature.ValueChanged += UpdateValue;
        //TODO: Add event handling to prefab;
    }

    private void UpdateValue(int newValue)
    {
        creatureValue.text = newValue.ToString();
    }
}
