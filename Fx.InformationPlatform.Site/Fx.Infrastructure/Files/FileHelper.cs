using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Fx.Infrastructure.Files
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public class FileHelper
    {
        // Fields
        private Encoding defaultEncoding = Encoding.UTF8;
        private int directoryIndex = 0;
        private StringBuilder fileTree = new StringBuilder();
        private int listIndex = 0;
        /// <summary>
        ///rootUrl
        /// </summary>
        public string rootUrl = "";

        /// <summary>
        /// 文件复制
        /// </summary>
        /// <param name="FileOldPath">被复制文件的地址</param>
        /// <param name="FileNewPath">需要复制到的地址</param>
        /// <param name="IsReplaceFile">是否覆盖</param>
        /// <returns>是否成功</returns>
        public bool CopyFile(string FileOldPath, string FileNewPath, bool IsReplaceFile)
        {
            try
            {
              
                if (File.Exists(FileOldPath))
                {
                    if (!File.Exists(FileNewPath))
                    {
                        if (!File.Exists(FileNewPath.Substring(0, FileNewPath.LastIndexOf(@"\"))))
                        {
                            this.CreateDirectory(FileNewPath.Substring(0, FileNewPath.LastIndexOf(@"\")));
                        }
                        File.Copy(FileOldPath, FileNewPath);
                        return true;
                    }
                    if (IsReplaceFile)
                    {
                        File.Delete(FileNewPath);
                        File.Copy(FileOldPath, FileNewPath);
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="filePath">文件夹的地址</param>
        /// <returns>是否成功</returns>
        public bool CreateDirectory(string filePath)
        {
            try
            {
                if (!Directory.Exists(filePath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(filePath);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 创建文件的地址
        /// </summary>
        /// <param name="filePath">文件的路径</param>
        /// <param name="fileContent">文件的内容</param>
        /// <returns>是否成功</returns>
        public bool CreateFile(string filePath, string fileContent)
        {
            try
            {
                if (this.CreateDirectory(Path.GetDirectoryName(filePath)))
                {
                    Encoding code = this.defaultEncoding;
                    StreamWriter mySream = new StreamWriter(filePath, false, code);
                    mySream.WriteLine(fileContent);
                    mySream.Flush();
                    mySream.Close();
                    mySream = null;
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="directoryPath">文件夹的路径</param>
        /// <returns>是否成功</returns>
        public bool DeleteDirectory(string directoryPath)
        {
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    Directory.Delete(directoryPath);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath">文件的路径</param>
        /// <returns>是否删除成功</returns>
        public bool DeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="filePath">文件的路径集合</param>
        /// <returns>是否全部删除成功</returns>
        public bool DeleteFile(string[] filePath)
        {
            bool isAllDelete = true;
            for (int i = 0; i < filePath.Length; i++)
            {
                if (!this.DeleteFile(filePath[i]))
                {
                    isAllDelete = false;
                }
            }
            return isAllDelete;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="level"></param>
        public void listFileName(string dir, int level)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(dir);
                foreach (string d in dirs)
                {
                    this.directoryIndex++;
                    if (d.LastIndexOf(@"\") == -1)
                    {
                        this.fileTree.AppendLine(string.Concat(new object[] { "d.add(", this.directoryIndex, ",", level, ",'", d.Substring(d.LastIndexOf("/") + 1), "','javascript: GetFileUrl(filelist[", this.listIndex, "]);');" }));
                    }
                    else
                    {
                        this.fileTree.AppendLine(string.Concat(new object[] { "filelist[", this.listIndex, "]='", d.Replace(this.rootUrl + @"\", "").Replace(@"\", "/"), "';" }));
                        this.fileTree.AppendLine(string.Concat(new object[] { "d.add(", this.directoryIndex, ",", level, ",'", d.Substring(d.LastIndexOf(@"\") + 1), "','javascript: GetFileUrl(filelist[", this.listIndex, "]);');" }));
                    }
                    this.listIndex++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="level"></param>
        public void ListFiles(string dir, int level)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(dir);
                foreach (string d in dirs)
                {
                    this.directoryIndex++;
                    if (d.LastIndexOf(@"\") == -1)
                    {
                        this.fileTree.AppendLine(string.Concat(new object[] { "d.add(", this.directoryIndex, ",", level, ",'", d.Substring(d.LastIndexOf("/") + 1), "');" }));
                    }
                    else
                    {
                        this.fileTree.AppendLine(string.Concat(new object[] { "d.add(", this.directoryIndex, ",", level, ",'", d.Substring(d.LastIndexOf(@"\") + 1), "');" }));
                    }
                    if (Directory.Exists(d))
                    {
                        this.ListFiles(d, this.directoryIndex);
                    }
                }
                string[] files = Directory.GetFiles(dir, "*.*htm*");
                foreach (string f in files)
                {
                    this.directoryIndex++;
                    if (f.LastIndexOf(@"\") == -1)
                    {
                        this.fileTree.AppendLine(string.Concat(new object[] { "filelist[", this.listIndex, "]='", f.Replace(this.rootUrl + @"\", "").Replace(@"\", "/"), "';" }));
                        this.fileTree.AppendLine(string.Concat(new object[] { "d.add(", this.directoryIndex, ",", level, ",''", f.Substring(f.LastIndexOf("/") + 1), "','javascript: GetFileUrl(filelist[", this.listIndex, "]);');" }));
                    }
                    else
                    {
                        this.fileTree.AppendLine(string.Concat(new object[] { "filelist[", this.listIndex, "]='", f.Replace(this.rootUrl + @"\", "").Replace(@"\", "/"), "';" }));
                        this.fileTree.AppendLine(string.Concat(new object[] { "d.add(", this.directoryIndex, ",", level, ",'", f.Substring(f.LastIndexOf(@"\") + 1), "','javascript: GetFileUrl(filelist[", this.listIndex, "]);');" }));
                    }
                    this.listIndex++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 读取文件的内容
        /// </summary>
        /// <param name="filePath">文件的路径</param>
        /// <returns>返回文件内容的字符串</returns>
        public string ReadFileContent(string filePath)
        {
            return this.ReadFileContent(filePath, this.defaultEncoding);
        }

        /// <summary>
        /// 读取文件的内容
        /// </summary>
        /// <param name="filePath">文件的路径</param>
        /// <param name="encoding">设置文件的编码格式</param>
        /// <returns></returns>
        public string ReadFileContent(string filePath, Encoding encoding)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath, encoding))
                {
                    return sr.ReadToEnd();
                }
            }
            catch
            {
                return "读取文件时产生不可预知的错误。";
            }
        }


        /// <summary>
        /// 读取文件的HTML内容
        /// </summary>
        /// <param name="Path">文件的路径</param>
        /// <returns>返回文件的HTML内容</returns>
        public static string ReadHtml(string Path)
        {
            string result = string.Empty;
            if (File.Exists(Path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(Path, Encoding.GetEncoding("UTF-8")))
                    {
                        result = sr.ReadToEnd();
                    }
                }
                catch
                {
                }
                return result;
            }
            return "文件读取失败!";
        }

        /// <summary>
        /// 重命名文件
        /// </summary>
        /// <param name="filePath">文件夹的路径</param>
        /// <param name="oldName">老名字</param>
        /// <param name="newName">新名字</param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public bool ReNameFile(string filePath, string oldName, string newName, int fileType)
        {
            try
            {
                if (fileType.Equals(0))
                {
                    if (Directory.Exists(filePath + @"\" + oldName))
                    {
                        Directory.Move(filePath + @"\" + oldName, filePath + @"\" + newName.Replace(".", ""));
                        return true;
                    }
                    return false;
                }
                if (File.Exists(filePath + @"\" + oldName))
                {
                    File.Move(filePath + @"\" + oldName, filePath + @"\" + newName);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

       
        /// <summary>
        /// 写内容到文件
        /// </summary>
        /// <param name="filePath">文件的路径</param>
        /// <param name="fileContent">写入的内容</param>
        /// <param name="isAppend">是否追加</param>
        /// <returns>是否成功</returns>
        public bool WriteFileContent(string filePath, string fileContent, bool isAppend)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    this.CreateFile(filePath, "");
                }
                StreamWriter Fso = new StreamWriter(filePath);
                Fso.WriteLine(fileContent);
                Fso.Close();
                Fso.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
