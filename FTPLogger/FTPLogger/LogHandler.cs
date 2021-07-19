using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace FTPLogger
{
	public class LogHandler
	{
		public HashSet<Log> directories = new HashSet<Log>();
		public HashSet<Log> checkedDir = new HashSet<Log>();
		public HashSet<Log> toCheck = new HashSet<Log>();
		public HashSet<Log> printedLogs = new HashSet<Log>();

		public async void WriteToFile(String content, String path)
        {
			String checkedPath = (String.IsNullOrEmpty(path) ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : path);

			await File.WriteAllTextAsync(checkedPath + "\\log.txt", content);
        }

		public HashSet<Log> ConnectFtp(String host, String user, String password)
        {
			HashSet<Log> tempLogs = new HashSet<Log>();
			try
			{
				
				FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" +host + "/");
				request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

				request.Credentials = new NetworkCredential(user, password);

				FtpWebResponse response = (FtpWebResponse)request.GetResponse();

				Stream responseStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(responseStream);
				

				string line = reader.ReadLine();
				
				while (!string.IsNullOrEmpty(line))
				{
					Log log = LogFactory(line, false);
					tempLogs.Add(log);
					line = reader.ReadLine();
				} 
				reader.Close();

				return tempLogs;

			}
			catch (WebException webEx)
			{
				Log errorLog = LogFactory(webEx.Message, true); 
				tempLogs.Add(errorLog);
				foreach (Log log in tempLogs)
				{
					Debug.WriteLine(log.GetFullString());
				}
				return tempLogs;
			}
			catch (Exception ex)
			{
				Log errorLog = LogFactory(ex.Message, true);
				tempLogs.Add(errorLog);
				return tempLogs;
			}
			
		}

		public String ListPrinter(String prev)
        {
			int count = 0;
			StringBuilder sb = new StringBuilder(prev);
			if (!directories.Equals(printedLogs))
			{
				foreach (Log log in directories)
				{
					if (printedLogs.Count() > 0)
					{

						if (!printedLogs.Contains(log))
						{
							Debug.WriteLine("what");
							sb.Append(log.GetFullString());
							sb.Append(Environment.NewLine);
						}

					}
					else
					{
						sb.Append(log.GetFullString());
						sb.Append(Environment.NewLine);
					}
					Debug.WriteLine("yeah");
				}
			}
			printedLogs = directories;

			sb.Append("-- " + System.DateTime.Now + " --");
			sb.Append(Environment.NewLine);
			return sb.ToString();

        }

		public void ListBuilder(String host, String username, String password)
        {
			
			toCheck = ConnectFtp(host,username,password);
			HashSet<String> newHosts = new HashSet<String>();

			foreach (Log log in toCheck)
			{
					checkedDir.Add(log);
					directories.Add(log);
					if (log.GetMetaData().Contains("drwxr-xr-x"))
					{
						String[] arr = log.GetFullString().Split(" ");
						log.SetFolder(true);
						String newHost = host + "/" + arr[21];
						newHosts.Add(newHost);
					}
			}

			if (newHosts.Count() > 0)
            {
				NextList(newHosts, username, password);
            }
		}

		public String host;

		public void NextList(HashSet<String> hostList, String username, String password)
		{
		
			HashSet<String> newHosts = new HashSet<String>();

			foreach (String currentHost in hostList)
			{
				toCheck = ConnectFtp(currentHost, username, password);
				host = currentHost;
			}

			foreach (Log log in toCheck)
			{
						foreach (Log check in checkedDir)
						{
							if (!log.Equals(check))
							{
								directories.Add(log);
							if (log.GetMetaData().Contains("drwxr-xr-x"))
							{
								String[] arr = log.GetFullString().Split(" ");
								log.SetFolder(true);
								String newHost = host + "/" + arr[21];
							foreach (String checkHost in hostList)
							{
								if (newHost != checkHost)
								{
									newHosts.Add(newHost);
								}
							}
						}
					}
				}	
				checkedDir.Add(log);
			}
			
			if (newHosts.Count() > 0)
			{
				NextList(newHosts, username, password);
			}
		}


		public Log LogFactory(String value, bool error)
        {

			String[] split = value.Split(" ");
			Log log = new Log();
			if (split.Length > 1 && !error)
			{
				if (split[0].Contains("drwxr-xr-x"))
				{
					log.SetFolder(true);
				}
				StringBuilder sb = new StringBuilder(log.GetMetaData());
				for (int i = 0; i < 10; i++)
				{
					sb.Append(split[i]);
				}
				log.SetMetaData(sb.ToString());
				log.SetFileName(split[21]);
				log.SetError(error);
				log.SetFullString(value);
				log.SetDateUpdated(split[18] + split[19] + split[20]);
			}
			else { 
				log.SetFullString(value);
				log.SetError(error);
			}

            
			return log;
        }

	}


}
