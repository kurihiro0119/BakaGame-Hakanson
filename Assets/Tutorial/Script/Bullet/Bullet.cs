using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 velocity;

    public void Init(Vector3 origin, float angle)
    {
        transform.position = origin;
        velocity = 9f * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
