using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;
    public bool isRotten = false;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            if (!isRotten)
            {
                ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
                apScript.AppleMissed();
            }

        }
    }
}
