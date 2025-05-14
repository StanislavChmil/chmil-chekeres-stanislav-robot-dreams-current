using System.Collections.Generic;

public class SequenceNode : BTNode
{
    private List<BTNode> _nodes;

    public SequenceNode(List<BTNode> nodes) => _nodes = nodes;

    public override NodeState Evaluate()
    {
        bool anyRunning = false;

        foreach (var node in _nodes)
        {
            var result = node.Evaluate();
            if (result == NodeState.Failure)
            {
                _state = NodeState.Failure;
                return _state;
            }
            if (result == NodeState.Running)
                anyRunning = true;
        }

        _state = anyRunning ? NodeState.Running : NodeState.Success;
        return _state;
    }
}