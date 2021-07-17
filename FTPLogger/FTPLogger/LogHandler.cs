using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Windows.Forms;

namespace FTPLogger
{
	public class LogHandler
	{

		public async void WriteToFile(String content, String path)
        {
			String checkedPath = (String.IsNullOrEmpty(path) ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : path);

			await File.WriteAllTextAsync(checkedPath + "\\log.txt", content);
        }

		public List<String> ConnectFtp(String host, String user, String password)
        {
			try
			{
				List<string> logDirectories = new List<string>();
				FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" +host + "/");
				request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

				request.Credentials = new NetworkCredential(user, password);

				FtpWebResponse response = (FtpWebResponse)request.GetResponse();

				Stream responseStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(responseStream);
				

				string line = reader.ReadLine();
				while (!string.IsNullOrEmpty(line))
				{
					var lineArr = line.Split('/');
					line = lineArr[lineArr.Count() - 1];
					logDirectories.Add(line);
					line = reader.ReadLine();
				}
				reader.Close();

				return logDirectories;

			}
			catch (WebException webEx)
			{
                List<String> error = new List<string>
                {
                    webEx.Message
                };
                return error;
			}
			catch (Exception ex)
			{
                List<String> error = new List<string>
                {
                    ex.Message
                };
                return error;
			}
		}

		public String ListIterator(List<String> logList, String logs)
		{
			StringBuilder sb = new StringBuilder(logs);
			foreach (String s in logList)
			{
				sb.Append(s);
				sb.Append(Environment.NewLine);
			}
			sb.Append("-- " + System.DateTime.Now + " --");
			sb.Append(Environment.NewLine);
			return sb.ToString();
		}

		public List<String> ListBuilder(String host, String username, String password)
        {
			List<String> logList = ConnectFtp(host,username,password);
			List<String> moreLogs = new List<String>();
			moreLogs.AddRange(logList);

			foreach (String s in logList)
			{
				if (s.Contains("drwxr-xr-x"))
				{
					String[] arr = s.Split(" ");
					

					moreLogs.AddRange(ConnectFtp(host + "/" + arr[21], username, password));
				}
			}

			return moreLogs;
		}

	}
}
