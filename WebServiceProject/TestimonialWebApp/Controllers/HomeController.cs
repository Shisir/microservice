using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;


namespace TestimonialWebApp.Controllers
{
    public class HomeController : Controller
    {

		public ActionResult Index()
		{
			return View("Index");
        }

		[HttpPost]
		public ActionResult VerifyStudent(FormCollection data)
		{
			string submit = data["submit"];
			string regNum = data["regNum"];
			if (regNum == "")
            {
				TempData["error"] = "Registration Number is empty!";
				return Redirect(Url.Action("Index", "Home"));
            }
			TestimonialWebApp.StudentVerifierService.StudentVerifierService studentVerifier = new StudentVerifierService.StudentVerifierService();

			if (studentVerifier.verifyStudent(regNum) == false)
			{
				TempData["error"] = "Registration Number is not valid!";
				return Redirect(Url.Action("Index", "Home"));
			}
           
			TempData["regNum"] = regNum;

            if (submit.Equals("Form Fill up Status"))
            {
                return Redirect(Url.Action("Status", "Home"));
            }
            else
            {
                var studentInfo = studentVerifier.getStudentInfo(regNum);
                TempData["name"] = studentInfo.name;
                TempData["regNum"] = studentInfo.regNum;
                TempData["fatherName"] = studentInfo.fatherName;
                TempData["motherName"] = studentInfo.motherName;
                TempData["session"] = studentInfo.session;
                TempData["instOrDept"] = studentInfo.instOrDept;
                TempData["hall"] = studentInfo.hall;
                TempData["currentSemester"] = studentInfo.currentSemester;

                return View("formInfo");
            }


		}

        [HttpPost]
        public ActionResult DeptVerify(FormCollection data)
        {
            string submit = data["submit"];
            string regNum = data["regNum"];
            if (submit.Equals("Go Back"))
            {
                return Redirect(Url.Action("Index", "Home"));
            }
            else
            {
                var res = new DepartmentService.DepartmentService();
                var student = res.GetStudentInfoFromDept(regNum);

                if(student.attendance< 75 || student.dept_payment<7000)
                {
                    if (student.attendance < 75 && student.dept_payment < 7000) TempData["dept_error"] = "Low attendance: " + student.attendance + " and payment: " + student.dept_payment;
                    else if (student.attendance < 75) TempData["dept_error"] = "Low attendance: " + student.attendance;
                    else TempData["dept_error"] = "Low payment: " + student.dept_payment;
                    TestimonialWebApp.StudentVerifierService.StudentVerifierService studentVerifier = new StudentVerifierService.StudentVerifierService();
                    var studentInfo = studentVerifier.getStudentInfo(regNum);
                    TempData["name"] = studentInfo.name;
                    TempData["regNum"] = studentInfo.regNum;
                    TempData["fatherName"] = studentInfo.fatherName;
                    TempData["motherName"] = studentInfo.motherName;
                    TempData["session"] = studentInfo.session;
                    TempData["instOrDept"] = studentInfo.instOrDept;
                    TempData["hall"] = studentInfo.hall;
                    TempData["currentSemester"] = studentInfo.currentSemester;
                    return View("formInfo");
                }

                TempData["regNum"] = student.regNum;
                TempData["attendance"] = student.attendance;
                TempData["dept_payment"] = student.dept_payment;
                return View("deptInfo");
            }
        }
     
        [HttpPost]
        public ActionResult HallVerify(FormCollection data)
        {
            string submit = data["submit"];
            string regNum = data["regNum"];
            if (submit.Equals("Go Back"))
            {
                return Redirect(Url.Action("Index", "Home"));
            }
            else
            {
                var res = new HallService.HallService();
                var student = res.GetStudentInfoFromHall(regNum);
                TempData["regNum"] = student.regNum;
                TempData["hall_payment_res"] = student.hall_payment_res;
                TempData["is_resident"] = student.is_resident;
                return View("hallInfo");
            }

        }
        [HttpPost]
        public ActionResult FormPayment(FormCollection data)
        {
            string submit = data["submit"];
            string regNum = data["regNum"];
            TempData["regNum"] = regNum;
            if (submit.Equals("Go Back"))
            {
                return Redirect(Url.Action("Index", "Home"));
            }
            return View("paymentInfo");
        }
        [HttpPost]
        public ActionResult SubmitPayment(FormCollection data)
        {
            string submit = data["submit"];
            string regNum = data["regNum"];

            var payment = new PaymentService.PaymentService();
           
            if (submit.Equals("Go Back"))
            {
                return Redirect(Url.Action("Index", "Home"));
            }
            else
            {
                var transacNum = payment.createPayment(regNum);
                //var transacNum = 12;
                TempData["regNum"] = regNum;
                TempData["transacNum"] = transacNum;
                return View("transactionInfo");
            }
        }

