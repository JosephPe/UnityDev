using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Range(1, 10), Tooltip("This controlls the speed")] public float speed = 5;
    [Range(1, 100), Tooltip("This controlls the rotation rate")] public float rotationRate = 5;
    //public float rotationRate = 180;
    
    public GameObject prefab;
    public Transform bulletOrigin;

    private void Awake()
    {
        Debug.Log("Awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");

        //transform.position = new Vector3(2, 3, 1);
        //transform.rotation = Quaternion.Euler(30, 60, 90);
        //transform.localScale = Vector3.one * Random.value * 5;

        Vector3 direction = Vector3.zero;
        direction.z = Input.GetAxis("Vertical");

        Vector3 rotation = Vector3.zero;
        rotation.y = Input.GetAxis("Horizontal");

        Quaternion rotate = Quaternion.Euler(rotation * rotationRate * Time.deltaTime);
        transform.rotation = transform.rotation * rotate;
        transform.Translate(direction * speed * Time.deltaTime);

        //transform.position += direction * speed * Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Pew");
            //GetComponent<AudioSource>().Play();
            GameObject go = Instantiate(prefab, bulletOrigin.position, bulletOrigin.rotation);
            Destroy(go, 5);
        }
    }
}
