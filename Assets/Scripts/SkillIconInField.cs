using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillIconInField : MonoBehaviour
{
    public Transform BlockParent { set; get; }
    public GameObject SkillIconParent { set; get; }

    public int EffectID = 0;

    private bool moving = true;

    private void Update()
    {
        if (moving)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 cameraPosition = Input.mousePosition;
                cameraPosition.z = 10.0f;
                transform.position = Camera.main.ScreenToWorldPoint(cameraPosition);
            }
            else
            {
                foreach (Transform block in BlockParent)
                {
                    if ((block.position - transform.position).magnitude <= 0.1f)
                    {
                        transform.position = block.position;
                        block.GetComponent<Block>().SetEffect(EffectID);
                        transform.parent = block;
                        moving = false;
                        break;
                    }
                }
                if (moving)
                {
                    SkillIconParent.SetActive(true);
                    Destroy(gameObject);
                }
            }
        }
    }
}
