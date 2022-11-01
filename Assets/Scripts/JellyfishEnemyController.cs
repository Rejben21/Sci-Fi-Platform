using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishEnemyController : MonoBehaviour
{
    public bool followPlayer;
    public float moveSpeed;
    public GameObject player;
    private new Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {

        }

        if(followPlayer)
        {
            FollowPlayer();
        }
        else
        {
            rigidbody.AddForce(Vector2.zero);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            followPlayer = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            followPlayer = false;
        }
    }

    private void FollowPlayer()
    {
        StartCoroutine(FollowPlayerCoroutine());
    }

    private IEnumerator FollowPlayerCoroutine()
    {
        if(player == null)
        {

        }
        else
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z -180));
            transform.rotation = rotation;
            rigidbody.AddForce(Vector2.up * moveSpeed * Time.deltaTime);
        }

        yield return new WaitForSeconds(2);
    }
}
