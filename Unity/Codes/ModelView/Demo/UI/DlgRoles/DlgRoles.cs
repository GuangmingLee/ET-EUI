using System.Collections.Generic;

namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgRoles :Entity,IAwake,IUILogic
	{

<<<<<<< HEAD
		public DlgRolesViewComponent View { get => this.Parent.GetComponent<DlgRolesViewComponent>();}

		public Dictionary<int, Scroll_Item_RolesInfo> ScrollItemRoles = new Dictionary<int, Scroll_Item_RolesInfo>();
=======
		public DlgRolesViewComponent View { get => this.Parent.GetComponent<DlgRolesViewComponent>();} 

		public Dictionary<int, Scroll_Item_roleInfo> ScrollItemRoleInfos = new Dictionary<int, Scroll_Item_roleInfo>();
>>>>>>> main

	}
}
