﻿using System;
using System.Data;
using System.Collections.Generic;
using Express.Common;
using Express.Model;
namespace Express.BLL
{
	/// <summary>
	/// User
	/// </summary>
	public partial class UserBLL
	{
		private readonly Express.DAL.UserDAL dal=new Express.DAL.UserDAL();
		public UserBLL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string UserId)
		{
			return dal.Exists(UserId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Express.Model.User model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Express.Model.User model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string UserId)
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
		public Express.Model.User GetModel(string UserId)
		{
			
			return dal.GetModel(UserId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Express.Model.User GetModelByCache(string UserId)
		{
			
			string CacheKey = "UserModel-" + UserId;
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
			return (Express.Model.User)objModel;
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
		public List<Express.Model.User> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Express.Model.User> DataTableToList(DataTable dt)
		{
			List<Express.Model.User> modelList = new List<Express.Model.User>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Express.Model.User model;
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

		#endregion  ExtensionMethod
	}
}

