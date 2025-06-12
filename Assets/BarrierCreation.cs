using UnityEngine;

public class BarrierCreation : MonoBehaviour
{
    [SerializeField]
    private float Hp =100;

    public void Damage(float damage)
    {
        Hp -= damage;
        if(Hp<=0)
        {
            Destroy(this.gameObject);
        }
    }

    
}
