//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestimonialWebApp.StudentVerifierService {
    using System.Xml.Serialization;
    using System.Diagnostics;
    using System.Web.Services;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System;
    
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MonoDevelop", "2.6.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="StudentVerifierServiceSoap", Namespace="dse.webservices")]
    public partial class StudentVerifierService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback getStudentInfoOperationCompleted;
        
        private System.Threading.SendOrPostCallback verifyStudentOperationCompleted;
        
        /// CodeRemarks
        public StudentVerifierService() {
            this.Url = "http://127.0.0.1:8020/StudentVerifierService.asmx";
        }
        
        public StudentVerifierService(string url) {
            this.Url = url;
        }
        
        /// CodeRemarks
        public event getStudentInfoCompletedEventHandler getStudentInfoCompleted;
        
        /// CodeRemarks
        public event verifyStudentCompletedEventHandler verifyStudentCompleted;
        
        /// CodeRemarks
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("dse.webservices/getStudentInfo", RequestNamespace="dse.webservices", ResponseNamespace="dse.webservices", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Student getStudentInfo(string regNum) {
            object[] results = this.Invoke("getStudentInfo", new object[] {
                        regNum});
            return ((Student)(results[0]));
        }
        
        /// CodeRemarks
        public void getStudentInfoAsync(string regNum) {
            this.getStudentInfoAsync(regNum, null);
        }
        
        /// CodeRemarks
        public void getStudentInfoAsync(string regNum, object userState) {
            if ((this.getStudentInfoOperationCompleted == null)) {
                this.getStudentInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetStudentInfoOperationCompleted);
            }
            this.InvokeAsync("getStudentInfo", new object[] {
                        regNum}, this.getStudentInfoOperationCompleted, userState);
        }
        
        private void OngetStudentInfoOperationCompleted(object arg) {
            if ((this.getStudentInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getStudentInfoCompleted(this, new getStudentInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// CodeRemarks
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("dse.webservices/verifyStudent", RequestNamespace="dse.webservices", ResponseNamespace="dse.webservices", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool verifyStudent(string regNum) {
            object[] results = this.Invoke("verifyStudent", new object[] {
                        regNum});
            return ((bool)(results[0]));
        }
        
        /// CodeRemarks
        public void verifyStudentAsync(string regNum) {
            this.verifyStudentAsync(regNum, null);
        }
        
        /// CodeRemarks
        public void verifyStudentAsync(string regNum, object userState) {
            if ((this.verifyStudentOperationCompleted == null)) {
                this.verifyStudentOperationCompleted = new System.Threading.SendOrPostCallback(this.OnverifyStudentOperationCompleted);
            }
            this.InvokeAsync("verifyStudent", new object[] {
                        regNum}, this.verifyStudentOperationCompleted, userState);
        }
        
        private void OnverifyStudentOperationCompleted(object arg) {
            if ((this.verifyStudentCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.verifyStudentCompleted(this, new verifyStudentCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// CodeRemarks
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MonoDevelop", "2.6.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="dse.webservices")]
    public partial class Student {
        
        /// <remarks/>
        public string regNum;
        
        /// <remarks/>
        public string name;
        
        /// <remarks/>
        public string gender;
        
        /// <remarks/>
        public string fatherName;
        
        /// <remarks/>
        public string motherName;
        
        /// <remarks/>
        public string session;
        
        /// <remarks/>
        public string instOrDept;
        
        /// <remarks/>
        public string hall;
        
        /// <remarks/>
        public int currentSemester;
    }
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MonoDevelop", "2.6.0.0")]
    public delegate void getStudentInfoCompletedEventHandler(object sender, getStudentInfoCompletedEventArgs e);
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MonoDevelop", "2.6.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getStudentInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getStudentInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// CodeRemarks
        public Student Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Student)(this.results[0]));
            }
        }
    }
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MonoDevelop", "2.6.0.0")]
    public delegate void verifyStudentCompletedEventHandler(object sender, verifyStudentCompletedEventArgs e);
    
    /// CodeRemarks
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MonoDevelop", "2.6.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class verifyStudentCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal verifyStudentCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// CodeRemarks
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
}
