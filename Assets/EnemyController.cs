using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movementSpeed;
    Rigidbody rb;
    LevelManager levelManager;
    public int enemyHealth = 10;
    public Canvas canvas;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        canvas = GetComponentInChildren<Canvas>();
    }

    private void FixedUpdate()
    {
        if (canvas != null && Camera.main != null)
        {
            canvas.transform.LookAt(Camera.main.transform);
            canvas.transform.rotation = Quaternion.LookRotation(canvas.transform.position - Camera.main.transform.position);
        }

        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        canvas.GetComponentInChildren<TextMeshProUGUI>().text = enemyHealth.ToString();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            enemyHealth -= 1;

        }else if (other.gameObject.CompareTag("Sword"))
        {
            enemyHealth -= 4;
        }else if (other.gameObject.CompareTag("Star"))
        {
            enemyHealth -= 5;
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            levelManager.AddPoints(1);
        }
    }
}
