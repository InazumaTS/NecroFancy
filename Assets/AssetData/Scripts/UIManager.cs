using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPackScroll;
    public void ShowCards()
    {
        if (cardPackScroll.activeSelf)
        {
            cardPackScroll.SetActive(false);
           
        }
        else
        {
            cardPackScroll.SetActive(true);
        }
    }
}