        [HttpPost]
        public ActionResult SubmitRegistrar(FormCollection data)
        {
            string submit = data["submit"];
            string regNum = data["regNum"];

            var registrar = new RegistrarService.RegistrarService();

            if (submit.Equals("Go Back"))
            {
                return Redirect(Url.Action("Index", "Home"));
            }
            else
            {
                var student = registrar.GetStudentInfoFromRegistrar(regNum);
                if(student.universityFee<5000)
                {
                    TempData["error"] = "Pay your university Fee first!";
                    return Redirect(Url.Action("Index", "Home"));
                }

                int examRoll = registrar.CreateStudentRollFromRegistrar(regNum);

                TestimonialWebApp.StudentVerifierService.StudentVerifierService studentVerifier = new StudentVerifierService.StudentVerifierService();
                var studentInfo = studentVerifier.getStudentInfo(regNum);
                TempData["name"] = studentInfo.name;
                TempData["regNum"] = studentInfo.regNum;
                TempData["fatherName"] = studentInfo.fatherName;
                TempData["motherName"] = studentInfo.motherName;
                TempData["session"] = studentInfo.session;
                TempData["instOrDept"] = studentInfo.instOrDept;
                TempData["hall"] = studentInfo.hall;
                TempData["currentSemester"] = studentInfo.currentSemester;

                //int examRoll = 123;
                TempData["examRoll"] = examRoll;
                return View("Success");
            }
        }


        public ActionResult Status()
		{
			
			return View("Status");
		}

		[HttpPost]
		public ActionResult GetStatus(FormCollection data)
		{
			string regNum = data["regNum"];
			string transacNum = data["transacNum"];

			TempData["regNum"] = regNum;
			TempData["transacNum"] = transacNum;

			ApplicationService.ApplicationService applicationService = new ApplicationService.ApplicationService();
			var status = applicationService.getApplicationStatus(regNum, transacNum);
			int appId = status.Item1;
			bool approved = status.Item2;
			TempData["message"] = null;
			if (appId == -1)
			{
				TempData["message"] = "There is no application with given reg. number and transaction num!";
			}
			else 
			{
				if (approved == false)
				{
					TempData["message"] = "Application Number is: " + appId + " and testimonial is not deliverd yet."; 
				}
				else TempData["message"] = "Application Number is: " + appId + " and the testimonial was deliverd.";
			}
           
			return Redirect(Url.Action("Status", "Home"));
		}

		public ActionResult Apply()
        {
			TestimonialWebApp.ResultService.ResultService resultService = new ResultService.ResultService();
			TestimonialWebApp.ResultService.Degree[] degreeList = resultService.getDegreeList();

			Dictionary<int, string> degrees = new Dictionary<int, string>();

			for (int i = 0; i < degreeList.Length; i++)
			{
				degrees[degreeList[i].id] = degreeList[i].degree;
			}

			ViewData["dict"] = degrees;

			return View("Apply");
        }

		[HttpPost]
		public ActionResult Submit(FormCollection data)
		{
			string regNum = data["regNum"];
			string transacNum = data["transacNum"];
			int degreeId = Int32.Parse(data["degree"]);
			string email = data["email"];
			TempData["regNum"] = regNum;
            Console.WriteLine("dsf");

			TestimonialWebApp.ResultService.ResultService resultService = new ResultService.ResultService();
            bool checkResult = resultService.checkStudentInResult(regNum, degreeId);

            if (checkResult == false)
            {
                TempData["error_program"] = "There is no result under the selected degree program for the student";
                return Redirect(Url.Action("Apply", "Home"));
            }

			TestimonialWebApp.PaymentService.PaymentService paymentService = new PaymentService.PaymentService();
            float transAmount = (float)paymentService.getPayment(transacNum);

			if (transAmount < 100.00)
			{
				TempData["error"] = "Given Transaction number is not applicable!";
				return Redirect(Url.Action("Apply", "Home"));
			}

			TestimonialWebApp.ApplicationService.ApplicationService applicationService = new ApplicationService.ApplicationService();
			long appId = (long)applicationService.apply(regNum, transacNum, degreeId, email);

			if (appId==-1)
			{
				TempData["error"] = "There is already an application with given transaction number!";
                return Redirect(Url.Action("Apply", "Home"));
			}


			TempData["success"] = "Your Application for testimonial has been successfully sent and your application id is "+ appId +".";
			return Redirect(Url.Action("Index", "Home"));
		}
    }
}
