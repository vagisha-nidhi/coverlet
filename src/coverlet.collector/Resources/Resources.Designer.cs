﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace coverlet.collector.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("coverlet.collector.Resources.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: Failed to get coverage report.
        /// </summary>
        internal static string CoverageReportException {
            get {
                return ResourceManager.GetString("CoverageReportException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: Failed to get coverage result.
        /// </summary>
        internal static string CoverageResultException {
            get {
                return ResourceManager.GetString("CoverageResultException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: Failed to cleanup report directory: &apos;{1}&apos;.
        /// </summary>
        internal static string FailedToCleanupReportDirectory {
            get {
                return ResourceManager.GetString("FailedToCleanupReportDirectory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: Failed to save coverage report &apos;{1}&apos; in directory &apos;{2}&apos;.
        /// </summary>
        internal static string FailedToSaveCoverageReport {
            get {
                return ResourceManager.GetString("FailedToSaveCoverageReport", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: Failed to instrument modules.
        /// </summary>
        internal static string InstrumentationException {
            get {
                return ResourceManager.GetString("InstrumentationException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: No test modules found.
        /// </summary>
        internal static string NoTestModulesFound {
            get {
                return ResourceManager.GetString("NoTestModulesFound", resourceCulture);
            }
        }
    }
}