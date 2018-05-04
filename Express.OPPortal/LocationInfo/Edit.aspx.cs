using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Express.OPPortal.LocationInfo
{
    using Express.BLL;
    using Express.Common;
    using Express.Model;

    public partial class Edit : PageBase
    {
        Ep_ShelfBLL bllShelf = new Ep_ShelfBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定快递状态
                BindExpressType();

                //判断新建页或编辑页
                string strId = Request.QueryString["id"];
                if (!string.IsNullOrWhiteSpace(strId))
                {
                    BindData(Convert.ToInt32(strId));
                }
            }
        }

        private void BindExpressType()
        {
            ddlShelfType.Items.Add(new ListItem("普通件", "1"));
            ddlShelfType.Items.Add(new ListItem("贵重件", "2"));
            ddlShelfType.Items.Add(new ListItem("大体积", "3"));
            //设置默认选中项
            ddlShelfType.SelectedValue = "1";            

            List<Ep_Shelf> listShelfEntity = new List<Ep_Shelf>();
            listShelfEntity = bllShelf.GetModelList("");

            List<string> listShelf = new List<string>();
            for (int i = 1; i <= 10; i++)
            {
                listShelf.Add(i.ToString("D2"));
                //ddlShelf.Items.Add(new ListItem(i.ToString("D2"), i.ToString()));
            }
            foreach (var item in listShelfEntity)
            {
                listShelf.Remove(item.Location);
            }
            //ddlShelf.SelectedValue = "1";
            ddlShelf.DataSource = listShelf;
            ddlShelf.DataBind();

            List<string> listLocation = new List<string>();
            for (int i = 1; i <= 10; i++)
            {
                
                listLocation.Add(i.ToString("D2"));
                //ddlLocation.Items.Add(new ListItem(i.ToString("D2"), i.ToString()));
            }
            //foreach (var item in listShelfEntity)
            //{
            //    listLocation.Remove(item.Shelf);
            //}
            //ddlLocation.SelectedValue = "1";            
            ddlLocation.DataSource = listLocation;
            ddlLocation.DataBind();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="userId">用户编号</param>
        private void BindData(int id)
        {
            //1.0 从数据库读取数据            
            Ep_Shelf model = bllShelf.GetModel(id);

            //2.0 将数据设置到控件上
            //非空验证
            if (model == null)
            {
                return;
            }

            ddlShelf.Text = model.Shelf;
            ddlLocation.Text = model.Location;
            ddlShelfType.Text = model.Type.ToString();
            txtRemark.Text = model.Remark;

            ViewState["id"] = model.SId;//将原数据保存在隐藏域中
            //viewstate 只保存ID
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Ep_Shelf model = new Ep_Shelf();
            model.Shelf = ddlShelf.SelectedValue;
            model.Location = ddlLocation.SelectedValue;
            model.Type = Convert.ToInt32(ddlShelfType.SelectedValue);
            model.Remark = txtRemark.Text;

            if (ViewState["id"] != null)//修改
            {                
                model.SId = Convert.ToInt32(ViewState["id"]);
                model.CreateTime = bllShelf.GetModel(model.SId).CreateTime;
                model.UpdateTime = DateTime.Now;

                bllShelf.Update(model);
                ScriptHelper.AlertRedirect("更新成功", "/LocationInfo/List.aspx");
            }
            else//新增
            {                
                model.CreateTime = DateTime.Now;
                model.UpdateTime = DateTime.Now;
                bllShelf.Add(model);
                ScriptHelper.AlertRedirect("添加成功", "/LocationInfo/List.aspx");
            }
        }
    }
}