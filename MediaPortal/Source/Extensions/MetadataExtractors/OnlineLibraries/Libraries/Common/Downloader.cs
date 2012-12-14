﻿#region Copyright (C) 2007-2012 Team MediaPortal

/*
    Copyright (C) 2007-2012 Team MediaPortal
    http://www.team-mediaportal.com

    This file is part of MediaPortal 2

    MediaPortal 2 is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    MediaPortal 2 is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with MediaPortal 2. If not, see <http://www.gnu.org/licenses/>.
*/

#endregion

using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace MediaPortal.Extensions.OnlineLibraries.Libraries.Common
{
  public class Downloader
  {
    /// <summary>
    /// Downloads the requested information from the JSON api and deserializes the response to the requested <typeparam name="TE">Type</typeparam>.
    /// This method can save the response to local cache, if a valid path is passed in <paramref name="saveCacheFile"/>.
    /// </summary>
    /// <typeparam name="TE">Target type</typeparam>
    /// <param name="url">Url to download</param>
    /// <param name="saveCacheFile">Optional name for saving response to cache</param>
    /// <param name="addAcceptJSON"><c>true</c> to add "Accept:application/json"</param>
    /// <returns>Downloaded object</returns>
    public TE Download<TE>(string url, string saveCacheFile = null, bool addAcceptJSON = true)
    {
      string json = DownloadJSON(url, addAcceptJSON);
      if (!string.IsNullOrEmpty(saveCacheFile))
        WriteCache(saveCacheFile, json);
      return JsonConvert.DeserializeObject<TE>(json);
    }

    /// <summary>
    /// Downloads the JSON string from API.
    /// </summary>
    /// <param name="url">Url to download</param>
    /// <param name="addAcceptJSON"><c>true</c> to add "Accept:application/json"</param>
    /// <returns>JSON result</returns>
    protected string DownloadJSON(string url, bool addAcceptJSON = true)
    {
      WebClient webClient = new WebClient { Encoding = Encoding.UTF8 };
      if (addAcceptJSON)
        webClient.Headers["Accept"] = "application/json";
      return webClient.DownloadString(url);
    }

    /// <summary>
    /// Donwload a file from given <paramref name="url"/> and save it to <paramref name="downloadFile"/>.
    /// </summary>
    /// <param name="url">Url to download</param>
    /// <param name="downloadFile">Target file name</param>
    /// <returns><c>true</c> if successful</returns>
    public bool DownloadFile(string url, string downloadFile)
    {
      if (File.Exists(downloadFile))
        return true;
      try
      {
        WebClient webClient = new WebClient();
        webClient.DownloadFile(url, downloadFile);
        return true;
      }
      catch (Exception ex)
      {
        // TODO: logging
        return false;
      }
    }

    /// <summary>
    /// Writes JSON strings to cache file.
    /// </summary>
    /// <param name="cachePath"></param>
    /// <param name="json"></param>
    protected void WriteCache(string cachePath, string json)
    {
      if (string.IsNullOrEmpty(cachePath))
        return;

      using (FileStream fs = new FileStream(cachePath, FileMode.Create, FileAccess.Write))
      {
        using (StreamWriter sw = new StreamWriter(fs))
        {
          sw.Write(json);
          sw.Close();
        }
        fs.Close();
      }
    }
  }
}