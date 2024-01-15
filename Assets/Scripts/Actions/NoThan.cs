using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoThan : MonoBehaviour
{
    public GameObject noThanSkill;
    public GameObject noThanPos;

    public void NoThanButton()
    {
        // random from -10 to 10
        float random = Random.Range(-30f, 20f);

        GameObject skill = Instantiate(noThanSkill, new Vector3(noThanPos.transform.position.x + random, noThanPos.transform.position.y + random, noThanPos.transform.position.z), Quaternion.identity);
        Animator animator = skill.GetComponentInChildren<Animator>();

        int randomSkill = Random.Range(1, 3);
        if (randomSkill == 1)
        {
            animator.SetTrigger("skill1");
        }
        else
        {
            animator.SetTrigger("skill2");
        }
    }
}
