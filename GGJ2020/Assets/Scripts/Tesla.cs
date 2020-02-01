using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tesla : MonoBehaviour
{
    public SphereCollider aoeRadius;
    public GameObject golem;
    public Golem golemScript;
    public int hp;
    float timer;
    public int cooldown;
    public ParticleSystem particle;


    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Golem"))
        {
            Tazzing();
        }
    }

    private void Tazzing()
    {
        Vector3 direction = transform.position - golem.transform.position; // se servir de ce vecteur pour particule ?
        timer += Time.deltaTime;
        if (timer >= cooldown)
        {
            //Instantiate tazzing particle using direction + direction.magnitude
            
            golemScript.hp--;
            print(golemScript.hp);
            timer = 0;
        }
    }
}
