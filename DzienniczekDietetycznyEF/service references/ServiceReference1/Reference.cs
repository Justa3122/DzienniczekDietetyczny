﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DzienniczekDietetycznyEF.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WcfLogin", Namespace="http://schemas.datacontract.org/2004/07/DietCalendarServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class WcfLogin : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WcfFavorite", Namespace="http://schemas.datacontract.org/2004/07/DietCalendarServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class WcfFavorite : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DzienniczekDietetycznyEF.ServiceReference1.WcfFavoriteComponent[] FavoriteCompontentsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FavoriteNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DzienniczekDietetycznyEF.ServiceReference1.WcfFavoriteComponent[] FavoriteCompontents {
            get {
                return this.FavoriteCompontentsField;
            }
            set {
                if ((object.ReferenceEquals(this.FavoriteCompontentsField, value) != true)) {
                    this.FavoriteCompontentsField = value;
                    this.RaisePropertyChanged("FavoriteCompontents");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FavoriteName {
            get {
                return this.FavoriteNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FavoriteNameField, value) != true)) {
                    this.FavoriteNameField = value;
                    this.RaisePropertyChanged("FavoriteName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WcfFavoriteComponent", Namespace="http://schemas.datacontract.org/2004/07/DietCalendarServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class WcfFavoriteComponent : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DzienniczekDietetycznyEF.ServiceReference1.WcfMeal MealField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float QuantityField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DzienniczekDietetycznyEF.ServiceReference1.WcfMeal Meal {
            get {
                return this.MealField;
            }
            set {
                if ((object.ReferenceEquals(this.MealField, value) != true)) {
                    this.MealField = value;
                    this.RaisePropertyChanged("Meal");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Quantity {
            get {
                return this.QuantityField;
            }
            set {
                if ((this.QuantityField.Equals(value) != true)) {
                    this.QuantityField = value;
                    this.RaisePropertyChanged("Quantity");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WcfMeal", Namespace="http://schemas.datacontract.org/2004/07/DietCalendarServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class WcfMeal : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float CaloriesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float CarboHydratesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float FatField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MealNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float ProteinField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Calories {
            get {
                return this.CaloriesField;
            }
            set {
                if ((this.CaloriesField.Equals(value) != true)) {
                    this.CaloriesField = value;
                    this.RaisePropertyChanged("Calories");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float CarboHydrates {
            get {
                return this.CarboHydratesField;
            }
            set {
                if ((this.CarboHydratesField.Equals(value) != true)) {
                    this.CarboHydratesField = value;
                    this.RaisePropertyChanged("CarboHydrates");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Fat {
            get {
                return this.FatField;
            }
            set {
                if ((this.FatField.Equals(value) != true)) {
                    this.FatField = value;
                    this.RaisePropertyChanged("Fat");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MealName {
            get {
                return this.MealNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MealNameField, value) != true)) {
                    this.MealNameField = value;
                    this.RaisePropertyChanged("MealName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Protein {
            get {
                return this.ProteinField;
            }
            set {
                if ((this.ProteinField.Equals(value) != true)) {
                    this.ProteinField = value;
                    this.RaisePropertyChanged("Protein");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WcfConsumed", Namespace="http://schemas.datacontract.org/2004/07/DietCalendarServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class WcfConsumed : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ConsumeTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DzienniczekDietetycznyEF.ServiceReference1.WcfFavorite FavoriteField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ConsumeTime {
            get {
                return this.ConsumeTimeField;
            }
            set {
                if ((this.ConsumeTimeField.Equals(value) != true)) {
                    this.ConsumeTimeField = value;
                    this.RaisePropertyChanged("ConsumeTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public DzienniczekDietetycznyEF.ServiceReference1.WcfFavorite Favorite {
            get {
                return this.FavoriteField;
            }
            set {
                if ((object.ReferenceEquals(this.FavoriteField, value) != true)) {
                    this.FavoriteField = value;
                    this.RaisePropertyChanged("Favorite");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IDietCalendarService2")]
    public interface IDietCalendarService2 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDietCalendarService2/Login", ReplyAction="http://tempuri.org/IDietCalendarService2/LoginResponse")]
        bool Login([System.ServiceModel.MessageParameterAttribute(Name="login")] DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDietCalendarService2/Login", ReplyAction="http://tempuri.org/IDietCalendarService2/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDietCalendarService2/AddFavorite", ReplyAction="http://tempuri.org/IDietCalendarService2/AddFavoriteResponse")]
        bool AddFavorite(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login, DzienniczekDietetycznyEF.ServiceReference1.WcfFavorite favorite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDietCalendarService2/AddFavorite", ReplyAction="http://tempuri.org/IDietCalendarService2/AddFavoriteResponse")]
        System.Threading.Tasks.Task<bool> AddFavoriteAsync(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login, DzienniczekDietetycznyEF.ServiceReference1.WcfFavorite favorite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDietCalendarService2/AddConsumed", ReplyAction="http://tempuri.org/IDietCalendarService2/AddConsumedResponse")]
        bool AddConsumed(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login, DzienniczekDietetycznyEF.ServiceReference1.WcfConsumed consumed);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDietCalendarService2/AddConsumed", ReplyAction="http://tempuri.org/IDietCalendarService2/AddConsumedResponse")]
        System.Threading.Tasks.Task<bool> AddConsumedAsync(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login, DzienniczekDietetycznyEF.ServiceReference1.WcfConsumed consumed);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDietCalendarService2/DownloadFavorites", ReplyAction="http://tempuri.org/IDietCalendarService2/DownloadFavoritesResponse")]
        DzienniczekDietetycznyEF.ServiceReference1.WcfFavorite[] DownloadFavorites(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDietCalendarService2/DownloadFavorites", ReplyAction="http://tempuri.org/IDietCalendarService2/DownloadFavoritesResponse")]
        System.Threading.Tasks.Task<DzienniczekDietetycznyEF.ServiceReference1.WcfFavorite[]> DownloadFavoritesAsync(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDietCalendarService2/DownloadConsumed", ReplyAction="http://tempuri.org/IDietCalendarService2/DownloadConsumedResponse")]
        DzienniczekDietetycznyEF.ServiceReference1.WcfConsumed[] DownloadConsumed(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDietCalendarService2/DownloadConsumed", ReplyAction="http://tempuri.org/IDietCalendarService2/DownloadConsumedResponse")]
        System.Threading.Tasks.Task<DzienniczekDietetycznyEF.ServiceReference1.WcfConsumed[]> DownloadConsumedAsync(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDietCalendarService2/DownloadAllMeals", ReplyAction="http://tempuri.org/IDietCalendarService2/DownloadAllMealsResponse")]
        DzienniczekDietetycznyEF.ServiceReference1.WcfMeal[] DownloadAllMeals(string phrase);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDietCalendarService2/DownloadAllMeals", ReplyAction="http://tempuri.org/IDietCalendarService2/DownloadAllMealsResponse")]
        System.Threading.Tasks.Task<DzienniczekDietetycznyEF.ServiceReference1.WcfMeal[]> DownloadAllMealsAsync(string phrase);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDietCalendarService2Channel : DzienniczekDietetycznyEF.ServiceReference1.IDietCalendarService2, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DietCalendarService2Client : System.ServiceModel.ClientBase<DzienniczekDietetycznyEF.ServiceReference1.IDietCalendarService2>, DzienniczekDietetycznyEF.ServiceReference1.IDietCalendarService2 {
        
        public DietCalendarService2Client() {
        }
        
        public DietCalendarService2Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DietCalendarService2Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DietCalendarService2Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DietCalendarService2Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Login(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login1) {
            return base.Channel.Login(login1);
        }
        
        public System.Threading.Tasks.Task<bool> LoginAsync(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login) {
            return base.Channel.LoginAsync(login);
        }
        
        public bool AddFavorite(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login, DzienniczekDietetycznyEF.ServiceReference1.WcfFavorite favorite) {
            return base.Channel.AddFavorite(login, favorite);
        }
        
        public System.Threading.Tasks.Task<bool> AddFavoriteAsync(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login, DzienniczekDietetycznyEF.ServiceReference1.WcfFavorite favorite) {
            return base.Channel.AddFavoriteAsync(login, favorite);
        }
        
        public bool AddConsumed(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login, DzienniczekDietetycznyEF.ServiceReference1.WcfConsumed consumed) {
            return base.Channel.AddConsumed(login, consumed);
        }
        
        public System.Threading.Tasks.Task<bool> AddConsumedAsync(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login, DzienniczekDietetycznyEF.ServiceReference1.WcfConsumed consumed) {
            return base.Channel.AddConsumedAsync(login, consumed);
        }
        
        public DzienniczekDietetycznyEF.ServiceReference1.WcfFavorite[] DownloadFavorites(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login) {
            return base.Channel.DownloadFavorites(login);
        }
        
        public System.Threading.Tasks.Task<DzienniczekDietetycznyEF.ServiceReference1.WcfFavorite[]> DownloadFavoritesAsync(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login) {
            return base.Channel.DownloadFavoritesAsync(login);
        }
        
        public DzienniczekDietetycznyEF.ServiceReference1.WcfConsumed[] DownloadConsumed(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login) {
            return base.Channel.DownloadConsumed(login);
        }
        
        public System.Threading.Tasks.Task<DzienniczekDietetycznyEF.ServiceReference1.WcfConsumed[]> DownloadConsumedAsync(DzienniczekDietetycznyEF.ServiceReference1.WcfLogin login) {
            return base.Channel.DownloadConsumedAsync(login);
        }
        
        public DzienniczekDietetycznyEF.ServiceReference1.WcfMeal[] DownloadAllMeals(string phrase) {
            return base.Channel.DownloadAllMeals(phrase);
        }
        
        public System.Threading.Tasks.Task<DzienniczekDietetycznyEF.ServiceReference1.WcfMeal[]> DownloadAllMealsAsync(string phrase) {
            return base.Channel.DownloadAllMealsAsync(phrase);
        }
    }
}
