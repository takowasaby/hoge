using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillIcon : MonoBehaviour
{
    [SerializeField]
    private GameObject skillIconInField;

    [SerializeField]
    private Transform blockParent;

    private GameObject skillIconInFieldIns;

    public void Awake()
    {
        if (skillIconInFieldIns != null)
        {
            Destroy(skillIconInFieldIns);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                if (hit2d.transform.gameObject == gameObject)
                {
                    skillIconInFieldIns = Instantiate(skillIconInField, transform.position, transform.rotation);
                    SkillIconInField skillIconInFieldComponet = skillIconInFieldIns.GetComponent<SkillIconInField>();
                    skillIconInFieldComponet.BlockParent = blockParent;
                    skillIconInFieldComponet.SkillIconParent = gameObject;
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
