using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform childTransform;

    [SerializeField] GameObject BulletObjectPrefab;

    [SerializeField] private int bulletCount = 5;
    [SerializeField] private float bulletAngle = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(0.0f, -1f, 0.0f);
        childTransform.localPosition = new Vector3(0.0f, 2f, 0.0f);

        //transform.rotation = Quaternion.Euler(0, 0, 45.0f); // Reset rotation to initial state
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, 100) * Time.deltaTime);
            //childTransform.Rotate(new Vector3(0, 100, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, -100) * Time.deltaTime);
            //childTransform.Rotate(new Vector3(0, -100, 0) * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)) Shoot();

    }

    void Shoot()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            Vector3 ShootDirection = new Vector3(childTransform.rotation.x,  i * bulletAngle - ((bulletAngle * (float)bulletCount) / 2.0f),childTransform.rotation.y);
            GameObject bulletObj = Instantiate(BulletObjectPrefab, childTransform.position, childTransform.rotation); 
            bulletObj.transform.Rotate(ShootDirection);
            Rigidbody m_rigidbody = bulletObj.GetComponent<Rigidbody>();
            m_rigidbody.linearVelocity = bulletObj.transform.forward * 10;
            Destroy(bulletObj, 3.0f);
        }
    }
}
