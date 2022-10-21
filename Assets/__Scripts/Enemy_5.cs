using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_5 : Enemy {

    [Header("Set in Inspector: Enemy_5")]
    public float weaponCooldown = 0.3f;
    float nextShootTime = 0;

    public float waveFrequency = 3;
    
    public float waveWidth = 8;
    public float waveRotY = 90;

    private float x0; 
    private float birthTime;

    public Weapon weapon;
	
	void Start()
    {
        nextShootTime = Time.deltaTime;
        x0 = pos.x;

        birthTime = Time.time;
        weapon = GetComponentInChildren<Weapon>();
    }

    private void FixedUpdate(){
        Fire();
    }
    
    public override void Move()
    {
        Vector3 tempPos = pos;
        float age = Time.time - birthTime;
        float theta = Mathf.PI * 4 * age / waveFrequency;
        float sin = Mathf.Sin(theta);
        tempPos.x = x0 + waveWidth * sin;
        pos = tempPos;
        Vector3 rot = new Vector3(0, sin * waveRotY, 0);
        this.transform.rotation = Quaternion.Euler(rot);    
        base.Move();
    }

    public void Fire(){
        if (Time.time >= nextShootTime){
            weapon.Fire();
            nextShootTime = Time.time + weaponCooldown;
        }
        
    }
}
