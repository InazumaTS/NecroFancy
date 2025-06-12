using UnityEngine;
using UnityEngine.UI;

public class CardWorks : MonoBehaviour
{
    [SerializeField]
    private float healing;
    [SerializeField] 
    private float HealDrain;
    [SerializeField]
    private float AttackDrain;
    [SerializeField]
    private float ShieldDrain;
    [SerializeField]
    private GameObject cardPackScroll;
    [SerializeField]
    private GameObject bigPunch;
    [SerializeField]
    private GameObject skelefriend;
    [SerializeField]
    private GameObject barrier;

    private Vector3 spawnPosition = new Vector3(0, -3, 0);

    private float punchOffset = 1;
    private void Start()
    {
        skelefriend = GameObject.Find("SkeleFriend");
    }
    public void Heal()
    {
        if (ManaSystem.Instance.ManaCheck(HealDrain))
        {
            HpSystem.Instance.Heal(healing);
            ManaSystem.Instance.ManaDrain(HealDrain);
            cardPackScroll.SetActive(false);
        }
    }
    
    public void Punch()
    {
        if (ManaSystem.Instance.ManaCheck(AttackDrain))
        {
            Instantiate(bigPunch, new Vector3(skelefriend.transform.position.x + punchOffset, skelefriend.transform.position.y, 0), Quaternion.identity);
            ManaSystem.Instance.ManaDrain(AttackDrain);
            cardPackScroll.SetActive(false);
        }
    }
    
    public void Shield()
    {
        Instantiate(barrier,spawnPosition, Quaternion.identity);
        ManaSystem.Instance.ManaDrain(ShieldDrain);
        cardPackScroll.SetActive(false);
    }

    public void Special()
    {
        cardPackScroll.SetActive(false);
    }
}
