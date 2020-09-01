<<<<<<< Updated upstream
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public bool canRotate;

    public void Update()
    {
        if (canRotate)
        {
            StartCoroutine(Rotate( Vector3.forward, 90, 1.0f));
        }
    }

    public void StartRotation()
    {
        canRotate = true;
    }

    IEnumerator Rotate( Vector3 axis, float angle, float duration = 1.0f)
    {
        Quaternion from = transform.rotation;

        Quaternion to = transform.rotation;

        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;

        while( elapsed < duration && canRotate)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;
        canRotate = false;
    }
}
>>>>>>> Stashed changes
