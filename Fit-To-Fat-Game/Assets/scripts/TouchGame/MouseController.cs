using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesHitTriggers = true;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
            CastMouseRaycayst();
		}
    }


    private void CastMouseRaycayst()
	{
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            hit.collider.GetComponent<DeactivateBall>().ReturnToPool();
        }
    }
}
