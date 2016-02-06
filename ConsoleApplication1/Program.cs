using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApplication1
{
  /// <summary>
  /// 
  /// </summary>
  public class Program
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {

      List< XmlDocsInformations > files = LoadFilesPath( );

      foreach ( XmlDocsInformations xmlDocPath in files )
      {

        XmlProcess xmlProcess = new XmlProcess();

        Thread t = new Thread( xmlProcess.Execute );
        t.Start( xmlDocPath );
        t.Join();

      }

      Console.WriteLine( " Check merged docs! " );
      Console.ReadKey();
    }

    

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static List< XmlDocsInformations > LoadFilesPath( )
    {
      List< XmlDocsInformations >    files = new List<XmlDocsInformations>( );
      string []                      filesTarget = System.IO.Directory.GetFiles( Path.Combine( Environment.CurrentDirectory, "008622415_14_Sittel") );
      string                         fileTarget  = string.Empty;
      XmlDocsInformations            xmlDocInfo;

      foreach ( string fileSource in System.IO.Directory.GetFiles( Path.Combine( Environment.CurrentDirectory, "000699816_1_Sittel" ) ) )
      {
        xmlDocInfo = new XmlDocsInformations();

        fileTarget = filesTarget.FirstOrDefault( x => x.GetUniqueName( '_' ).Equals( fileSource.GetUniqueName( '_' ) ) );

        if ( fileTarget == null ) continue;

        xmlDocInfo.FileNameSource  = fileSource.GetUniqueName( '_' );
        xmlDocInfo.FileNameTarget = fileTarget.GetUniqueName( '_' );
        xmlDocInfo.FullPathSource = fileSource;
        xmlDocInfo.FullPathTarget = fileTarget;
        xmlDocInfo.StreamSource = GetStream( fileSource );
        xmlDocInfo.StreamTarget = GetStream( fileTarget );
        xmlDocInfo.MergedFileName = fileSource.GetUniqueName( '_' );

        files.Add( xmlDocInfo );
      }

      return files;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="file"></param>
    private static MemoryStream GetStream( string file )
    {
      MemoryStream stream = new MemoryStream( File.ReadAllBytes( file ) );

      return stream;
    }
  }
}
