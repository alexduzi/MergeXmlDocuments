using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  /// <summary>
  /// 
  /// </summary>
  public class XmlDocsInformations
  {
    /// <summary>
    /// 
    /// </summary>
    public string FileNameSource { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string FileNameTarget { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string FullPathSource { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string FullPathTarget { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public MemoryStream StreamSource { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public MemoryStream StreamTarget { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string MergedFileName { set; get; }
  }
}
