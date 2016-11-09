using System;
namespace TravelAgent.Model
{
	/// <summary>
	/// ʵ����Admin ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class AdminList
	{
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string ReadName { get; set; }
        public int RoleId { get; set; }
        public int IsLock { get; set; }

        public TravelAgent.Model.AdminRole Role { get; set; }
	}
}

