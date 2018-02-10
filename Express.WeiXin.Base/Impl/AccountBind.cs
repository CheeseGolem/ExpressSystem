using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Base.Impl
{
    using Express.BLL;
    using Express.Common;
    using Express.Model;
    using Express.WeiXin;
    using Senparc.Weixin.MP.AdvancedAPIs;
    using Senparc.Weixin.MP.AdvancedAPIs.User;

    public class AccountBind
    {
        Ep_UserBLL bllUser = new Ep_UserBLL();

        public Msg UserBinding(string bindname, string phone, string openid)
        {
            Msg msg = new Msg();
            msg.Result = false;
            Ep_User user = new Ep_User();

            List<string> sqlList = new List<string>();//存储sql语句

            //string user_id = "";//用来存储user_d作为副键，关联两张表

            user = GetEp_userByWeiXin(openid);
            user.Name = bindname;
            user.Phone = phone;
            try
            {
                bllUser.Add(user);
            }
            catch (Exception e)
            {
                string s = e.Message;
                throw;
            }

            string strWhere = " and openid='" + openid + "' ";
            //var UserList = bllUser.GetModelList(strWhere); 
            //获取微信信息
            //if (UserList.Count == 0)//判断本地是从存关注者信息
            //{
            //    user = GetEp_userByWeiXin(openid);
            //    user.Name = bindname;
            //    user.Phone = phone;
            //    bllUser.Add(user);
            //    //user_id = user.Id;
            //    //sqlList.Add(Pub_userDal.InsertSQL(user));
            //}
            //else
            //{
            //    //user_id = UserList.FirstOrDefault().Id;
            //}

            return msg;
        }

        /// <summary>
        /// 从微信服务器获取关注者信息
        /// </summary>
        /// <param name="openid"></param>
        public static Ep_User GetEp_userByWeiXin(string openid)
        {
            Ep_User user = new Ep_User();
            try
            {
                UserInfoJson WxUser = UserApi.Info(WeiXinConfigBase.AppID, openid);
                //user.UserId = Guid.NewGuid().ToString();
                user.HeadImage = WxUser.headimgurl;
                user.NickName = WxUser.nickname;
                user.OpenId = openid;
                //user.Sex = WxUser.sex.ToString();//1-男 2-女 0-未知
                user.CreateTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                user.Remark = ex.Message;
                return null;
            }
            return user;
        }

        /// <summary>
        /// 某个绑定号是否绑定到该微信下了
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="bindhaoma"></param>
        /// <returns></returns>
        public bool isBanding(string openid)
        {
            try
            {
                //var user = Pub_userDal.List(new Pub_user() { Openid = openid });
                //if (Pub_user_bindDal.List(new Pub_user_bind() { Bind_num = bindhaoma, User_id = user.FirstOrDefault().Id }).Count >= 1)
                //{
                //    return true;
                //}
                List<Ep_User> user = bllUser.GetModelList(" and openid='" + openid + "' ");
                if (user.Count >= 1)
                {
                    return true;
                }                
            }
            catch (Exception)
            {
            }

            return false;
        }
    }
}
