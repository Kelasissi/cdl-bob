using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SheaurikenAbility : MonoBehaviour
{
    [SerializeField] int baseSheaurikenNumber = 3;
    int currentSheaurikenNumber;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject[] projectileLefts;
    private Rigidbody2D m_rigidBody;

    public AudioClip shuriken;
    AudioSource audiosource;


    private void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        

    }
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        currentSheaurikenNumber = baseSheaurikenNumber;
        StartCoroutine(DisplayProjectileLefts());
        audiosource.PlayOneShot(shuriken, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && currentSheaurikenNumber > 0)
        {
            ThrowSheauriken();
            currentSheaurikenNumber -= 1;
            Destroy(projectileLefts[currentSheaurikenNumber]);
            
        }
    }

    void ThrowSheauriken()
    {
        projectile.transform.position = m_rigidBody.transform.position;
        Instantiate(projectile);
    }

    IEnumerator DisplayProjectileLefts()
    {
        projectileLefts[0].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        projectileLefts[1].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        projectileLefts[2].SetActive(true);
    }
}
