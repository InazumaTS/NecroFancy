using UnityEngine;
using UnityEngine.UIElements;

public class EnemyUnDead : MonoBehaviour
{
    public float enemyDamage = 5;
    [SerializeField]
    private float undeadHealth = 100;
    [SerializeField]
    private float punchDamage = 10;
    [SerializeField]
    private float enemySpeed;
    [SerializeField]
    private float manaValue = 30;
    [SerializeField]
    private float knockbackvalue= 5;
    private float originXValue;
    private float moveTrigger = 0.5f;
    private float states = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (states)
        {
            case 0://Code to Move the Enemy
                transform.position = new Vector2(transform.position.x - (enemySpeed * Time.deltaTime), transform.position.y);

                break;
            case 1://Code to Give Enemy KnockBack
                transform.position = Vector2.Lerp(transform.position, new Vector2 (originXValue + knockbackvalue,transform.position.y),Time.deltaTime);
                //Code returns state to Move after KnockBack is done
                if (transform.position.x >= (originXValue + knockbackvalue - moveTrigger))
                    states = 0;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "PunchAttack"))
        {
            states = 1;
            originXValue = transform.position.x;
            undeadHealth -= punchDamage;
            if (undeadHealth <= 0)
            {
                
                ManaSystem.Instance.ManaGain(manaValue);
                Destroy(this.gameObject);
            }
        }
        if(collision.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        if(collision.tag == "Barrier")
        {
            BarrierCreation barrier = collision.GetComponent<BarrierCreation>();
            if (barrier != null)
            {
                states = 1;
                originXValue = transform.position.x;
                barrier.Damage(enemyDamage);
            }
        }
    }
    
}
