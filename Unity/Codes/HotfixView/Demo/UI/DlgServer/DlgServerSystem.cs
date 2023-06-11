using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    [FriendClass(typeof (ServerInfosComponent))]
    [FriendClass(typeof (DlgServer))]
    public static class DlgServerSystem
    {
        public static void RegisterUIEvent(this DlgServer self)
        {
            self.View.E_EnterServerButton.AddListenerAsync(() => { return self.OnConfilmClickHandler(); });
            self.View.ELoopScrollList_ServerLoopVerticalScrollRect.AddItemRefreshListener((Transform Transform, int index) =>
            {
                self.OnLoopListItemRefreshHandler(Transform, index);
            });
        }

        public static void ShowWindow(this DlgServer self, Entity contextData = null)
        {
            self.ServerList = self.DomainScene().GetComponent<ServerInfosComponent>().ServerInfoList;
            int count = self.ServerList.Count;
            self.AddUIScrollItems(ref self.ScrollItemServerDict, count);

            self.View.ELoopScrollList_ServerLoopVerticalScrollRect.SetVisible(true, count);
        }

        public static async ETTask OnConfilmClickHandler(this DlgServer self)
        {
            bool isSelect = self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId != 0;
            if (!isSelect)
            {
                Log.Error("请先选择服务器");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.GetRoles(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
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

        private static void OnLoopListItemRefreshHandler(this DlgServer self, Transform item, int index)
        {
            Scroll_Item_server itemServer = self.ScrollItemServerDict[index].BindTrans(item);
            ServerInfo info = self.ZoneScene().GetComponent<ServerInfosComponent>().ServerInfoList[index];
            itemServer.E_serverbgImage.color =
                    info.Id == self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId? Color.red : Color.cyan;
            itemServer.E_servertitleText.SetText(info.ServerName);
            itemServer.E_SelectButton.AddListener(() => { self.OnSelectServerItemHandler(info.Id); });
        }

        public static void HideWindow(this DlgServer self)
        {
            self.RemoveUIScrollItems(ref self.ScrollItemServerDict);
        }

        public static void OnSelectServerItemHandler(this DlgServer self, long serverId)
        {
            self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId = int.Parse(serverId.ToString());
            Log.Debug($"当前选择的服务器Id是:{serverId}");
            self.View.ELoopScrollList_ServerLoopVerticalScrollRect.RefillCells();
        }
    }
}