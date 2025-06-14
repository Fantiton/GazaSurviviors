using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    Vector2 controllerInput;
    LevelManager levelManager;
    Rigidbody rb;
    public List<GameObject> enemies;
    public GameObject gun;
    public GameObject bulletSpawn;
    public GameObject bulletPrefab;
    public GameObject swordHandle;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        rb = GetComponent<Rigidbody>();
        enemies = new List<GameObject>();
        InvokeRepeating("Shoot", 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        controllerInput =  new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        enemies = enemies.OrderBy(enemy => Vector3.Distance(enemy.transform.position, transform.position)).ToList();

        if (enemies.Count > 0 && Vector3.Distance(transform.position, enemies[0].transform.position) < 2f)
        {
            swordHandle.SetActive(true);
            swordHandle.transform.Rotate(0, 10f, 0);
        }
        else
        {
            swordHandle.SetActive(false);
        }

    }

    private void FixedUpdate()
    {
        Vector3 movementVector = new Vector3(controllerInput.x, 0, controllerInput.y);
        Vector3 targetPosition = transform.position + movementVector * Time.fixedDeltaTime * movementSpeed;
        rb.MovePosition(targetPosition);
    }

    void Shoot()
    {
        if(enemies.Count > 0)
        {
            gun.transform.LookAt(enemies[0].transform);
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, gun.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(gun.transform.forward * 1000);
            //Destroy(enemies[0]);
            Debug.Log("Pif Paf!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            levelManager.ReducePlayerHealth(5);
            //Destroy(gameObject);
        }
    }
}
 