using TMPro;
using UnityEngine;

public class ManaSystem : MonoBehaviour
{

    public static ManaSystem Instance { get; private set; }
    [SerializeField]
    private TMP_Text manaAmountText;
    private float manaAmount;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        manaAmountText = GetComponent<TMP_Text>();
        manaAmount = 100;
        manaAmountText.text = "100";
    }

    // Update is called once per frame
    
    public void ManaDrain(float drain)
    {
        manaAmount -= drain;
        if (manaAmount <= 0)
            manaAmount = 0;
        manaAmountText.text = manaAmount.ToString();
    }

    public void ManaGain(float gain)
    {
        manaAmount += gain;
        if(manaAmount >100)
            manaAmount = 100;
        manaAmountText.text = manaAmount.ToString();
    }

    public bool ManaCheck(float val)
    {
        if(val >  manaAmount)
            return false;
        else 
            return true;
    }
}
