using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public float _Time = 3.0f;
    public float _Radius = 5.0f;
    public float _Power = 3.0f;
    public GameObject _FX;

	public void DoExplode () {
        Invoke("Explode", _Time);
        
	}
	
	

    void Explode()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, _Radius);
   
        foreach(var colider in colliders)
        {
            Rigidbody2D rgbody = colider.GetComponent<Rigidbody2D>();
            if (rgbody == null) continue;

            Vector2 vector = colider.transform.position - transform.position;

            Vector2 dir = vector.normalized;
            float len = vector.magnitude;

            rgbody.AddForce(dir * _Power * Mathf.Pow(1 / (len + 1), 2)); 
        }
        _FX.SetActive(true);
        Destroy(gameObject, 0.3f);
    }
}
