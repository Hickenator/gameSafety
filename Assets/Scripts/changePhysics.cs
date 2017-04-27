using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePhysics : MonoBehaviour {

    // Use this for initialization
    public Rigidbody rb;
    private Rigidbody rbAll;
    public Animator playerAnim;

    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rbAll = GetComponentInChildren<Rigidbody>();
        rbAll.isKinematic = true;
        playerAnim.enabled = true;
	}

    void EnableRagdoll()
    {
        rb.isKinematic = false;
        rbAll.isKinematic = false;
        playerAnim.enabled = false;
    }

    void DisableRagdoll()
    {
        rb.isKinematic = true;
        rbAll.isKinematic = true;
        playerAnim.enabled = true;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("f"))
            if (rbAll.isKinematic == false) {
                DisableRagdoll();
                print("f was pressed and DisableRagdoll() has activated");
            }
            else {
                EnableRagdoll();
                print("f was pressed and EnableRagdoll() has activated");
            }
    }


}
