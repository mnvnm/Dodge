using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody m_rigidbody;
    float m_speed = 3.0f;
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        Move_Different();
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

    void Move_Different()
    {

        if (Input.GetKey(KeyCode.W))
        {
            m_rigidbody.AddForce(Vector3.forward * m_speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_rigidbody.AddForce(Vector3.back * m_speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_rigidbody.AddForce(Vector3.left * m_speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_rigidbody.AddForce(Vector3.right * m_speed, ForceMode.Impulse);
        }
        // 다른 방식으로 이동 구현
    }
}
