using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float moveSpeed;
    private float realSpeed;
    public float timeToDestory;
    public GameObject contactEffect;

    void Start()
    {
        if(PlayerController.instance.isTurned)
        {
            realSpeed = -1 * moveSpeed;
        }
        else
        {
            realSpeed = moveSpeed;
        }
    }

    void Update()
    {
        transform.Translate(Vector3.right * realSpeed * Time.deltaTime);

        Destroy(gameObject, timeToDestory);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if(other.CompareTag("Ground"))
        {
            Instantiate(contactEffect, transform.position, Quaternion.identity);
        }
    }
}
