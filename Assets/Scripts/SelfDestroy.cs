using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float timeToDestroy;

    public bool destroyOnTime = false;

    public Sprite[] sR;
    private new SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        renderer.sprite = sR[Random.Range(0, 4)];
    }

    void Update()
    {
        if(destroyOnTime)
        {
            Destroy(gameObject, timeToDestroy);
        }
    }

    private void DestroyEvent()
    {
        Destroy(gameObject);
    }
}
