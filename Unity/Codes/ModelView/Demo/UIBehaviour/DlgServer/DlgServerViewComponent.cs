
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgServerViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ConfirmServerButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmServerButton == null )
     			{
		    		this.m_E_ConfirmServerButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/E_ConfirmServer");
     			}
     			return this.m_E_ConfirmServerButton;
     		}
     	}

		public UnityEngine.UI.Image E_ConfirmServerImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmServerImage == null )
     			{
		    		this.m_E_ConfirmServerImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/E_ConfirmServer");
     			}
     			return this.m_E_ConfirmServerImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_ServerListLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ServerListLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ServerListLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Sprite_BackGround/E_ServerList");
     			}
     			return this.m_E_ServerListLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ConfirmServerButton = null;
			this.m_E_ConfirmServerImage = null;
			this.m_E_ServerListLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ConfirmServerButton = null;
		private UnityEngine.UI.Image m_E_ConfirmServerImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_ServerListLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
