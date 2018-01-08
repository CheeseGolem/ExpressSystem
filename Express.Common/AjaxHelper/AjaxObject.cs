using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Express.Common
{
    /// <summary>
    /// Ajax����
    /// </summary>
    public class AjaxObject
    {
        /// <summary>
        /// ���캯�� ��ʼ������
        /// </summary>
        public AjaxObject()
        {
            
            this.Status = 0;
            this.Msg = string.Empty;
            this.Data = null;
        }
        /// <summary>
        /// ״̬ 0��ʾ�ɹ� 1��ʾ��δ��¼ ������ʾ��������
        /// </summary>
        public AjaxSatusEnum Status { get; set; }
        /// <summary>
        /// ������Ϣ
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public object Data { get; set; }
    }
}
