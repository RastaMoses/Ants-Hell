using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingTent : MonoBehaviour
{
    [SerializeField] int charges = 3;
    [SerializeField] float activationTime = 10f;
    [SerializeField] float moveSpeedMultiplier = 1.7f;
    [SerializeField] GameObject cosntructionZone;

    PlayerController player;
    bool buffIsActive;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !buffIsActive)
        {
            buffIsActive = true;
            charges--;
            player = collision.GetComponent<PlayerController>();
            StartCoroutine(Buff());
        }
    }

    IEnumerator Buff()
    {
        player.stats.Buff(moveSpeedMultiplier);
        yield return new WaitForSeconds(activationTime);
        player.stats.Debuff();
        if (charges <= 0)
        {
            Instantiate(cosntructionZone, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        buffIsActive = false;
    }
}
