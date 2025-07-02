using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private float m_speed = 15.0f;
    void Awake()
    {
        
    }
    public void Init()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.linearVelocity = transform.forward * m_speed;
        Destroy(gameObject, 3.0f); // Destroy bullet after 3 seconds
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null) player.Dead();
            GameMng.Inst.EndGame();
            Destroy(gameObject);
        }
    }
}
