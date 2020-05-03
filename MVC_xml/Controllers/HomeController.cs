using MVC_xml.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Microsoft.SqlServer.Server;

namespace MVC_xml.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      string content = GetJsonContent("https://opendata.cwb.gov.tw/fileapi/v1/opendataapi/F-D0047-065?Authorization=CWB-BC2E6A08-130F-4DCA-B26C-8E5ADF09F133&downloadType=WEB&format=XML");
      string xmlUrl = content.Replace("urn:cwb:gov:tw:cwbcommon:0.1", "");

      XmlDocument xmlDocument = new XmlDocument();
      //xmlDocument.Load("https://opendata.cwb.gov.tw/fileapi/v1/opendataapi/F-D0047-065?Authorization=CWB-BC2E6A08-130F-4DCA-B26C-8E5ADF09F133&downloadType=WEB&format=XML");
      //xmlDocument.Load(Server.MapPath("/F-D0047-065.xml"));
      xmlDocument.LoadXml(xmlUrl);
      XmlNode root = xmlDocument.DocumentElement;
      ViewBag.City = root.SelectSingleNode("dataset/locations/locationsName").InnerText;
      
      List<WeatherData> weatherDatas = new List<WeatherData>();//建立一個List空集合

      //XmlNodeList locationList = xmlDocument.SelectNodes("/cwbopendata/dataset/locations/location");
      XmlNodeList locationList = root.SelectNodes("dataset/locations/location");//38個
      foreach (XmlNode locationNode in locationList) //location
      {
        XmlNodeList weatherNodeList = locationNode.SelectNodes("weatherElement");
        foreach (XmlNode weather in weatherNodeList)
        {
          XmlNodeList timeList = weather.SelectNodes("time");

          switch (weather["elementName"].InnerText)
          {
            case "T":
              foreach (XmlNode time in timeList)
              {
                WeatherData weatherData = new WeatherData()
                {
                  zone = locationNode["locationName"].InnerText,//地區
                  TName = weather["elementName"].InnerText,//氣象代號
                  T = weather["description"].InnerText,//氣象名稱
                  startTime = time.SelectSingleNode("dataTime").InnerText,//開始時間
                  Tvalue = time.SelectSingleNode("elementValue").FirstChild.InnerText,//氣象值
                  Tmeasures = time.SelectSingleNode("elementValue").LastChild.InnerText,//氣象單位
                };
                weatherDatas.Add(weatherData);
              }
              break;
            case "Td":
              foreach (XmlNode time in timeList)
              {
                var location = weatherDatas.Where(x => x.startTime == time.SelectSingleNode("dataTime").InnerText &&
                       x.zone == locationNode["locationName"].InnerText).First();

                location.TdName = weather["elementName"].InnerText;
                location.Td = weather["description"].InnerText;
                location.Tdvalue = time.SelectSingleNode("elementValue").FirstChild.InnerText;
                location.Tdmeasures = time.SelectSingleNode("elementValue").LastChild.InnerText;
              }
              break;
            case "RH":
              foreach (XmlNode time in timeList)
              {
                var location = weatherDatas.Where(x => x.startTime == time.SelectSingleNode("dataTime").InnerText &&
                       x.zone == locationNode["locationName"].InnerText).First();

                location.RHName = weather["elementName"].InnerText;
                location.RH = weather["description"].InnerText;
                location.RHvalue = time.SelectSingleNode("elementValue").FirstChild.InnerText;
                location.RHmeasures = time.SelectSingleNode("elementValue").LastChild.InnerText;
              }
              break;
            case "PoP6h":
              foreach (XmlNode time in timeList)
              {
                var location = weatherDatas.Where(x => x.startTime == time.SelectSingleNode("startTime").InnerText &&
                       x.zone == locationNode["locationName"].InnerText).First();

                location.PoP6hName = weather["elementName"].InnerText;
                location.PoP6h = weather["description"].InnerText;
                location.PoP6hvalue = time.SelectSingleNode("elementValue").FirstChild.InnerText;
                location.PoP6hmeasures = time.SelectSingleNode("elementValue").LastChild.InnerText;
              }
              break;
            case "PoP12h":
              foreach (XmlNode time in timeList)
              {
                var location = weatherDatas.Where(x => x.startTime == time.SelectSingleNode("startTime").InnerText &&
                       x.zone == locationNode["locationName"].InnerText).First();

                location.PoP12hName = weather["elementName"].InnerText;
                location.PoP12h = weather["description"].InnerText;
                location.PoP12hvalue = time.SelectSingleNode("elementValue").FirstChild.InnerText;
                location.PoP12hmeasures = time.SelectSingleNode("elementValue").LastChild.InnerText;
              }
              break;
            case "WD":
              foreach (XmlNode time in timeList)
              {
                var location = weatherDatas.Where(x => x.startTime == time.SelectSingleNode("dataTime").InnerText &&
                       x.zone == locationNode["locationName"].InnerText).First();

                location.WDName = weather["elementName"].InnerText;
                location.WD = weather["description"].InnerText;
                location.WDvalue = time.SelectSingleNode("elementValue").FirstChild.InnerText;
                location.WDmeasures = time.SelectSingleNode("elementValue").LastChild.InnerText;
              }
              break;
            case "WS":
              foreach (XmlNode time in timeList)
              {
                var location = weatherDatas.Where(x => x.startTime == time.SelectSingleNode("dataTime").InnerText &&
                       x.zone == locationNode["locationName"].InnerText).First();

                location.WSName = weather["elementName"].InnerText;
                location.WS = weather["description"].InnerText;
                location.WSvalue = time.SelectSingleNode("elementValue").FirstChild.InnerText;
                location.WSmeasures = time.SelectSingleNode("elementValue").LastChild.InnerText;
              }
              break;
            case "CI":
              foreach (XmlNode time in timeList)
              {
                var location = weatherDatas.Where(x => x.startTime == time.SelectSingleNode("dataTime").InnerText &&
                       x.zone == locationNode["locationName"].InnerText).First();

                location.CIName = weather["elementName"].InnerText;
                location.CI = weather["description"].InnerText;
                location.CIvalue = time.SelectSingleNode("elementValue").FirstChild.InnerText;
              }
              break;
            case "AT":
              foreach (XmlNode time in timeList)
              {
                var location = weatherDatas.Where(x => x.startTime == time.SelectSingleNode("dataTime").InnerText &&
                       x.zone == locationNode["locationName"].InnerText).First();

                location.ATName = weather["elementName"].InnerText;
                location.AT = weather["description"].InnerText;
                location.ATvalue = time.SelectSingleNode("elementValue").FirstChild.InnerText;
                location.ATmeasures = time.SelectSingleNode("elementValue").LastChild.InnerText;
              }
              break;
            case "Wx":
              foreach (XmlNode time in timeList)
              {
                var location = weatherDatas.Where(x => x.startTime == time.SelectSingleNode("startTime").InnerText &&
                       x.zone == locationNode["locationName"].InnerText).First();

                location.WxName = weather["elementName"].InnerText;
                location.Wx = weather["description"].InnerText;

                XmlNodeList valueList = time.SelectNodes("elementValue");
                location.Wxvalue = valueList[0]["value"].InnerText;
                location.Wxvalue2 = valueList[1]["value"].InnerText;
              }
              break;
            case "WeatherDescription":
              foreach (XmlNode time in timeList)
              {
                var location = weatherDatas.Where(x => x.startTime == time.SelectSingleNode("startTime").InnerText &&
                       x.zone == locationNode["locationName"].InnerText).First();

                location.descriptionName = weather["elementName"].InnerText;
                location.description = weather["description"].InnerText;
                location.descriptionValue = time.SelectSingleNode("elementValue").FirstChild.InnerText;
              }
              break;
          }
        }
      }
      return View(weatherDatas);
    }
    private string GetJsonContent(string Url)
    {
      try //程式主執行區或可能發生錯誤的地方
      {
        string targetURI = Url;
        var request = System.Net.WebRequest.Create(targetURI);  // Create a request for the URL.
        request.ContentType = "application/json; charset=utf-8";
        string text;
        var response = (System.Net.HttpWebResponse)request.GetResponse();
        using (var sr = new StreamReader(response.GetResponseStream()))
        {
          text = sr.ReadToEnd();
        }
        return text;
      }
      catch (Exception) //例外的處理方法，如秀出警告
      {
        return string.Empty;
      }
    }
    //public ActionResult Index()
    //{
    //  List<Weather> weathers = new List<Weather>();//建立一個List空集合

    //  XmlDocument xmlDocument = new XmlDocument();
    //  xmlDocument.Load(Server.MapPath("/F-D0047-065.xml"));
    //  //xmlDocument.Load("https://opendata.cwb.gov.tw/fileapi/v1/opendataapi/F-D0047-065?Authorization=CWB-BC2E6A08-130F-4DCA-B26C-8E5ADF09F133&downloadType=WEB&format=XML");

    //  //XmlNodeList locations = xmlDocument.SelectNodes("/cwbopendata/dataset/locations/location");
    //  XmlNode root = xmlDocument.DocumentElement;
    //  XmlNode city = root.SelectSingleNode("dataset/locations/locationsName");
    //  XmlNodeList locations = root.SelectNodes("dataset/locations/location");//38個

    //  #region ChildNodes 寫法(不好)
    //  //XmlNode dataset = root.LastChild;
    //  //XmlNode locations = dataset.LastChild;
    //  //XmlNode city = locations.FirstChild;//locations=>locationsName
    //  //XmlNodeList locationList = locations.ChildNodes;//locations=>location*N
    //  #endregion
    //  ViewBag.City = city.InnerText;

    //  foreach (XmlNode locationNode in locations) //location
    //  {
    //    Weather weather = new Weather//建立 Weather 物件
    //    {
    //      zone = locationNode["locationName"].InnerText //地區
    //    };

    //    XmlNodeList weatherList = locationNode.SelectNodes("weatherElement"); //11個
    //    foreach (XmlNode weatherNode in weatherList) //weatherElement
    //    {
    //      XmlNodeList timeList = weatherNode.SelectNodes("time");
    //      switch (weatherNode["elementName"].InnerText)
    //      {
    //        case "T": //溫度
    //          weather.T = weatherNode["description"].InnerText;

    //          weather.WeatherTs = new List<WeatherT>();
    //          foreach (XmlNode timeNode in timeList)
    //          {
    //            WeatherT weatherT = new WeatherT
    //            {
    //              dataTime = timeNode["dataTime"].InnerText,
    //              WeatherValue = new WeatherValue
    //              {
    //                value = timeNode["elementValue"].FirstChild.InnerText,
    //                measures = timeNode["elementValue"].LastChild.InnerText
    //              }
    //            };
    //            weather.WeatherTs.Add(weatherT);
    //          }
    //          break;
    //        case "Td": //露點溫度
    //          weather.Td = weatherNode["description"].InnerText;

    //          weather.WeatherTds = new List<WeatherTd>();
    //          foreach (XmlNode timeNode in timeList)
    //          {
    //            WeatherTd weatherTd = new WeatherTd
    //            {
    //              dataTime = timeNode["dataTime"].InnerText,
    //              WeatherValue = new WeatherValue
    //              {
    //                value = timeNode["elementValue"].FirstChild.InnerText,
    //                measures = timeNode["elementValue"].LastChild.InnerText
    //              }
    //            };
    //            weather.WeatherTds.Add(weatherTd);
    //          }
    //          break;
    //        case "RH": //相對濕度
    //          weather.RH = weatherNode["description"].InnerText;

    //          weather.WeatherRhs = new List<WeatherRH>();
    //          foreach (XmlNode timeNode in timeList)
    //          {
    //            WeatherRH weatherRH = new WeatherRH
    //            {
    //              dataTime = timeNode["dataTime"].InnerText,
    //              WeatherValue = new WeatherValue
    //              {
    //                value = timeNode["elementValue"].FirstChild.InnerText,
    //                measures = timeNode["elementValue"].LastChild.InnerText
    //              }
    //            };
    //            weather.WeatherRhs.Add(weatherRH);
    //          }
    //          break;
    //        case "PoP6h": //6小時降雨機率
    //          weather.PoP6h = weatherNode["description"].InnerText;

    //          weather.WeatherPoP6Hs = new List<WeatherPoP6h>();
    //          foreach (XmlNode timeNode in timeList)
    //          {
    //            WeatherPoP6h weatherPoP6h = new WeatherPoP6h
    //            {
    //              startTime = timeNode["startTime"].InnerText,
    //              endTime = timeNode["endTime"].InnerText,
    //              WeatherValue = new WeatherValue
    //              {
    //                value = timeNode["elementValue"].FirstChild.InnerText,
    //                measures = timeNode["elementValue"].LastChild.InnerText
    //              }
    //            };
    //            weather.WeatherPoP6Hs.Add(weatherPoP6h);
    //          }
    //          break;
    //        case "PoP12h": //12小時降雨機率
    //          weather.PoP12h = weatherNode["description"].InnerText;

    //          weather.WeatherPoP12Hs = new List<WeatherPoP12h>();
    //          foreach (XmlNode timeNode in timeList)
    //          {
    //            WeatherPoP12h weatherPoP12h = new WeatherPoP12h
    //            {
    //              startTime = timeNode["startTime"].InnerText,
    //              endTime = timeNode["endTime"].InnerText,
    //              WeatherValue = new WeatherValue
    //              {
    //                value = timeNode["elementValue"].FirstChild.InnerText,
    //                measures = timeNode["elementValue"].LastChild.InnerText
    //              }
    //            };
    //            weather.WeatherPoP12Hs.Add(weatherPoP12h);
    //          }
    //          break;
    //        case "WD": //風向
    //          weather.WD = weatherNode["description"].InnerText;

    //          weather.WeatherWds = new List<WeatherWD>();
    //          foreach (XmlNode timeNode in timeList)
    //          {
    //            WeatherWD weatherWD = new WeatherWD
    //            {
    //              dataTime = timeNode["dataTime"].InnerText,
    //              WeatherValue = new WeatherValue
    //              {
    //                value = timeNode["elementValue"].FirstChild.InnerText,
    //                measures = timeNode["elementValue"].LastChild.InnerText
    //              }
    //            };
    //            weather.WeatherWds.Add(weatherWD);
    //          }
    //          break;
    //        case "WS": //風速
    //          weather.WS = weatherNode["description"].InnerText;

    //          weather.WeatherWses = new List<WeatherWS>();
    //          foreach (XmlNode timeNode in timeList)
    //          {
    //            WeatherWS weatherWS = new WeatherWS
    //            {
    //              dataTime = timeNode["dataTime"].InnerText,
    //              WeatherValue = new WeatherValue
    //              {
    //                value = timeNode["elementValue"].FirstChild.InnerText,
    //                measures = timeNode["elementValue"].LastChild.InnerText
    //              }
    //            };
    //            weather.WeatherWses.Add(weatherWS);
    //          }
    //          break;
    //        case "CI": //舒適度指數
    //          weather.CI = weatherNode["description"].InnerText;

    //          weather.WeatherCis = new List<WeatherCI>();
    //          foreach (XmlNode timeNode in timeList)
    //          {
    //            WeatherCI weatherCI = new WeatherCI
    //            {
    //              dataTime = timeNode["dataTime"].InnerText,
    //              WeatherValue = new WeatherValue
    //              {
    //                value = timeNode["elementValue"].FirstChild.InnerText,
    //                //measures = timeNode["elementValue"].LastChild.InnerText
    //              }
    //            };
    //            weather.WeatherCis.Add(weatherCI);
    //          }
    //          break;
    //        case "AT": //體感溫度
    //          weather.AT = weatherNode["description"].InnerText;

    //          weather.WeatherAts = new List<WeatherAT>();
    //          foreach (XmlNode timeNode in timeList)
    //          {
    //            WeatherAT weatherAT = new WeatherAT
    //            {
    //              dataTime = timeNode["dataTime"].InnerText,
    //              WeatherValue = new WeatherValue
    //              {
    //                value = timeNode["elementValue"].FirstChild.InnerText,
    //                measures = timeNode["elementValue"].LastChild.InnerText
    //              }
    //            };
    //            weather.WeatherAts.Add(weatherAT);
    //          }
    //          break;
    //        case "Wx": //天氣現象
    //          weather.Wx = weatherNode["description"].InnerText;

    //          weather.WeatherWxes = new List<WeatherWx>();
    //          foreach (XmlNode timeNode in timeList)
    //          {
    //            WeatherWx weatherWx = new WeatherWx
    //            {
    //              startTime = timeNode["startTime"].InnerText,
    //              endTime = timeNode["endTime"].InnerText,
    //              WeatherValue = new WeatherValue
    //              {
    //                value = timeNode["elementValue"].FirstChild.InnerText,
    //                //measures = timeNode["elementValue"].LastChild.InnerText
    //              }
    //            };
    //            weather.WeatherWxes.Add(weatherWx);
    //          }
    //          break;
    //        case "WeatherDescription": //天氣預報綜合描述
    //          weather.description = weatherNode["description"].InnerText;

    //          weather.WeatherDescriptions = new List<WeatherDescription>();
    //          foreach (XmlNode timeNode in timeList)
    //          {
    //            WeatherDescription weatherDescription = new WeatherDescription
    //            {
    //              startTime = timeNode["startTime"].InnerText,
    //              endTime = timeNode["endTime"].InnerText,
    //              WeatherValue = new WeatherValue
    //              {
    //                value = timeNode["elementValue"].FirstChild.InnerText,
    //                //measures = timeNode["elementValue"].LastChild.InnerText
    //              }
    //            };
    //            weather.WeatherDescriptions.Add(weatherDescription);
    //          }
    //          break;
    //      }
    //    }
    //    weathers.Add(weather);
    //  }
    //  return View(weathers);
    //}

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}