using System;
namespace TravelAgent.Model
{
	/// <summary>
	/// 实体类Admin 。(属性说明自动提取数据库字段的描述信息)
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

