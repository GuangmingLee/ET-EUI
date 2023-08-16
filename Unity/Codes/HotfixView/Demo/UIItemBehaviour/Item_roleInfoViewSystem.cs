
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_roleInfoDestroySystem : DestroySystem<Scroll_Item_roleInfo> 
	{
		public override void Destroy( Scroll_Item_roleInfo self )
		{
			self.DestroyWidget();
		}
	}
}
