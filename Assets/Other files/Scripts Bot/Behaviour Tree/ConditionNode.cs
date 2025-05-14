using System;

public class ConditionNode : BTNode
{
    private Func<bool> _condition;

    public ConditionNode(Func<bool> condition) => _condition = condition;

    public override NodeState Evaluate()
    {
        return _condition() ? NodeState.Success : NodeState.Failure;
    }
}