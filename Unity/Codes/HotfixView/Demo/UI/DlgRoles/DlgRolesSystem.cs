using System;
using UnityEngine;

namespace ET
{
    [FriendClassAttribute(typeof (ET.RoleInfosComponent))]
    [FriendClassAttribute(typeof (ET.DlgRoles))]
    public static class DlgRolesSystem
    {
        public static void RegisterUIEvent(this DlgRoles self)
        {
            self.View.E_ConfirmButton.AddListenerAsync(() => { return self.OnConfirmClickHandler(); });
            self.View.E_CreateRoleButton.AddListenerAsync(() => { return self.OnCreateRoleClickHandler(); });
            self.View.E_DeleteRoleButton.AddListenerAsync(() => { return self.onDeleteRoleClickHandler(); });
            self.View.ELoopScrollList_RolesLoopHorizontalScrollRect.AddItemRefreshListener((Transform Transform, int index) =>
            {
                self.OnRoleListRefreshHandler(Transform, index);
            });
        }

        public static void ShowWindow(this DlgRoles self, Entity contextData = null)
        {
            self.RefreshRoleItems();
        }

        public static void HideWindow(this DlgRoles self)
        {
        }

        public static void RefreshRoleItems(this DlgRoles self)
        {
            int count = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos.Count;
            self.AddUIScrollItems(ref self.ScrollItemRoles, count);
            self.View.ELoopScrollList_RolesLoopHorizontalScrollRect.SetVisible(true, count);
        }

        public static void OnRoleListRefreshHandler(this DlgRoles self, Transform transform, int index)
        {
        }

        public static async ETTask OnConfirmClickHandler(this DlgRoles self)
        {
            await ETTask.CompletedTask;
        }

        public static async ETTask OnCreateRoleClickHandler(this DlgRoles self)
        {
            string name = self.View.E_InputNameInputField.text;
            if (string.IsNullOrEmpty(name))
            {
                Log.Error("Name is Null");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.CreateRole(self.ZoneScene(), name);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                self.RefreshRoleItems();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        public static async ETTask onDeleteRoleClickHandler(this DlgRoles self)
        {
            if (self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == 0)
            {
                Log.Error("请选择要删除的角色");
                return;
            }

            try
            {
                int errorrCode = await LoginHelper.DeleteRole(self.ZoneScene());
                if (errorrCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorrCode.ToString());
                    return;
                }

                self.RefreshRoleItems();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }
}