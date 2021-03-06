//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIResources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class MessagesResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MessagesResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BSoft.DemoApp.API.Resources.MessagesResources", typeof(MessagesResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Program terminated unexpectedly!.
        /// </summary>
        public static string ErrorApplicationBrake {
            get {
                return ResourceManager.GetString("ErrorApplicationBrake", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bad Request - Invalid Request Exception: {0}.
        /// </summary>
        public static string ErrorBadRequest {
            get {
                return ResourceManager.GetString("ErrorBadRequest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Internal Server Error.
        /// </summary>
        public static string ErrorInternalServerError {
            get {
                return ResourceManager.GetString("ErrorInternalServerError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The person does not exist..
        /// </summary>
        public static string ErrorPersonNotExists {
            get {
                return ResourceManager.GetString("ErrorPersonNotExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The person with id &apos;{0}&apos; does not exist..
        /// </summary>
        public static string ErrorPersonNotExistsDetails {
            get {
                return ResourceManager.GetString("ErrorPersonNotExistsDetails", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Service Validation failed.
        /// </summary>
        public static string ErrorServiceValidation {
            get {
                return ResourceManager.GetString("ErrorServiceValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid Request, reasons: .
        /// </summary>
        public static string ErrorValidatorsTitle {
            get {
                return ResourceManager.GetString("ErrorValidatorsTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Argument Exception.
        /// </summary>
        public static string ErrorWithArgument {
            get {
                return ResourceManager.GetString("ErrorWithArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Conflict Business Validation.
        /// </summary>
        public static string ErrorWithBusinessValidation {
            get {
                return ResourceManager.GetString("ErrorWithBusinessValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} with document number &apos;{1}&apos; was removed from the application successfully..
        /// </summary>
        public static string InformationRemovePersonSuccess {
            get {
                return ResourceManager.GetString("InformationRemovePersonSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter &apos;Bearer&apos; following by space and JWT..
        /// </summary>
        public static string InformationSwaggerDescription {
            get {
                return ResourceManager.GetString("InformationSwaggerDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Authorization.
        /// </summary>
        public static string InformationSwaggerName {
            get {
                return ResourceManager.GetString("InformationSwaggerName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Starting up.
        /// </summary>
        public static string LoggingStartUp {
            get {
                return ResourceManager.GetString("LoggingStartUp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Configuring web host in {0} Environment.
        /// </summary>
        public static string LoggingStartUpConfiguration {
            get {
                return ResourceManager.GetString("LoggingStartUpConfiguration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Starting web host ({0})....
        /// </summary>
        public static string LoggingStartUpWebHost {
            get {
                return ResourceManager.GetString("LoggingStartUpWebHost", resourceCulture);
            }
        }
    }
}
