using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool isRotating = true;
    [SerializeField] private float rotationSpeed = 50.0f;

    float changeDelay = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void Init()
    {
        changeDelay = 0.0f;
        rotationSpeed = Random.Range(-60.0f, 60.0f);
        isRotating = true;

        transform.rotation = new Quaternion(0,0,0,0); // Reset rotation to initial state
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            changeDelay += Time.deltaTime;
            if (changeDelay >= 5.0f)
            {
                rotationSpeed = Random.Range(-60.0f, 60.0f);
                changeDelay = 0;
            }

            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
        }
    }
}
