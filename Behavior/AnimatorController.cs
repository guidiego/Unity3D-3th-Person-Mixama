using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {

        _animator = GetComponent<Animator>();
    }

    public void MoveState(bool state)
    {
        _animator.SetBool("Move", state);
    }

    public void RunState(bool state)
    {
        _animator.SetBool("Run", state);
    }
}
