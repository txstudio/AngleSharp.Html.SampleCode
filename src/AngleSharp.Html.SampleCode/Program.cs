using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AngleSharp.Html.SampleCode
{
    public class Program
    {
        //取得網頁 HTML 原始碼
        public static string GetHtml(string url)
        {
            HttpClient _client = new HttpClient();

            var _response = _client.GetAsync(url).Result;
            var _html = _response.Content.ReadAsStringAsync().Result;

            return _html;
        }

        //使用 AngelSharp 的 HtmlParser 類別處理下載的 HTML 文件
        public static string GetTitle(string html)
        {
            var _selector = "h1.title";

            var _parser = new HtmlParser();
            var _document = _parser.Parse(html);
            var _element = _document.QuerySelector(_selector);
            var _title = _element.TextContent;

            _title = _title.Trim();

            return _title;
        }


        public static void Main(string[] args)
        {
            //指定主控台輸出編碼為 Big5
            //  TextEncoding.Big5 為 AngelSharp 提供的 Encoding Helper

            Console.OutputEncoding = TextEncoding.Big5;

            string _url = "https://txstudio-tw.blogspot.tw/";


            var _html = GetHtml(_url);
            var _title = GetTitle(_html);

            
            //輸出文字內容
            Console.WriteLine("網站 \"{0}\"", _url);
            Console.WriteLine("網站主要標題：\"{0}\"", _title);

            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
    }
}
