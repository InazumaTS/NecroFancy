using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private HpSystem hpSystem;
    [SerializeField]
    private float damage;
    [SerializeField]
    private ManaSystem manaSystem;
    void Start()
    {
        damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            ManaSystem.Instance.ManaGain(damage);
            HpSystem.Instance.Damage(damage);
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ManaSystem.Instance.ManaDrain(damage);
        }
    }
}
