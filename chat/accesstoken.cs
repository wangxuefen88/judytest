using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Configuration;
using System.Data;
using Model;
using BLL;
namespace chat
{
      public  class accesstoken
     {
          public static void SendWechat() {
              //获取我们的token数据
              string access_token = getAccessToken();
            //连接微信的接口
            string a = "asdf";
              string url = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + access_token;
              string AgentId = "1000003";
            //  string postText = "{\"touser\" :\"@all\",\"toparty\" : \"@all\",\"totag\" : \"@all\",\"msgtype\" : \"text\",\"agentid\" : " + AgentId + ",\"text\" : {\"content\" : \"欢迎大家使用微信订餐<a href='http://tfjybj.com/OrderSystem'>请点击这里</a>\n祝大家学习愉快！。\"},\"safe\":0}";
            string postText = "{\"touser\" :\"@all\",\"toparty\" : \"@all\",\"totag\" : \"@all\",\"msgtype\" : \"news\",\"agentid\" : " + AgentId + ",\"news\" : {\"articles\" :[{ \"title\" : \""+a+"\",\"description\" : \"问题：你是否有你想象中努力？\",\"url\" : \"http://tfjybj.com/OrderSystem\",\"picurl\" : \"http://pic2.sc.chinaz.com/files/pic/pic9/201801/bpic5184.jpg\",\"btntxt\":\"点击查看\"]}";
           // string pstTexty= "\"title\" : \"中秋节礼品领取\",\"description\" : \"今年中秋节公司有豪礼相送\",\"url\" : \"URL\",\"picurl\" : \"http://res.mail.qq.com/node/ww/wwopenmng/images/independent/doc/test_pic_msg1.png\",\"btntxt\":\"更多\"";
                Encoding encoding = Encoding.GetEncoding("utf-8");
              byte[] bytesToPost = encoding.GetBytes(postText);
              string res = Post(url, bytesToPost);
              Console.WriteLine(res);
          }

        public static void Sendchat()
        {
            //获取我们的token数据
            string access_token = getAccessToken();
            //连接微信的接口
            string url = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + access_token;
            string AgentId = "1000003";
            string postText = "{\"touser\" :\"@all\",\"toparty\" : \"@all\",\"totag\" : \"@all\",\"msgtype\" : \"text\",\"agentid\" : " + AgentId + ",\"text\" : {\"content\" : \"asdf<a href='http://tfjybj.com/OrderSystem'>请点击这里</a>\n祝大家学习愉快！。\"},\"safe\":0}";
            Encoding encoding = Encoding.GetEncoding("utf-8");
            byte[] bytesToPost = encoding.GetBytes(postText);
            string res = Post(url, bytesToPost);
            Console.WriteLine(res);
        }

        public static void quertion()
        {
            List<Model.test> list = new List<Model.test>();

            list = QAnswerBLL.querstionBll();
            //获取我们的token数据
            string access_token = chat.accesstoken.getAccessToken();
            //连接微信的接口
            string url = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + access_token;
            string AgentId = "1000003";
            string postText = "{\"touser\" :\"@all\",\"toparty\" : \"@all\",\"totag\" : \"@all\",\"msgtype\" : \"news\",\"agentid\" : " + AgentId + ",\"news\" : {\"articles\" :[{ \"title\" : \"" + list[0].question + "\",\"description\" : \"问题：你是否有你想象中努力？\",\"url\" : \"http://tfjybj.com/OrderSystem\",\"picurl\" : \"http://pic2.sc.chinaz.com/files/pic/pic9/201801/bpic5184.jpg\",\"btntxt\":\"点击查看\"]}";
            Encoding encoding = Encoding.GetEncoding("utf-8");
            byte[] bytesToPost = encoding.GetBytes(postText);
            string res = chat.accesstoken.Post(url, bytesToPost);
            Console.WriteLine(res);
        }

        #region 通过post方式把数据推送-李鑫超-2017年7月17日17:22:21
        /// <summary>-
        /// 通过post方式把数据推送-王雪芬-2017年12月28日22:23:45
        /// </summary>
        /// <param name="url"></param>
        /// <param name="bytesToPost"></param>
        /// <returns></returns>
        public static string Post(string url, byte[] bytesToPost)
          {
              if (String.IsNullOrEmpty(url))
                  return "url参数为空值";
              if (bytesToPost == null)
                  return "post数据为空值";
              string ResponseString = "";
              HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
              System.Net.ServicePointManager.DefaultConnectionLimit = 50;
              request.KeepAlive = false;
              request.Method = "POST";
              request.ContentType = "text/xml";//提交xml   
              request.ContentLength = bytesToPost.Length;
              Stream writer = request.GetRequestStream();
              writer.Write(bytesToPost, 0, bytesToPost.Length);
              HttpWebResponse HttpWebRespon = (HttpWebResponse)request.GetResponse();
              StreamReader myStreamReader = new StreamReader(HttpWebRespon.GetResponseStream(), Encoding.UTF8);
              ResponseString = myStreamReader.ReadToEnd();
              myStreamReader.Close();
              writer.Flush();
              if (writer != null)
              {
                  writer.Close();
              }
              if (request != null)
              {
                  request.Abort();
              }
              return ResponseString;
          }
          #endregion
                  
          /// <summary>
          /// 获取accesstoken-王雪芬-2017年12月28日22:23:26
          /// </summary>
          /// <returns></returns>
          public static string getAccessToken()
          {
              //企业的唯一id
              string appid = "wwf6c94a15f44222d5";
              //密包 ，。
              string appsecret = "PDT2BzavAHvzeJqNMclmyx7pbIT-4NhZxXs-c85oTuA";
            //实例化一个access_token 
            string access_token = null;
            //传送的地址和id，还是密保
            string url = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=" + appid + "&corpsecret=" + appsecret;
            string jsonReturn = "";
            //用于发送和接受Http数据
            //使用system.net命名空间 
            //他有一点跟我们普通的对象不一样，就是他不是用new不出来的对象，使用.Cretate()方法创建                                                                               
            HttpWebRequest httprequest = (HttpWebRequest)WebRequest.Create(url);
            //请求的方式为get类型
            httprequest.Method = "GET";
           //读取服务器返回的信息
            HttpWebResponse response = (HttpWebResponse)httprequest.GetResponse();
            using (Stream steam = response.GetResponseStream())
            {
                //我们使用stock表示把一个文本发送到机器中，而使用Encode发送给我们可以识别的数字
                StreamReader reader = new StreamReader(steam, Encoding.GetEncoding("gb2312"));
                //表示一次性的返回整个信息
                jsonReturn = reader.ReadToEnd();
                //关闭数据流
                steam.Close();
            }
              JObject jo = JObject.Parse(jsonReturn);
               access_token = jo["access_token"].ToString();
               return access_token;
             }           
          }
   }