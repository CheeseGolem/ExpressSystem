using System;

namespace Express.Common
{
    /// <summary>
    /// Msg ��ժҪ˵����
    /// ��Ϣ�ࡣ���ڵײ���ǰ�˴���������Ϣ��Ϊ��������Trace,Debug,Info,Warn,Error,Fatal
    /// �ֱ�ΪС���⡢�����Ϣ��һ����Ϣ��������Ϣ���쳣��Ϣ���ش�����������𡣵���Ϣ�ļ���
    /// ����Ҫ��ʾ����Ϣʱǰ�˶Ը���Ϣ������ʾ��
    /// 
    /// </summary>
    public enum MsgLevel  // ����ö����
    {
        /// <summary>
        /// С����
        /// </summary>
        Trace,
        /// <summary>
        /// �����Ϣ
        /// </summary>
        Debug,
        /// <summary>
        /// һ����Ϣ
        /// </summary>
        Info,
        /// <summary>
        /// ������Ϣ
        /// </summary>
        Warn,
        /// <summary>
        /// �쳣��Ϣ
        /// </summary>
        Error,
        /// <summary>
        /// �ش����
        /// </summary>
        Fatal
    }
    /// <summary>
    /// ������Ϣ��
    /// </summary>
    [Serializable]
    public class Msg
    {

        public Msg()
        {
            Result = true;
            // msg = System.Guid.NewGuid().ToString();
        }

        #region ��������        
        //private string msg = "";
        ///// <summary>
        ///// ��־ΨһID
        ///// </summary>
        //public string MsgID
        //{
        //    get
        //    {
        //        return msg;
        //    }
        //    private set
        //    {
        //    }
        //}

        /// <summary>
        /// ���
        /// </summary>
        public bool Result
        {
            get;
            set;
        }

        /// <summary>
        /// ��Ϣʵ�壬��ŷǻ�����������
        /// </summary>
        public object MsgObjectContent
        {
            get;
            set;
        }


        private string msgcontent = "";
        /// <summary>
        /// �ۼ���Ϣ
        /// </summary>
        /// <param name="msg"></param>
        public void AddMsg(string msg)
        {
            this.msgcontent += msg;

        }

        #endregion

 
        /// <summary>
        /// �����Ϣ
        /// </summary>
        /// 
        public void ClearMsg()
        {
            msgcontent = "";

        }

        /// <summary>
        /// ��дToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return msgcontent;
        }   
    }
}
