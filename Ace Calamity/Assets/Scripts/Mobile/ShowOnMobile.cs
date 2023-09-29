using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnMobile : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(Application.isMobilePlatform);
    }
}
