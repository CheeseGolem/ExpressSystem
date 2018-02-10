using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.WeiXin.Base.Common
{
    public enum WeiXinMenuType
    {
        /// <summary>
        /// 点击推事件用户点击click类型按钮后，微信服务器会通过消息接口推送消息类型为event的结构给开发者（参考消息接口指南），并且带上按钮中开发者填写的key值，开发者可以通过自定义的key值与用户进行交互
        /// </summary>
        [Description("click")]
        click,
        /// <summary>
        /// 跳转URL用户点击view类型按钮后，微信客户端将会打开开发者在按钮中填写的网页URL，可与网页授权获取用户基本信息接口结合，获得用户基本信息。
        /// </summary>
        [Description("view")]
        view,
    }


    /// <summary>
    ///用于同步科室
    /// </summary>
    public enum DepartmentLeiBie
    {

        [Description("门诊诊室")]
        门诊诊室,
        [Description("住院科室")]
        住院科室
    }

    /// <summary>
    /// 用于同步医生
    /// </summary>
    public enum DoctorZhicheng {
        
        医师,
        主治医师,
        住院医师,
        副主任医师,
        主任医师
    }
}
