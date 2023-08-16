
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgServerViewComponent : Entity,IAwake,IDestroy 
	{
<<<<<<< HEAD
		public UnityEngine.UI.Button E_EnterServerButton
=======
		public UnityEngine.UI.Button E_ConfirmServerButton
>>>>>>> main
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
<<<<<<< HEAD
     			if( this.m_E_EnterServerButton == null )
     			{
		    		this.m_E_EnterServerButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/E_EnterServer");
     			}
     			return this.m_E_EnterServerButton;
     		}
     	}

		public UnityEngine.UI.Image E_EnterServerImage
=======
     			if( this.m_E_ConfirmServerButton == null )
     			{
		    		this.m_E_ConfirmServerButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/E_ConfirmServer");
     			}
     			return this.m_E_ConfirmServerButton;
     		}
     	}

		public UnityEngine.UI.Image E_ConfirmServerImage
>>>>>>> main
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
<<<<<<< HEAD
     			if( this.m_E_EnterServerImage == null )
     			{
		    		this.m_E_EnterServerImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/E_EnterServer");
     			}
     			return this.m_E_EnterServerImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_ServerLoopVerticalScrollRect
=======
     			if( this.m_E_ConfirmServerImage == null )
     			{
		    		this.m_E_ConfirmServerImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/E_ConfirmServer");
     			}
     			return this.m_E_ConfirmServerImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_ServerListLoopVerticalScrollRect
>>>>>>> main
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
<<<<<<< HEAD
     			if( this.m_ELoopScrollList_ServerLoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_ServerLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Sprite_BackGround/ELoopScrollList_Server");
     			}
     			return this.m_ELoopScrollList_ServerLoopVerticalScrollRect;
=======
     			if( this.m_E_ServerListLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ServerListLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Sprite_BackGround/E_ServerList");
     			}
     			return this.m_E_ServerListLoopVerticalScrollRect;
>>>>>>> main
     		}
     	}

		public void DestroyWidget()
		{
<<<<<<< HEAD
			this.m_E_EnterServerButton = null;
			this.m_E_EnterServerImage = null;
			this.m_ELoopScrollList_ServerLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_EnterServerButton = null;
		private UnityEngine.UI.Image m_E_EnterServerImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_ServerLoopVerticalScrollRect = null;
=======
			this.m_E_ConfirmServerButton = null;
			this.m_E_ConfirmServerImage = null;
			this.m_E_ServerListLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ConfirmServerButton = null;
		private UnityEngine.UI.Image m_E_ConfirmServerImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_ServerListLoopVerticalScrollRect = null;
>>>>>>> main
		public Transform uiTransform = null;
	}
}
