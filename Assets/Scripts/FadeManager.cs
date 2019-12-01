using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace WickedStudios
{
    public class FadeManager : MonoBehaviour
    {
        private Text fadingImage;
        void Awake()
        {
            fadingImage = GetComponent<Text>();
            fadingImage.CrossFadeAlpha(0, 2.5f, false);
            StartCoroutine(Timer());
        }

        IEnumerator Timer()
        {
            fadingImage.CrossFadeAlpha(0, 2.5f, false);
            yield return new WaitForSeconds(2.5f);
            Destroy(gameObject);
        }
    }
}

