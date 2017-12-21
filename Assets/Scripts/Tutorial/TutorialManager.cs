using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

    public List<Tutorial> Tutorials = new List<Tutorial>();

    public Text expText;

    private static TutorialManager instance;
    public static TutorialManager Instance
    {
        get{
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TutorialManager>();
            }

            if (instance == null)
            {
                Debug.Log("There is a no TutorialManager");
            }

            return instance;
        }
    }

    private Tutorial currentTutorial;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Tutorial GetTutorialByOrder(int Order)
    {
        foreach (Tutorial t in Tutorials)
        {
            if (t.Order == Order)
            {
                return t;
            }
        }

        return null;
    }
}
