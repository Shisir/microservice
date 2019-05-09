using System;
namespace RegistrarService
{
	[Serializable]
    public class StudentRegistrarInfo
    {

		public string regNum;
		public string id;
		public double universityFee;
        public int examRoll;

		public StudentRegistrarInfo()
        {
        }

    }
}
