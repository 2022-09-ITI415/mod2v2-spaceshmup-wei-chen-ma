using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_5 : Enemy {

    [Header("Set in Inspector: Enemy_5")]
    
    public float waveFrequency = 3;
    
    public float waveWidth = 8;
    public float waveRotY = 90;

    private float x0; 
    private float birthTime;

	
	void Start()
    {
        
        x0 = pos.x;

        birthTime = Time.time;
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
}
