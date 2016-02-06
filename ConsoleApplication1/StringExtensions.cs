using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  /// <summary>
  /// 
  /// </summary>
  public static class StringExtensions
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static string GetUniqueName ( this string fileName, char separator)
    {
      var fileNameSplited = fileName.Split( separator );

      return fileNameSplited[ fileNameSplited.Length - 1 ].ToUpper();
    }
  }
}
