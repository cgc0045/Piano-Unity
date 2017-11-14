using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PianoC3 : MonoBehaviour {
    AudioSource source;
    public float semitone = 0f;

    private void Start()
    {
        
        source = GetComponent<AudioSource>();

        if (!source)
        {
            Debug.Break();
        }

        source.playOnAwake = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            transform.Rotate(new Vector3(0, 0, 0));
        }
	}

    private void OnMouseDown()
    {
        source.pitch = Mathf.Pow(2f, semitone / 12f);

        transform.Rotate(new Vector3(-15, 0, 0));

        source.Play();
    }

    private void OnMouseUp()
    {
        transform.Rotate(new Vector3(0, 0, 0));
    }
}
