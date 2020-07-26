using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private Animator anim;
    public float range = 100f; //Max range of weapon
    public int bulletsPerMag = 6; //Bullets per cylinder
    public int bulletsLeft = 36; //Total bullets we have
    public int currentBullets; //Current bullets in cylinder
    public Transform shootPoint; //Point where bullet leaves barrel
    public float fireRate = 0.3f; //Delay between shots
    float fireTimer; //Time counter for delay

    // Start is called before the first frame update
    void Start() {

        anim = GetComponent<Animator>();
        currentBullets = bulletsPerMag;

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButton ("Fire1")) {
            Fire(); //Execute fire if you press left mouse button
        }

        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime; //Add time counter
    }

    void FixedUpdate() {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

        if (info.IsName ("Fire")) anim.SetBool ("Fire", false);
    }

    private void Fire() {
        if (fireTimer < fireRate) return;

        RaycastHit hit;

        if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range)) {
            Debug.Log (hit.transform.name + "found!");
            GameObject hitObject = hit.transform.gameObject;
            ReactiveTarget target = hitObject.GetComponent<ReactiveTarget> ();
                if (target != null) {
                    target.ReactToHit ();
                }

        }

        //anim.CrossFadeInFixedTime("Fire", 0.01f);
        anim.SetBool("Fire", true);
        currentBullets--;
        fireTimer = 0.0f; //Resetting fire timer
    }
}