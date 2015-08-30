using System;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;

namespace iPOS.IMC.Tool
{
    public class TreeListChangeChildNodesOperation : TreeListOperation
    {
        private TreeListColumn _column;
        private bool _state;
        private TreeListNode _parentNode;

        public TreeListChangeChildNodesOperation(TreeListColumn column, TreeListNode node, bool state)
        {
            this._column = column;
            this._state = state;
            this._parentNode = node;
        }

        public override void Execute(TreeListNode node)
        {
            if (node.HasAsParent(_parentNode))
                node.SetValue(_column, _state);
            else
            {
                if (_parentNode.HasAsParent(node))
                    if (_state)
                        node[_column] = _state;
                    else node[_column] = !_state;
            }
        }

        public override bool NeedsVisitChildren(TreeListNode node) { return true; }
    }
}
