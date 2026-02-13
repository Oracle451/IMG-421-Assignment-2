using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;
    public bool isRotten = false;

    private Transform basketTransform;

    void Start()
{
    if (GameManager.Instance.currentDifficulty == GameManager.Difficulty.Easy)
    {
        Basket basket = FindObjectOfType<Basket>();
        if (basket != null)
        {
            basketTransform = basket.transform;
        }
    }
}

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (GameManager.Instance.currentDifficulty == GameManager.Difficulty.Easy && basketTransform != null)
        {
            float step = 10f * Time.deltaTime;
            pos.x = Mathf.Lerp(pos.x, basketTransform.position.x, step);
        }

        transform.position = pos;

        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            if (GameManager.Instance.currentDifficulty != GameManager.Difficulty.Easy)
            {
                if (!isRotten)
                {
                    ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
                    apScript.AppleMissed();
                }
            }
            

        }
    }
}
