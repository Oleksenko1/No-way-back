using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class PlayerGunHandler : MonoBehaviour
{
    [Header("Gun stats")]
    [SerializeField] private float damage;
    [SerializeField] private float fireDelay;
    [SerializeField] private float reloadTime;
    [SerializeField] private int maxClipSize = 10;
    [SerializeField] private int currentClip;
    
    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float lifeTime;

    [Header("Other")]
    [SerializeField] private GameObject playerGO;
    private Animator playerAnim;
    [SerializeField] private Transform gunPoint;
    public UnityEvent<Vector2> OnAmmoChanged = new UnityEvent<Vector2>(); // Invokes when ammo and\or stats of ammo is changed

    private float nextShot = 0f;
    private bool isReloading = false;

    private void Awake()
    {
        playerAnim = playerGO.GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        currentClip = maxClipSize;
        OnAmmoChanged?.Invoke(new Vector2(currentClip, maxClipSize));
    }
    public void ShootBullet()
    {
        if (currentClip > 0 && nextShot <= Time.time && !isReloading)
        {
            var bullet = Instantiate(bulletPrefab, gunPoint.position, playerGO.transform.rotation); // Creates bullet
            var bulletScript = bullet.GetComponent<BulletScript>();

            bulletScript.setStats(damage, bulletSpeed, lifeTime); // Shoots bullet

            playerGO.GetComponentInChildren<Animator>().SetTrigger("Shoot");
            
            nextShot = Time.time + fireDelay;

            currentClip--;

            OnAmmoChanged?.Invoke(new Vector2(currentClip, maxClipSize));
        }
    }
    public void Reload()
    {
        isReloading = true;

        playerAnim.SetTrigger("Reload"); // plays reload animation

        StopCoroutine("ReloadTimerCoroutine");
        StartCoroutine("ReloadTimerCoroutine");
    }
    IEnumerator ReloadTimerCoroutine()
    {
        yield return new WaitForSeconds(reloadTime);
        int reloadAmount = maxClipSize - currentClip; // How many bullets to reload
        currentClip += reloadAmount;

        OnAmmoChanged?.Invoke(new Vector2(currentClip, maxClipSize));

        isReloading = false;
    }
    public void ChangeMaxClipCapacity(int change)
    {
        maxClipSize += change;
        OnAmmoChanged?.Invoke(new Vector2(currentClip, maxClipSize));
    }
    
}
