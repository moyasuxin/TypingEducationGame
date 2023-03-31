using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectors : MonoBehaviour
{
    public static Detectors detector{private set;get;} //Singleton
    public string tagToDetect = "Enemy";
    public List<GameObject> allEnemies = new List<GameObject>();

    public GameObject closestEnemy;


    void Awake()
    {
        detector = this;
    }
    
    void OnDestroy()
    {
        detector = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(closestEnemy.name);
    }

    GameObject ClosestEnemy()
    {
        GameObject closestHere = gameObject;
        float leastDistance = Mathf.Infinity;

        foreach (var enemy in allEnemies)
        {
            float distanceHere = Vector3.Distance(transform.position, enemy.transform.position);

            if(distanceHere<leastDistance)
            {
                leastDistance = distanceHere;
                closestHere = enemy;
            }
        }


        return closestHere;
    }

    public void DestroyEnemy()
    {
        //if(allEnemies.Count < 1) return; (Since typer doing the check now, here no need to check again. It should never redline.)
        
        closestEnemy = ClosestEnemy();
        Zombie zombie = closestEnemy.GetComponent<Zombie>();
        zombie.alive = false;
        zombie.zombieAnim.SetInteger("Int2", 1 );
        
    }
}
