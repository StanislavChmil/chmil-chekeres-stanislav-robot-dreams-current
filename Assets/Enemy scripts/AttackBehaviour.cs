using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    Transform player;
    PlayerHealth playerHealth;

    public int damage = 10;
    public float attackInterval = 1.5f; // наносим урон каждые 1.5 сек

    float timer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            playerHealth = playerObj.GetComponent<PlayerHealth>();
        }

        timer = 0f;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null || playerHealth == null) return;

        animator.transform.LookAt(player);

        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance > 3f)
        {
            animator.SetBool("isAttacking", false);
            return;
        }

        timer += Time.deltaTime;

        if (timer >= attackInterval)
        {
            playerHealth.TakeDamage(damage);
            timer = 0f; // сбрасываем таймер
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0f; // сбрасываем на выходе
    }
}