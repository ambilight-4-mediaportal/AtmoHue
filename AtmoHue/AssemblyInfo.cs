﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Win32;

namespace AtmoHue
{
  class AssemblyInfo
  {
    static public class AssemblyInfoLookUp
    {
      public static string Company { get { return GetExecutingAssemblyAttribute<AssemblyCompanyAttribute>(a => a.Company); } }
      public static string Configuration { get { return GetExecutingAssemblyAttribute<AssemblyDescriptionAttribute>(a => a.Description); } }

      public static string Copyright { get { return GetExecutingAssemblyAttribute<AssemblyCopyrightAttribute>(a => a.Copyright); } }

      public static string Description { get { return GetExecutingAssemblyAttribute<AssemblyDescriptionAttribute>(a => a.Description); } }

      public static string FileVersion { get { return GetExecutingAssemblyAttribute<AssemblyFileVersionAttribute>(a => a.Version); } }

      public static string Product { get { return GetExecutingAssemblyAttribute<AssemblyProductAttribute>(a => a.Product); } }
      public static string Title { get { return GetExecutingAssemblyAttribute<AssemblyTitleAttribute>(a => a.Title); } }

      public static string Trademark { get { return GetExecutingAssemblyAttribute<AssemblyTrademarkAttribute>(a => a.Trademark); } }
      public static Version Version { get { return Assembly.GetExecutingAssembly().GetName().Version; } }
      public static string VersionBuild { get { return Version.Build.ToString(); } }

      public static string VersionFull { get { return Version.ToString(); } }
      public static string VersionMajor { get { return Version.Major.ToString(); } }
      public static string VersionMinor { get { return Version.Minor.ToString(); } }
      public static string VersionRevision { get { return Version.Revision.ToString(); } }

      private static string GetExecutingAssemblyAttribute<T>(Func<T, string> value) where T : Attribute
      {
        T attribute = (T)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(T));
        return value.Invoke(attribute);
      }
    }


    /// <summary>
    /// Gets the values from the AssemblyInfo.cs file for the previous assembly
    /// </summary>
    /// <example>
    /// AssemblyInfoCalling assembly = new AssemblyInfoCalling();
    /// string company1 = assembly.Company;
    /// string product1 = assembly.Product;
    /// string copyright1 = assembly.Copyright;
    /// string trademark1 = assembly.Trademark;
    /// string title1 = assembly.Title;
    /// string description1 = assembly.Description;
    /// string configuration1 = assembly.Configuration;
    /// string fileversion1 = assembly.FileVersion;
    /// Version version1 = assembly.Version;
    /// string versionFull1 = assembly.VersionFull;
    /// string versionMajor1 = assembly.VersionMajor;
    /// string versionMinor1 = assembly.VersionMinor;
    /// string versionBuild1 = assembly.VersionBuild;
    /// string versionRevision1 = assembly.VersionRevision;
    /// </example>
    public class AssemblyInfoCalling
    {
      /// <summary>
      /// Initializes a new instance of the <see cref="AssemblyInfoCalling"/> class.
      /// </summary>
      /// <param name="traceLevel">The trace level needed to get correct assembly 
      /// - will need to adjust based on where you put these classes in your project(s).</param>
      public AssemblyInfoCalling(int traceLevel = 4)
      {
        //----------------------------------------------------------------------
        // Default to "3" as the number of levels back in the stack trace to get the 
        //  correct assembly for "calling" assembly
        //----------------------------------------------------------------------
        StackTraceLevel = traceLevel;
      }

      //----------------------------------------------------------------------
      // Set how deep in the stack trace we're looking - allows for customized changes
      //----------------------------------------------------------------------
      public static int StackTraceLevel { get; set; }

      //----------------------------------------------------------------------
      // Version attributes
      //----------------------------------------------------------------------
      public static Version Version
      {
        get
        {
          //----------------------------------------------------------------------
          // Get the assembly, return empty if null
          //----------------------------------------------------------------------
          Assembly assembly = GetAssembly(StackTraceLevel);
          return assembly == null ? new Version() : assembly.GetName().Version;
        }
      }

      //----------------------------------------------------------------------
      // Standard assembly attributes
      //----------------------------------------------------------------------
      public string Company { get { return GetCallingAssemblyAttribute<AssemblyCompanyAttribute>(a => a.Company); } }
      public string Configuration { get { return GetCallingAssemblyAttribute<AssemblyDescriptionAttribute>(a => a.Description); } }

      public string Copyright { get { return GetCallingAssemblyAttribute<AssemblyCopyrightAttribute>(a => a.Copyright); } }

      public string Description { get { return GetCallingAssemblyAttribute<AssemblyDescriptionAttribute>(a => a.Description); } }

      public string FileVersion { get { return GetCallingAssemblyAttribute<AssemblyFileVersionAttribute>(a => a.Version); } }

      public string Product { get { return GetCallingAssemblyAttribute<AssemblyProductAttribute>(a => a.Product); } }
      public string Title { get { return GetCallingAssemblyAttribute<AssemblyTitleAttribute>(a => a.Title); } }

      public string Trademark { get { return GetCallingAssemblyAttribute<AssemblyTrademarkAttribute>(a => a.Trademark); } }
      public string VersionBuild { get { return Version.Build.ToString(); } }

      public string VersionFull { get { return Version.ToString(); } }
      public string VersionMajor { get { return Version.Major.ToString(); } }
      public string VersionMinor { get { return Version.Minor.ToString(); } }
      public string VersionRevision { get { return Version.Revision.ToString(); } }
      /// <summary>
      /// Go through the stack and gets the assembly
      /// </summary>
      /// <param name="stackTraceLevel">The stack trace level.</param>
      /// <returns></returns>
      private static Assembly GetAssembly(int stackTraceLevel)
      {
        //----------------------------------------------------------------------
        // Get the stack frame, returning null if none
        //----------------------------------------------------------------------
        StackTrace stackTrace = new StackTrace();
        StackFrame[] stackFrames = stackTrace.GetFrames();
        if (stackFrames == null) return null;

        //----------------------------------------------------------------------
        // Get the declaring type from the associated stack frame, returning null if nonw
        //----------------------------------------------------------------------
        var declaringType = stackFrames[stackTraceLevel].GetMethod().DeclaringType;
        if (declaringType == null) return null;

        //----------------------------------------------------------------------
        // Return the assembly
        //----------------------------------------------------------------------
        var assembly = declaringType.Assembly;
        return assembly;
      }

      /// <summary>
      /// Gets the calling assembly attribute.
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <param name="value">The value.</param>
      /// <example>return GetCallingAssemblyAttribute&lt;AssemblyCompanyAttribute&gt;(a => a.Company);</example>
      /// <returns></returns>
      private string GetCallingAssemblyAttribute<T>(Func<T, string> value) where T : Attribute
      {
        //----------------------------------------------------------------------
        // Get the assembly, return empty if null
        //----------------------------------------------------------------------
        Assembly assembly = GetAssembly(StackTraceLevel);
        if (assembly == null) return string.Empty;

        //----------------------------------------------------------------------
        // Get the attribute value
        //----------------------------------------------------------------------
        T attribute = (T)Attribute.GetCustomAttribute(assembly, typeof(T));
        return value.Invoke(attribute);
      }
    }
  }
}
