using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_xml.Models
{
  public class WeatherData
  {
    public string zone { get; set; }//地區
    public string startTime { get; set; }//開始時間
    public string endTime { get; set; }
    public string T { get; set; }//溫度
    public string Tvalue { get; set; }
    public string Tmeasures { get; set; }
    public string TName { get; set; }
    public string Td { get; set; }//露點溫度
    public string Tdvalue { get; set; }
    public string Tdmeasures { get; set; }
    public string TdName { get; set; }
    public string RH { get; set; }//相對濕度
    public string RHvalue { get; set; }
    public string RHmeasures { get; set; }
    public string RHName { get; set; }
    public string PoP6h { get; set; }//6小時降雨機率
    public string PoP6hvalue { get; set; }
    public string PoP6hmeasures { get; set; }
    public string PoP6hName { get; set; }
    public string PoP12h { get; set; }//12小時降雨機率
    public string PoP12hmeasures { get; set; }
    public string PoP12hvalue { get; set; }
    public string PoP12hName { get; set; }
    public string WD { get; set; }//風向
    public string WDvalue { get; set; }
    public string WDmeasures { get; set; }
    public string WDName { get; set; }
    public string WS { get; set; }//風速
    public string WSvalue { get; set; }
    public string WSmeasures { get; set; }
    public string WSName { get; set; }
    public string CI { get; set; }//舒適度指數
    public string CIvalue { get; set; }
    //public string CImeasures { get; set; }
    public string CIName { get; set; }
    public string AT { get; set; }//體感溫度
    public string ATvalue { get; set; }
    public string ATmeasures { get; set; }
    public string ATName { get; set; }
    public string Wx { get; set; }//天氣現象
    public string Wxvalue { get; set; }
    public string Wxvalue2 { get; set; }
    public string WxName { get; set; }
    public string description { get; set; }//天氣預報綜合描述
    public string descriptionValue { get; set; }
    //public string descriptionMeasures { get; set; }
    public string descriptionName { get; set; }
  }
}