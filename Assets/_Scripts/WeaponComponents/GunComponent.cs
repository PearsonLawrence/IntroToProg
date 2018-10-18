using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunComponent : MonoBehaviour {

    public int MaxMagCapacity = 30;
    private int CurrentMagCapacity;

    public float MaxShootDelay;
    public float ShootDelay;

    public float bulletLaunchVelocity = 10;
    public GameObject BulletPrefab; // Bullet to spawn

    public Transform ShootPoint;

    float DT;

    public void Fire()
    {
        if(CurrentMagCapacity > 0 && ShootDelay <= 0)
        {
            // Instantiate bullet
            GameObject TempBullet = Instantiate(BulletPrefab, ShootPoint.position, ShootPoint.rotation);
            // launch bullet in direction
            TempBullet.GetComponent<Rigidbody>().velocity = ShootPoint.forward * bulletLaunchVelocity;

            TempBullet.GetComponent<BulletComponent>().Owner = gameObject;
            // Destroy bullet after 4 seconds
            Destroy(TempBullet, 4.0f);

            ShootDelay = MaxShootDelay;
            CurrentMagCapacity--;
        }
        else if(CurrentMagCapacity <= 0)
        {
            Debug.Log("Empty");
        }
    }

	// Use this for initialization
	void Start () {
        CurrentMagCapacity = MaxMagCapacity;
	}
	
	// Update is called once per frame
	void Update () {

        DT = Time.deltaTime;
        ShootDelay -= DT;

	}
}
