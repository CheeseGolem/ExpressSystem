using System;
using System.Data;
using System.Collections.Generic;
using Express.Common;
using Express.Model;
namespace Express.BLL
{
	/// <summary>
	/// 用户信息
	/// </summary>
	public partial class AdminBLL
	{
		private readonly Express.Dal.AdminDAL dal=new Express.Dal.AdminDAL();
		public AdminBLL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserId)
		{
			return dal.Exists(UserId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Express.Model.Admin model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Express.Model.Admin model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int UserId)
		{
			
			return dal.Delete(UserId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string UserIdlist )
		{
			return dal.DeleteList(Express.Common.PageValidate.SafeLongFilter(UserIdlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Express.Model.Admin GetModel(int UserId)
		{
			
			return dal.GetModel(UserId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Express.Model.Admin GetModelByCache(int UserId)
		{
			
			string CacheKey = "AdminModel-" + UserId;
			object objModel = Express.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UserId);
					if (objModel != null)
					{
						int ModelCache = Express.Common.ConfigHelper.GetConfigInt("ModelCache");
						Express.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Express.Model.Admin)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Express.Model.Admin> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Express.Model.Admin> DataTableToList(DataTable dt)
		{
			List<Express.Model.Admin> modelList = new List<Express.Model.Admin>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Express.Model.Admin model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

        #region 根据用户名获取用户信息
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>用户实体</returns>
        public Admin GetModelByUsername(string username)
        {
            string where = " Username='" + username + "'";
            DataSet ds = this.GetList(where);
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                return null;
            }

            return dal.DataRowToModel(ds.Tables[0].Rows[0]);
        }

        /// <summary>
        /// 判断用户名是否已存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public bool isExistsUsername(string username, int userId)
        {
            object obj = dal.isExistsUsername(username,userId);
            if (Convert.ToInt32(obj) > 0)
            {
                return true;
            }
            return false;
        }

        public bool AddOrUpdate(Admin model)
        {
            if (model.UserId > 0)//修改
            {
                return dal.Update(model, !string.IsNullOrWhiteSpace(model.Password));
            }
            else//新增
            {
                return dal.Add(model) > 0;
            }
        }
        #endregion

		#endregion  ExtensionMethod
	}
}

