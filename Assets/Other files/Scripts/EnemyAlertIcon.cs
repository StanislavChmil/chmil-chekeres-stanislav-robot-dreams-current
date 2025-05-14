using UnityEngine;
using UnityEngine.UI;

public class EnemyAlertIcon : MonoBehaviour
{
    [Header("Иконки")]
    public Sprite questionMark;
    public Sprite exclamationMark;

    [Header("Цвета")]
    public Color patrolColor = Color.gray;
    public Color alertColor = Color.red;

    private Image alertImage;
    private Animator animator;

    void Start()
    {
        alertImage = GetComponentInChildren<Image>();
        animator = GetComponentInParent<Animator>();
    }

    void Update()
    {
        if (animator == null || alertImage == null) return;

        bool isChasing = animator.GetBool("isChasing");
        bool isAttacking = animator.GetBool("isAttacking");
        bool isPatrolling = animator.GetBool("isPatrolling");

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        bool isIdleState = stateInfo.IsName("Idle");

        if (isChasing || isAttacking)
        {
            alertImage.sprite = exclamationMark;
            alertImage.color = alertColor;
            alertImage.enabled = true;
        }
        else if (isPatrolling || isIdleState)
        {
            alertImage.sprite = questionMark;
            alertImage.color = patrolColor;
            alertImage.enabled = true;
        }
        else
        {
            alertImage.enabled = false;
        }
    }
}