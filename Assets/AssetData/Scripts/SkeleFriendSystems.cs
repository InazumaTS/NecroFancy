using UnityEngine;

public class SkeleFriendSystems : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemyUnDead enemyUnDead = collision.GetComponent<EnemyUnDead>();
            HpSystem.Instance.Damage(enemyUnDead.enemyDamage);
        }
    }
}
