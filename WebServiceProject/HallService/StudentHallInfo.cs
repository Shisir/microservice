using System;
namespace HallService
{
	[Serializable]
    public class StudentHallInfo
    {

		public string regNum;
		public string id;
		public bool is_resident;
        public double hall_payment_res;

		public StudentHallInfo()
        {
        }

    }
}
