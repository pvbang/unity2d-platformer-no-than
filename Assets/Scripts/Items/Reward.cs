using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    public bool sureReward = false;
    public GameObject[] reward;

    public void RewardItem()
    {
        if (sureReward)
        {
            RandomReward();
        }
        else
        {
            bool isReward = Random.Range(0, 2) == 0;
            if (isReward)
            {
                RandomReward();
            }
        }
    }

    private void RandomReward()
    {
        int random = Random.Range(0, reward.Length);
        Instantiate(reward[random], new Vector3(transform.position.x, -3.3f, transform.position.z), Quaternion.identity);
    }
}
