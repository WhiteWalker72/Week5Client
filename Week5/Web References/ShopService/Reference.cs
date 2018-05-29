﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Week5.ShopService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IRegisterService", Namespace="http://tempuri.org/")]
    public partial class RegisterService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback RegisterOperationCompleted;
        
        private System.Threading.SendOrPostCallback AccountExistsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GeneratePasswordOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public RegisterService() {
            this.Url = global::Week5.Properties.Settings.Default.Week5_ShopService_RegisterService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event RegisterCompletedEventHandler RegisterCompleted;
        
        /// <remarks/>
        public event AccountExistsCompletedEventHandler AccountExistsCompleted;
        
        /// <remarks/>
        public event GeneratePasswordCompletedEventHandler GeneratePasswordCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IRegisterService/Register", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Register([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string username, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string password) {
            this.Invoke("Register", new object[] {
                        username,
                        password});
        }
        
        /// <remarks/>
        public void RegisterAsync(string username, string password) {
            this.RegisterAsync(username, password, null);
        }
        
        /// <remarks/>
        public void RegisterAsync(string username, string password, object userState) {
            if ((this.RegisterOperationCompleted == null)) {
                this.RegisterOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRegisterOperationCompleted);
            }
            this.InvokeAsync("Register", new object[] {
                        username,
                        password}, this.RegisterOperationCompleted, userState);
        }
        
        private void OnRegisterOperationCompleted(object arg) {
            if ((this.RegisterCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RegisterCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IRegisterService/AccountExists", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void AccountExists([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string username, out bool AccountExistsResult, [System.Xml.Serialization.XmlIgnoreAttribute()] out bool AccountExistsResultSpecified) {
            object[] results = this.Invoke("AccountExists", new object[] {
                        username});
            AccountExistsResult = ((bool)(results[0]));
            AccountExistsResultSpecified = ((bool)(results[1]));
        }
        
        /// <remarks/>
        public void AccountExistsAsync(string username) {
            this.AccountExistsAsync(username, null);
        }
        
        /// <remarks/>
        public void AccountExistsAsync(string username, object userState) {
            if ((this.AccountExistsOperationCompleted == null)) {
                this.AccountExistsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAccountExistsOperationCompleted);
            }
            this.InvokeAsync("AccountExists", new object[] {
                        username}, this.AccountExistsOperationCompleted, userState);
        }
        
        private void OnAccountExistsOperationCompleted(object arg) {
            if ((this.AccountExistsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AccountExistsCompleted(this, new AccountExistsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IRegisterService/GeneratePassword", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string GeneratePassword() {
            object[] results = this.Invoke("GeneratePassword", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GeneratePasswordAsync() {
            this.GeneratePasswordAsync(null);
        }
        
        /// <remarks/>
        public void GeneratePasswordAsync(object userState) {
            if ((this.GeneratePasswordOperationCompleted == null)) {
                this.GeneratePasswordOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGeneratePasswordOperationCompleted);
            }
            this.InvokeAsync("GeneratePassword", new object[0], this.GeneratePasswordOperationCompleted, userState);
        }
        
        private void OnGeneratePasswordOperationCompleted(object arg) {
            if ((this.GeneratePasswordCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GeneratePasswordCompleted(this, new GeneratePasswordCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void RegisterCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void AccountExistsCompletedEventHandler(object sender, AccountExistsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AccountExistsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AccountExistsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool AccountExistsResult {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public bool AccountExistsResultSpecified {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void GeneratePasswordCompletedEventHandler(object sender, GeneratePasswordCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GeneratePasswordCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GeneratePasswordCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591