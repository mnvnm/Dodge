using System.Collections;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    [SerializeField] AudioSource fireSoundSrc;
    [SerializeField] AudioClip fireSoundClip;

    float minShootTime = 0.5f;
    float maxShootTime = 2.0f;
    public void Init()
    {
        StartCoroutine(Fire());
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameMng.Inst.gameUI.m_playerController.transform.position);
    }

    IEnumerator Fire()
    {
        while (true)
        {
            float randomgap = Random.Range(minShootTime, maxShootTime);
            yield return new WaitForSeconds(randomgap);
            GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.Init();
                fireSoundSrc.PlayOneShot(fireSoundClip);
            }
        }
    }
    public void StopFire()
    {
        StopAllCoroutines();
    }
}
