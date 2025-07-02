using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody m_rigidbody;
    float m_speed = 10.0f;
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Init()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        if (m_rigidbody == null)
        {
            Debug.LogError("Rigidbody 컴포넌트가 없음");
            m_rigidbody = gameObject.AddComponent<Rigidbody>();
        }
    }

    void Move()
    {
        float Horizontal_Speed = Input.GetAxisRaw("Horizontal");
        float Vertical_Speed = Input.GetAxisRaw("Vertical");

        Vector3 velocity = new Vector3(Horizontal_Speed, 0.0f, Vertical_Speed).normalized * m_speed;
        //velocity = Vector3.ClampMagnitude(velocity, m_speed);
        m_rigidbody.linearVelocity = velocity;
    }
}
