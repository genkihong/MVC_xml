using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_xml.Models
{
  public class Weather
  {
    public string zone { get; set; }//地區
    public string T { get; set; }//溫度
    public List<WeatherT> WeatherTs { get; set; }
   
    public string Td { get; set; }//露點溫度
    public List<WeatherTd> WeatherTds{ get; set; }
    
    public string RH { get; set; }//相對濕度
    public List<WeatherRH> WeatherRhs { get; set; }
   
    public string PoP6h { get; set; }//6小時降雨機率
    public List<WeatherPoP6h> WeatherPoP6Hs { get; set; }
   
    public string PoP12h { get; set; }//12小時降雨機率
    public List<WeatherPoP12h> WeatherPoP12Hs { get; set; }
   
    public string WD { get; set; }//風向
    public List<WeatherWD> WeatherWds { get; set; }
    
    public string WS { get; set; }//風速
    public List<WeatherWS> WeatherWses{ get; set; }
    
    public string CI { get; set; }//舒適度指數
    public List<WeatherCI> WeatherCis { get; set; }
    
    public string AT { get; set; }//體感溫度
    public List<WeatherAT> WeatherAts { get; set; }
    
    public string Wx { get; set; }//天氣現象
    public List<WeatherWx> WeatherWxes { get; set; }
    
    public string description { get; set; }//天氣預報綜合描述
    public List<WeatherDescription> WeatherDescriptions { get; set; }
  }

  public class WeatherT
  {
    public string dataTime { get; set; }
    public WeatherValue WeatherValue { get; set; }
  }

  public class WeatherRH
  {
    public string dataTime { get; set; }
    public WeatherValue WeatherValue { get; set; }
  }

  public class WeatherTd
  {
    public string dataTime { get; set; }
    public WeatherValue WeatherValue { get; set; }
  }

  public class WeatherPoP6h
  {
    public string startTime { get; set; }
    public string endTime { get; set; }
    public WeatherValue WeatherValue { get; set; }
  }

  public class WeatherPoP12h
  {
    public string startTime { get; set; }
    public string endTime { get; set; }
    public WeatherValue WeatherValue { get; set; }
  }

  public class WeatherWD
  {
    public string dataTime { get; set; }
    public WeatherValue WeatherValue { get; set; }
  }

  public class WeatherWS
  {
    public string dataTime { get; set; }
    public WeatherValue WeatherValue { get; set; }
  }

  public class WeatherCI
  {
    public string dataTime { get; set; }
    public WeatherValue WeatherValue { get; set; }
  }

  public class WeatherAT
  {
    public string dataTime { get; set; }
    public WeatherValue WeatherValue { get; set; }
  }

  public class WeatherWx
  {
    public string startTime { get; set; }
    public string endTime { get; set; }
    public WeatherValue WeatherValue { get; set; }
  }

  public class WeatherDescription
  {
    public string startTime { get; set; }
    public string endTime { get; set; }
    public WeatherValue WeatherValue { get; set; }
  }

  public class WeatherValue
  {
    public string value { get; set; }
    public string measures { get; set; }
  }
}