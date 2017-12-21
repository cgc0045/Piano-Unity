using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

[RequireComponent(typeof(AudioSource))]

public class PianoC3 : MonoBehaviour {
    AudioSource source;
    public float semitone = 0f;
    public float angle = 5f;

    private Vector3 initPos;
    private Quaternion initRot;

    private float resetVelocity = -5;
    private float maxRotation = 5;

    private bool isTouch = false;

    private Vector3 maxBox;
    private Vector3 minBox;

    private void Start()
    {
        Debug.Log(this.name);

        maxBox = GetComponent<Collider>().bounds.max;
        minBox = GetComponent<Collider>().bounds.min;

        source = GetComponent<AudioSource>();

        if (!source)
        {
            Debug.Log("The key don't have any audio file attached");
        }

        source.playOnAwake = false;
        initPos = transform.position;
        initRot = transform.rotation;
    }

    // Update is called once per frame
    void Update () {
        
        
    }

    private void OnMouseDown()
    {
        source.pitch = Mathf.Pow(2f, semitone / 12f);

        //transform.Rotate(new Vector3(-15, 0, 0));
        //transform.RotateAround(new Vector3(-0.55f,0f,0.58f), new Vector3(1f,0f,0f), 0f - angle);
        Vector3 zero = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.SmoothDamp(transform.rotation.eulerAngles,
                transform.rotation.eulerAngles + new Vector3(1500, 0, 0), ref zero, 0.5f));
        source.Play();
    }


    private void OnMouseUp()
    {
        transform.rotation = initRot;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("The collider is: " + other.gameObject.tag);
        if (other.gameObject.tag.Equals("Keys") || other.gameObject.tag.Equals("Piano"))
        {
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
        }
        else
        {
            if (isTouch.Equals(false) &&
                other.contacts[0].point.x <maxBox.x && other.contacts[0].point.x > minBox.x)
            {
                Debug.Log("Box Collider of " + this.name + ": " + this.maxBox + " collision position: " + other.contacts[0].point);
                Debug.Log("Rotation " + transform.rotation.eulerAngles.z);
                source.pitch = Mathf.Pow(2f, semitone / 12f);
                Vector3 zero = Vector3.zero;
                transform.rotation = Quaternion.Euler(Vector3.SmoothDamp(transform.rotation.eulerAngles,
                        transform.rotation.eulerAngles + new Vector3(1500, 0, 0), ref zero, 0.5f));

                source.Play();
                isTouch = true;
                Debug.Log("Key touched " + isTouch);
            }
        }
        
    }


    private void OnCollisionExit(Collision other)
    {
        //transform.Rotate(new Vector3(15, 0, 0));
        /*FingerModel finger = other.gameObject.GetComponentInParent<FingerModel>();
        
        if (finger)
        {
            Vector3 finPos = finger.GetTipPosition();
            Debug.Log(finPos);
            
            //Si el dedo esta dentro de los limites del bloque no debería de hacer nada
            
                Debug.Log("Finger exit" + finger.fingerType);
                //transform.RotateAround(new Vector3(-0.55f, 0f, 0.58f), new Vector3(1f, 0f, 0f), 7.5f);
                //transform.Translate(new Vector3(-0.55f, 0f, 0.58f));
                transform.rotation = initRot;
            
            
        }*/
        //FingerModel finger = other.gameObject.GetComponentInParent<FingerModel>();

        //if (GetComponent<Collider>().bounds.max.x > other.contacts[0].point.x && GetComponent<Collider>().bounds.min.x < other.contacts[0].point.x
        //&& GetComponent<Collider>().bounds.min.y < other.contacts[0].point.y)
        //if (other.contacts[0].point.x > maxBox.x && other.contacts[0].point.x < minBox.x &&
        //   other.contacts[0].point.y > maxBox.y && other.contacts[0].point.y < minBox.y &&
        //     other.contacts[0].point.z > maxBox.z && other.contacts[0].point.z < minBox.z)
        
        Debug.Log("Collision exit: " + other.contacts[0].point.y);
        if(isTouch.Equals(true))
        {
            //Vector3 finPos = finger.GetTipPosition();
            transform.rotation = initRot;
            isTouch = false;
        }
    }
}
