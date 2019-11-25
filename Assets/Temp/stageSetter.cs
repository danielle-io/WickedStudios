using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stageSetter : MonoBehaviour {

    Text stageName;
	// Use this for initialization
	void Start () {
        stageName = GetComponent<Text>();
        stageName.text = SceneManager.GetActiveScene().name;
        stageName.CrossFadeAlpha(0.0f, 2.5f, false);

    }
}
