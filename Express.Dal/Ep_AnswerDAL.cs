using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Express.DBUtility;
namespace Express.DAL
{
    //Ep_Answer
    public partial class Ep_AnswerDAL
    {

        #region method
        public bool Exists(int AId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ep_Answer");
            strSql.Append(" where ");
            strSql.Append(" AId = @AId  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@AId", SqlDbType.Int,4)
            };
            parameters[0].Value = AId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Express.Model.Ep_Answer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ep_Answer(");
            strSql.Append("QId,AContent,ATime");
            strSql.Append(") values (");
            strSql.Append("@QId,@AContent,@ATime");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@QId", SqlDbType.Int,4) ,
                        new SqlParameter("@AContent", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@ATime", SqlDbType.DateTime)

            };

            parameters[0].Value = model.QId;
            parameters[1].Value = model.AContent;
            parameters[2].Value = model.ATime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {

                return Convert.ToInt32(obj);

            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Express.Model.Ep_Answer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ep_Answer set ");

            strSql.Append(" QId = @QId , ");
            strSql.Append(" AContent = @AContent , ");
            strSql.Append(" ATime = @ATime  ");
            strSql.Append(" where AId=@AId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@AId", SqlDbType.Int,4) ,
                        new SqlParameter("@QId", SqlDbType.Int,4) ,
                        new SqlParameter("@AContent", SqlDbType.NVarChar,200) ,
                        new SqlParameter("@ATime", SqlDbType.DateTime)

            };

            parameters[0].Value = model.AId;
            parameters[1].Value = model.QId;
            parameters[2].Value = model.AContent;
            parameters[3].Value = model.ATime;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ep_Answer ");
            strSql.Append(" where AId=@AId");
            SqlParameter[] parameters = {
                    new SqlParameter("@AId", SqlDbType.Int,4)
            };
            parameters[0].Value = AId;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string AIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ep_Answer ");
            strSql.Append(" where ID in (" + AIdlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Express.Model.Ep_Answer GetModel(int AId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AId, QId, AContent, ATime  ");
            strSql.Append("  from Ep_Answer ");
            strSql.Append(" where AId=@AId");
            SqlParameter[] parameters = {
                    new SqlParameter("@AId", SqlDbType.Int,4)
            };
            parameters[0].Value = AId;


            Express.Model.Ep_Answer model = new Express.Model.Ep_Answer();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AId"].ToString() != "")
                {
                    model.AId = int.Parse(ds.Tables[0].Rows[0]["AId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["QId"].ToString() != "")
                {
                    model.QId = int.Parse(ds.Tables[0].Rows[0]["QId"].ToString());
                }
                model.AContent = ds.Tables[0].Rows[0]["AContent"].ToString();
                if (ds.Tables[0].Rows[0]["ATime"].ToString() != "")
                {
                    model.ATime = DateTime.Parse(ds.Tables[0].Rows[0]["ATime"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Ep_Answer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM Ep_Answer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion

        #region ExtensionMethod
        public bool HasAnswerByQId(int qId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ep_Answer");
            strSql.Append(" where ");
            strSql.Append(" QId = @QId  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@QId", SqlDbType.Int,4)
            };
            parameters[0].Value = qId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion
    }
}

