//using TMPro.EditorUtilities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunSys : MonoBehaviour
{
    //Gun stats
    public int damage = 5;
    public int magazineSize, totalBullets;
    public int BulletsShot=0; public int bulletsLeft=0;
    public float range = 20f;

    //bools
    bool Shooting;

    //References
     public Transform attackpoint;
     public Hud hud;
    //public RaycastHit rayHit;
    //public LayerMask WhatIsEnemy;

    public GameObject ImpactParticle;
    public GameObject muzzleFlashParticle;
    GameObject impact;
    public GameObject firePoint;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    void Start()
    {
        bulletsLeft = magazineSize;
        hud.updateAmmo(bulletsLeft, totalBullets);
    }
    void Update()
    {
        //press R to reload
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            reload();
        }

        //checks to see if player has shot all of their bullets. If so, gun will not shoot until player reloads 
        if(Mouse.current.leftButton.wasPressedThisFrame){
            Shooting = true;
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
         {
            Shooting = false;
        }
        //checks to see if player should be shooting and how fast to shoot
        if (Shooting && Time.time > nextFireTime)
        {
            if(bulletsLeft == 0)
            {
                Debug.Log("reload!");
            }
            else{
                Shoot();
                AudioManager.Instance.Play(AudioManager.SoundType.Shoot);
                nextFireTime = Time.time + fireRate;
                BulletsShot += 1;
                bulletsLeft -= 1;
                //hud update
                hud.updateAmmo(bulletsLeft, totalBullets);
            }
        }
        
        
    }

    private void Shoot()
    {
        //method for activating raycast to shoot
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, range))
        {
            //Debug.Log("Hit");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*hitInfo.distance, Color.red); // red line shown on hit
            //BossHealthSystem bossHealth = hitInfo.collider.GetComponentInParent<BossHealthSystem>();//detects if gameObject with boss health system was hit
            
            if (hitInfo.collider.CompareTag("Enemy"))// detects if object hit was enemy
            {
                Debug.Log("Hit Enemy");
                GameObject hitEnemy = hitInfo.collider.gameObject; //get reference of enemy hit
                Enemy enemyScript = hitEnemy.GetComponent<Enemy>();
                enemyScript.damageEnemy(damage);
                Debug.Log("Enemy Health:" + enemyScript.getHealth());
            }
            
            if (hitInfo.collider.transform.root.CompareTag("Boss"))
            {
                BossHealthSystem BossHealthScript = hitInfo.collider.GetComponentInParent<BossHealthSystem>();
                BossHealthScript.damage(damage);
            }

            //particle effect on hit. to be destroyed after hit
            impact = Instantiate(ImpactParticle, hitInfo.point, quaternion.identity);
            Destroy(impact, 2f);
            impact = null;

            //TODO: Needs fixing, Muzzle flash is lagging behind attack point. needs to move with the attack point 
              firePoint = Instantiate(muzzleFlashParticle, attackpoint.position, attackpoint.rotation, attackpoint);
              Destroy(firePoint, 0.2f);

        }
        else
        {
            Debug.Log("Miss");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*range, Color.green); //green line shown on miss
        }
        
    }
    public void getAmmo(int AmmoAmount)
    {
        totalBullets += AmmoAmount;
        hud.updateAmmo(bulletsLeft, totalBullets);
        Debug.Log("getAmmo has been triggered");
    }

    private void reload()
    {
        if(BulletsShot <= totalBullets){
            
            totalBullets -= BulletsShot;
            bulletsLeft = magazineSize;
            hud.updateAmmo(bulletsLeft, totalBullets);
            BulletsShot = 0;
            }
            else if (totalBullets < BulletsShot){
                bulletsLeft += totalBullets;
                totalBullets = 0;
                hud.updateAmmo(bulletsLeft, totalBullets);
            }
            else
            {
                Debug.Log("no more ammo!");
            }


    }
}
