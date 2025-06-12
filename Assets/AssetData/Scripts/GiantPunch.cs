using UnityEngine;

public class GiantPunch : MonoBehaviour
{
    [SerializeField]
    private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float hitCount =0;
    private float hitCountMax = 3;
    private void Update()
    {
        transform.position = new Vector2 (transform.position.x + (speed*Time.deltaTime),transform.position.y);
        if(transform.position.x >1000)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            hitCount++;
            if(hitCount == hitCountMax)
                Destroy(this.gameObject);
        }
    }
}
