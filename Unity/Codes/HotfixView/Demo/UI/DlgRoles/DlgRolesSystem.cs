<<<<<<< HEAD
﻿using System;
using UnityEngine;

namespace ET
{
    [FriendClassAttribute(typeof (ET.RoleInfosComponent))]
    [FriendClassAttribute(typeof (ET.DlgRoles))]
=======
﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof (DlgRoles))]
    [FriendClassAttribute(typeof (ET.RoleInfosComponent))]
    [FriendClassAttribute(typeof (ET.RoleInfo))]
>>>>>>> main
    public static class DlgRolesSystem
    {
        public static void RegisterUIEvent(this DlgRoles self)
        {
<<<<<<< HEAD
            self.View.E_ConfirmButton.AddListenerAsync(() => { return self.OnConfirmClickHandler(); });
            self.View.E_CreateRoleButton.AddListenerAsync(() => { return self.OnCreateRoleClickHandler(); });
            self.View.E_DeleteRoleButton.AddListenerAsync(() => { return self.onDeleteRoleClickHandler(); });
            self.View.ELoopScrollList_RolesLoopHorizontalScrollRect.AddItemRefreshListener((Transform Transform, int index) =>
            {
                self.OnRoleListRefreshHandler(Transform, index);
            });
=======
            self.View.E_CreateRoleButton.AddListenerAsync(() => { return self.OnClickCreateRoleHandler(); });
            self.View.E_DeleteRoleButton.AddListenerAsync(() => { return self.OnClickDelteRoleHandler(); });
            self.View.E_StartGameButton.AddListenerAsync(() => { return self.OnEnterGameHandler(); });
            self.View.E_RoleLoopHorizontalScrollRect.AddItemRefreshListener(((Transform transform, int index) =>
            {
                self.OnRoleListRefreshHandler(transform, index);
            }));
>>>>>>> main
        }

        public static void ShowWindow(this DlgRoles self, Entity contextData = null)
        {
            self.RefreshRoleItems();
        }

<<<<<<< HEAD
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
=======
        public static void RefreshRoleItems(this DlgRoles self)
        {
            int count = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos.Count;
            self.AddUIScrollItems(ref self.ScrollItemRoleInfos, count);
            self.View.E_RoleLoopHorizontalScrollRect.SetVisible(true, count);
        }

        public static void HideWindow(this DlgRoles self)
        {
            self.RemoveUIScrollItems(ref self.ScrollItemRoleInfos);
        }

        public static async ETTask OnClickCreateRoleHandler(this DlgRoles self)
        {
            var name = self.View.E_InputNameInputField.text;
            if (string.IsNullOrEmpty(name))
            {
                Log.Error("名字不能为空");
>>>>>>> main
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

<<<<<<< HEAD
        public static async ETTask onDeleteRoleClickHandler(this DlgRoles self)
        {
            if (self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == 0)
            {
                Log.Error("请选择要删除的角色");
=======
        public static async ETTask OnClickDelteRoleHandler(this DlgRoles self)
        {
            var roleId = self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId;
            if (roleId == 0)
            {
                Log.Error($"未选中要删除的角色");
>>>>>>> main
                return;
            }

            try
            {
<<<<<<< HEAD
                int errorrCode = await LoginHelper.DeleteRole(self.ZoneScene());
                if (errorrCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorrCode.ToString());
                    return;
                }

=======
                int errorCode = await LoginHelper.DeleteRole(self.ZoneScene(), roleId);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId = 0;
>>>>>>> main
                self.RefreshRoleItems();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
<<<<<<< HEAD
=======

        public static void OnRoleListRefreshHandler(this DlgRoles self, Transform transform, int index)
        {
            Scroll_Item_roleInfo roleInfoItem = self.ScrollItemRoleInfos[index].BindTrans(transform);
            RoleInfo roleInfo = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos[index];
            roleInfoItem.E_RoleNameText.SetText(roleInfo.Name);
            roleInfoItem.E_RoleBgImage.color =
                    roleInfo.Id == self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId? Color.red : Color.black;
            roleInfoItem.E_RoleBgButton.AddListener(() => self.OnSelectRoleInfoItemHandler(roleInfo.Id));
        }

        public static void OnSelectRoleInfoItemHandler(this DlgRoles self, long roleInfoId)
        {
            self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId = roleInfoId;
            Log.Debug($"当前选择的角色id是{roleInfoId}");
            self.View.E_RoleLoopHorizontalScrollRect.RefillCells();
        }

        public static async ETTask OnEnterGameHandler(this DlgRoles self)
        {
            if (self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == 0)
            {
                Log.Error("未选择角色");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.GetRealmKey(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                errorCode = await LoginHelper.EnterGame(self.ZoneScene());
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            await ETTask.CompletedTask;
        }
>>>>>>> main
    }
}