using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    [SerializeField] private CooldDownTime cooldown;
    public GameObject alien;
    public GameObject location;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (cooldown.isCoolingDown)

       if(col.gameObject.tag == "Player")
        {
            Transform l = location.transform;
            GameObject a = Instantiate(alien.gameObject, l);

            a.transform.LookAt(GameObject.Find("Player").transform.position);

            StartCoroutine(DestroyObject(a));
            cooldown.StartCooldown();
        } 
    }
    public IEnumerator DestroyObject(GameObject e)
    {
        yield return new WaitForSeconds(1);

        Destroy(e.gameObject);
    }
}
