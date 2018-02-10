using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Express.Common;
using Express.Model;
namespace Express.BLL
{
    //Ep_Answer
    public partial class Ep_AnswerBLL
    {

        private readonly Express.DAL.Ep_AnswerDAL dal = new Express.DAL.Ep_AnswerDAL();
        public Ep_AnswerBLL()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AId)
        {
            return dal.Exists(AId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Express.Model.Ep_Answer model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Express.Model.Ep_Answer model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AId)
        {

            return dal.Delete(AId);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string AIdlist)
        {
            return dal.DeleteList(AIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Express.Model.Ep_Answer GetModel(int AId)
        {

            return dal.GetModel(AId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Express.Model.Ep_Answer GetModelByCache(int AId)
        {

            string CacheKey = "Ep_AnswerModel-" + AId;
            object objModel = Express.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(AId);
                    if (objModel != null)
                    {
                        int ModelCache = Express.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Express.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Express.Model.Ep_Answer)objModel;
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
        public List<Express.Model.Ep_Answer> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Express.Model.Ep_Answer> DataTableToList(DataTable dt)
        {
            List<Express.Model.Ep_Answer> modelList = new List<Express.Model.Ep_Answer>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Express.Model.Ep_Answer model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Express.Model.Ep_Answer();
                    if (dt.Rows[n]["AId"].ToString() != "")
                    {
                        model.AId = int.Parse(dt.Rows[n]["AId"].ToString());
                    }
                    if (dt.Rows[n]["QId"].ToString() != "")
                    {
                        model.QId = int.Parse(dt.Rows[n]["QId"].ToString());
                    }
                    model.AContent = dt.Rows[n]["AContent"].ToString();
                    if (dt.Rows[n]["ATime"].ToString() != "")
                    {
                        model.ATime = DateTime.Parse(dt.Rows[n]["ATime"].ToString());
                    }


                    modelList.Add(model);
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
        #endregion

        #region  ExtensionMethod

        public bool HasAnswerByQId(int qId)
        {
            return dal.HasAnswerByQId(qId);
        }
        #endregion  ExtensionMethod
    }
}