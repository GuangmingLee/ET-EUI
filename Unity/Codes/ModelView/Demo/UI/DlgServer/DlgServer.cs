using System.Collections.Generic;

namespace ET
{
<<<<<<< HEAD
    [ComponentOf(typeof(UIBaseWindow))]
=======
    [ComponentOf(typeof (UIBaseWindow))]
>>>>>>> main
    public class DlgServer: Entity, IAwake, IUILogic
    {
        public DlgServerViewComponent View
        {
            get => this.Parent.GetComponent<DlgServerViewComponent>();
        }
<<<<<<< HEAD

        public Dictionary<int, Scroll_Item_server> ScrollItemServerDict;

        public List<ServerInfo> ServerList;
=======
        public Dictionary<int, Scroll_Item_server> ScrollItemServerTests = new Dictionary<int, Scroll_Item_server>();
>>>>>>> main
    }
}