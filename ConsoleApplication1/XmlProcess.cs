using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApplication1
{
  /// <summary>
  /// 
  /// </summary>
  public class XmlProcess
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="xmlDocInfo"></param>
    public void Execute ( object xmlDocInfoData )
    {
      var xmlDocInfo = (XmlDocsInformations)xmlDocInfoData;
      Console.WriteLine ( "Processing the source file {0} ...", xmlDocInfo.FullPathSource );
      Console.WriteLine ( "Processing the target file {0} ...", xmlDocInfo.FullPathTarget );
      this.MergeXmlDocs ( xmlDocInfo );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="docSource"></param>
    /// <param name="docTarget"></param>
    /// <returns></returns>
    private void MergeXmlDocs( XmlDocsInformations docInfo )
    {
      XDocument docSource           = XDocument.Load( docInfo.StreamSource );
      XDocument docTarget           = XDocument.Load( docInfo.StreamTarget );

      foreach ( XElement nodeSource in docSource.Root.Nodes() )
      {
        docTarget.Root.FirstNode.AddAfterSelf( nodeSource );
      }

      DeleteMergedDoc ( Path.Combine( Environment.CurrentDirectory, "MergedDoc", docInfo.MergedFileName ) );

      Console.WriteLine ( "Generating the merged file {0} ...", docInfo.MergedFileName );

      docTarget.Save  ( Path.Combine( Environment.CurrentDirectory, "MergedDoc", docInfo.MergedFileName ) );
    }

    /// <summary>
    /// 
    /// </summary>
    private void DeleteMergedDoc( string file )
    {
      if ( System.IO.File.Exists( file ) )
      {
        System.IO.File.Delete( file );
      }
    }
  }
}
