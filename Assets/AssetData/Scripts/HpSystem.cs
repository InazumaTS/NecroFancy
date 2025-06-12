using TMPro;
using UnityEngine;

public class HpSystem : MonoBehaviour
{
    public static HpSystem Instance { get; private set; }
    [SerializeField]
    private float hp;
    [SerializeField]
    private GameObject skeleFriend;
    [SerializeField] 
    private GameObject spawnManager;
    [SerializeField]
    private SpawnManager spawnCheck;
    [SerializeField]
    private float maxHp;
    private TMP_Text hpSystem;
    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        spawnManager = GameObject.Find("EnemySpawnManager");
        spawnCheck = spawnManager.GetComponent<SpawnManager>();
        skeleFriend = GameObject.Find("SkeleFriend");
        hpSystem = GetComponent<TMP_Text>();
        maxHp = 30;
        hpSystem.text = hp.ToString();
    }

    public void Damage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
            spawnCheck.StopSpawning();
            skeleFriend.SetActive(false);
        }
        hpSystem.text = hp.ToString();
    }

    public void Heal(float damage)
    {
        hp += damage;
        if (hp >= maxHp)
            hp = 30;
        
        hpSystem.text = hp.ToString();
    }    
}
