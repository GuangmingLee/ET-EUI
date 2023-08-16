﻿
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_RolesInfoDestroySystem : DestroySystem<Scroll_Item_RolesInfo> 
	{
		public override void Destroy( Scroll_Item_RolesInfo self )
		{
			self.DestroyWidget();
		}
	}
}