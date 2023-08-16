namespace ET
{
    [FriendClass(typeof (WindowCoreData))]
    [FriendClass(typeof (UIBaseWindow))]
    [AUIEvent(WindowID.WindowID_Roles)]
    public class DlgRolesEventHandler: IAUIEventHandler
    {
        public void OnInitWindowCoreData(UIBaseWindow uiBaseWindow)
        {
<<<<<<< HEAD
            uiBaseWindow.WindowData.windowType = UIWindowType.Normal; 
=======
            uiBaseWindow.WindowData.windowType = UIWindowType.Normal;
>>>>>>> main
        }

        public void OnInitComponent(UIBaseWindow uiBaseWindow)
        {
<<<<<<< HEAD
            uiBaseWindow.AddComponent<DlgRolesViewComponent>(); 
            uiBaseWindow.AddComponent<DlgRoles>(); 
=======
            uiBaseWindow.AddComponent<DlgRolesViewComponent>();
            uiBaseWindow.AddComponent<DlgRoles>();
>>>>>>> main
        }

        public void OnRegisterUIEvent(UIBaseWindow uiBaseWindow)
        {
<<<<<<< HEAD
            uiBaseWindow.GetComponent<DlgRoles>().RegisterUIEvent(); 
=======
            uiBaseWindow.GetComponent<DlgRoles>().RegisterUIEvent();
>>>>>>> main
        }

        public void OnShowWindow(UIBaseWindow uiBaseWindow, Entity contextData = null)
        {
<<<<<<< HEAD
            uiBaseWindow.GetComponent<DlgRoles>().ShowWindow(contextData); 
=======
            uiBaseWindow.GetComponent<DlgRoles>().ShowWindow(contextData);
>>>>>>> main
        }

        public void OnHideWindow(UIBaseWindow uiBaseWindow)
        {
            uiBaseWindow.GetComponent<DlgRoles>().HideWindow();
        }

        public void BeforeUnload(UIBaseWindow uiBaseWindow)
        {
<<<<<<< HEAD
            throw new System.NotImplementedException();
=======
>>>>>>> main
        }
    }
}