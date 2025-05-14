using System.Collections.Generic;

public class SelectorNode : BTNode
{
    private List<BTNode> _nodes;

    public SelectorNode(List<BTNode> nodes) => _nodes = nodes;

    public override NodeState Evaluate()
    {
        foreach (var node in _nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.Success:
                    _state = NodeState.Success;
                    return _state;
                case NodeState.Running:
                    _state = NodeState.Running;
                    return _state;
            }
        }
        _state = NodeState.Failure;
        return _state;
    }
}