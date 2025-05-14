public abstract class BTNode
{
    public enum NodeState { Running, Success, Failure }
    protected NodeState _state;

    public abstract NodeState Evaluate();
}