using System.Collections.Generic;

public class UndirectedGraphNode {
    public int label;
    public IList<UndirectedGraphNode> neighbors;
    public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
};
