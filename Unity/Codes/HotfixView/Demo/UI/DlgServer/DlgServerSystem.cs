using System.Collections;
using System.Collections.Generic;
using System;
using CommandLine;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof (DlgServer))]
    [FriendClassAttribute(typeof (ET.ServerInfosComponent))]
    public static class DlgServerSystem
    {
        public static void RegisterUIEvent(this DlgServer self)
        {
            self.View.E_ConfirmServerButton.AddListenerAsync(() => { return self.OnConfirmClickHandler(); });
            self.View.E_ServerListLoopVerticalScrollRect.AddItemRefreshListener(((Transform transform, int index) =>
            {
                self.OnScrollItemRefreshHandler(transform, index);
            }));
        }

        public static void ShowWindow(this DlgServer self, Entity contextData = null)
        {
            int count = self.ZoneScene().GetComponent<ServerInfosComponent>().serverInfoList.Count;
            self.AddUIScrollItems(ref self.ScrollItemServerTests, count);
            self.View.E_ServerListLoopVerticalScrollRect.SetVisible(true, count);
        }

        public static void HideWindow(this DlgServer self)
        {
            self.RemoveUIScrollItems(ref self.ScrollItemServerTests);
        }

        public static void OnScrollItemRefreshHandler(this DlgServer self, Transform transform, int index)
        {
            Scroll_Item_server serverTest = self.ScrollItemServerTests[index].BindTrans(transform);
            ServerInfo info = self.ZoneScene().GetComponent<ServerInfosComponent>().serverInfoList[index];
            serverTest.E_selectImage.color =
                    info.Id == self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId? Color.red : Color.blue;
            serverTest.ELabel_serverText.SetText(info.serverName);
            serverTest.E_selectButton.AddListener(() => self.OnSelectServerItemHandler(info.Id));
        }

        public static void OnSelectServerItemHandler(this DlgServer self, long serverId)
        {
            self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId = int.Parse(serverId.ToString());
            Log.Debug($"当前选择的服务器是{serverId}");
            self.View.E_ServerListLoopVerticalScrollRect.RefillCells();
        }

        public static async ETTask OnConfirmClickHandler(this DlgServer self)
        {
            bool isSelect = self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId != 0;
            if (!isSelect)
            {
                Log.Error("请先选择区服");
                return;
            }

            try
            {
                int errorcode = await LoginHelper.GetRoles(self.ZoneScene());

                if (errorcode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorcode.ToString());
                    return;
                }
                
                self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Roles);
                self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Server);
                
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }
}