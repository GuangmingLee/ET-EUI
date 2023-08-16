
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class Scroll_Item_server : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_server BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

<<<<<<< HEAD
		public UnityEngine.UI.Image E_serverbgImage
=======
		public UnityEngine.UI.Button E_selectButton
>>>>>>> main
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
<<<<<<< HEAD
     				if( this.m_E_serverbgImage == null )
     				{
		    			this.m_E_serverbgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_serverbg");
     				}
     				return this.m_E_serverbgImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_serverbg");
=======
     				if( this.m_E_selectButton == null )
     				{
		    			this.m_E_selectButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_select");
     				}
     				return this.m_E_selectButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_select");
>>>>>>> main
     			}
     		}
     	}

<<<<<<< HEAD
		public UnityEngine.UI.Text E_servertitleText
=======
		public UnityEngine.UI.Image E_selectImage
>>>>>>> main
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
<<<<<<< HEAD
     				if( this.m_E_servertitleText == null )
     				{
		    			this.m_E_servertitleText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_servertitle");
     				}
     				return this.m_E_servertitleText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_servertitle");
=======
     				if( this.m_E_selectImage == null )
     				{
		    			this.m_E_selectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_select");
     				}
     				return this.m_E_selectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_select");
>>>>>>> main
     			}
     		}
     	}

<<<<<<< HEAD
		public UnityEngine.UI.Button E_SelectButton
=======
		public UnityEngine.UI.Text ELabel_serverText
>>>>>>> main
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
<<<<<<< HEAD
     				if( this.m_E_SelectButton == null )
     				{
		    			this.m_E_SelectButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Select");
     				}
     				return this.m_E_SelectButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Select");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_SelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_E_SelectImage == null )
     				{
		    			this.m_E_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Select");
     				}
     				return this.m_E_SelectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Select");
=======
     				if( this.m_ELabel_serverText == null )
     				{
		    			this.m_ELabel_serverText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_server");
     				}
     				return this.m_ELabel_serverText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_server");
>>>>>>> main
     			}
     		}
     	}

		public void DestroyWidget()
		{
<<<<<<< HEAD
			this.m_E_serverbgImage = null;
			this.m_E_servertitleText = null;
			this.m_E_SelectButton = null;
			this.m_E_SelectImage = null;
=======
			this.m_E_selectButton = null;
			this.m_E_selectImage = null;
			this.m_ELabel_serverText = null;
>>>>>>> main
			this.uiTransform = null;
			this.DataId = 0;
		}

<<<<<<< HEAD
		private UnityEngine.UI.Image m_E_serverbgImage = null;
		private UnityEngine.UI.Text m_E_servertitleText = null;
		private UnityEngine.UI.Button m_E_SelectButton = null;
		private UnityEngine.UI.Image m_E_SelectImage = null;
=======
		private UnityEngine.UI.Button m_E_selectButton = null;
		private UnityEngine.UI.Image m_E_selectImage = null;
		private UnityEngine.UI.Text m_ELabel_serverText = null;
>>>>>>> main
		public Transform uiTransform = null;
	}
}
