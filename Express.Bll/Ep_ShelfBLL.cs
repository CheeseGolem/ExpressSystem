using System;
using System.Data;
using System.Collections.Generic;
using Express.Common;
using Express.Model;
namespace Express.BLL
{
	/// <summary>
	/// Ep_ShelfBLL
	/// </summary>
	public partial class Ep_ShelfBLL
	{
		private readonly Express.DAL.Ep_ShelfDAL dal=new Express.DAL.Ep_ShelfDAL();
		public Ep_ShelfBLL()
		{}
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SId)
        {
            return dal.Exists(SId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Express.Model.Ep_Shelf model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Express.Model.Ep_Shelf model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int SId)
        {

            return dal.Delete(SId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SIdlist)
        {
            return dal.DeleteList(Express.Common.PageValidate.SafeLongFilter(SIdlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Express.Model.Ep_Shelf GetModel(int SId)
        {

            return dal.GetModel(SId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Express.Model.Ep_Shelf GetModelByCache(int SId)
        {

            string CacheKey = "Ep_ShelfModel-" + SId;
            object objModel = Express.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(SId);
                    if (objModel != null)
                    {
                        int ModelCache = Express.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Express.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Express.Model.Ep_Shelf)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Express.Model.Ep_Shelf> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Express.Model.Ep_Shelf> DataTableToList(DataTable dt)
        {
            List<Express.Model.Ep_Shelf> modelList = new List<Express.Model.Ep_Shelf>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Express.Model.Ep_Shelf model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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

