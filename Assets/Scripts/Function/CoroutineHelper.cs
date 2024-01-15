using System.Collections;
using UnityEngine;

public static class CoroutineHelper
{
    public static IEnumerator DelaySeconds(System.Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action();
    }
}
